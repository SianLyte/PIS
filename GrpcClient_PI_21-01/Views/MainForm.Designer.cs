namespace GrpcClient_PI_21_01
{
    partial class MainForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            tabControl1=new TabControl();
            tabPage1=new TabPage();
            buttonExportExelActs=new Button();
            buttobPreviosActs=new Button();
            buttonNextActs=new Button();
            filterActButton=new Button();
            buttonAnimalCard=new Button();
            AddActButton=new Button();
            UpdateActButton=new Button();
            DeleteActButton=new Button();
            dateTimePickerAct=new DateTimePicker();
            label1=new Label();
            DataGridViewActs=new DataGridView();
            Id=new DataGridViewTextBoxColumn();
            CountDogs=new DataGridViewTextBoxColumn();
            CountCats=new DataGridViewTextBoxColumn();
            Organization=new DataGridViewTextBoxColumn();
            Date=new DataGridViewTextBoxColumn();
            Target=new DataGridViewTextBoxColumn();
            Kontracts=new DataGridViewTextBoxColumn();
            pictureBox1=new PictureBox();
            tabPage2=new TabPage();
            button5=new Button();
            button6=new Button();
            button7=new Button();
            dateTimePicker2=new DateTimePicker();
            label2=new Label();
            dataGridViewReport=new DataGridView();
            checkBox1=new CheckBox();
            tabPage3=new TabPage();
            buttonExcelContract=new Button();
            buttonPreviosContract=new Button();
            buttonNextContract=new Button();
            contractFiltersButton=new Button();
            EditButton=new Button();
            AddButton=new Button();
            DeleteButton=new Button();
            ContractTable=new DataGridView();
            Column1=new DataGridViewTextBoxColumn();
            Column2=new DataGridViewTextBoxColumn();
            Column3=new DataGridViewTextBoxColumn();
            Column5=new DataGridViewTextBoxColumn();
            Column6=new DataGridViewTextBoxColumn();
            tabPage4=new TabPage();
            buttonExcelApp=new Button();
            buttonPreviosApps=new Button();
            buttonNextApps=new Button();
            applicationFiltersButton=new Button();
            AppAdd=new Button();
            AppEdit=new Button();
            AppDelete=new Button();
            dataGridViewApp=new DataGridView();
            tabPage5=new TabPage();
            buttonExcelOrg=new Button();
            buttonPreviosOrganisations=new Button();
            buttonNextOrganisations=new Button();
            organizationFiltersButton=new Button();
            dataGridViewOrg=new DataGridView();
            OrgAdd=new Button();
            OrgEdit=new Button();
            OrgDelete=new Button();
            tabPage6=new TabPage();
            historyFiltersButton=new Button();
            buttonExcelHistory=new Button();
            buttonPriviosHistory=new Button();
            buttonNextHistory=new Button();
            dataGridViewHistory=new DataGridView();
            buttonPriviosPageAct=new Button();
            buttonNextPageAct=new Button();
            buttonPreviousContracts=new Button();
            buttonNextContracts=new Button();
            dateTimePicker1=new DateTimePicker();
            label7=new Label();
            IdReport=new DataGridViewTextBoxColumn();
            CreatedAt=new DataGridViewTextBoxColumn();
            UpdateAt=new DataGridViewTextBoxColumn();
            StartDate=new DataGridViewTextBoxColumn();
            EndDate=new DataGridViewTextBoxColumn();
            Profit=new DataGridViewTextBoxColumn();
            AnimalsCount=new DataGridViewTextBoxColumn();
            ClosedAppsCount=new DataGridViewTextBoxColumn();
            User=new DataGridViewTextBoxColumn();
            Status=new DataGridViewTextBoxColumn();
            tabControl1.SuspendLayout();
            tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)DataGridViewActs).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewReport).BeginInit();
            tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)ContractTable).BeginInit();
            tabPage4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewApp).BeginInit();
            tabPage5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewOrg).BeginInit();
            tabPage6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewHistory).BeginInit();
            SuspendLayout();
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(tabPage1);
            tabControl1.Controls.Add(tabPage2);
            tabControl1.Controls.Add(tabPage3);
            tabControl1.Controls.Add(tabPage4);
            tabControl1.Controls.Add(tabPage5);
            tabControl1.Controls.Add(tabPage6);
            tabControl1.Font=new Font("Segoe Print", 10F, FontStyle.Bold, GraphicsUnit.Point);
            tabControl1.Location=new Point(18, 18);
            tabControl1.Margin=new Padding(4, 3, 4, 3);
            tabControl1.Name="tabControl1";
            tabControl1.RightToLeft=RightToLeft.No;
            tabControl1.SelectedIndex=0;
            tabControl1.Size=new Size(1382, 758);
            tabControl1.TabIndex=0;
            // 
            // tabPage1
            // 
            tabPage1.BackColor=Color.Tan;
            tabPage1.Controls.Add(buttonExportExelActs);
            tabPage1.Controls.Add(buttobPreviosActs);
            tabPage1.Controls.Add(buttonNextActs);
            tabPage1.Controls.Add(filterActButton);
            tabPage1.Controls.Add(buttonAnimalCard);
            tabPage1.Controls.Add(AddActButton);
            tabPage1.Controls.Add(UpdateActButton);
            tabPage1.Controls.Add(DeleteActButton);
            tabPage1.Controls.Add(dateTimePickerAct);
            tabPage1.Controls.Add(label1);
            tabPage1.Controls.Add(DataGridViewActs);
            tabPage1.Controls.Add(pictureBox1);
            tabPage1.Location=new Point(4, 39);
            tabPage1.Name="tabPage1";
            tabPage1.Padding=new Padding(3);
            tabPage1.Size=new Size(1374, 715);
            tabPage1.TabIndex=0;
            tabPage1.Text="Акты";
            // 
            // buttonExportExelActs
            // 
            buttonExportExelActs.BackColor=Color.Cornsilk;
            buttonExportExelActs.FlatStyle=FlatStyle.Popup;
            buttonExportExelActs.Location=new Point(332, 633);
            buttonExportExelActs.Name="buttonExportExelActs";
            buttonExportExelActs.Size=new Size(132, 76);
            buttonExportExelActs.TabIndex=13;
            buttonExportExelActs.Text="Экспорт в \r\nэксель";
            buttonExportExelActs.UseVisualStyleBackColor=false;
            // 
            // buttobPreviosActs
            // 
            buttobPreviosActs.BackColor=Color.Cornsilk;
            buttobPreviosActs.FlatStyle=FlatStyle.Popup;
            buttobPreviosActs.Location=new Point(1258, 592);
            buttobPreviosActs.Name="buttobPreviosActs";
            buttobPreviosActs.RightToLeft=RightToLeft.No;
            buttobPreviosActs.Size=new Size(45, 35);
            buttobPreviosActs.TabIndex=12;
            buttobPreviosActs.Text="<";
            buttobPreviosActs.UseVisualStyleBackColor=false;
            // 
            // buttonNextActs
            // 
            buttonNextActs.BackColor=Color.Cornsilk;
            buttonNextActs.FlatStyle=FlatStyle.Popup;
            buttonNextActs.Location=new Point(1309, 592);
            buttonNextActs.Name="buttonNextActs";
            buttonNextActs.RightToLeft=RightToLeft.No;
            buttonNextActs.Size=new Size(45, 35);
            buttonNextActs.TabIndex=11;
            buttonNextActs.Text=">";
            buttonNextActs.UseVisualStyleBackColor=false;
            // 
            // filterActButton
            // 
            filterActButton.BackColor=Color.Cornsilk;
            filterActButton.FlatStyle=FlatStyle.Popup;
            filterActButton.Location=new Point(25, 592);
            filterActButton.Name="filterActButton";
            filterActButton.Size=new Size(137, 36);
            filterActButton.TabIndex=10;
            filterActButton.Text="Фильтры";
            filterActButton.UseVisualStyleBackColor=false;
            // 
            // buttonAnimalCard
            // 
            buttonAnimalCard.BackColor=Color.Cornsilk;
            buttonAnimalCard.FlatStyle=FlatStyle.Popup;
            buttonAnimalCard.Location=new Point(1185, 633);
            buttonAnimalCard.Name="buttonAnimalCard";
            buttonAnimalCard.Size=new Size(169, 64);
            buttonAnimalCard.TabIndex=8;
            buttonAnimalCard.Text="показать карточку животного";
            buttonAnimalCard.UseVisualStyleBackColor=false;
            // 
            // AddActButton
            // 
            AddActButton.BackColor=Color.Cornsilk;
            AddActButton.FlatStyle=FlatStyle.Popup;
            AddActButton.Location=new Point(671, 649);
            AddActButton.Name="AddActButton";
            AddActButton.Size=new Size(132, 45);
            AddActButton.TabIndex=6;
            AddActButton.Text="Добавить";
            AddActButton.UseVisualStyleBackColor=false;
            // 
            // UpdateActButton
            // 
            UpdateActButton.BackColor=Color.Cornsilk;
            UpdateActButton.FlatStyle=FlatStyle.Popup;
            UpdateActButton.Location=new Point(809, 649);
            UpdateActButton.Name="UpdateActButton";
            UpdateActButton.Size=new Size(164, 45);
            UpdateActButton.TabIndex=5;
            UpdateActButton.Text="Изменить";
            UpdateActButton.UseVisualStyleBackColor=false;
            // 
            // DeleteActButton
            // 
            DeleteActButton.BackColor=Color.Cornsilk;
            DeleteActButton.FlatStyle=FlatStyle.Popup;
            DeleteActButton.Location=new Point(980, 649);
            DeleteActButton.Name="DeleteActButton";
            DeleteActButton.RightToLeft=RightToLeft.No;
            DeleteActButton.Size=new Size(132, 45);
            DeleteActButton.TabIndex=4;
            DeleteActButton.Text="Удалить";
            DeleteActButton.UseVisualStyleBackColor=false;
            // 
            // dateTimePickerAct
            // 
            dateTimePickerAct.Format=DateTimePickerFormat.Short;
            dateTimePickerAct.Location=new Point(149, 648);
            dateTimePickerAct.Name="dateTimePickerAct";
            dateTimePickerAct.Size=new Size(142, 37);
            dateTimePickerAct.TabIndex=2;
            dateTimePickerAct.Value=new DateTime(2023, 1, 1, 0, 0, 0, 0);
            // 
            // label1
            // 
            label1.AutoSize=true;
            label1.BackColor=Color.Tan;
            label1.Location=new Point(19, 648);
            label1.Name="label1";
            label1.Size=new Size(107, 30);
            label1.TabIndex=1;
            label1.Text="Акты от:";
            // 
            // DataGridViewActs
            // 
            DataGridViewActs.AllowUserToAddRows=false;
            DataGridViewActs.AllowUserToDeleteRows=false;
            DataGridViewActs.AllowUserToResizeColumns=false;
            DataGridViewActs.AllowUserToResizeRows=false;
            DataGridViewActs.AutoSizeColumnsMode=DataGridViewAutoSizeColumnsMode.Fill;
            DataGridViewActs.BackgroundColor=Color.OldLace;
            DataGridViewActs.ColumnHeadersHeightSizeMode=DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            DataGridViewActs.Columns.AddRange(new DataGridViewColumn[] { Id, CountDogs, CountCats, Organization, Date, Target, Kontracts });
            DataGridViewActs.Location=new Point(6, 6);
            DataGridViewActs.MultiSelect=false;
            DataGridViewActs.Name="DataGridViewActs";
            DataGridViewActs.ReadOnly=true;
            DataGridViewActs.RowHeadersVisible=false;
            DataGridViewActs.RowHeadersWidth=51;
            DataGridViewActs.RowTemplate.Height=24;
            DataGridViewActs.SelectionMode=DataGridViewSelectionMode.FullRowSelect;
            DataGridViewActs.Size=new Size(1329, 580);
            DataGridViewActs.TabIndex=0;
            // 
            // Id
            // 
            Id.HeaderText="№ Акта";
            Id.MinimumWidth=8;
            Id.Name="Id";
            Id.ReadOnly=true;
            // 
            // CountDogs
            // 
            CountDogs.HeaderText="Количество собак";
            CountDogs.MinimumWidth=8;
            CountDogs.Name="CountDogs";
            CountDogs.ReadOnly=true;
            // 
            // CountCats
            // 
            CountCats.HeaderText="Количество кошек";
            CountCats.MinimumWidth=8;
            CountCats.Name="CountCats";
            CountCats.ReadOnly=true;
            // 
            // Organization
            // 
            Organization.HeaderText="Организация";
            Organization.MinimumWidth=8;
            Organization.Name="Organization";
            Organization.ReadOnly=true;
            // 
            // Date
            // 
            Date.HeaderText="Дата";
            Date.MinimumWidth=8;
            Date.Name="Date";
            Date.ReadOnly=true;
            // 
            // Target
            // 
            Target.HeaderText="Цель отлова";
            Target.MinimumWidth=8;
            Target.Name="Target";
            Target.ReadOnly=true;
            // 
            // Kontracts
            // 
            Kontracts.HeaderText="Контракты";
            Kontracts.MinimumWidth=8;
            Kontracts.Name="Kontracts";
            Kontracts.ReadOnly=true;
            // 
            // pictureBox1
            // 
            pictureBox1.Location=new Point(0, 0);
            pictureBox1.Margin=new Padding(4, 5, 4, 5);
            pictureBox1.Name="pictureBox1";
            pictureBox1.Size=new Size(150, 77);
            pictureBox1.TabIndex=7;
            pictureBox1.TabStop=false;
            // 
            // tabPage2
            // 
            tabPage2.BackColor=Color.Tan;
            tabPage2.Controls.Add(button5);
            tabPage2.Controls.Add(button6);
            tabPage2.Controls.Add(button7);
            tabPage2.Controls.Add(dateTimePicker2);
            tabPage2.Controls.Add(label2);
            tabPage2.Controls.Add(dataGridViewReport);
            tabPage2.Controls.Add(checkBox1);
            tabPage2.Location=new Point(4, 39);
            tabPage2.Name="tabPage2";
            tabPage2.Padding=new Padding(3);
            tabPage2.Size=new Size(1374, 715);
            tabPage2.TabIndex=1;
            tabPage2.Text="Отчёт";
            // 
            // button5
            // 
            button5.Location=new Point(1272, 771);
            button5.Margin=new Padding(4, 3, 4, 3);
            button5.Name="button5";
            button5.Size=new Size(132, 45);
            button5.TabIndex=12;
            button5.Text="Добавить";
            button5.UseVisualStyleBackColor=true;
            // 
            // button6
            // 
            button6.BackColor=Color.Cornsilk;
            button6.FlatStyle=FlatStyle.Popup;
            button6.ForeColor=Color.Black;
            button6.Location=new Point(1078, 639);
            button6.Name="button6";
            button6.Size=new Size(148, 45);
            button6.TabIndex=11;
            button6.Text="Изменить";
            button6.UseVisualStyleBackColor=false;
            // 
            // button7
            // 
            button7.BackColor=Color.Cornsilk;
            button7.FlatStyle=FlatStyle.Popup;
            button7.Location=new Point(1233, 639);
            button7.Name="button7";
            button7.Size=new Size(132, 45);
            button7.TabIndex=10;
            button7.Text="Удалить";
            button7.UseVisualStyleBackColor=false;
            // 
            // dateTimePicker2
            // 
            dateTimePicker2.Location=new Point(304, 644);
            dateTimePicker2.Name="dateTimePicker2";
            dateTimePicker2.Size=new Size(172, 37);
            dateTimePicker2.TabIndex=9;
            // 
            // label2
            // 
            label2.AutoSize=true;
            label2.BackColor=Color.SeaShell;
            label2.Location=new Point(15, 646);
            label2.Name="label2";
            label2.Size=new Size(233, 30);
            label2.TabIndex=8;
            label2.Text="Реестр организаций от:";
            // 
            // dataGridViewReport
            // 
            dataGridViewReport.AllowUserToAddRows=false;
            dataGridViewReport.AllowUserToDeleteRows=false;
            dataGridViewReport.AllowUserToResizeColumns=false;
            dataGridViewReport.AllowUserToResizeRows=false;
            dataGridViewReport.AutoSizeColumnsMode=DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewReport.BackgroundColor=Color.OldLace;
            dataGridViewReport.ColumnHeadersHeightSizeMode=DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewReport.Columns.AddRange(new DataGridViewColumn[] { IdReport, CreatedAt, UpdateAt, StartDate, EndDate, Profit, AnimalsCount, ClosedAppsCount, User, Status });
            dataGridViewReport.Location=new Point(6, 6);
            dataGridViewReport.Name="dataGridViewReport";
            dataGridViewReport.ReadOnly=true;
            dataGridViewReport.RowHeadersVisible=false;
            dataGridViewReport.RowHeadersWidth=51;
            dataGridViewReport.RowTemplate.Height=24;
            dataGridViewReport.Size=new Size(1335, 599);
            dataGridViewReport.TabIndex=7;
            // 
            // checkBox1
            // 
            checkBox1.AutoSize=true;
            checkBox1.Checked=true;
            checkBox1.CheckState=CheckState.Checked;
            checkBox1.Location=new Point(94, 495);
            checkBox1.Name="checkBox1";
            checkBox1.Size=new Size(220, 34);
            checkBox1.TabIndex=16;
            checkBox1.Text="Работа без вылетов";
            checkBox1.UseVisualStyleBackColor=true;
            // 
            // tabPage3
            // 
            tabPage3.BackColor=Color.Tan;
            tabPage3.Controls.Add(buttonExcelContract);
            tabPage3.Controls.Add(buttonPreviosContract);
            tabPage3.Controls.Add(buttonNextContract);
            tabPage3.Controls.Add(contractFiltersButton);
            tabPage3.Controls.Add(EditButton);
            tabPage3.Controls.Add(AddButton);
            tabPage3.Controls.Add(DeleteButton);
            tabPage3.Controls.Add(ContractTable);
            tabPage3.Location=new Point(4, 39);
            tabPage3.Name="tabPage3";
            tabPage3.Size=new Size(1374, 715);
            tabPage3.TabIndex=2;
            tabPage3.Text="Муниципальные контракты";
            // 
            // buttonExcelContract
            // 
            buttonExcelContract.BackColor=Color.Cornsilk;
            buttonExcelContract.FlatStyle=FlatStyle.Popup;
            buttonExcelContract.Location=new Point(173, 620);
            buttonExcelContract.Name="buttonExcelContract";
            buttonExcelContract.Size=new Size(225, 36);
            buttonExcelContract.TabIndex=23;
            buttonExcelContract.Text="Экспорт в эксель";
            buttonExcelContract.UseVisualStyleBackColor=false;
            // 
            // buttonPreviosContract
            // 
            buttonPreviosContract.BackColor=Color.Cornsilk;
            buttonPreviosContract.FlatStyle=FlatStyle.Popup;
            buttonPreviosContract.Location=new Point(1275, 609);
            buttonPreviosContract.Name="buttonPreviosContract";
            buttonPreviosContract.RightToLeft=RightToLeft.No;
            buttonPreviosContract.Size=new Size(45, 35);
            buttonPreviosContract.TabIndex=22;
            buttonPreviosContract.Text="<";
            buttonPreviosContract.UseVisualStyleBackColor=false;
            // 
            // buttonNextContract
            // 
            buttonNextContract.BackColor=Color.Cornsilk;
            buttonNextContract.FlatStyle=FlatStyle.Popup;
            buttonNextContract.Location=new Point(1326, 609);
            buttonNextContract.Name="buttonNextContract";
            buttonNextContract.RightToLeft=RightToLeft.No;
            buttonNextContract.Size=new Size(45, 35);
            buttonNextContract.TabIndex=21;
            buttonNextContract.Text=">";
            buttonNextContract.UseVisualStyleBackColor=false;
            // 
            // contractFiltersButton
            // 
            contractFiltersButton.BackColor=Color.Cornsilk;
            contractFiltersButton.FlatStyle=FlatStyle.Popup;
            contractFiltersButton.Location=new Point(18, 620);
            contractFiltersButton.Name="contractFiltersButton";
            contractFiltersButton.Size=new Size(137, 36);
            contractFiltersButton.TabIndex=15;
            contractFiltersButton.Text="Фильтры";
            contractFiltersButton.UseVisualStyleBackColor=false;
            // 
            // EditButton
            // 
            EditButton.BackColor=Color.Cornsilk;
            EditButton.FlatStyle=FlatStyle.Popup;
            EditButton.Location=new Point(1051, 665);
            EditButton.Name="EditButton";
            EditButton.Size=new Size(153, 44);
            EditButton.TabIndex=13;
            EditButton.Text="Изменить";
            EditButton.UseVisualStyleBackColor=false;
            // 
            // AddButton
            // 
            AddButton.BackColor=Color.Cornsilk;
            AddButton.FlatStyle=FlatStyle.Popup;
            AddButton.Location=new Point(895, 665);
            AddButton.Name="AddButton";
            AddButton.Size=new Size(136, 47);
            AddButton.TabIndex=12;
            AddButton.Text="Добавить";
            AddButton.UseVisualStyleBackColor=false;
            // 
            // DeleteButton
            // 
            DeleteButton.BackColor=Color.Cornsilk;
            DeleteButton.FlatStyle=FlatStyle.Popup;
            DeleteButton.Location=new Point(1222, 664);
            DeleteButton.Name="DeleteButton";
            DeleteButton.Size=new Size(142, 47);
            DeleteButton.TabIndex=11;
            DeleteButton.Text="Удалить";
            DeleteButton.UseVisualStyleBackColor=false;
            // 
            // ContractTable
            // 
            ContractTable.AllowUserToAddRows=false;
            ContractTable.AllowUserToDeleteRows=false;
            ContractTable.AllowUserToResizeColumns=false;
            ContractTable.AllowUserToResizeRows=false;
            ContractTable.AutoSizeColumnsMode=DataGridViewAutoSizeColumnsMode.Fill;
            ContractTable.BackgroundColor=Color.OldLace;
            ContractTable.ColumnHeadersHeightSizeMode=DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            ContractTable.Columns.AddRange(new DataGridViewColumn[] { Column1, Column2, Column3, Column5, Column6 });
            ContractTable.Location=new Point(18, 12);
            ContractTable.Name="ContractTable";
            ContractTable.ReadOnly=true;
            ContractTable.RowHeadersVisible=false;
            ContractTable.RowHeadersWidth=51;
            ContractTable.RowTemplate.Height=24;
            ContractTable.SelectionMode=DataGridViewSelectionMode.FullRowSelect;
            ContractTable.Size=new Size(1346, 591);
            ContractTable.TabIndex=8;
            // 
            // Column1
            // 
            Column1.FillWeight=75.75759F;
            Column1.HeaderText="Номер контракта";
            Column1.MinimumWidth=6;
            Column1.Name="Column1";
            Column1.ReadOnly=true;
            // 
            // Column2
            // 
            Column2.FillWeight=85.40144F;
            Column2.HeaderText="Дата заключения";
            Column2.MinimumWidth=6;
            Column2.Name="Column2";
            Column2.ReadOnly=true;
            // 
            // Column3
            // 
            Column3.FillWeight=94.00158F;
            Column3.HeaderText="Дата действия";
            Column3.MinimumWidth=6;
            Column3.Name="Column3";
            Column3.ReadOnly=true;
            // 
            // Column5
            // 
            Column5.FillWeight=114.6095F;
            Column5.HeaderText="Заказчик";
            Column5.MinimumWidth=6;
            Column5.Name="Column5";
            Column5.ReadOnly=true;
            // 
            // Column6
            // 
            Column6.FillWeight=120.0486F;
            Column6.HeaderText="Исполнитель";
            Column6.MinimumWidth=6;
            Column6.Name="Column6";
            Column6.ReadOnly=true;
            // 
            // tabPage4
            // 
            tabPage4.BackColor=Color.Tan;
            tabPage4.Controls.Add(buttonExcelApp);
            tabPage4.Controls.Add(buttonPreviosApps);
            tabPage4.Controls.Add(buttonNextApps);
            tabPage4.Controls.Add(applicationFiltersButton);
            tabPage4.Controls.Add(AppAdd);
            tabPage4.Controls.Add(AppEdit);
            tabPage4.Controls.Add(AppDelete);
            tabPage4.Controls.Add(dataGridViewApp);
            tabPage4.Location=new Point(4, 39);
            tabPage4.Name="tabPage4";
            tabPage4.Size=new Size(1374, 715);
            tabPage4.TabIndex=3;
            tabPage4.Text="Реестр заявок";
            // 
            // buttonExcelApp
            // 
            buttonExcelApp.BackColor=Color.Cornsilk;
            buttonExcelApp.FlatStyle=FlatStyle.Popup;
            buttonExcelApp.Location=new Point(243, 618);
            buttonExcelApp.Name="buttonExcelApp";
            buttonExcelApp.Size=new Size(132, 76);
            buttonExcelApp.TabIndex=26;
            buttonExcelApp.Text="Экспорт в \r\nэксель";
            buttonExcelApp.UseVisualStyleBackColor=false;
            // 
            // buttonPreviosApps
            // 
            buttonPreviosApps.BackColor=Color.Cornsilk;
            buttonPreviosApps.FlatStyle=FlatStyle.Popup;
            buttonPreviosApps.Location=new Point(1253, 607);
            buttonPreviosApps.Name="buttonPreviosApps";
            buttonPreviosApps.RightToLeft=RightToLeft.No;
            buttonPreviosApps.Size=new Size(45, 35);
            buttonPreviosApps.TabIndex=25;
            buttonPreviosApps.Text="<";
            buttonPreviosApps.UseVisualStyleBackColor=false;
            // 
            // buttonNextApps
            // 
            buttonNextApps.BackColor=Color.Cornsilk;
            buttonNextApps.FlatStyle=FlatStyle.Popup;
            buttonNextApps.Location=new Point(1304, 607);
            buttonNextApps.Name="buttonNextApps";
            buttonNextApps.RightToLeft=RightToLeft.No;
            buttonNextApps.Size=new Size(45, 35);
            buttonNextApps.TabIndex=24;
            buttonNextApps.Text=">";
            buttonNextApps.UseVisualStyleBackColor=false;
            // 
            // applicationFiltersButton
            // 
            applicationFiltersButton.BackColor=Color.Cornsilk;
            applicationFiltersButton.FlatStyle=FlatStyle.Popup;
            applicationFiltersButton.Location=new Point(18, 618);
            applicationFiltersButton.Name="applicationFiltersButton";
            applicationFiltersButton.Size=new Size(137, 36);
            applicationFiltersButton.TabIndex=23;
            applicationFiltersButton.Text="Фильтры";
            applicationFiltersButton.UseVisualStyleBackColor=false;
            // 
            // AppAdd
            // 
            AppAdd.BackColor=Color.Cornsilk;
            AppAdd.FlatStyle=FlatStyle.Popup;
            AppAdd.Font=new Font("Segoe Print", 10F, FontStyle.Bold, GraphicsUnit.Point);
            AppAdd.ForeColor=Color.Black;
            AppAdd.Location=new Point(942, 653);
            AppAdd.Name="AppAdd";
            AppAdd.Size=new Size(132, 45);
            AppAdd.TabIndex=16;
            AppAdd.Text="Добавить";
            AppAdd.UseVisualStyleBackColor=false;
            // 
            // AppEdit
            // 
            AppEdit.BackColor=Color.Cornsilk;
            AppEdit.FlatStyle=FlatStyle.Popup;
            AppEdit.Font=new Font("Segoe Print", 10F, FontStyle.Bold, GraphicsUnit.Point);
            AppEdit.Location=new Point(1089, 653);
            AppEdit.Name="AppEdit";
            AppEdit.Size=new Size(144, 45);
            AppEdit.TabIndex=15;
            AppEdit.Text="Изменить";
            AppEdit.UseVisualStyleBackColor=false;
            // 
            // AppDelete
            // 
            AppDelete.BackColor=Color.Cornsilk;
            AppDelete.FlatStyle=FlatStyle.Popup;
            AppDelete.Font=new Font("Segoe Print", 10F, FontStyle.Bold, GraphicsUnit.Point);
            AppDelete.Location=new Point(1239, 652);
            AppDelete.Name="AppDelete";
            AppDelete.Size=new Size(132, 45);
            AppDelete.TabIndex=14;
            AppDelete.Text="Удалить";
            AppDelete.UseVisualStyleBackColor=false;
            // 
            // dataGridViewApp
            // 
            dataGridViewApp.AllowUserToAddRows=false;
            dataGridViewApp.AllowUserToDeleteRows=false;
            dataGridViewApp.AllowUserToResizeColumns=false;
            dataGridViewApp.AllowUserToResizeRows=false;
            dataGridViewApp.AutoSizeColumnsMode=DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewApp.BackgroundColor=Color.OldLace;
            dataGridViewApp.CellBorderStyle=DataGridViewCellBorderStyle.RaisedVertical;
            dataGridViewApp.ColumnHeadersHeightSizeMode=DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewApp.Location=new Point(18, 14);
            dataGridViewApp.MultiSelect=false;
            dataGridViewApp.Name="dataGridViewApp";
            dataGridViewApp.ReadOnly=true;
            dataGridViewApp.RowHeadersVisible=false;
            dataGridViewApp.RowHeadersWidth=62;
            dataGridViewApp.RowTemplate.Height=28;
            dataGridViewApp.SelectionMode=DataGridViewSelectionMode.FullRowSelect;
            dataGridViewApp.Size=new Size(1331, 587);
            dataGridViewApp.TabIndex=0;
            // 
            // tabPage5
            // 
            tabPage5.BackColor=Color.Tan;
            tabPage5.Controls.Add(buttonExcelOrg);
            tabPage5.Controls.Add(buttonPreviosOrganisations);
            tabPage5.Controls.Add(buttonNextOrganisations);
            tabPage5.Controls.Add(organizationFiltersButton);
            tabPage5.Controls.Add(dataGridViewOrg);
            tabPage5.Controls.Add(OrgAdd);
            tabPage5.Controls.Add(OrgEdit);
            tabPage5.Controls.Add(OrgDelete);
            tabPage5.Location=new Point(4, 39);
            tabPage5.Name="tabPage5";
            tabPage5.Size=new Size(1374, 715);
            tabPage5.TabIndex=4;
            tabPage5.Text="Реестр организаций";
            // 
            // buttonExcelOrg
            // 
            buttonExcelOrg.BackColor=Color.Cornsilk;
            buttonExcelOrg.FlatStyle=FlatStyle.Popup;
            buttonExcelOrg.Location=new Point(211, 627);
            buttonExcelOrg.Name="buttonExcelOrg";
            buttonExcelOrg.Size=new Size(132, 76);
            buttonExcelOrg.TabIndex=28;
            buttonExcelOrg.Text="Экспорт в \r\nэксель";
            buttonExcelOrg.UseVisualStyleBackColor=false;
            // 
            // buttonPreviosOrganisations
            // 
            buttonPreviosOrganisations.BackColor=Color.Cornsilk;
            buttonPreviosOrganisations.FlatStyle=FlatStyle.Popup;
            buttonPreviosOrganisations.Location=new Point(1261, 616);
            buttonPreviosOrganisations.Name="buttonPreviosOrganisations";
            buttonPreviosOrganisations.RightToLeft=RightToLeft.No;
            buttonPreviosOrganisations.Size=new Size(45, 35);
            buttonPreviosOrganisations.TabIndex=27;
            buttonPreviosOrganisations.Text="<";
            buttonPreviosOrganisations.UseVisualStyleBackColor=false;
            // 
            // buttonNextOrganisations
            // 
            buttonNextOrganisations.BackColor=Color.Cornsilk;
            buttonNextOrganisations.FlatStyle=FlatStyle.Popup;
            buttonNextOrganisations.Location=new Point(1312, 616);
            buttonNextOrganisations.Name="buttonNextOrganisations";
            buttonNextOrganisations.RightToLeft=RightToLeft.No;
            buttonNextOrganisations.Size=new Size(45, 35);
            buttonNextOrganisations.TabIndex=26;
            buttonNextOrganisations.Text=">";
            buttonNextOrganisations.UseVisualStyleBackColor=false;
            // 
            // organizationFiltersButton
            // 
            organizationFiltersButton.BackColor=Color.Cornsilk;
            organizationFiltersButton.FlatStyle=FlatStyle.Popup;
            organizationFiltersButton.Location=new Point(26, 627);
            organizationFiltersButton.Name="organizationFiltersButton";
            organizationFiltersButton.Size=new Size(137, 36);
            organizationFiltersButton.TabIndex=24;
            organizationFiltersButton.Text="Фильтры";
            organizationFiltersButton.UseVisualStyleBackColor=false;
            // 
            // dataGridViewOrg
            // 
            dataGridViewOrg.AllowUserToAddRows=false;
            dataGridViewOrg.AllowUserToDeleteRows=false;
            dataGridViewOrg.AllowUserToResizeColumns=false;
            dataGridViewOrg.AllowUserToResizeRows=false;
            dataGridViewOrg.AutoSizeColumnsMode=DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewOrg.BackgroundColor=Color.OldLace;
            dataGridViewOrg.ColumnHeadersHeightSizeMode=DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewOrg.Location=new Point(26, 3);
            dataGridViewOrg.MultiSelect=false;
            dataGridViewOrg.Name="dataGridViewOrg";
            dataGridViewOrg.ReadOnly=true;
            dataGridViewOrg.RowHeadersVisible=false;
            dataGridViewOrg.RowHeadersWidth=62;
            dataGridViewOrg.RowTemplate.Height=28;
            dataGridViewOrg.SelectionMode=DataGridViewSelectionMode.FullRowSelect;
            dataGridViewOrg.Size=new Size(1331, 607);
            dataGridViewOrg.TabIndex=17;
            // 
            // OrgAdd
            // 
            OrgAdd.BackColor=Color.Cornsilk;
            OrgAdd.FlatStyle=FlatStyle.Popup;
            OrgAdd.Location=new Point(943, 652);
            OrgAdd.Name="OrgAdd";
            OrgAdd.Size=new Size(132, 45);
            OrgAdd.TabIndex=16;
            OrgAdd.Text="Добавить";
            OrgAdd.UseVisualStyleBackColor=false;
            // 
            // OrgEdit
            // 
            OrgEdit.BackColor=Color.Cornsilk;
            OrgEdit.FlatStyle=FlatStyle.Popup;
            OrgEdit.Location=new Point(1081, 652);
            OrgEdit.Name="OrgEdit";
            OrgEdit.Size=new Size(152, 45);
            OrgEdit.TabIndex=15;
            OrgEdit.Text="Изменить";
            OrgEdit.UseVisualStyleBackColor=false;
            // 
            // OrgDelete
            // 
            OrgDelete.BackColor=Color.Cornsilk;
            OrgDelete.FlatStyle=FlatStyle.Popup;
            OrgDelete.Location=new Point(1239, 652);
            OrgDelete.Name="OrgDelete";
            OrgDelete.Size=new Size(132, 45);
            OrgDelete.TabIndex=14;
            OrgDelete.Text="Удалить";
            OrgDelete.UseVisualStyleBackColor=false;
            // 
            // tabPage6
            // 
            tabPage6.BackColor=Color.Tan;
            tabPage6.Controls.Add(historyFiltersButton);
            tabPage6.Controls.Add(buttonExcelHistory);
            tabPage6.Controls.Add(buttonPriviosHistory);
            tabPage6.Controls.Add(buttonNextHistory);
            tabPage6.Controls.Add(dataGridViewHistory);
            tabPage6.ForeColor=Color.Black;
            tabPage6.Location=new Point(4, 39);
            tabPage6.Name="tabPage6";
            tabPage6.Padding=new Padding(3);
            tabPage6.Size=new Size(1374, 715);
            tabPage6.TabIndex=5;
            tabPage6.Text="История";
            // 
            // historyFiltersButton
            // 
            historyFiltersButton.BackColor=Color.Cornsilk;
            historyFiltersButton.FlatStyle=FlatStyle.Popup;
            historyFiltersButton.Location=new Point(161, 619);
            historyFiltersButton.Name="historyFiltersButton";
            historyFiltersButton.Size=new Size(132, 76);
            historyFiltersButton.TabIndex=22;
            historyFiltersButton.Text="Фильтры";
            historyFiltersButton.UseVisualStyleBackColor=false;
            // 
            // buttonExcelHistory
            // 
            buttonExcelHistory.BackColor=Color.Cornsilk;
            buttonExcelHistory.FlatStyle=FlatStyle.Popup;
            buttonExcelHistory.Location=new Point(6, 619);
            buttonExcelHistory.Name="buttonExcelHistory";
            buttonExcelHistory.Size=new Size(132, 76);
            buttonExcelHistory.TabIndex=21;
            buttonExcelHistory.Text="Экспорт в \r\nэксель";
            buttonExcelHistory.UseVisualStyleBackColor=false;
            // 
            // buttonPriviosHistory
            // 
            buttonPriviosHistory.BackColor=Color.Cornsilk;
            buttonPriviosHistory.FlatStyle=FlatStyle.Popup;
            buttonPriviosHistory.Location=new Point(1272, 619);
            buttonPriviosHistory.Name="buttonPriviosHistory";
            buttonPriviosHistory.RightToLeft=RightToLeft.No;
            buttonPriviosHistory.Size=new Size(45, 35);
            buttonPriviosHistory.TabIndex=20;
            buttonPriviosHistory.Text="<";
            buttonPriviosHistory.UseVisualStyleBackColor=false;
            // 
            // buttonNextHistory
            // 
            buttonNextHistory.BackColor=Color.Cornsilk;
            buttonNextHistory.FlatStyle=FlatStyle.Popup;
            buttonNextHistory.Location=new Point(1323, 619);
            buttonNextHistory.Name="buttonNextHistory";
            buttonNextHistory.RightToLeft=RightToLeft.No;
            buttonNextHistory.Size=new Size(45, 35);
            buttonNextHistory.TabIndex=19;
            buttonNextHistory.Text=">";
            buttonNextHistory.UseVisualStyleBackColor=false;
            // 
            // dataGridViewHistory
            // 
            dataGridViewHistory.AllowUserToAddRows=false;
            dataGridViewHistory.AllowUserToDeleteRows=false;
            dataGridViewHistory.AllowUserToResizeColumns=false;
            dataGridViewHistory.AllowUserToResizeRows=false;
            dataGridViewHistory.AutoSizeColumnsMode=DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewHistory.BackgroundColor=Color.OldLace;
            dataGridViewHistory.ColumnHeadersHeightSizeMode=DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewHistory.Location=new Point(6, 6);
            dataGridViewHistory.MultiSelect=false;
            dataGridViewHistory.Name="dataGridViewHistory";
            dataGridViewHistory.ReadOnly=true;
            dataGridViewHistory.RowHeadersVisible=false;
            dataGridViewHistory.RowHeadersWidth=62;
            dataGridViewHistory.RowTemplate.Height=28;
            dataGridViewHistory.SelectionMode=DataGridViewSelectionMode.FullRowSelect;
            dataGridViewHistory.Size=new Size(1362, 607);
            dataGridViewHistory.TabIndex=18;
            // 
            // buttonPriviosPageAct
            // 
            buttonPriviosPageAct.BackColor=Color.Cornsilk;
            buttonPriviosPageAct.FlatStyle=FlatStyle.Popup;
            buttonPriviosPageAct.Location=new Point(1168, 592);
            buttonPriviosPageAct.Name="buttonPriviosPageAct";
            buttonPriviosPageAct.RightToLeft=RightToLeft.No;
            buttonPriviosPageAct.Size=new Size(90, 36);
            buttonPriviosPageAct.TabIndex=14;
            buttonPriviosPageAct.Text="<";
            buttonPriviosPageAct.UseVisualStyleBackColor=false;
            // 
            // buttonNextPageAct
            // 
            buttonNextPageAct.BackColor=Color.Cornsilk;
            buttonNextPageAct.FlatStyle=FlatStyle.Popup;
            buttonNextPageAct.Location=new Point(1264, 592);
            buttonNextPageAct.Name="buttonNextPageAct";
            buttonNextPageAct.RightToLeft=RightToLeft.No;
            buttonNextPageAct.Size=new Size(90, 36);
            buttonNextPageAct.TabIndex=13;
            buttonNextPageAct.Text=">";
            buttonNextPageAct.UseVisualStyleBackColor=false;
            // 
            // buttonPreviousContracts
            // 
            buttonPreviousContracts.BackColor=Color.Cornsilk;
            buttonPreviousContracts.FlatStyle=FlatStyle.Popup;
            buttonPreviousContracts.Location=new Point(1178, 609);
            buttonPreviousContracts.Name="buttonPreviousContracts";
            buttonPreviousContracts.RightToLeft=RightToLeft.No;
            buttonPreviousContracts.Size=new Size(90, 36);
            buttonPreviousContracts.TabIndex=16;
            buttonPreviousContracts.Text="<";
            buttonPreviousContracts.UseVisualStyleBackColor=false;
            // 
            // buttonNextContracts
            // 
            buttonNextContracts.BackColor=Color.Cornsilk;
            buttonNextContracts.FlatStyle=FlatStyle.Popup;
            buttonNextContracts.Location=new Point(1274, 609);
            buttonNextContracts.Name="buttonNextContracts";
            buttonNextContracts.RightToLeft=RightToLeft.No;
            buttonNextContracts.Size=new Size(90, 36);
            buttonNextContracts.TabIndex=15;
            buttonNextContracts.Text=">";
            buttonNextContracts.UseVisualStyleBackColor=false;
            // 
            // dateTimePicker1
            // 
            dateTimePicker1.Location=new Point(425, 498);
            dateTimePicker1.Margin=new Padding(3, 2, 3, 2);
            dateTimePicker1.Name="dateTimePicker1";
            dateTimePicker1.Size=new Size(153, 27);
            dateTimePicker1.TabIndex=17;
            dateTimePicker1.Value=new DateTime(2000, 6, 10, 0, 0, 0, 0);
            // 
            // label7
            // 
            label7.AutoSize=true;
            label7.Location=new Point(393, 498);
            label7.Name="label7";
            label7.Size=new Size(26, 16);
            label7.TabIndex=16;
            label7.Text="до:";
            // 
            // IdReport
            // 
            IdReport.HeaderText="Номер контракта";
            IdReport.MinimumWidth=6;
            IdReport.Name="IdReport";
            IdReport.ReadOnly=true;
            IdReport.Visible=false;
            // 
            // CreatedAt
            // 
            CreatedAt.HeaderText="Дата создания";
            CreatedAt.MinimumWidth=6;
            CreatedAt.Name="CreatedAt";
            CreatedAt.ReadOnly=true;
            CreatedAt.Visible=false;
            // 
            // UpdateAt
            // 
            UpdateAt.HeaderText="Обновлён";
            UpdateAt.MinimumWidth=6;
            UpdateAt.Name="UpdateAt";
            UpdateAt.ReadOnly=true;
            // 
            // StartDate
            // 
            StartDate.HeaderText="Дата старта";
            StartDate.MinimumWidth=6;
            StartDate.Name="StartDate";
            StartDate.ReadOnly=true;
            // 
            // EndDate
            // 
            EndDate.HeaderText="Дата окончания";
            EndDate.MinimumWidth=6;
            EndDate.Name="EndDate";
            EndDate.ReadOnly=true;
            // 
            // Profit
            // 
            Profit.HeaderText="Доход";
            Profit.MinimumWidth=6;
            Profit.Name="Profit";
            Profit.ReadOnly=true;
            // 
            // AnimalsCount
            // 
            AnimalsCount.HeaderText="Количество животных";
            AnimalsCount.MinimumWidth=6;
            AnimalsCount.Name="AnimalsCount";
            AnimalsCount.ReadOnly=true;
            // 
            // ClosedAppsCount
            // 
            ClosedAppsCount.HeaderText="Количество закрытых заявок";
            ClosedAppsCount.MinimumWidth=6;
            ClosedAppsCount.Name="ClosedAppsCount";
            ClosedAppsCount.ReadOnly=true;
            // 
            // User
            // 
            User.HeaderText="Пользователь";
            User.MinimumWidth=6;
            User.Name="User";
            User.ReadOnly=true;
            // 
            // Status
            // 
            Status.HeaderText="Статус";
            Status.MinimumWidth=6;
            Status.Name="Status";
            Status.ReadOnly=true;
            // 
            // MainForm
            // 
            AutoScaleMode=AutoScaleMode.Inherit;
            BackColor=Color.Wheat;
            ClientSize=new Size(1408, 788);
            Controls.Add(tabControl1);
            Cursor=Cursors.PanNW;
            Font=new Font("Segoe Print", 10F, FontStyle.Bold, GraphicsUnit.Point);
            ForeColor=Color.Black;
            FormBorderStyle=FormBorderStyle.FixedToolWindow;
            Icon=(Icon)resources.GetObject("$this.Icon");
            Name="MainForm";
            StartPosition=FormStartPosition.CenterScreen;
            Tag="";
            Text="Заявки на отлов";
            tabControl1.ResumeLayout(false);
            tabPage1.ResumeLayout(false);
            tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)DataGridViewActs).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            tabPage2.ResumeLayout(false);
            tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewReport).EndInit();
            tabPage3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)ContractTable).EndInit();
            tabPage4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridViewApp).EndInit();
            tabPage5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridViewOrg).EndInit();
            tabPage6.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridViewHistory).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private TabControl tabControl1;
        private TabPage tabPage1;
        private Button AddActButton;
        private Button UpdateActButton;
        private Button DeleteActButton;
        private DateTimePicker dateTimePickerAct;
        private Label label1;
        private DataGridView DataGridViewActs;
        private TabPage tabPage2;
        private Button button5;
        private Button button6;
        private Button button7;
        private DateTimePicker dateTimePicker2;
        private Label label2;
        private DataGridView dataGridViewReport;
        private TabPage tabPage3;
        private DataGridView ContractTable;
        private TabPage tabPage4;
        private TabPage tabPage5;
        private Button AppAdd;
        private Button AppEdit;
        private Button AppDelete;
        private DataGridView dataGridViewApp;
        private DataGridView dataGridViewOrg;
        private Button OrgAdd;
        private Button OrgEdit;
        private Button OrgDelete;
        private PictureBox pictureBox1;
        private Button EditButton;
        private Button AddButton;
        private Button DeleteButton;
        private DataGridViewTextBoxColumn Column1;
        private DataGridViewTextBoxColumn Column2;
        private DataGridViewTextBoxColumn Column3;
        private DataGridViewTextBoxColumn Column5;
        private DataGridViewTextBoxColumn Column6;
        private DateTimePicker dateTimePicker1;
        private Label label7;
        private Button buttonAnimalCard;
        private CheckBox checkBox1;
        private DataGridViewTextBoxColumn Id;
        private DataGridViewTextBoxColumn CountDogs;
        private DataGridViewTextBoxColumn CountCats;
        private DataGridViewTextBoxColumn Organization;
        private DataGridViewTextBoxColumn Date;
        private DataGridViewTextBoxColumn Target;
        private DataGridViewTextBoxColumn Kontracts;
        private Button filterActButton;
        private Button contractFiltersButton;
        private Button applicationFiltersButton;
        private TabPage tabPage6;
        private DataGridView dataGridViewHistory;
        private Button buttonPriviosPageAct;
        private Button buttonNextPageAct;
        private Button buttonPreviousContracts;
        private Button buttonNextContracts;
        private Button organizationFiltersButton;
        private Button buttonNextActs;
        private Button buttobPreviosActs;
        private Button buttonPriviosHistory;
        private Button buttonNextHistory;
        private Button buttonPreviosContract;
        private Button buttonNextContract;
        private Button buttonPreviosApps;
        private Button buttonNextApps;
        private Button buttonPreviosOrganisations;
        private Button buttonNextOrganisations;
        private Button buttonExportExelActs;
        private Button buttonExcelContract;
        private Button buttonExcelApp;
        private Button buttonExcelOrg;
        private Button buttonExcelHistory;
        private Button historyFiltersButton;
        private DataGridViewTextBoxColumn IdReport;
        private DataGridViewTextBoxColumn CreatedAt;
        private DataGridViewTextBoxColumn UpdateAt;
        private DataGridViewTextBoxColumn StartDate;
        private DataGridViewTextBoxColumn EndDate;
        private DataGridViewTextBoxColumn Profit;
        private DataGridViewTextBoxColumn AnimalsCount;
        private DataGridViewTextBoxColumn ClosedAppsCount;
        private DataGridViewTextBoxColumn User;
        private DataGridViewTextBoxColumn Status;
    }
}

