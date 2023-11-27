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
        public AppEdit()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
        }
        private readonly int appNum = -1;
        public AppEdit(int num)
        {
            InitializeComponent();
            appNum = num;
            Task.Run(SetupForm);
        }

        private async void SetupForm()
        {
            var localities = await LocationService.GetLocations();
            var orderedLocalities = localities.OrderBy(loc => loc.City)
                .ToArray();
            locality.Items.Clear();
            locality.Items.AddRange(orderedLocalities);
            locality.DisplayMember = "City";

            category.Items.Clear();
            category.Items.AddRange(new string[]
            {
                "Физ. лицо",
                "Юр. лицо",
                "Гос. лицо",
                "Ин. лицо",
            });

            FillAppEdit();
        }

        private async void FillAppEdit()
        {
            //var NumAppId = AppRepository.Applicatiions.FindIndex(x => x.number == Convert.ToInt32(appNum));
            //App app = AppRepository.Applicatiions[NumAppId];

            var app = await AppService.GetApplication(appNum);

            try
            {
                dateTime.Value = app.date;
                locality.SelectedIndex = locality.Items.IndexOf(app.locality);
                territory.Text = app.territory;
                animalHabbiat.Text = app.animalHabiat;
                urgency.Text = app.urgencyOfExecution;
                descrip.Text = app.animaldescription;
                category.SelectedItem = app.applicantCategory;
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
            var app = new App(DateTime.Parse(dateTime.Text), appNum,
                loc.City, territory.Text, animalHabbiat.Text, urgency.Text,
                descrip.Text, category.SelectedItem.ToString());
            var updated = await AppService.UpdateApplication(app);
            if (!updated)
            {
                MessageBox.Show("Could not update the application in the database." +
                    " Please, double check what you entered inside of textboxes." +
                    " If you are sure that inputs are correct, please contact the administrator.",
                    "Internal error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else this.Close();

        }

        private void Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
