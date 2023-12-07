namespace GrpcClient_PI_21_01.Views.Filters
{
    partial class ActFilter
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.orgBox = new System.Windows.Forms.GroupBox();
            this.orgComboBox = new System.Windows.Forms.ComboBox();
            this.animalBox = new System.Windows.Forms.GroupBox();
            this.enableCatFilter = new System.Windows.Forms.CheckBox();
            this.enableDogFilter = new System.Windows.Forms.CheckBox();
            this.catBox = new System.Windows.Forms.GroupBox();
            this.catNotLess = new System.Windows.Forms.RadioButton();
            this.catNotMore = new System.Windows.Forms.RadioButton();
            this.catLess = new System.Windows.Forms.RadioButton();
            this.catMore = new System.Windows.Forms.RadioButton();
            this.catEqual = new System.Windows.Forms.RadioButton();
            this.catCount = new System.Windows.Forms.NumericUpDown();
            this.dogBox = new System.Windows.Forms.GroupBox();
            this.dogNotLess = new System.Windows.Forms.RadioButton();
            this.dogNotMore = new System.Windows.Forms.RadioButton();
            this.dogLess = new System.Windows.Forms.RadioButton();
            this.dogMore = new System.Windows.Forms.RadioButton();
            this.dogEqual = new System.Windows.Forms.RadioButton();
            this.dogCount = new System.Windows.Forms.NumericUpDown();
            this.goalBox = new System.Windows.Forms.GroupBox();
            this.goalTextBox = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.toDateLabel = new System.Windows.Forms.Label();
            this.toDate = new System.Windows.Forms.DateTimePicker();
            this.fromDateLabel = new System.Windows.Forms.Label();
            this.fromDate = new System.Windows.Forms.DateTimePicker();
            this.contractBox = new System.Windows.Forms.GroupBox();
            this.contractComboBox = new System.Windows.Forms.ComboBox();
            this.applicationBox = new System.Windows.Forms.GroupBox();
            this.appListLabel = new System.Windows.Forms.Label();
            this.removeApplication = new System.Windows.Forms.Button();
            this.addApplication = new System.Windows.Forms.Button();
            this.appComboBox = new System.Windows.Forms.ComboBox();
            this.applications = new System.Windows.Forms.ListBox();
            this.apply = new System.Windows.Forms.Button();
            this.reset = new System.Windows.Forms.Button();
            this.close = new System.Windows.Forms.Button();
            this.orgBox.SuspendLayout();
            this.animalBox.SuspendLayout();
            this.catBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.catCount)).BeginInit();
            this.dogBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dogCount)).BeginInit();
            this.goalBox.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.contractBox.SuspendLayout();
            this.applicationBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // orgBox
            // 
            this.orgBox.Controls.Add(this.orgComboBox);
            this.orgBox.Location = new System.Drawing.Point(21, 12);
            this.orgBox.Name = "orgBox";
            this.orgBox.Size = new System.Drawing.Size(606, 69);
            this.orgBox.TabIndex = 2;
            this.orgBox.TabStop = false;
            this.orgBox.Text = "По организации";
            // 
            // orgComboBox
            // 
            this.orgComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.orgComboBox.FormattingEnabled = true;
            this.orgComboBox.Location = new System.Drawing.Point(15, 26);
            this.orgComboBox.Name = "orgComboBox";
            this.orgComboBox.Size = new System.Drawing.Size(572, 28);
            this.orgComboBox.TabIndex = 0;
            // 
            // animalBox
            // 
            this.animalBox.Controls.Add(this.enableCatFilter);
            this.animalBox.Controls.Add(this.enableDogFilter);
            this.animalBox.Controls.Add(this.catBox);
            this.animalBox.Controls.Add(this.dogBox);
            this.animalBox.Location = new System.Drawing.Point(21, 103);
            this.animalBox.Name = "animalBox";
            this.animalBox.Size = new System.Drawing.Size(606, 313);
            this.animalBox.TabIndex = 3;
            this.animalBox.TabStop = false;
            this.animalBox.Text = "По количеству отловленных животных";
            // 
            // enableCatFilter
            // 
            this.enableCatFilter.AutoSize = true;
            this.enableCatFilter.Location = new System.Drawing.Point(325, 43);
            this.enableCatFilter.Name = "enableCatFilter";
            this.enableCatFilter.Size = new System.Drawing.Size(152, 24);
            this.enableCatFilter.TabIndex = 7;
            this.enableCatFilter.Text = "Включить фильтр";
            this.enableCatFilter.UseVisualStyleBackColor = true;
            // 
            // enableDogFilter
            // 
            this.enableDogFilter.AutoSize = true;
            this.enableDogFilter.Location = new System.Drawing.Point(15, 43);
            this.enableDogFilter.Name = "enableDogFilter";
            this.enableDogFilter.Size = new System.Drawing.Size(152, 24);
            this.enableDogFilter.TabIndex = 4;
            this.enableDogFilter.Text = "Включить фильтр";
            this.enableDogFilter.UseVisualStyleBackColor = true;
            // 
            // catBox
            // 
            this.catBox.Controls.Add(this.catNotLess);
            this.catBox.Controls.Add(this.catNotMore);
            this.catBox.Controls.Add(this.catLess);
            this.catBox.Controls.Add(this.catMore);
            this.catBox.Controls.Add(this.catEqual);
            this.catBox.Controls.Add(this.catCount);
            this.catBox.Enabled = false;
            this.catBox.Location = new System.Drawing.Point(325, 73);
            this.catBox.Name = "catBox";
            this.catBox.Size = new System.Drawing.Size(262, 221);
            this.catBox.TabIndex = 6;
            this.catBox.TabStop = false;
            this.catBox.Text = "Количество отловленных кошек";
            // 
            // catNotLess
            // 
            this.catNotLess.AutoSize = true;
            this.catNotLess.Location = new System.Drawing.Point(20, 179);
            this.catNotLess.Name = "catNotLess";
            this.catNotLess.Size = new System.Drawing.Size(97, 24);
            this.catNotLess.TabIndex = 5;
            this.catNotLess.TabStop = true;
            this.catNotLess.Text = "Не менее";
            this.catNotLess.UseVisualStyleBackColor = true;
            // 
            // catNotMore
            // 
            this.catNotMore.AutoSize = true;
            this.catNotMore.Location = new System.Drawing.Point(20, 149);
            this.catNotMore.Name = "catNotMore";
            this.catNotMore.Size = new System.Drawing.Size(95, 24);
            this.catNotMore.TabIndex = 4;
            this.catNotMore.TabStop = true;
            this.catNotMore.Text = "Не более";
            this.catNotMore.UseVisualStyleBackColor = true;
            // 
            // catLess
            // 
            this.catLess.AutoSize = true;
            this.catLess.Location = new System.Drawing.Point(20, 119);
            this.catLess.Name = "catLess";
            this.catLess.Size = new System.Drawing.Size(88, 24);
            this.catLess.TabIndex = 3;
            this.catLess.TabStop = true;
            this.catLess.Text = "Меньше";
            this.catLess.UseVisualStyleBackColor = true;
            // 
            // catMore
            // 
            this.catMore.AutoSize = true;
            this.catMore.Location = new System.Drawing.Point(20, 89);
            this.catMore.Name = "catMore";
            this.catMore.Size = new System.Drawing.Size(84, 24);
            this.catMore.TabIndex = 2;
            this.catMore.TabStop = true;
            this.catMore.Text = "Больше";
            this.catMore.UseVisualStyleBackColor = true;
            // 
            // catEqual
            // 
            this.catEqual.AutoSize = true;
            this.catEqual.Location = new System.Drawing.Point(20, 59);
            this.catEqual.Name = "catEqual";
            this.catEqual.Size = new System.Drawing.Size(72, 24);
            this.catEqual.TabIndex = 1;
            this.catEqual.TabStop = true;
            this.catEqual.Text = "Равно";
            this.catEqual.UseVisualStyleBackColor = true;
            // 
            // catCount
            // 
            this.catCount.Location = new System.Drawing.Point(20, 26);
            this.catCount.Name = "catCount";
            this.catCount.Size = new System.Drawing.Size(211, 27);
            this.catCount.TabIndex = 0;
            // 
            // dogBox
            // 
            this.dogBox.Controls.Add(this.dogNotLess);
            this.dogBox.Controls.Add(this.dogNotMore);
            this.dogBox.Controls.Add(this.dogLess);
            this.dogBox.Controls.Add(this.dogMore);
            this.dogBox.Controls.Add(this.dogEqual);
            this.dogBox.Controls.Add(this.dogCount);
            this.dogBox.Enabled = false;
            this.dogBox.Location = new System.Drawing.Point(15, 73);
            this.dogBox.Name = "dogBox";
            this.dogBox.Size = new System.Drawing.Size(262, 221);
            this.dogBox.TabIndex = 1;
            this.dogBox.TabStop = false;
            this.dogBox.Text = "Количество отловленных собак";
            // 
            // dogNotLess
            // 
            this.dogNotLess.AutoSize = true;
            this.dogNotLess.Location = new System.Drawing.Point(20, 179);
            this.dogNotLess.Name = "dogNotLess";
            this.dogNotLess.Size = new System.Drawing.Size(97, 24);
            this.dogNotLess.TabIndex = 5;
            this.dogNotLess.TabStop = true;
            this.dogNotLess.Text = "Не менее";
            this.dogNotLess.UseVisualStyleBackColor = true;
            // 
            // dogNotMore
            // 
            this.dogNotMore.AutoSize = true;
            this.dogNotMore.Location = new System.Drawing.Point(20, 149);
            this.dogNotMore.Name = "dogNotMore";
            this.dogNotMore.Size = new System.Drawing.Size(95, 24);
            this.dogNotMore.TabIndex = 4;
            this.dogNotMore.TabStop = true;
            this.dogNotMore.Text = "Не более";
            this.dogNotMore.UseVisualStyleBackColor = true;
            // 
            // dogLess
            // 
            this.dogLess.AutoSize = true;
            this.dogLess.Location = new System.Drawing.Point(20, 119);
            this.dogLess.Name = "dogLess";
            this.dogLess.Size = new System.Drawing.Size(88, 24);
            this.dogLess.TabIndex = 3;
            this.dogLess.TabStop = true;
            this.dogLess.Text = "Меньше";
            this.dogLess.UseVisualStyleBackColor = true;
            // 
            // dogMore
            // 
            this.dogMore.AutoSize = true;
            this.dogMore.Location = new System.Drawing.Point(20, 89);
            this.dogMore.Name = "dogMore";
            this.dogMore.Size = new System.Drawing.Size(84, 24);
            this.dogMore.TabIndex = 2;
            this.dogMore.TabStop = true;
            this.dogMore.Text = "Больше";
            this.dogMore.UseVisualStyleBackColor = true;
            // 
            // dogEqual
            // 
            this.dogEqual.AutoSize = true;
            this.dogEqual.Location = new System.Drawing.Point(20, 59);
            this.dogEqual.Name = "dogEqual";
            this.dogEqual.Size = new System.Drawing.Size(72, 24);
            this.dogEqual.TabIndex = 1;
            this.dogEqual.TabStop = true;
            this.dogEqual.Text = "Равно";
            this.dogEqual.UseVisualStyleBackColor = true;
            // 
            // dogCount
            // 
            this.dogCount.Location = new System.Drawing.Point(20, 26);
            this.dogCount.Name = "dogCount";
            this.dogCount.Size = new System.Drawing.Size(211, 27);
            this.dogCount.TabIndex = 0;
            // 
            // goalBox
            // 
            this.goalBox.Controls.Add(this.goalTextBox);
            this.goalBox.Location = new System.Drawing.Point(21, 434);
            this.goalBox.Name = "goalBox";
            this.goalBox.Size = new System.Drawing.Size(606, 78);
            this.goalBox.TabIndex = 4;
            this.goalBox.TabStop = false;
            this.goalBox.Text = "По цели отлова";
            // 
            // goalTextBox
            // 
            this.goalTextBox.Location = new System.Drawing.Point(15, 35);
            this.goalTextBox.Name = "goalTextBox";
            this.goalTextBox.PlaceholderText = "Если окно ввода текста пустое, то фильтр не применяется";
            this.goalTextBox.Size = new System.Drawing.Size(572, 27);
            this.goalTextBox.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.toDateLabel);
            this.groupBox1.Controls.Add(this.toDate);
            this.groupBox1.Controls.Add(this.fromDateLabel);
            this.groupBox1.Controls.Add(this.fromDate);
            this.groupBox1.Location = new System.Drawing.Point(21, 529);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(606, 88);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "По дате отлова";
            // 
            // toDateLabel
            // 
            this.toDateLabel.AutoSize = true;
            this.toDateLabel.Location = new System.Drawing.Point(310, 42);
            this.toDateLabel.Name = "toDateLabel";
            this.toDateLabel.Size = new System.Drawing.Size(31, 20);
            this.toDateLabel.TabIndex = 3;
            this.toDateLabel.Text = "До:";
            // 
            // toDate
            // 
            this.toDate.Location = new System.Drawing.Point(345, 39);
            this.toDate.Name = "toDate";
            this.toDate.Size = new System.Drawing.Size(221, 27);
            this.toDate.TabIndex = 2;
            // 
            // fromDateLabel
            // 
            this.fromDateLabel.AutoSize = true;
            this.fromDateLabel.Location = new System.Drawing.Point(37, 42);
            this.fromDateLabel.Name = "fromDateLabel";
            this.fromDateLabel.Size = new System.Drawing.Size(29, 20);
            this.fromDateLabel.TabIndex = 1;
            this.fromDateLabel.Text = "От:";
            // 
            // fromDate
            // 
            this.fromDate.Location = new System.Drawing.Point(70, 39);
            this.fromDate.Name = "fromDate";
            this.fromDate.Size = new System.Drawing.Size(221, 27);
            this.fromDate.TabIndex = 0;
            // 
            // contractBox
            // 
            this.contractBox.Controls.Add(this.contractComboBox);
            this.contractBox.Location = new System.Drawing.Point(21, 633);
            this.contractBox.Name = "contractBox";
            this.contractBox.Size = new System.Drawing.Size(606, 72);
            this.contractBox.TabIndex = 6;
            this.contractBox.TabStop = false;
            this.contractBox.Text = "По муниципальному контракту";
            // 
            // contractComboBox
            // 
            this.contractComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.contractComboBox.FormattingEnabled = true;
            this.contractComboBox.Location = new System.Drawing.Point(16, 26);
            this.contractComboBox.Name = "contractComboBox";
            this.contractComboBox.Size = new System.Drawing.Size(571, 28);
            this.contractComboBox.TabIndex = 0;
            // 
            // applicationBox
            // 
            this.applicationBox.Controls.Add(this.appListLabel);
            this.applicationBox.Controls.Add(this.removeApplication);
            this.applicationBox.Controls.Add(this.addApplication);
            this.applicationBox.Controls.Add(this.appComboBox);
            this.applicationBox.Controls.Add(this.applications);
            this.applicationBox.Location = new System.Drawing.Point(21, 723);
            this.applicationBox.Name = "applicationBox";
            this.applicationBox.Size = new System.Drawing.Size(606, 165);
            this.applicationBox.TabIndex = 7;
            this.applicationBox.TabStop = false;
            this.applicationBox.Text = "По заявкам";
            // 
            // appListLabel
            // 
            this.appListLabel.AutoSize = true;
            this.appListLabel.Location = new System.Drawing.Point(190, 26);
            this.appListLabel.Name = "appListLabel";
            this.appListLabel.Size = new System.Drawing.Size(129, 20);
            this.appListLabel.TabIndex = 4;
            this.appListLabel.Text = "Перечень заявок";
            // 
            // removeApplication
            // 
            this.removeApplication.Location = new System.Drawing.Point(16, 121);
            this.removeApplication.Name = "removeApplication";
            this.removeApplication.Size = new System.Drawing.Size(149, 29);
            this.removeApplication.TabIndex = 3;
            this.removeApplication.Text = "Убрать заявку";
            this.removeApplication.UseVisualStyleBackColor = true;
            // 
            // addApplication
            // 
            this.addApplication.Location = new System.Drawing.Point(430, 83);
            this.addApplication.Name = "addApplication";
            this.addApplication.Size = new System.Drawing.Size(157, 29);
            this.addApplication.TabIndex = 2;
            this.addApplication.Text = "Добавить заявку";
            this.addApplication.UseVisualStyleBackColor = true;
            // 
            // appComboBox
            // 
            this.appComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.appComboBox.FormattingEnabled = true;
            this.appComboBox.Location = new System.Drawing.Point(190, 49);
            this.appComboBox.Name = "appComboBox";
            this.appComboBox.Size = new System.Drawing.Size(397, 28);
            this.appComboBox.TabIndex = 1;
            // 
            // applications
            // 
            this.applications.FormattingEnabled = true;
            this.applications.ItemHeight = 20;
            this.applications.Location = new System.Drawing.Point(15, 26);
            this.applications.Name = "applications";
            this.applications.Size = new System.Drawing.Size(150, 84);
            this.applications.TabIndex = 0;
            // 
            // apply
            // 
            this.apply.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(255)))), ((int)(((byte)(200)))));
            this.apply.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.apply.Location = new System.Drawing.Point(21, 905);
            this.apply.Name = "apply";
            this.apply.Size = new System.Drawing.Size(141, 29);
            this.apply.TabIndex = 8;
            this.apply.Text = "Применить";
            this.apply.UseVisualStyleBackColor = false;
            // 
            // reset
            // 
            this.reset.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(200)))));
            this.reset.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.reset.Location = new System.Drawing.Point(257, 905);
            this.reset.Name = "reset";
            this.reset.Size = new System.Drawing.Size(141, 29);
            this.reset.TabIndex = 9;
            this.reset.Text = "Сбросить";
            this.reset.UseVisualStyleBackColor = false;
            // 
            // close
            // 
            this.close.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.close.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.close.Location = new System.Drawing.Point(486, 905);
            this.close.Name = "close";
            this.close.Size = new System.Drawing.Size(141, 29);
            this.close.TabIndex = 10;
            this.close.Text = "Закрыть";
            this.close.UseVisualStyleBackColor = false;
            // 
            // ActFilter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(646, 946);
            this.Controls.Add(this.close);
            this.Controls.Add(this.reset);
            this.Controls.Add(this.apply);
            this.Controls.Add(this.applicationBox);
            this.Controls.Add(this.contractBox);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.goalBox);
            this.Controls.Add(this.animalBox);
            this.Controls.Add(this.orgBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "ActFilter";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Фильтры: Акты Отлова";
            this.orgBox.ResumeLayout(false);
            this.animalBox.ResumeLayout(false);
            this.animalBox.PerformLayout();
            this.catBox.ResumeLayout(false);
            this.catBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.catCount)).EndInit();
            this.dogBox.ResumeLayout(false);
            this.dogBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dogCount)).EndInit();
            this.goalBox.ResumeLayout(false);
            this.goalBox.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.contractBox.ResumeLayout(false);
            this.applicationBox.ResumeLayout(false);
            this.applicationBox.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private GroupBox orgBox;
        private ComboBox orgComboBox;
        private GroupBox animalBox;
        private GroupBox dogBox;
        private RadioButton dogNotLess;
        private RadioButton dogNotMore;
        private RadioButton dogLess;
        private RadioButton dogMore;
        private RadioButton dogEqual;
        private NumericUpDown dogCount;
        private GroupBox catBox;
        private RadioButton catNotLess;
        private RadioButton catNotMore;
        private RadioButton catLess;
        private RadioButton catMore;
        private RadioButton catEqual;
        private NumericUpDown catCount;
        private CheckBox enableDogFilter;
        private CheckBox enableCatFilter;
        private GroupBox goalBox;
        private TextBox goalTextBox;
        private GroupBox groupBox1;
        private Label fromDateLabel;
        private DateTimePicker fromDate;
        private Label toDateLabel;
        private DateTimePicker toDate;
        private GroupBox contractBox;
        private ComboBox contractComboBox;
        private GroupBox applicationBox;
        private Label appListLabel;
        private Button removeApplication;
        private Button addApplication;
        private ComboBox appComboBox;
        private ListBox applications;
        private Button apply;
        private Button reset;
        private Button close;
    }
}