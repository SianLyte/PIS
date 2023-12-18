using GrpcClient_PI_21_01.Controllers;
using GrpcClient_PI_21_01.Models;
using System.Data;

namespace GrpcClient_PI_21_01.Views
{
    public partial class ActEdit : Form
    {
        private bool actToEdit => editAct != null;
        private int actId => editAct.ActNumber;
        private readonly Act editAct;


        public ActEdit()
        {
            InitializeComponent();
            FillEditor();
        }

        public ActEdit(Act editAct)
        {
            InitializeComponent();
            this.editAct = editAct;
            FillEditor();
        }

        private async void FillEditor()
        {
            OK.Click += OK_Click;
            addApp.Click += AddApplication;
            deleteButton.Click += DeleteApplication;
            appsBox.SelectedIndexChanged += AppSelected;
            numericUpDownDog.ValueChanged += AnimalCountUpdate;
            numericUpDownCat.ValueChanged += AnimalCountUpdate;
            numericUpDownDog.Value = 0;
            numericUpDownCat.Value = 0;
            appsBox.Items.Clear();
            appsBox.Format += (s, e) =>
            {
                if (e.ListItem is ActApp actApp)
                {
                    e.Value = actApp.Application.number.ToString();
                }
            };

            Isus.Text = "Редактирование акта";
            dateAct.Value = DateTime.Now;

            if (actToEdit)
            {
                var act = await ActService.GetAct(actId);
                dateAct.Value = act.Date;
                textBoxTarget.Text = act.TargetCapture;
                await FullComboBox();
                comboBoxOrganization.Text = act.Organization.name;
                comboBoxContract.Text = act.Contracts.IdContract.ToString();
                var actApps = (await ActService.GetActApps())
                    .Where(aa => aa.Act.ActNumber == actId);
                foreach (var app in actApps)
                {
                    appsBox.Items.Add(app);
                }

                var _appDogs = actApps.Select(async aa => await Task.FromResult(aa.CountDogs))
                    .Select(task => task.Result)
                    .ToList();
                var _appCats = actApps.Select(async aa => await Task.FromResult(aa.CountCats))
                    .Select(task => task.Result)
                    .ToList();
            }
            else
            {
                await FullComboBox();
            }
        }

        private void AnimalCountUpdate(object? sender, EventArgs e)
        {
            if (appsBox.SelectedItem is ActApp actApp)
            {
                actApp.CountDogs = (int)numericUpDownDog.Value;
                actApp.CountCats = (int)numericUpDownCat.Value;
            }
            else
            {
                numericUpDownCat.ValueChanged -= AnimalCountUpdate;
                numericUpDownDog.ValueChanged -= AnimalCountUpdate;
                numericUpDownCat.Value = 0;
                numericUpDownDog.Value = 0;
                numericUpDownCat.ValueChanged += AnimalCountUpdate;
                numericUpDownDog.ValueChanged += AnimalCountUpdate;
            }
        }

        private void DeleteApplication(object? sender, EventArgs e)
        {
            if (appsBox.SelectedItem is ActApp actApp)
            {
                appsBox.Items.Remove(actApp);

                comboBoxApp.Items.Add(actApp.Application);
            }
        }

        private void AddApplication(object? sender, EventArgs e)
        {
            if (comboBoxApp.SelectedItem is App app)
            {
                var actApp = new ActApp(-1, editAct, app, 0, 0);
                appsBox.Items.Add(actApp);

                comboBoxApp.Items.Remove(app);
            }
        }

        private void AppSelected(object? sender, EventArgs e)
        {
            if (appsBox.SelectedItem is ActApp actApp)
            {
                numericUpDownCat.ValueChanged -= AnimalCountUpdate;
                numericUpDownDog.ValueChanged -= AnimalCountUpdate;
                numericUpDownCat.Value = actApp.CountCats;
                numericUpDownDog.Value = actApp.CountDogs;
                numericUpDownCat.ValueChanged += AnimalCountUpdate;
                numericUpDownDog.ValueChanged += AnimalCountUpdate;
            }
        }

        private async Task FullComboBox()
        {
            var appFilter = new Filter<App>();
            appFilter.AddOrFilter(app => app.status, AppStatus.Registered.ToString());
            appFilter.AddOrFilter(app => app.status, AppStatus.Performed.ToString());
            if (actToEdit) appFilter.AddOrFilter(app => app.status, AppStatus.Fulfilled.ToString());

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

            comboBoxApp.Items.AddRange(applications.ToArray());
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
            if (ChekOtvet())
            {
                var act = new Act(editAct is null ? -1 : editAct.ActNumber, (int)numericUpDownDog.Value, (int)numericUpDownCat.Value,
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

                    if (flag)
                    {
                        var successful = await ActService.AddAct(act);
                        if (!successful)
                        {
                            this.DialogResult = DialogResult.Cancel;
                            MessageBox.Show("Internal error while adding capture act. Please try again later");
                            return;
                        }
                        foreach (ActApp actApp in appsBox.Items)
                        {
                            actApp.Act = act;
                            successful = await ActService.AddActApp(actApp);
                            List<AnimalCard> listAnimals = new();

                            for (int i = 0; i < actApp.CountDogs; i++)
                            {
                                var animForm = new AnimalCardForm("Собака");
                                DialogResult otvet = animForm.ShowDialog();
                                if (otvet == DialogResult.OK)
                                    listAnimals.Add(animForm.returnAnime);

                                if (otvet == DialogResult.Cancel)
                                    flag = false;
                            }

                            for (int i = 0; i < actApp.CountCats; i++)
                            {
                                var animForm = new AnimalCardForm("Кот");
                                DialogResult otvet = animForm.ShowDialog();
                                if (otvet == DialogResult.OK)
                                    listAnimals.Add(animForm.returnAnime);

                                if (otvet == DialogResult.Cancel)
                                    flag = false;
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

        private bool ChekOtvet()
        {
            foreach (ActApp actApp in appsBox.Items)
            {
                var app = actApp.Application;
                if (app.date > dateAct.Value)
                {
                    MessageBox.Show("Заявка с ID " + app.number + " была подана " + app.date.ToString("dd.MM.yyyy") +
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
    }
}
