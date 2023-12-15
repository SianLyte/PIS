using GrpcClient_PI_21_01.Controllers;
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

namespace GrpcClient_PI_21_01.Views.Filters
{
    public partial class OperationFilter : Form
    {
        public OperationFilter(Filter<Operation> filter, Func<Task> reloadGridCallback)
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

        public Filter<Operation> Filter { get; }
        public Func<Task> Apply { get; }
        public FilterType IdFilterType
        {
            get
            {
                foreach (var control in idBox.Controls)
                {
                    if (control is RadioButton rb)
                    {
                        if (rb.Checked)
                        {
                            return Enum.Parse<FilterType>(rb.Tag.ToString());
                        }
                    }
                }
                return FilterType.Equals;
            }
        }

        public async void InitBoxes()
        {
            const string unselected_combo_box_default_value = "< не выбрано >";

            // actor name/surname/patronymic
            name.TextChanged += (s, e) => ApplyFilter();
            surname.TextChanged += (s, e) => ApplyFilter();
            patronymic.TextChanged += (s, e) => ApplyFilter();

            // actor organization
            var organizations = await OrgService.GetOrganizations();
            orgComboBox.Items.Clear();
            orgComboBox.Items.Add(unselected_combo_box_default_value);
            orgComboBox.Items.AddRange(organizations.ToArray());
            orgComboBox.DisplayMember = "name";
            orgComboBox.SelectedIndexChanged += (s, e) => ApplyFilter();

            // actor privelege
            var priveleges = PreveligeService.GetPrevileges();
            privelegeComboBox.Items.Clear();
            privelegeComboBox.Items.Add(unselected_combo_box_default_value);
            privelegeComboBox.Items.AddRange(priveleges.ToArray());
            privelegeComboBox.DisplayMember = "DisplayName";
            privelegeComboBox.SelectedIndexChanged += (s, e) => ApplyFilter();

            // actor login
            login.TextChanged += (s, e) => ApplyFilter();

            // operation date
            toDate.ValueChanged += (s, e) => ApplyFilter();
            fromDate.ValueChanged += (s, e) => ApplyFilter();

            // modified object id
            id.ValueChanged += (s, e) => ApplyFilter();
            idEqual.CheckedChanged += (s, e) => ApplyFilter();
            idLess.CheckedChanged += (s, e) => ApplyFilter();
            idMore.CheckedChanged += (s, e) => ApplyFilter();

            // action type
            actionAdd.CheckedChanged += (s, e) => ApplyFilter();
            actionDelete.CheckedChanged += (s, e) => ApplyFilter();
            actionUpdate.CheckedChanged += (s, e) => ApplyFilter();

            // table name
            var tables = new string[]
            {
                "Contract", "Act Capture", "Application", "Animal Card",
                "Act App", "Location Contract", "Location", "Organization"
            }; // я надеюсь это никто не увидит но мне лень привязывать сервер к этому делу, пусть будет хардкод
               // наш любимый , ломающий все :hearts_with_smiling_face:
            tableComboBox.Items.Clear();
            tableComboBox.Items.Add(unselected_combo_box_default_value);
            tableComboBox.Items.AddRange(tables);
            tableComboBox.SelectedIndexChanged += (s, e) => ApplyFilter();

            Reset(this, EventArgs.Empty);
        }

        public void ApplyFilter()
        {
            Filter.Clear();

            if (name.Text.Length > 0)
                Filter.AndAddInnerJoinFilter<User, string>(actor => actor.Name, name.Text);

            if (surname.Text.Length > 0)
                Filter.AndAddInnerJoinFilter<User, string>(actor => actor.Surname, surname.Text);

            if (patronymic.Text.Length > 0)
                Filter.AndAddInnerJoinFilter<User, string>(actor => actor.Patronymic, patronymic.Text);

            if (orgComboBox.SelectedItem is Organization org)
                Filter.AndAddInnerJoinFilter<User, Organization>(actor => actor.Organization, org.idOrg.ToString());

            if (privelegeComboBox.SelectedItem is Models.Previlege previlege)
                Filter.AndAddInnerJoinFilter<User, string>(actor => actor.PrivelegeLevel, previlege.Name);

            if (login.Text.Length > 0)
                Filter.AndAddInnerJoinFilter<User, string>(actor => actor.Login, login.Text);

            Filter.AddFilter(op => op.ActionDate, fromDate.Value.ToString(), FilterType.GreaterThan | FilterType.Equals);
            Filter.AddFilter(op => op.ActionDate, toDate.Value.ToString(), FilterType.LesserThan | FilterType.Equals);

            Filter.AddFilter(op => op.ModifiedObjectId, id.Value.ToString(), IdFilterType);

            if (actionAdd.Checked)
                Filter.AddOrFilter(op => op.ActionType, ActionType.ActionAdd.ToString());
            if (actionUpdate.Checked)
                Filter.AddOrFilter(op => op.ActionType, ActionType.ActionUpdate.ToString());
            if (actionDelete.Checked)
                Filter.AddOrFilter(op => op.ActionType, ActionType.ActionDelete.ToString());

            if (tableComboBox.SelectedIndex > 0)
                Filter.AddFilter(op => op.ModifiedTableName, tableComboBox.SelectedItem.ToString());

            Apply();
        }

        private void Reset(object sender, EventArgs e)
        {
            name.Text = String.Empty;
            surname.Text = String.Empty;
            patronymic.Text = String.Empty;
            orgComboBox.SelectedIndex = 0;
            privelegeComboBox.SelectedIndex = 0;
            login.Text = String.Empty;
            fromDate.Value = fromDate.MinDate;
            toDate.Value = DateTime.Now;
            id.Value = 0;
            idMore.Checked = true;
            actionAdd.Checked = true;
            actionDelete.Checked  =true;
            actionUpdate.Checked  =true;
            tableComboBox.SelectedIndex = 0;

            ApplyFilter();
        }
    }
}
