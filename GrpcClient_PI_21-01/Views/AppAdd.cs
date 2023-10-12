using GrpcClient_PI_21_01.Controllers;
//using GrpcClient_PI_21_01.Data;
using GrpcClient_PI_21_01.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
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
        }

        private async void OkAppAdd_Click(object sender, EventArgs e)
        {
            var app = new App(DateTime.Parse(date.Text),
                -1,
                loc.Text, territory.Text, animalHabbiat.Text, urgency.Text,
                descrip.Text, categoryApp.Text);
            await AppService.AddApplication(app);
            this.Close();
        }

        private void Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
