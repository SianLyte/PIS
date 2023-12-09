using GrpcClient_PI_21_01.Controllers;
using GrpcClient_PI_21_01.Models;
using System.Data;

namespace GrpcClient_PI_21_01.Views
{
    public partial class AddContractForm : Form
    {
        public bool ContToEdit;
        public int ContId;
        private List<Location> _locations = new();
        private readonly Dictionary<int, int> _idCityToCost = new();


        public AddContractForm()
        {
            InitializeComponent();
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
            dataGridView1.MouseClick += DataGridView1_MouseClick;
            costNumericUpDown.ValueChanged += CostNumericUpDown_ValueChanged;
            deleteButton.Click += DeleteButton_Click;
            newCity.Click += NewCity_Click;
            CancelcontEdit.Click += CancelcontEdit_Click;
            OKcontAdd.Click += OKcontAdd_Click;
            button1.Click += button1_Click;

            if (ContToEdit)
            {
                var cont = await ContractService.GetContract(ContId);
                dateConclusion.Value = cont.DateConclusion;
                dateAction.Value = cont.ActionDate;
                await FullComboBox();
                executerCombo.Text = cont.Executer.name;
                customerCombo.Text = cont.Costumer.name;

                var locContrFilter = new Filter<Location_Contract>();
                locContrFilter.AddFilter(lc => lc.Contract, ContToEdit.ToString());
                var lcs = await LocationService.GetLocationContracts(-1, locContrFilter);

                _locations = lcs.Select(lc => lc.Locality).ToList();
                lcs.ForEach(lc => _idCityToCost.Add(lc.Locality.IdLocation, (int)lc.Price));

                CreateData();
                foreach (var loc in _locations)
                {
                    dataGridView1.Rows.Add(loc.IdLocation, loc.City);
                }
                DataGridClearSelection();
            }
            else
                await FullComboBox();
        }

        private void CreateData()
        {
            dataGridView1.ColumnCount = 2;
            dataGridView1.Columns[0].Visible = false;
            dataGridView1.RowCount = 0;
        }

        public async Task FullComboBox()
        {
            var orgs = await OrgService.GetOrganizations();
            cityCombo.DataSource = await LocationService.GetLocations();
            cityCombo.DisplayMember = "City";
            cityCombo.ValueMember = "IdLocation";

            customerCombo.DataSource = new BindingSource(orgs
                .Where(o => o.type != OrganizationType.Trapping && o.type != OrganizationType.TrappingAndShelter), null);
            customerCombo.DisplayMember = "name";
            customerCombo.ValueMember = "idOrg";

            executerCombo.DataSource = new BindingSource(orgs
                .Where(o => o.type == OrganizationType.TrappingAndShelter || o.type == OrganizationType.Trapping), null);
            executerCombo.DisplayMember = "name";
            executerCombo.ValueMember = "idOrg";
        }

