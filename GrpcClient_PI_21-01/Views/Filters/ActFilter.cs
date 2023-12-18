using System;
using GrpcClient_PI_21_01.Models;
using GrpcClient_PI_21_01.Controllers;
using Google.Protobuf.WellKnownTypes;

namespace GrpcClient_PI_21_01.Views.Filters
{
    public partial class ActFilter : Form
    {
        public ActFilter(Filter<Act> filter, Func<Task> reloadGridCallback)
        {
            InitializeComponent();
            Filter = filter;
            apply.Click += async (s, e) => await reloadGridCallback();
            reset.Click += Reset;
            close.Click += (s, e) => Close();
            Apply = reloadGridCallback;
            Location = new Point(Location.X, -55);

            InitBoxes();
        }

        public Filter<Act> Filter { get; }
        public Func<Task> Apply { get; }
        private FilterType CatFilterTypes { get; set; }
        private FilterType DogFilterTypes { get; set; }

        public async void InitBoxes()
        {
            // organization combo box
            var organizations = await OrgService.GetOrganizations();
            orgComboBox.Items.Clear();
            orgComboBox.Items.Add("< нет >");
            orgComboBox.Items.AddRange(organizations.ToArray());
            orgComboBox.DisplayMember = "name";
            orgComboBox.SelectedIndexChanged += (s, e) => ApplyFilter();

            // animal box
            enableCatFilter.CheckedChanged += EnableFilterCat_Checked;
            enableDogFilter.CheckedChanged += EnableFilterDog_Checked;
            catEqual.Tag = FilterType.Equals;
            catMore.Tag = FilterType.GreaterThan;
            catLess.Tag = FilterType.LesserThan;
            catNotMore.Tag = FilterType.Equals | FilterType.LesserThan;
            catNotLess.Tag = FilterType.Equals | FilterType.GreaterThan;
            dogEqual.Tag = catEqual.Tag;
            dogMore.Tag = catMore.Tag;
            dogLess.Tag = catLess.Tag;
            dogNotMore.Tag = catNotMore.Tag;
            dogNotLess.Tag = catNotLess.Tag;
            foreach (var control in catBox.Controls)
                if (control is RadioButton catRB)
                    catRB.CheckedChanged += CatRadioButton;
            foreach (var control in dogBox.Controls)
                if (control is RadioButton dogRB)
                    dogRB.CheckedChanged += DogRadioButton;
            dogCount.ValueChanged += (s, e) => ApplyFilter();
            catCount.ValueChanged += (s, e) => ApplyFilter();

            // goal box
            goalTextBox.TextChanged += (s, e) => ApplyFilter();

            // date box
            fromDate.ValueChanged += (s, e) => ApplyFilter();
            toDate.ValueChanged += (s, e) => ApplyFilter();

            // contract box
            var contracts = await ContractService.GetContracts();
            contractComboBox.Format += (s, e) =>
            {
                if (e.ListItem is Contract c)
                    e.Value = $"[ID: {c.IdContract}] Performer: {c.Executer.name} | Customer: {c.Costumer.name}";
            };
            contractComboBox.Items.Clear();
            contractComboBox.Items.Add("< нет >");
            contractComboBox.Items.AddRange(contracts.ToArray());
            contractComboBox.DisplayMember = "IdContract";
            contractComboBox.SelectedIndexChanged += (s, e) => ApplyFilter();

            // application box
            var applications = await AppService.GetApplications();
            appComboBox.Format += (s, e) =>
            {
                if (e.ListItem is App app)
                    e.Value = $"[ID: {app.number}] Date: {app.date:dd/MM/yyyy}";
            };
            appComboBox.Items.Clear();
            appComboBox.Items.AddRange(applications.OrderByDescending(a => a.date).ToArray());
            appComboBox.DisplayMember = "number";
            addApplication.Click += AddApplication;
            removeApplication.Click += RemoveApplication;
            this.applications.DisplayMember = "number";

            Reset(this, EventArgs.Empty);
        }

