using GrpcClient_PI_21_01.Controllers;
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

namespace GrpcClient_PI_21_01.Views
{
    public partial class OrgAdd : Form
    {
        public OrgAdd()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            Task.Run(InitFormAsync);
        }

        private async void InitFormAsync()
        {
            name.Items.Clear();
            foreach (Organization org in await OrgService.GetOrganizations())
            {
                name.Items.Add(org.name);
            }

            AdressReg.Items.Clear();
            foreach (Location loc in await LocationService.GetLocations())
            {
                AdressReg.Items.Add(loc.City);
            }
        }

        private async void OKorgAdd_Click(object sender, EventArgs e)
        {
            var org = new Organization(-1, name.Text, INN.Text,
                KPP.Text, AdressReg.Text, Type.Text, Status.Text);
            await OrgService.AddOrganization(org);
            this.Close();
        }

        private void CancelOrgEdit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
