using GrpcClient_PI_21_01.Controllers;
//using GrpcClient_PI_21_01.Data;
using GrpcClient_PI_21_01.Models;
using GrpcClient_PI_21_01.Views;
using GrpcClient_PI_21_01.Views.Filters;
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

namespace GrpcClient_PI_21_01
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.FixedSingle;

            // Только сейчас заметил, что это?!
            // где?
            // именно, где мои кнопки?!)
            // кончились
            dateTimePickerAct.ValueChanged += dateTimePickerAct_ValueChanged;

            OrgAdd.Click += OrgAdd_Click;
            OrgEdit.Click += OrgEdit_Click;
            OrgDelete.Click += OrgDelete_Click;

            AppAdd.Click += AppAdd_Click;
            AppEdit.Click += AppEdit_Click;
            AppDelete.Click += AppDelete_Click;

            AddActButton.Click += AddButton_Click;
            UpdateActButton.Click += UpdateButton_Click;
            DeleteActButton.Click += DeleteActButton_Click;
            buttonAnimalCard.Click += buttonAnimalCard_Click;

            AddButton.Click += AddButton_Click_1;
            EditButton.Click += EditButton_Click;
            DeleteButton.Click += DeleteButton_Click;
            ContractTable.CellMouseDoubleClick += ContractTable_CellMouseDoubleClick;

            button1.Click += button1_Click;

            tabControl1.SelectedIndexChanged += tabControl1_SelectedIndexChanged;

            contractFiltersButton.Click += OpenContractFilters;
            applicationFiltersButton.Click += OpenApplicationFilters;
            organizationFiltersButton.Click += OpenOrganizationFilters;

            DataGridViewActs.ColumnHeaderMouseClick += SortActs;
            dataGridViewApp.ColumnHeaderMouseClick += SortApps;
            dataGridViewOrg.ColumnHeaderMouseClick += SortOrganizations;
            ContractTable.ColumnHeaderMouseClick += SortContracts;

            Task.Run(Setup);
        }

        readonly Filter<Act> actFilter = new();
        readonly Filter<App> appFilter = new();
        readonly Filter<Organization> orgFilter = new();
        readonly Filter<Contract> contrFilter = new();
        static private int _pageSize = 10;

        private async Task Setup()
        {
            await SetDataGridAct();
            await ShowContract();

            await SetDataGridApp();
            await SetDataGridOrg();
            await InicilisationHistory();
        }

        private static async Task<bool> CheckPrivilege(NameMdels model)
        {
            if (!await PreveligeService.IsUserPrevilegedFor(model))
            {
                MessageBox.Show("У вас недостаточно прав!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return false;
            }
            return true;
        }

        #region Related: Act Capture
        /* -----------------------------------ACT----------------------------------------------------- */

        private int _ActPage = 0;
        private int _ActPageMax = 0;
        private readonly SemaphoreSlim actGridSemaphore = new(1, 1);
        private async Task SetDataGridAct()
        {
            await actGridSemaphore.WaitAsync();
            try
            {
                DataGridViewActs.Rows.Clear();
                var acts = await ActService.GetActs(_ActPage, actFilter);
                ActService.FillDataGrid(acts, DataGridViewActs);
                _ActPageMax = await ActService.GetPageCount(_pageSize, actFilter);
                CheckPageButton(buttobPreviosActs, buttonNextActs, _ActPage, _ActPageMax);
            }
            finally
            {
                actGridSemaphore.Release();
            }
        }


        private async void AddButton_Click(object sender, EventArgs e)
        {
            if (await CheckPrivilege(NameMdels.Act))
            {
                var editWindow = new ActEdit();
                editWindow.ShowDialog();
                await SetDataGridAct();
            }
        }

        private async void UpdateButton_Click(object sender, EventArgs e)
        {
            if (await CheckPrivilege(NameMdels.Act))
                if (DataGridViewActs.CurrentRow != null)
                {
                    var editWindow = new ActEdit(int.Parse(DataGridViewActs.CurrentRow.Cells[0].Value.ToString()));
                    editWindow.ShowDialog();
                    await SetDataGridAct();
                }
        }

        private async void DeleteActButton_Click(object sender, EventArgs e)
        {
            if (await CheckPrivilege(NameMdels.Act))
                if (DataGridViewActs.CurrentRow != null)
                {
                    await ActService.RemoveAct(int.Parse(DataGridViewActs.CurrentRow.Cells[0].Value.ToString()));
                    await SetDataGridAct();
                }
        }

        private async void buttonAnimalCard_Click(object sender, EventArgs e)
        {
            if (await CheckPrivilege(NameMdels.Act))
                if (DataGridViewActs.CurrentRow != null)
                {
                    bool IsDog = int.Parse(DataGridViewActs.CurrentRow.Cells[1].Value.ToString()) > 0;
                    bool IsCat = int.Parse(DataGridViewActs.CurrentRow.Cells[2].Value.ToString()) > 0;

                    if (IsDog)
                    {
                        var otvet = new AnimalCardForm(int.Parse(DataGridViewActs.CurrentRow.Cells[0].Value.ToString()), "Собака");
                        otvet.ShowDialog();
                    }
                    if (IsCat)
                    {
                        var otvet = new AnimalCardForm(int.Parse(DataGridViewActs.CurrentRow.Cells[0].Value.ToString()), "Кот");
                        otvet.ShowDialog();
                    }
                }
        }

        private async void dateTimePickerAct_ValueChanged(object sender, EventArgs e)
        {
            await SetDataGridAct();
        }


        private void OpenActFilters(object sender, EventArgs e) =>
            new ActFilter(actFilter, SetDataGridAct).Show();

        private async void buttonNextActs_Click(object sender, EventArgs e)
        {
            _ActPage++;
            await SetDataGridAct();
        }

        private async void buttobPreviosActs_Click(object sender, EventArgs e)
        {
            _ActPage--;
            await SetDataGridAct();
        }

        private async void SortActs(object sender, DataGridViewCellMouseEventArgs e)
        {
            var column = DataGridViewActs.Columns[e.ColumnIndex];
            foreach (DataGridViewColumn c in DataGridViewActs.Columns)
                if (column.Index != c.Index) c.HeaderCell.SortGlyphDirection = SortOrder.None;
            SorterService.SortByColumn(actFilter, column);
            await SetDataGridAct();
        }

        #endregion
        #region Related: Organizations
        private int _OrgPage = 0;
        private int _OrgPageMax = 0;
        private readonly SemaphoreSlim orgGridSemaphore = new(1, 1);
        private async Task SetDataGridOrg()
        {
            await orgGridSemaphore.WaitAsync();
            try
            {
                var orgs = await OrgService.GetOrganizations(_OrgPage, orgFilter);
                OrgService.FillDataGrid(orgs, dataGridViewOrg);
                _OrgPageMax = await OrgService.GetPageCount(_pageSize, orgFilter);
                CheckPageButton(buttonPreviosOrganisations, buttonNextOrganisations, _OrgPage, _OrgPageMax);
            }
            finally { orgGridSemaphore.Release(); }
        }

        private async void OrgDelete_Click(object sender, EventArgs e)
        {
            if (await CheckPrivilege(NameMdels.Org))
                if (dataGridViewOrg.CurrentRow != null)
                {
                    var org = int.Parse(dataGridViewOrg.CurrentRow.Cells[0].Value.ToString());
                    var a = await OrgService.RemoveOrganization(org);
                    if (!a)
                    {
                        MessageBox.Show("Произошла ошибка");
                    }
                    await SetDataGridOrg();
                }
        }

        private async void OrgEdit_Click(object sender, EventArgs e)
        {
            if (await CheckPrivilege(NameMdels.Org))
                if (dataGridViewOrg.CurrentRow != null)
                {
                    var orgId = int.Parse(dataGridViewOrg.CurrentRow.Cells[0].Value.ToString());
                    var org = await OrgService.GetOrganization(orgId);
                    var orgEdit = new OrgAdd(org);
                    orgEdit.ShowDialog();
                    await SetDataGridOrg();
                }
        }

        private async void OrgAdd_Click(object sender, EventArgs e)
        {
            if (await CheckPrivilege(NameMdels.Org))
            {
                var orgAdd = new OrgAdd();
                orgAdd.ShowDialog();
                await SetDataGridOrg();
            }
        }

        private void OpenOrganizationFilters(object sender, EventArgs e)
            => new OrgFilter(orgFilter, SetDataGridOrg).Show();
        private void buttonNextOrganisations_Click(object sender, EventArgs e)
        {
            _OrgPage++;
        }

        private void buttonPreviosOrganisations_Click(object sender, EventArgs e)
        {
            _OrgPage--;
        }

        private async void SortOrganizations(object sender, DataGridViewCellMouseEventArgs e)
        {
            var column = dataGridViewOrg.Columns[e.ColumnIndex];
            foreach (DataGridViewColumn c in dataGridViewOrg.Columns)
                if (column.Index != c.Index) c.HeaderCell.SortGlyphDirection = SortOrder.None;
            SorterService.SortByColumn(orgFilter, column);
            await SetDataGridOrg();
        }

        #endregion
        #region Related: Applications
        private int _AppPage = 0;
        private int _AppPageMax = 0;
        private readonly SemaphoreSlim appGridSemaphore = new(1, 1);
        private async Task SetDataGridApp()
        {
            await appGridSemaphore.WaitAsync();
            try
            {
                var apps = await AppService.GetApplications(_AppPage, appFilter);
                AppService.FillDataGrid(apps, dataGridViewApp);
                _AppPageMax = await AppService.GetPageCount(_pageSize, appFilter);
                CheckPageButton(buttonPreviosApps, buttonNextApps, _AppPage, _AppPageMax);
            }
            finally { appGridSemaphore.Release(); }
        }

        /*------------------------------------------------------------------*/
        private async void AppDelete_Click(object sender, EventArgs e)
        {
            if (await CheckPrivilege(NameMdels.App))
                if (dataGridViewApp.CurrentRow != null)
                {
                    int app = Convert.ToInt32(dataGridViewApp.CurrentRow.Cells[1].Value.ToString());
                    await AppService.RemoveApplication(app);
                    await SetDataGridApp();
                }
        }

        private async void AppEdit_Click(object sender, EventArgs e)
        {
            if (await CheckPrivilege(NameMdels.App))
                if (dataGridViewApp.CurrentRow != null)
                {
                    var appId = int.Parse(dataGridViewApp.CurrentRow.Cells[1].Value.ToString());
                    var app = await AppService.GetApplication(appId);
                    var appEdit = new AppEdit(app);
                    appEdit.ShowDialog();
                    await SetDataGridApp();
                }
        }

        private async void AppAdd_Click(object sender, EventArgs e)
        {
            if (await CheckPrivilege(NameMdels.App))
            {
                var appAdd = new AppEdit();
                appAdd.ShowDialog();
                await SetDataGridApp();
            }
        }

        private void OpenApplicationFilters(object sender, EventArgs e) =>
            new AppFilter(appFilter, SetDataGridApp).Show();
        private async void buttonNextApps_Click(object sender, EventArgs e)
        {
            _AppPage++;
            await SetDataGridApp();
        }

        private async void buttonPreviosApps_Click(object sender, EventArgs e)
        {
            _AppPage--;
            await SetDataGridApp();
        }

        private async void SortApps(object sender, DataGridViewCellMouseEventArgs e)
        {
            var column = dataGridViewApp.Columns[e.ColumnIndex];
            foreach (DataGridViewColumn c in dataGridViewApp.Columns)
                if (column.Index != c.Index) c.HeaderCell.SortGlyphDirection = SortOrder.None;
            SorterService.SortByColumn(appFilter, column);
            await SetDataGridApp();
        }

        #endregion
        #region Related: Contracts
        private int _PageContract = 0;
        private int _PageContractMax = 0;
        private readonly SemaphoreSlim contrGridSemaphore = new(1, 1);
        private async Task ShowContract()
        {
            await contrGridSemaphore.WaitAsync();
            try
            {
                CheckPageButton(buttonPreviosContract, buttonNextContract, _PageContract, _PageContractMax);
                _PageContractMax = await ContractService.GetPageCount(_pageSize, contrFilter);
                ContractTable.Rows.Clear();
                var cont = await ContractService.GetContracts(_PageContract, contrFilter);
                ContractService.FillDataGrid(cont, ContractTable);
            }
            finally
            {
                contrGridSemaphore.Release();
            }
        }

        private async void AddButton_Click_1(object sender, EventArgs e)
        {
            if (await CheckPrivilege(NameMdels.Contract))
            {
                var contAdd = new AddContractForm();
                contAdd.ShowDialog();
                await ShowContract();
            }
        }

        private async void EditButton_Click(object sender, EventArgs e)
        {
            if (await CheckPrivilege(NameMdels.Contract))
                if (ContractTable.CurrentRow != null)
                {
                    var contAdd = new AddContractForm(int.Parse(ContractTable.CurrentRow.Cells[0].Value.ToString()));
                    contAdd.ShowDialog();
                    await ShowContract();
                }
        }

        private async void DeleteButton_Click(object sender, EventArgs e)
        {
            if (await CheckPrivilege(NameMdels.Contract))
                if (ContractTable.CurrentRow != null)
                {
                    await ContractService.RemoveContract(int.Parse(ContractTable.CurrentRow.Cells[0].Value.ToString()));
                    await ShowContract();
                }
        }

        private async void ContractTable_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            var contAdd = new AddContractForm(int.Parse(ContractTable.CurrentRow.Cells[0].Value.ToString()));
            contAdd.ShowDialog();
            await ShowContract();
        }

        private void OpenContractFilters(object sender, EventArgs e) =>
            new ContractFilter(contrFilter, ShowContract).Show();

        private async void buttonNextContract_Click(object sender, EventArgs e)
        {
            _HistoryPage++;
            await ShowContract();
        }

        private async void buttonPreviosContract_Click(object sender, EventArgs e)
        {
            _HistoryPage--;
            await ShowContract();
        }

        private async void SortContracts(object sender, DataGridViewCellMouseEventArgs e)
        {
            var column = ContractTable.Columns[e.ColumnIndex];
            foreach (DataGridViewColumn c in ContractTable.Columns)
                if (column.Index != c.Index) c.HeaderCell.SortGlyphDirection = SortOrder.None;
            SorterService.SortByColumn(contrFilter, column);
            await ShowContract();
        }

        #endregion
        #region Related: Reports
        private void button1_Click(object sender, EventArgs e)
        {
            OpenReport();
        }

        private static async void OpenReport()
        {
            if (await CheckPrivilege(NameMdels.Report))
            {
                var rep = new ReportForm();
                rep.ShowDialog();
            }
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl1.SelectedTab == tabPage2)
            {
                tabControl1.SelectedTab = tabPage1;
                OpenReport();
            }
        }
        #endregion
        #region Related: Operation History
        private List<Operation>? _data;
        readonly DataSet _dbHistory = new();
        private int _HistoryPage = 0;
        private int _HistoryPageMax = 0;

        public async Task InicilisationHistory()
        {
            if (await CheckPrivilege(NameMdels.History))
            {
                _data = await OperationService.GetOperations(_HistoryPage);
                CreateDataSet();
                _HistoryPageMax = await OperationService.GetPageCount(_pageSize);
                CheckPageButton(buttonPriviosHistory, buttonNextHistory, _HistoryPage, _HistoryPageMax);

            }
            else MessageBox.Show("У вас недостаточно прав, чтобы просматривать историю операций", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public async void CreateDataSet()
        {
            _dbHistory.Tables.Clear();
            _dbHistory.Tables.Add("History");
            _dbHistory.Tables[0].Columns.Add("Фамилия");
            _dbHistory.Tables[0].Columns.Add("Имя");
            _dbHistory.Tables[0].Columns.Add("Отчество");
            _dbHistory.Tables[0].Columns.Add("Организация");
            _dbHistory.Tables[0].Columns.Add("Должность");
            _dbHistory.Tables[0].Columns.Add("Логин");
            _dbHistory.Tables[0].Columns.Add("Дата и время");
            _dbHistory.Tables[0].Columns.Add("Идетификационный номер экземляра объекта");
            _dbHistory.Tables[0].Columns.Add("Вид действия");
            _dbHistory.Tables[0].Columns.Add("Наименование таблицы, в которой произошло изменение");

            //var parceData = await OperationService.GetParceDataHistory(_data);
            foreach (var data in _data.Select(x => OperationService.ToDataArray(x)))
                _dbHistory.Tables[0].Rows.Add(data);

            dataGridViewHistory.DataSource = _dbHistory.Tables[0];
        }

        private void buttonPriviosHistory_Click(object sender, EventArgs e)
        {
            _HistoryPage--;
            InicilisationHistory();
        }

        private void buttonNextHistory_Click(object sender, EventArgs e)
        {
            _HistoryPage++;
            InicilisationHistory();
        }

        #endregion

        private static void CheckPageButton(Button buttonPrevious, Button buttonNext, int page, int pageMax)
        {
            buttonPrevious.Enabled = true;
            buttonNext.Enabled = true;
            if (page <= 0)
            {
                buttonPrevious.Enabled = false;
            }
            if (page >= pageMax-1)
            {
                buttonNext.Enabled = false;
            }
        }

        private async void buttonExportExel_Click(object sender, EventArgs e)
        {
            switch (tabControl1.SelectedIndex)
            {
                case 0:
                    {
                        var acts = await ActService.GetActs(-1, actFilter);
                        ExelService.ExportExel(DataGridViewActs, acts.Select(x => ActService.ToDataArray(x)).ToList(), "act");
                    }
                    break;
                case 1:
                    {
                        // для отчётов надо отдельно смотреть
                    }
                    break;
                case 2:
                    {
                        var cont = await ContractService.GetContracts(-1, contrFilter);
                        ExelService.ExportExel(ContractTable, cont.Select(x => ContractService.ToDataArray(x)).ToList(), "contract");
                    }
                    break;
                case 3:
                    {
                        var apps = await AppService.GetApplications(-1, appFilter);
                        ExelService.ExportExel(dataGridViewApp, apps.Select(x => AppService.ToDataArray(x)).ToList(), "app");
                    }
                    break;
                case 4:
                    {
                        var orgs = await OrgService.GetOrganizations(-1, orgFilter);
                        ExelService.ExportExel(dataGridViewOrg, orgs.Select(x => OrgService.ToDataArray(x)).ToList(), "org");
                    }
                    break;
                case 5:
                    {
                        var historys = await OperationService.GetOperations(-1);
                        ExelService.ExportExel(dataGridViewHistory, historys.Select(x => OperationService.ToDataArray(x)).ToList(), "hist");
                    }
                    break;

            }
        }
    }
}
