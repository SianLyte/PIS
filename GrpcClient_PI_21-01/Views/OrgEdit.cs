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
using System.Xml.Linq;

namespace GrpcClient_PI_21_01.Views
{
    public partial class OrgEdit : Form
    {
        private readonly int orgId;
        public OrgEdit()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
        }

        public OrgEdit(int id)
        {
            InitializeComponent();
            orgId = id;
            FillOrgEdit();
        }

        private async void FillOrgEdit()
        {
            //var Idorg = OrgRepository.Organizations.FindIndex(x => x.idOrg == Convert.ToInt32(OrgId));
            //Organization org = OrgRepository.Organizations[Idorg];
            var org = await OrgService.GetOrganization(orgId);
            name.Text = org.name;
            INN.Text = org.INN;
            KPP.Text = org.KPP;
            AdressReg.Text = org.registrationAdress;
            Type.Text = org.type;
            Status.Text = org.status;

            name.Items.Clear();
            foreach (Organization or in await OrgService.GetOrganizations())
            {
                name.Items.Add(or.name);
            }

            AdressReg.Items.Clear();
            foreach (Location loc in await LocationService.GetLocations())
            {
                AdressReg.Items.Add(loc.City);
            }
        }

        private async void OKorgEdit_Click(object sender, EventArgs e)
        {
            var org = new Organization(orgId, name.Text,
                INN.Text, KPP.Text, AdressReg.Text, Type.Text, Status.Text);
            await OrgService.UpdateOrganization(org);
            this.Close();
        }

        private void CancelOrgEdit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void OrgEdit_Load(object sender, EventArgs e)
        {

        }
    }
}
