using GrpcClient_PI_21_01.Controllers;
using GrpcClient_PI_21_01.Models;
using System.Data;

namespace GrpcClient_PI_21_01.Views
{
    public partial class ActEdit : Form
    {
        private readonly bool actToEdit = false;
        private readonly int actId;
        private List<int> _apps = new();

        public ActEdit()
        {
            InitializeComponent();
            FillEditor();
        }

        public ActEdit(int id)
        {
            InitializeComponent();
            actToEdit = true;
            actId = id;
            FillEditor();
        }

        private async void FillEditor()
        {
            OK.Click += OK_Click;
            addApp.Click += AddApplication;
            deleteButton.Click += DeleteApplication;
            Isus.Text = "Редактирование акта";

            if (actToEdit)
            {
                var act = await ActService.GetAct(actId);
                numericUpDownDog.Value = act.CountDogs;
                numericUpDownCat.Value = act.CountCats;
                dateAct.Value = act.Date;
                textBoxTarget.Text = act.TargetCapture;
                await FullComboBox();
                comboBoxOrganization.Text = act.Organization.name;
                comboBoxContract.Text = act.Contracts.IdContract.ToString();
                var actApps = (await ActService.GetActApps())
                    .Where(aa => aa.Act.ActNumber == actId);
                _apps = actApps.Select(async aa => await Task.FromResult(aa.Application.number))
                    .Select(task => task.Result)
                    .ToList();
                CreateData();
                foreach (var app in _apps)
                {
                    dataGridView1.Rows.Add(app.ToString());
                }
            }
            else
            {
                await FullComboBox();
            }
        }

        private async Task FullComboBox()
        {
            var appFilter = new Filter<App>();
            // включить фильтры после прикручивания статусов
            //appFilter.AddOrFilter(app => app.status, AppStatus.Registered.ToString());
            //appFilter.AddOrFilter(app => app.status, AppStatus.Performed.ToString());
            //if (actToEdit) appFilter.AddOrFilter(app => app.status, AppStatus.Fulfilled.ToString());

            var contractFilter = new Filter<Contract>();
            if (UserService.CurrentUser?.PrivelegeLevel != "Admin")
                contractFilter.AddFilter(c => c.Executer, UserService.CurrentUser?.Organization.idOrg.ToString());
            contractFilter.AddFilter(c => c.ActionDate, DateTime.Now.ToString(), FilterType.GreaterThan | FilterType.Equals);

            var contracts = await ContractService.GetContracts(-1, contractFilter);
            var applications = await AppService.GetApplications(-1, appFilter);
            var organizations = contracts.Select(c => c.Executer).Distinct().ToList();

            comboBoxOrganization.DataSource = new BindingSource(organizations
                .Where(o => o.type == OrganizationType.Trapping || o.type == OrganizationType.TrappingAndShelter).ToList(), null);
            comboBoxOrganization.DisplayMember = "name";
            comboBoxOrganization.ValueMember = "idOrg";

            comboBoxApp.DataSource = new BindingSource(applications, null);
            comboBoxApp.DisplayMember = "number";
            comboBoxApp.ValueMember = "number";


            if (contracts.Count() != 0)
            {
                comboBoxContract.DataSource = new BindingSource(contracts, null);
                comboBoxContract.DisplayMember = "IdContract";
                comboBoxContract.ValueMember = "IdContract";
            }
        }