        public void ApplyFilter()
        {
            Filter.Clear();

            if (orgComboBox.SelectedItem is Organization org)
                Filter.AddFilter(act => act.Organization, org.idOrg.ToString());

            if (enableCatFilter.Checked)
                Filter.AddFilter(act => act.CountCats, catCount.Value.ToString(), CatFilterTypes);

            if (enableDogFilter.Checked)
                Filter.AddFilter(act => act.CountDogs, dogCount.Value.ToString(), DogFilterTypes);

            if (goalTextBox.Text.Length > 0)
                Filter.AddFilter(act => act.TargetCapture, goalTextBox.Text);

            if (contractComboBox.SelectedItem is Contract contr)
                Filter.AddFilter(act => act.Contracts, contr.IdContract.ToString());

            Filter.AddFilter(act => act.Date, fromDate.Value.ToString(), FilterType.GreaterThan | FilterType.Equals);
            Filter.AddFilter(act => act.Date, toDate.Value.AddDays(1).ToString(), FilterType.LesserThan);

            for (int i = 0; i < applications.Items.Count; i++)
            {
                if (applications.Items[i] is App a)
                {
                    //if (i == 0)
                    //    Filter.AndAddInnerJoinFilter<App, int>(app => app.number, a.number.ToString(), FilterType.Equals);
                    //else
                    Filter.OrAddInnerJoinFilter<App, int>(app => app.number, a.number.ToString(), FilterType.Equals);
                }
            }
            Apply();
        }

        private void Reset(object sender, EventArgs e)
        {
            orgComboBox.SelectedIndex = 0;
            enableDogFilter.Checked = false;
            enableCatFilter.Checked = false;
            catCount.Value = 0;
            dogCount.Value = 0;
            foreach (App app in applications.Items)
                appComboBox.Items.Add(app);
            applications.Items.Clear();
            appComboBox.SelectedIndex = 0;
            contractComboBox.SelectedIndex = 0;
            orgComboBox.SelectedIndex = 0;
            goalTextBox.Text = String.Empty;
            catEqual.Checked = true;
            dogEqual.Checked = true;
            fromDate.Value = new DateTime(2020, 1, 1);
            toDate.Value = DateTime.Now;

            if (sender != this) Apply();
        }

        private void EnableFilterDog_Checked(object sender, EventArgs e)
        {
            dogBox.Enabled = enableDogFilter.Checked;
            ApplyFilter();
        }

        private void EnableFilterCat_Checked(object sender, EventArgs e)
        {
            catBox.Enabled = enableCatFilter.Checked;
            ApplyFilter();
        }

        private void DogRadioButton(object sender, EventArgs e)
        {
            if (sender is RadioButton rb)
            {
                if (rb.Checked)
                {
                    DogFilterTypes = rb.Tag is FilterType t ? t : FilterType.Equals;
                    if (dogBox.Enabled) ApplyFilter();
                }
            }
        }

        private void CatRadioButton(object sender, EventArgs e)
        {
            if (sender is RadioButton rb)
            {
                if (rb.Checked)
                {
                    CatFilterTypes = rb.Tag is FilterType t ? t : FilterType.Equals;
                    if (catBox.Enabled) ApplyFilter();
                }
            }
        }

        private void AddApplication(object sender, EventArgs e)
        {
            if (appComboBox.SelectedItem is App app)
            {
                var prevIndex = appComboBox.SelectedIndex;
                applications.Items.Add(app);
                appComboBox.Items.Remove(app);
                if (prevIndex > 0) appComboBox.SelectedIndex = prevIndex - 1;
                else if (appComboBox.Items.Count > 0) appComboBox.SelectedIndex = 0;

                ApplyFilter();
            }
        }

        private void RemoveApplication(object sender, EventArgs e)
        {
            if (applications.SelectedIndex != -1 && applications.SelectedItem is App app)
            {
                applications.Items.Remove(app);
                appComboBox.Items.Add(app);
                if (appComboBox.SelectedItem is not App) appComboBox.SelectedIndex = 0;

                ApplyFilter();
            }
        }
    }
}
