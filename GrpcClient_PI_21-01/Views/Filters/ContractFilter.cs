using GrpcClient_PI_21_01.Models;
using GrpcClient_PI_21_01.Controllers;

namespace GrpcClient_PI_21_01.Views.Filters
{
    public partial class ContractFilter : Form
    {
        public ContractFilter(Filter<Contract> filter, Func<Task> reloadGridCallback)
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

        public Filter<Contract> Filter { get; }
        public Func<Task> Apply { get; }
        public FilterType ExpirationDateFilterType => GetFilterTypeInDateBox(expDateBox);
        public FilterType RegistrationDateFilterType => GetFilterTypeInDateBox(regDateBox);

        public async void InitBoxes()
        {
            var allOrganizations = (await OrgService.GetOrganizations()).ToArray();
            const string unselected_combo_box_default_value = "< не выбрано >";

            // date box
            foreach (var control in dateBox.Controls)
                if (control is RadioButton dRB)
                    dRB.CheckedChanged += (s, e) => ApplyFilter();
            enableExpirationDateFilter.CheckedChanged += EnableExpirationDateFilter_CheckedChanged;
            enableRegistrationDateFilter.CheckedChanged += EnableRegistrationDateFilter_CheckedChanged;
            foreach (var control in regDateBox.Controls)
                if (control is RadioButton rdRB)
                    rdRB.CheckedChanged += (s, e) => ApplyFilter();
            foreach (var control in expDateBox.Controls)
                if (control is RadioButton edRB)
                    edRB.CheckedChanged += (s, e) => ApplyFilter();
            regDate.ValueChanged += (s, e) => ApplyFilter();
            expDate.ValueChanged += (s, e) => ApplyFilter();

            // performer box
            performerComboBox.Items.Clear();
            performerComboBox.Items.Add(unselected_combo_box_default_value);
            performerComboBox.Items.AddRange(allOrganizations);
            performerComboBox.DisplayMember = "name";
            performerComboBox.SelectedIndexChanged += (s, e) => ApplyFilter();

            // customer box
            customerComboBox.Items.Clear();
            customerComboBox.Items.Add(unselected_combo_box_default_value);
            customerComboBox.Items.AddRange(allOrganizations);
            customerComboBox.DisplayMember = performerComboBox.DisplayMember;
            customerComboBox.SelectedIndexChanged += (s, e) => ApplyFilter();

            Reset(this, EventArgs.Empty);
        }

        public void ApplyFilter()
        {
            Filter.Clear();

            if (enableExpirationDateFilter.Checked)
                Filter.AddFilter(c => c.ActionDate, expDate.Value.ToString(), ExpirationDateFilterType);

            if (enableRegistrationDateFilter.Checked)
                Filter.AddFilter(c => c.DateConclusion, regDate.Value.ToString(), RegistrationDateFilterType);

            if (showContractActive.Checked)
            {
                Filter.AddFilter(c => c.ActionDate, DateTime.Now.ToString(), FilterType.GreaterThan | FilterType.Equals);
                Filter.AddFilter(c => c.DateConclusion, DateTime.Now.ToString(), FilterType.LesserThan | FilterType.Equals);
            }

            if (showContractExpired.Checked)
            {
                Filter.AddOrFilter(c => c.ActionDate, DateTime.Now.ToString(), FilterType.LesserThan | FilterType.Equals);
                Filter.AddOrFilter(c => c.DateConclusion, DateTime.Now.ToString(), FilterType.GreaterThan | FilterType.Equals);
            }

            if (performerComboBox.SelectedItem is Organization performer)
                Filter.AddFilter(c => c.Executer, performer.idOrg.ToString());

            if (customerComboBox.SelectedItem is Organization customer)
                Filter.AddFilter(c => c.Costumer, customer.idOrg.ToString());


            //Раскомментировать, когда в фильтрах появятся города для выбора, listBox для городов назвать locations
            //for (int i = 0; i < locations.Items.Count; i++)
            //{
            //    if (locations.Items[i] is Location l)
            //    {
            //        
            //            Filter.OrAddInnerJoinFilter<Location, int>(loc => loc.IdLocation, l.IdLocation.ToString(), FilterType.Equals);
            //    }
            //}

            Apply();
        }

        private void Reset(object sender, EventArgs e)
        {
            showContractAll.Checked = true;
            enableExpirationDateFilter.Checked = false;
            enableRegistrationDateFilter.Checked = false;
            regDate.Value = DateTime.Now;
            expDate.Value = DateTime.Now;
            regEqual.Checked = true;
            expEqual.Checked = true;
            performerComboBox.SelectedIndex = 0;
            customerComboBox.SelectedIndex = 0;
            regDateBox.Enabled = false;
            expDateBox.Enabled = false;

            ApplyFilter();
        }

        private void EnableRegistrationDateFilter_CheckedChanged(object? sender, EventArgs e)
        {
            regDateBox.Enabled = enableRegistrationDateFilter.Checked;
            ApplyFilter();
        }

        private void EnableExpirationDateFilter_CheckedChanged(object? sender, EventArgs e)
        {
            expDateBox.Enabled = enableExpirationDateFilter.Checked;
            ApplyFilter();
        }

        private static FilterType GetFilterTypeInDateBox(GroupBox gb)
        {
            foreach (var control in gb.Controls)
                if (control is RadioButton rb)
                    if (rb.Checked)
                        if (Enum.TryParse<FilterType>(rb.Tag.ToString(), out var ft))
                            return ft;
            throw new Exception("Filter Type was null at checked radio button");
        }
    }
}