        private async void OK_Click(object sender, EventArgs e)
        {
            if (await ChekOtvet())
            {
                var act = new Act(actId, (int)numericUpDownDog.Value, (int)numericUpDownCat.Value,
                        comboBoxOrganization.SelectedItem as Organization,
                        dateAct.Value, textBoxTarget.Text,
                        comboBoxContract.SelectedItem as Contract);
                if (actToEdit)
                {
                    var updated = await ActService.UpdateAct(act);
                    if (!updated)
                    {
                        MessageBox.Show("Internal error has occured while updating the act. Please try again later."
                            , "Internal Error", 0, MessageBoxIcon.Error);
                        return;
                    }
                    this.DialogResult = DialogResult.OK;
                }
                else
                {
                    bool flag = true;
                    List<AnimalCard> listAnimals = new();

                    for (int i = 0; i < act.CountDogs; i++)
                    {
                        var animForm = new AnimalCardForm("Собака");
                        DialogResult otvet = animForm.ShowDialog();
                        if (otvet == DialogResult.OK)
                            listAnimals.Add(animForm.returnAnime);

                        if (otvet == DialogResult.Cancel)
                            flag = false;
                    }

                    if (flag)
                    {
                        for (int i = 0; i < act.CountCats; i++)
                        {
                            var animForm = new AnimalCardForm("Кот");
                            DialogResult otvet = animForm.ShowDialog();
                            if (otvet == DialogResult.OK)
                                listAnimals.Add(animForm.returnAnime);

                            if (otvet == DialogResult.Cancel)
                                flag = false;
                        }
                    }

                    if (flag)
                    {
                        var successful = await ActService.AddAct(act);
                        if (!successful)
                        {
                            this.DialogResult = DialogResult.Cancel;
                            MessageBox.Show("Internal error while adding capture act. Please try again later");
                            return;
                        }
                        foreach (var animal in listAnimals)
                        {
                            animal.ActCapture = act;
                            successful = await AnimalCardService.AddAnimalCard(animal);
                            if (!successful)
                            {
                                this.DialogResult = DialogResult.Cancel;
                                MessageBox.Show("Internal error while adding animal card. Please try again later");
                                return;
                            }
                        }
                        foreach (var app in _apps)
                        {
                            var appReply = await AppService.GetApplication(app);
                            successful = await ActService.AddActApp(new ActApp(-1, act, appReply));
                            if (!successful)
                            {
                                this.DialogResult = DialogResult.Cancel;
                                MessageBox.Show("Internal error while adding animal card. Please try again later");
                                return;
                            }
                        }
                        this.DialogResult = DialogResult.OK;

                    }
                    this.DialogResult = DialogResult.OK;
                }
            }
        }

        private async Task<bool> ChekOtvet()
        {
            foreach (var appId in _apps)
            {
                var app = await AppService.GetApplication(appId);
                if (app.date > dateAct.Value)
                {
                    MessageBox.Show("Заявка с ID " + appId + " была подана " + app.date.ToString("dd.MM.yyyy") +
                        ", однако дата регистрации акта отлова - " + dateAct.Value.ToString("dd.MM.yyyy") + ", что " +
                        "противоречит логике.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }

            if (numericUpDownDog.Value == 0 && numericUpDownCat.Value == 0)
                MessageBox.Show("Вы не выбрали ни одного животного", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else if (textBoxTarget.Text == "")
                MessageBox.Show("Введите цель отлова", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else if (comboBoxOrganization.SelectedItem is null)
                MessageBox.Show("Не выбрана организация", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else if (comboBoxContract.SelectedItem is not Contract)
                MessageBox.Show("Не выбран муниципальный контракт.");
            else return true;
            return false;
        }

        private void AddApplication(object sender, EventArgs e)
        {
            if (_apps.Count == 0) { CreateData(); }
            int selectedApp = int.Parse(comboBoxApp.SelectedValue.ToString());

            if (ConteinceSelectedId(selectedApp)) { MessageBox.Show("Эта заявка уже выбрана"); }
            else
            {
                _apps.Add(selectedApp);
                InitialisationData();
            }
        }

        private bool ConteinceSelectedId(int selectedApp)
        {
            foreach (var item in _apps) { if (item == selectedApp) return true; }
            return false;
        }

        private void CreateData()
        {
            dataGridView1.ColumnCount = 1;
            dataGridView1.RowCount = 0;
        }

        private void InitialisationData()
        {
            if (actToEdit)
            {
                dataGridView1.Rows.Add("" + _apps[_apps.Count-1]);
            }
            else
            {
                dataGridView1.Rows.Add("" + _apps[_apps.Count-1]);
            }
        }

        private void DeleteApplication(object sender, EventArgs e)
        {
            if (CheckDataGrid())
            {
                int appId = int.Parse(dataGridView1.CurrentRow.Cells[0].Value.ToString());
                dataGridView1.Rows.Remove(dataGridView1.CurrentRow);
                _apps.Remove(appId);
                dataGridView1.ClearSelection();
                dataGridView1.CurrentCell  = null;
            }
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
