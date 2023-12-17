//using GrpcClient_PI_21_01.Data;
using GrpcClient_PI_21_01.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Xml.Linq;
using GrpcClient_PI_21_01.Controllers;
using System.Globalization;

namespace GrpcClient_PI_21_01.Views
{
    public partial class AppEdit : Form
    {
        private readonly App? app;
        public AppEdit()
        {
            InitializeComponent();

            buttonCloseApp.Click += ButtonCloseApp_Click;

            Task.Run(SetupForm);
        }

        private void ButtonCloseApp_Click(object? sender, EventArgs e)
        {
            //throw new NotImplementedException();
        }

        public AppEdit(App app)
        {
            InitializeComponent();
            this.app = app;
            Task.Run(SetupForm);
        }

        private async void SetupForm()
        {
            var localityFilter = new Filter<Location>();
            localityFilter.SetSort<Location, string>(loc => loc.City);
            var localities = await LocationService.GetLocations(-1, localityFilter);
            locality.Items.Clear();
            locality.Items.AddRange(localities.ToArray());
            locality.DisplayMember = "City";

            category.Items.Clear();
            category.Items.AddRange(AppService.GetApplicantTypes());

            FillAppEdit();
        }

        private void FillAppEdit()
        {
            if (app is null)
            {
                buttonCloseApp.Visible = false;
                textBoxStatus.Text = "ожидает регистрации";
                return;
            }
            try
            {
                dateTime.Value = app.date;
                locality.SelectedIndex = locality.Items.IndexOf(app.locality);
                territory.Text = app.territory;
                animalHabbiat.Text = app.animalHabiat;
                urgency.Text = app.urgencyOfExecution;
                descrip.Text = app.animaldescription;
                category.SelectedItem = app.applicantCategory;
                textBoxStatus.Text = app.status.ToString();
            }
            catch
            {
                MessageBox.Show("Unknown error has occured during data filling.\n" +
                    "This application's data is corrupted. Please contact the administrator.",
                    "Fill error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
        }

        private async void OkAppEdit_Click(object sender, EventArgs e)
        {
            if (locality.SelectedItem is not Location loc)
            {
                MessageBox.Show("Please select Locality first.", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                locality.Select();
                return;
            }
            if (!double.TryParse(urgency.Text, NumberStyles.Any, CultureInfo.InvariantCulture, out double _))
            {
                MessageBox.Show("Urgency of execution fields requires a numeric value.", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                urgency.Select();
                return;
            }

            var app = new App(DateTime.Parse(dateTime.Text), this.app is null ? -1 : this.app.number,
                loc, territory.Text, animalHabbiat.Text, urgency.Text,
                descrip.Text, category.SelectedItem.ToString(), AppStatus.Registered, UserService.CurrentUser?.Organization, 100);

            if (this.app is null)
            {
                var added = await AppService.AddApplication(app);
                if (!added)
                {
                    MessageBox.Show("Could not add the application to the database." +
                        " Please, double check what you entered inside of textboxes." +
                        " If you are sure that inputs are correct, please contact the administrator.",
                        "Internal error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else Close();
            }
            else
            {
                var updated = await AppService.UpdateApplication(app);
                if (!updated)
                {
                    MessageBox.Show("Could not update the application in the database." +
                        " Please, double check what you entered inside of textboxes." +
                        " If you are sure that inputs are correct, please contact the administrator.",
                        "Internal error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else Close();
            }

        }

        private void Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
