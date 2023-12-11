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
        private OrganizationType[] orgTypesArray = Array.Empty<OrganizationType>();
        private readonly Organization? toEdit;
        public OrgAdd()
        {
            InitializeComponent();
            InitBase();
        }

        public OrgAdd(Organization toEdit)
        {
            InitializeComponent();
            this.toEdit = toEdit;
            InitBase();
        }

        private string Status
        {
            get
            {
                if (statusOrg.Checked) return "Юр. лицо";
                if (statusIndividual.Checked) return "ИП";
                throw new Exception("Unknown error has occured: Organization status is not selected");
            }
        }
        
        private void InitBase()
        {
            orgTypesArray = Enum.GetValues<OrganizationType>();
            OKorgAdd.Click += OKorgAdd_Click;
            CancelOrgEdit.Click += CancelOrgEdit_Click;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            Task.Run(InitFormAsync);
        }

        private async void InitFormAsync()
        {
            AdressReg.Items.Clear();
            foreach (Location loc in await LocationService.GetLocations())
            {
                AdressReg.Items.Add(loc);
            }
            AdressReg.DisplayMember = "City";

            orgTypes.Items.Clear();
            orgTypes.Items.AddRange(orgTypesArray.Select(ot => ot.Translate()).ToArray());

            if (toEdit is not null)
                FillValues(toEdit);
        }

        private void FillValues(Organization org)
        {
            orgName.Text = org.name;
            INN.Text = org.INN;
            KPP.Text = org.KPP;
            AdressReg.SelectedItem = org.registrationAdress;

            for (int i = 0; i < orgTypesArray.Length; i++)
            {
                var ot = orgTypesArray[i];
                if (ot == org.type) orgTypes.SelectedIndex = i;
            }

            if (org.status == "ИП") statusIndividual.Checked = true;
        }

        private async void OKorgAdd_Click(object sender, EventArgs e)
        {
            if (!AreFieldsCorrect()) return;

            var org = new Organization(-1, orgName.Text, INN.Text,
                KPP.Text, AdressReg.SelectedItem as Location, orgTypesArray[orgTypes.SelectedIndex], Status);

            if (toEdit is null)
                await OrgService.AddOrganization(org);
            else
            {
                org.idOrg = toEdit.idOrg;
                var updateSuccessful = await OrgService.UpdateOrganization(org);
                if (!updateSuccessful)
                    MessageBox.Show("Some internal error has occured while updating the organization." +
                        " Please contact the administrator.", "Internal Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            this.Close();
        }

        private void CancelOrgEdit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private bool AreFieldsCorrect()
        {
            if (orgName.Text.Length <= 0)
                MessageBox.Show("Введите имя организации.",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else if (!long.TryParse(INN.Text, out long _) || INN.Text.Length != 12)
                MessageBox.Show("ИНН был введён некорректно. Он должен состоять из 12 цифр.",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else if (!long.TryParse(KPP.Text, out long _) || KPP.Text.Length != 9)
                MessageBox.Show("КПП был введён некорректно. Он должен состоять из 9 цифр.",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else if (AdressReg.SelectedItem is not Models.Location)
                MessageBox.Show("Выберите адрес регистрации.",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else if (orgTypes.SelectedIndex < 0)
                MessageBox.Show("Выберите тип организации.",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else return true;

            return false;
        }
    }
}
