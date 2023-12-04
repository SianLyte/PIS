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
using static Google.Protobuf.Reflection.SourceCodeInfo.Types;

namespace GrpcClient_PI_21_01.Views
{
    public partial class ActEdit : Form
    {
        private readonly bool actToEdit;
        private readonly int actId;
        private List<int> _apps = new List<int>();

        public ActEdit()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            actToEdit = false;
            Isus.Text = "Добавление акта";
            FillEditor();
        }
        public ActEdit(int id)
        {
            InitializeComponent();
            actToEdit = true;
            actId = id;
            Isus.Text = "Редактирование акта";
            FillEditor();
        }

        private async void FillEditor()
        {
            if (actToEdit)
            {

                //var index = ActRepository.acts.FindIndex(x => x.ActNumber == actId);
                //Act act = ActRepository.acts[index];
                var act = await ActService.GetAct(actId);
                numericUpDownDog.Value = act.CountDogs;
                numericUpDownCat.Value = act.CountCats;
                dateAct.Value = act.Date;
                textBoxTarget.Text = act.TargetCapture;
                await FullComboBox();
                comboBoxOrganization.Text = act.Organization.name;
                comboBoxContract.Text = act.Contracts.IdContract.ToString();
                //comboBoxApp.Text = act.Application.number.ToString();
                var actApps = (await ActService.GetActApps())
                    .Where(aa => aa.Act.ActNumber == actId);
                _apps = actApps.Select(async aa => await Task.FromResult(aa.App.Number))
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
            var organizations = await OrgService.GetOrganizations();
            var contracts = await ContractService.GetContracts();
            var applications = await AppService.GetApplications();

            comboBoxOrganization.DataSource = new BindingSource(organizations, null);
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
            if (ChekOtvet())
            {
                var act = new Act(actId, (int)numericUpDownDog.Value, (int)numericUpDownCat.Value,
                        comboBoxOrganization.SelectedItem as Organization,
                        dateAct.Value, textBoxTarget.Text,
                        comboBoxContract.SelectedItem as Contract);
                if (actToEdit)
                {
                    //var act = new string[] {actId.ToString(), numericUpDownDog.Value.ToString(),numericUpDownCat.Value.ToString(), comboBoxOrganization.SelectedValue.ToString(),
                    //        dateAct.Value.ToString(), textBoxTarget.Text, comboBoxApp.SelectedValue.ToString(), comboBoxContract.SelectedValue.ToString()};

                    await ActService.UpdateAct(act);
                    this.DialogResult = DialogResult.OK;

                }
                else
                {
                    //var act = new string[] {numericUpDownDog.Value.ToString(),numericUpDownCat.Value.ToString(), comboBoxOrganization.SelectedValue.ToString(),
                    //        dateAct.Value.ToString(), textBoxTarget.Text, comboBoxApp.SelectedValue.ToString(), comboBoxContract.SelectedValue.ToString()};

                    bool IsDog = act.CountDogs > 0;
                    bool IsCat = act.CountCats > 0;

                    bool flag = true;
                    List<AnimalCard> listAnimals = new();

                    if (IsDog)
                    {
                        var animForm = new AnimalCardForm("Собака");
                        DialogResult otvet = animForm.ShowDialog();
                        if (otvet == DialogResult.OK)
                            listAnimals.Add(animForm.returnAnime);

                        if (otvet == DialogResult.Cancel)
                            flag = false;
                    }

                    if (IsCat & flag)
                    {
                        var animForm = new AnimalCardForm("Кот");
                        DialogResult otvet = animForm.ShowDialog();
                        if (otvet == DialogResult.OK)
                            listAnimals.Add(animForm.returnAnime);

                        if (otvet == DialogResult.Cancel)
                            flag = false;

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
                            var appReply = (await AppService.GetApplication(app)).ToReply();
                            successful = await ActService.AddActApp(new ActAppReply()
                            {
                                App = appReply,
                                Act = act.ToReply()
                            });
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
            if (numericUpDownDog.Value == 0 & numericUpDownCat.Value == 0)
            {
                MessageBox.Show("Вы не выбрали ни одного животного", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (textBoxTarget.Text == "")
            {
                MessageBox.Show("Введите цель отлова", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }

        private void comboBoxApp_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void addApp_Click(object sender, EventArgs e)
        {
            if (_apps.Count == 0) { CreateData(); }
            int selectedApp = int.Parse(comboBoxApp.SelectedValue.ToString());

            if (ConteinceSelectedId(selectedApp)) { MessageBox.Show("Этот акт выбран"); }
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

        private void deleteButton_Click(object sender, EventArgs e)
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
