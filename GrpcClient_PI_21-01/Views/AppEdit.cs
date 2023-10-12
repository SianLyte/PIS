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
            FillAppEdit();
        }
        private async void FillAppEdit()
        {
            //var NumAppId = AppRepository.Applicatiions.FindIndex(x => x.number == Convert.ToInt32(appNum));
            //App app = AppRepository.Applicatiions[NumAppId];

            var app = await AppService.GetApplication(appNum);
            date.Text = app.date.ToString();
            loc.Text = app.locality;
            territory.Text = app.territory;
            animalHabbiat.Text = app.animalHabiat;
            urgency.Text = app.urgencyOfExecution;
            descrip.Text = app.animaldescription;
            categoryApp.Text = app.applicantCategory;
        }

        private async void OkAppEdit_Click(object sender, EventArgs e)
        {
            var app = new App(DateTime.Parse(date.Text), appNum,
                loc.Text, territory.Text, animalHabbiat.Text, urgency.Text,
                descrip.Text, categoryApp.Text);
            await AppService.UpdateApplication(app);
            this.Close();
        }

        private void Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
