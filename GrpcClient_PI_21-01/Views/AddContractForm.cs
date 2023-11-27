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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Xml.Linq;

namespace GrpcClient_PI_21_01.Views
{
    public partial class AddContractForm : Form
    {
        public bool ContToEdit;
        public int ContId;
        private List<Models.Location> _locations = new List<Models.Location>();


        public AddContractForm()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            ContToEdit = false;
            FillEditor();
        }

        public AddContractForm(int id)
        {
            InitializeComponent();
            ContToEdit = true;
            ContId = id;
            FillEditor();
        }

        public async void FillEditor()
        {
            if (ContToEdit)
            {
                //CreateData();
                //var index = ContractRepository.contract.FindIndex(x => x.IdContract == ContId);
                //Contract cont = ContractRepository.contract[index];
                var cont = await ContractService.GetContract(ContId);
                dateConclusion.Value = cont.DateConclusion;
                dateAction.Value = cont.ActionDate;
                await FullComboBox();
                executerCombo.Text = cont.Executer.name;
                customerCombo.Text = cont.Costumer.name;
            }
            else
                await FullComboBox();
        }

        private void CreateData()
        {
            dataGridView1.ColumnCount = 1;
            dataGridView1.RowCount = 0;
        }

        public async Task FullComboBox()
        {
            var orgs = await OrgService.GetOrganizations();
            cityCombo.DataSource = new BindingSource(await LocationService.GetLocations(), null);
            cityCombo.DisplayMember = "City";
            cityCombo.ValueMember = "IdLocation";

            executerCombo.DataSource = new BindingSource(orgs, null);
            executerCombo.DisplayMember = "name";
            executerCombo.ValueMember = "idOrg";

            customerCombo.DataSource = new BindingSource(orgs, null);
            customerCombo.DisplayMember = "name";
            customerCombo.ValueMember = "idOrg";
        }

        private void CancelcontEdit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private async void OKcontAdd_Click(object sender, EventArgs e)
        {
            if (ContToEdit)
                if (CostText.Text == "")
                    MessageBox.Show("Вы не указали цену.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else if (int.Parse(CostText.Text) == 0)
                    MessageBox.Show("Вы не можете указать цену раной 0.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else if (!int.TryParse(CostText.Text, out int _))
                    MessageBox.Show("Вы ввели некоректную цену.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                {
                    //var cont = new string[]
                    //{
                    //        ContId.ToString(), dateConclusion.Value.ToString(),
                    //                dateAction.Value.ToString(), cityCombo.SelectedValue.ToString(),
                    //                CostText.Text, executerCombo.SelectedValue.ToString(),
                    //                customerCombo.SelectedValue.ToString()
                    //};
                    var contr = new Contract(ContId, dateConclusion.Value,
                        dateAction.Value, executerCombo.SelectedItem as Organization,
                        customerCombo.SelectedItem as Organization);
                    await ContractService.UpdateContract(contr);
                    this.Close();
                }
            else
                if (CostText.Text == "")
                MessageBox.Show("Вы не указали цену.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else if (int.Parse(CostText.Text) == 0)
                MessageBox.Show("Вы не можете указать цену раной 0.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else if (!int.TryParse(CostText.Text, out int _))
                MessageBox.Show("Вы ввели некоректную цену.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
            {
                //var id = ContractRepository.contract.Max(x => x.IdContract) + 1;
                //var cont = new Contract(id,
                //                    dateConclusion.Value, dateAction.Value,
                //                    LocationCostReposiroty.locationCosts[int.Parse(cityCombo.SelectedValue.ToString()) - 1],
                //                    int.Parse(CostText.Text),
                //                    OrgRepository.Organizations[int.Parse(executerCombo.SelectedValue.ToString()) - 1],
                //                    OrgRepository.Organizations[int.Parse(customerCombo.SelectedValue.ToString()) - 1]);
                var contr = new Contract(-1,
                    dateConclusion.Value, dateAction.Value,
                    executerCombo.SelectedItem as Organization,
                    customerCombo.SelectedItem as Organization);
                var successful = await ContractService.AddContract(contr);
                if (!successful)
                {
                    this.DialogResult = DialogResult.Cancel;
                    MessageBox.Show("Internal error while adding animal card. Please try again later");
                    return;
                }
                //var successful = await LocationService.
                if (!successful)
                {
                    this.DialogResult = DialogResult.Cancel;
                    MessageBox.Show("Internal error while adding animal card. Please try again later");
                    return;
                }
                this.Close();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (_locations.Count == 0) { CreateData(); }
            Location selectedLoc = new Location(int.Parse(cityCombo.SelectedValue.ToString()) - 1, cityCombo.Text);

            if (ConteinceSelectedId(selectedLoc)) { MessageBox.Show("Этот город выбран"); }
            else
            {
                _locations.Add(selectedLoc);
                InitialisationData();
            }
        }

        private bool ConteinceSelectedId(Location selectedLoc)
        {
            foreach (var item in _locations) { if (item.IdLocation == selectedLoc.IdLocation) return true; }
            return false;
        }

        private void InitialisationData()
        {
            if (ContToEdit)
            {

            }
            else
            {
                dataGridView1.Rows.Add(_locations[_locations.Count-1].City);
            }
        }

        private void newCity_Click(object sender, EventArgs e)
        {
            var locationAdd = new LocationAdd();
            locationAdd.Show();
        }
    }
}
