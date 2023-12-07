using GrpcClient_PI_21_01.Controllers;
//using GrpcClient_PI_21_01.Data;
using GrpcClient_PI_21_01.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GrpcClient_PI_21_01.Views
{
    public partial class AppAdd : Form
    {
        public AppAdd()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.FixedSingle;

            category.Items.Clear();
            category.Items.AddRange(AppService.GetApplicantTypes());
            category.SelectedIndex = 0;

            Task.Run(LoadLocalities);
        }

        private async void OkAppAdd_Click(object sender, EventArgs e)
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
            var app = new App(DateTime.Parse(dateTimePicker.Text),
                -1,
                loc, territory.Text, animalHabbiat.Text, urgency.Text,
                descrip.Text, category.SelectedItem.ToString(), AppStatus.Registered);
            var added = await AppService.AddApplication(app);
            if (!added)
            {
                MessageBox.Show("Could not add the application to the database." +
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

        private async void LoadLocalities()
        {
            var localities = await LocationService.GetLocations();
            var orderedLocalities = localities.OrderBy(loc => loc.City)
                .ToArray();
            locality.Items.Clear();
            locality.Items.AddRange(orderedLocalities);
            locality.DisplayMember = "City";
        }
    }
}