        private void CancelcontEdit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private async void OKcontAdd_Click(object sender, EventArgs e)
        {
            var correct = await AreFieldsCorrect();
            if (!correct.Item1)
            {
                MessageBox.Show(correct.Item2, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (ContToEdit)
            {
                //else if (await ChekLocationAndPriceFromOtherAsync())
                //    ;
                var contr = new Contract(ContId, dateConclusion.Value,
                    dateAction.Value, executerCombo.SelectedItem as Organization,
                    customerCombo.SelectedItem as Organization);
                await ContractService.UpdateContract(contr);
                this.Close();
            }
            else
            { // дополнить, проверяет только текущую цену
              //else if (await ChekLocationAndPriceFromOtherAsync())
              //    ;
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

                foreach (var loc in _locations)
                {
                    Location_Contract l_C = new Location_Contract(-1, loc, _idCityToCost[loc.IdLocation], contr);
                    successful = await LocationService.AddLocationContract(l_C);

                    if (!successful)
                    {
                        this.DialogResult = DialogResult.Cancel;
                        MessageBox.Show("Internal error while adding animal card. Please try again later");
                        return;
                    }
                }

                this.Close();
            }
        }

        private async Task<Tuple<bool, string>> AreFieldsCorrect()
        {
            string errorMessage = string.Empty;

            var contrFilter = new Filter<Contract>();
            contrFilter.AddFilter(c => c.ActionDate, dateConclusion.Value.ToString(), FilterType.GreaterThan);
            var existingContracts = await ContractService.GetContracts(-1, contrFilter);

            var lcs = await LocationService.GetLocationContracts();

            if (dateAction.Value <= dateConclusion.Value)
                errorMessage = "Дата окончания контракта не может быть раньше даты заключения контракта.";
            else if (customerCombo.SelectedItem is not Organization)
                errorMessage = "Выберите заказчика.";
            else if (executerCombo.SelectedItem is not Organization)
                errorMessage = "Выберите исполнителя.";
            else if (customerCombo.SelectedItem is Organization c && executerCombo.SelectedItem is Organization e
                && c.idOrg == e.idOrg)
                errorMessage = "Контракт не может быть заключен между двумя одинаковыми организациями.";
            else if (customerCombo.SelectedItem is Organization c1 && executerCombo.SelectedItem is Organization e1
                && e1.type != OrganizationType.Trapping && e1.type != OrganizationType.TrappingAndShelter)
                errorMessage = "Исполнителем контракта должна быть организация по отлову";
            else if (_locations.Count <= 0 || _locations.All(l => _idCityToCost[l.IdLocation] > 0))
                errorMessage = "В одном из населённых пунктов не указана цена отлова.";
            else if (lcs.Any(lc => _locations.Contains(lc.Locality) && lc.Contract.Costumer.idOrg == c.idOrg
            && lc.Contract.Executer.idOrg == e.idOrg))
                errorMessage = "Уже существует действующий контракт, в котором указан один из выбранных населённых пунктов.";
            else return new Tuple<bool, string>(true, errorMessage);

            return new Tuple<bool, string>(false, errorMessage);
        }

        private bool CheckValueNumericUpDown()
        {
            var findProblem = false;
            foreach (var cityKey in _idCityToCost)
                if (cityKey.Value == 0)
                {
                    MessageBox.Show($"в {_locations.First(x => x.IdLocation == cityKey.Key).City} вы не можете указать цену 0.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    findProblem = false;
                    break;
                }
            return findProblem;
        }

        private async Task<bool> ChekLocationAndPriceFromOtherAsync()
        {
            var find = false;
            foreach (var idCityCost in _idCityToCost) 
            {
                var locCon = (await LocationService.GetLocationContracts()).FirstOrDefault(x => x.Price == idCityCost.Value & x.Locality.IdLocation == idCityCost.Key);
                if (locCon != null)
                { 
                    find = true; 
                    MessageBox.Show($"Имеется контракт №{locCon.Contract.IdContract}, у которого город '{locCon.Locality.City}' имеет цену {locCon.Price}"); 
                    break; 
                }
            } 
            return find;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (_locations.Count == 0)
            {
                CreateData();
            }
            Models.Location selectedLoc = (Models.Location)cityCombo.SelectedItem;

            if (ConteinceSelectedId(selectedLoc))
            {
                MessageBox.Show("Этот город выбран", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            else
            {
                _locations.Add(selectedLoc);
                _idCityToCost.Add(selectedLoc.IdLocation, 0);
                InitialisationData();
            }
        }

        private bool ConteinceSelectedId(Models.Location selectedLoc)
        {
            foreach (var item in _locations)
            {
                if (item.IdLocation == selectedLoc.IdLocation) return true;
            }
            return false;
        }

        private void InitialisationData()
        {
            if (ContToEdit)
            {
                dataGridView1.Rows.Add(_locations[_locations.Count-1].IdLocation, _locations[_locations.Count-1].City);
            }
            else
            {
                dataGridView1.Rows.Add(_locations[_locations.Count-1].IdLocation, _locations[_locations.Count-1].City);
            }
        }

        private void NewCity_Click(object sender, EventArgs e)
        {
            var locationAdd = new LocationAdd();
            locationAdd.Show();
        }

        //private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        //{
        //    if (CheckDataGrid())
        //        costNumericUpDown.Value = _idCityToCost[int.Parse(dataGridView1.CurrentRow.Cells[0].Value.ToString())];
        //}


        private void DeleteButton_Click(object sender, EventArgs e)
        {
            if (CheckDataGrid())
            {
                //MessageBox.Show(_locations.ToString());
                int idLoc = int.Parse(dataGridView1.CurrentRow.Cells[0].Value.ToString());
                _locations.Remove(_locations.First(x => x.IdLocation == idLoc));
                costNumericUpDown.Value = 0;
                dataGridView1.Rows.Remove(dataGridView1.CurrentRow);
                _idCityToCost.Remove(idLoc);
                DataGridClearSelection();
                //MessageBox.Show(_locations.ToString());
            }
        }

        private void DataGridClearSelection()
        {
            dataGridView1.ClearSelection();
            dataGridView1.CurrentCell  = null;
        }

        private void CostNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            if (CheckDataGrid())
            {
                var idLoc = int.Parse(dataGridView1.CurrentRow.Cells[0].Value.ToString());
                var cost = (int)costNumericUpDown.Value;
                if (!_idCityToCost.ContainsKey(idLoc))
                    _idCityToCost.Add(idLoc, cost);
                else
                    _idCityToCost[idLoc] = cost;
            }
            else
                if (costNumericUpDown.Value != 0)
            {
                MessageBox.Show("Вы не выбрали город!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                costNumericUpDown.Value = 0;
            }
        }

        private void DataGridView1_MouseClick(object sender, MouseEventArgs e)
        {
            if (CheckDataGrid())
                costNumericUpDown.Value = _idCityToCost[int.Parse(dataGridView1.CurrentRow.Cells[0].Value.ToString())];
        }

        private bool CheckDataGrid()
        {
            if (dataGridView1.CurrentRow != null) 
            { 
                return true; 
            }
            
            else 
            {
                MessageBox.Show("Вы не выбрали город!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false; 
            }
        }
    }
}
