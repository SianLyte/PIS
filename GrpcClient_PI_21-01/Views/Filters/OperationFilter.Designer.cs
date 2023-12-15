namespace GrpcClient_PI_21_01.Views.Filters
{
    partial class OperationFilter
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
            this.close = new System.Windows.Forms.Button();
            this.reset = new System.Windows.Forms.Button();
            this.apply = new System.Windows.Forms.Button();
            this.actorBox = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.name = new System.Windows.Forms.TextBox();
            this.surname = new System.Windows.Forms.TextBox();
            this.patronymic = new System.Windows.Forms.TextBox();
            this.patronymicLabel = new System.Windows.Forms.Label();
            this.surnameLabel = new System.Windows.Forms.Label();
            this.nameLabel = new System.Windows.Forms.Label();
            this.orgComboBox = new System.Windows.Forms.ComboBox();
            this.orgComboBoxLabel = new System.Windows.Forms.Label();
            this.privelegeLabel = new System.Windows.Forms.Label();
            this.privelegeComboBox = new System.Windows.Forms.ComboBox();
            this.login = new System.Windows.Forms.TextBox();
            this.loginLabel = new System.Windows.Forms.Label();
            this.dateBox = new System.Windows.Forms.GroupBox();
            this.fromDate = new System.Windows.Forms.DateTimePicker();
            this.toDate = new System.Windows.Forms.DateTimePicker();
            this.fromLabel = new System.Windows.Forms.Label();
            this.toLabel = new System.Windows.Forms.Label();
            this.idBox = new System.Windows.Forms.GroupBox();
            this.id = new System.Windows.Forms.NumericUpDown();
            this.idEqual = new System.Windows.Forms.RadioButton();
            this.idMore = new System.Windows.Forms.RadioButton();
            this.idLess = new System.Windows.Forms.RadioButton();
            this.typeBox = new System.Windows.Forms.GroupBox();
            this.actionAdd = new System.Windows.Forms.CheckBox();
            this.actionUpdate = new System.Windows.Forms.CheckBox();
            this.actionDelete = new System.Windows.Forms.CheckBox();
            this.tableBox = new System.Windows.Forms.GroupBox();
            this.tableComboBox = new System.Windows.Forms.ComboBox();
            this.actorBox.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.dateBox.SuspendLayout();
            this.idBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.id)).BeginInit();
            this.typeBox.SuspendLayout();
            this.tableBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // close
            // 
            this.close.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.close.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.close.Location = new System.Drawing.Point(495, 885);
            this.close.Name = "close";
            this.close.Size = new System.Drawing.Size(141, 29);
            this.close.TabIndex = 16;
            this.close.Text = "Закрыть";
            this.close.UseVisualStyleBackColor = false;
            // 
            // reset
            // 
            this.reset.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(200)))));
            this.reset.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.reset.Location = new System.Drawing.Point(253, 885);
            this.reset.Name = "reset";
            this.reset.Size = new System.Drawing.Size(141, 29);
            this.reset.TabIndex = 15;
            this.reset.Text = "Сбросить";
            this.reset.UseVisualStyleBackColor = false;
            // 
            // apply
            // 
            this.apply.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(255)))), ((int)(((byte)(200)))));
            this.apply.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.apply.Location = new System.Drawing.Point(12, 885);
            this.apply.Name = "apply";
            this.apply.Size = new System.Drawing.Size(141, 29);
            this.apply.TabIndex = 14;
            this.apply.Text = "Применить";
            this.apply.UseVisualStyleBackColor = false;
            // 
            // actorBox
            // 
            this.actorBox.Controls.Add(this.loginLabel);
            this.actorBox.Controls.Add(this.login);
            this.actorBox.Controls.Add(this.privelegeComboBox);
            this.actorBox.Controls.Add(this.privelegeLabel);
            this.actorBox.Controls.Add(this.orgComboBoxLabel);
            this.actorBox.Controls.Add(this.orgComboBox);
            this.actorBox.Controls.Add(this.groupBox2);
            this.actorBox.Location = new System.Drawing.Point(12, 12);
            this.actorBox.Name = "actorBox";
            this.actorBox.Size = new System.Drawing.Size(624, 450);
            this.actorBox.TabIndex = 17;
            this.actorBox.TabStop = false;
            this.actorBox.Text = "По исполнителю операции";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.nameLabel);
            this.groupBox2.Controls.Add(this.surnameLabel);
            this.groupBox2.Controls.Add(this.patronymicLabel);
            this.groupBox2.Controls.Add(this.patronymic);
            this.groupBox2.Controls.Add(this.surname);
            this.groupBox2.Controls.Add(this.name);
            this.groupBox2.Location = new System.Drawing.Point(17, 26);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(587, 184);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "По ФИО";
            // 
            // name
            // 
            this.name.Location = new System.Drawing.Point(98, 35);
            this.name.Name = "name";
            this.name.PlaceholderText = "Если окно пустое, то фильтр не применяется";
            this.name.Size = new System.Drawing.Size(468, 27);
            this.name.TabIndex = 0;
            // 
            // surname
            // 
            this.surname.Location = new System.Drawing.Point(98, 86);
            this.surname.Name = "surname";
            this.surname.PlaceholderText = "Если окно пустое, то фильтр не применяется";
            this.surname.Size = new System.Drawing.Size(468, 27);
            this.surname.TabIndex = 1;
            // 
            // patronymic
            // 
            this.patronymic.Location = new System.Drawing.Point(98, 135);
            this.patronymic.Name = "patronymic";
            this.patronymic.PlaceholderText = "Если окно пустое, то фильтр не применяется";
            this.patronymic.Size = new System.Drawing.Size(468, 27);
            this.patronymic.TabIndex = 2;
            // 
            // patronymicLabel
            // 
            this.patronymicLabel.AutoSize = true;
            this.patronymicLabel.Location = new System.Drawing.Point(6, 138);
            this.patronymicLabel.Name = "patronymicLabel";
            this.patronymicLabel.Size = new System.Drawing.Size(72, 20);
            this.patronymicLabel.TabIndex = 3;
            this.patronymicLabel.Text = "Отчество";
            // 
            // surnameLabel
            // 
            this.surnameLabel.AutoSize = true;
            this.surnameLabel.Location = new System.Drawing.Point(6, 89);
            this.surnameLabel.Name = "surnameLabel";
            this.surnameLabel.Size = new System.Drawing.Size(73, 20);
            this.surnameLabel.TabIndex = 4;
            this.surnameLabel.Text = "Фамилия";
            // 
            // nameLabel
            // 
            this.nameLabel.AutoSize = true;
            this.nameLabel.Location = new System.Drawing.Point(6, 38);
            this.nameLabel.Name = "nameLabel";
            this.nameLabel.Size = new System.Drawing.Size(39, 20);
            this.nameLabel.TabIndex = 5;
            this.nameLabel.Text = "Имя";
            // 
            // orgComboBox
            // 
            this.orgComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.orgComboBox.FormattingEnabled = true;
            this.orgComboBox.Location = new System.Drawing.Point(17, 244);
            this.orgComboBox.Name = "orgComboBox";
            this.orgComboBox.Size = new System.Drawing.Size(587, 28);
            this.orgComboBox.TabIndex = 1;
            // 
            // orgComboBoxLabel
            // 
            this.orgComboBoxLabel.AutoSize = true;
            this.orgComboBoxLabel.Location = new System.Drawing.Point(17, 221);
            this.orgComboBoxLabel.Name = "orgComboBoxLabel";
            this.orgComboBoxLabel.Size = new System.Drawing.Size(125, 20);
            this.orgComboBoxLabel.TabIndex = 2;
            this.orgComboBoxLabel.Text = "По организации";
            // 
            // privelegeLabel
            // 
            this.privelegeLabel.AutoSize = true;
            this.privelegeLabel.Location = new System.Drawing.Point(17, 301);
            this.privelegeLabel.Name = "privelegeLabel";
            this.privelegeLabel.Size = new System.Drawing.Size(109, 20);
            this.privelegeLabel.TabIndex = 3;
            this.privelegeLabel.Text = "По должности";
            // 
            // privelegeComboBox
            // 
            this.privelegeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.privelegeComboBox.FormattingEnabled = true;
            this.privelegeComboBox.Location = new System.Drawing.Point(17, 324);
            this.privelegeComboBox.Name = "privelegeComboBox";
            this.privelegeComboBox.Size = new System.Drawing.Size(587, 28);
            this.privelegeComboBox.TabIndex = 4;
            // 
            // login
            // 
            this.login.Location = new System.Drawing.Point(16, 402);
            this.login.Name = "login";
            this.login.PlaceholderText = "Если окно пустое, то фильтр не применяется";
            this.login.Size = new System.Drawing.Size(588, 27);
            this.login.TabIndex = 5;
            // 
            // loginLabel
            // 
            this.loginLabel.AutoSize = true;
            this.loginLabel.Location = new System.Drawing.Point(17, 379);
            this.loginLabel.Name = "loginLabel";
            this.loginLabel.Size = new System.Drawing.Size(81, 20);
            this.loginLabel.TabIndex = 6;
            this.loginLabel.Text = "По логину";
            // 
            // dateBox
            // 
            this.dateBox.Controls.Add(this.toLabel);
            this.dateBox.Controls.Add(this.fromLabel);
            this.dateBox.Controls.Add(this.toDate);
            this.dateBox.Controls.Add(this.fromDate);
            this.dateBox.Location = new System.Drawing.Point(12, 479);
            this.dateBox.Name = "dateBox";
            this.dateBox.Size = new System.Drawing.Size(624, 96);
            this.dateBox.TabIndex = 7;
            this.dateBox.TabStop = false;
            this.dateBox.Text = "По дате";
            // 
            // fromDate
            // 
            this.fromDate.CustomFormat = "dd/MM/yyyy HH:mm:ss";
            this.fromDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.fromDate.Location = new System.Drawing.Point(75, 40);
            this.fromDate.MinDate = new System.DateTime(2020, 1, 1, 0, 0, 0, 0);
            this.fromDate.Name = "fromDate";
            this.fromDate.Size = new System.Drawing.Size(193, 27);
            this.fromDate.TabIndex = 0;
            // 
            // toDate
            // 
            this.toDate.CustomFormat = "dd/MM/yyyy HH:mm:ss";
            this.toDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.toDate.Location = new System.Drawing.Point(380, 40);
            this.toDate.Name = "toDate";
            this.toDate.Size = new System.Drawing.Size(193, 27);
            this.toDate.TabIndex = 1;
            // 
            // fromLabel
            // 
            this.fromLabel.AutoSize = true;
            this.fromLabel.Location = new System.Drawing.Point(42, 43);
            this.fromLabel.Name = "fromLabel";
            this.fromLabel.Size = new System.Drawing.Size(26, 20);
            this.fromLabel.TabIndex = 2;
            this.fromLabel.Text = "От";
            // 
            // toLabel
            // 
            this.toLabel.AutoSize = true;
            this.toLabel.Location = new System.Drawing.Point(346, 43);
            this.toLabel.Name = "toLabel";
            this.toLabel.Size = new System.Drawing.Size(28, 20);
            this.toLabel.TabIndex = 3;
            this.toLabel.Text = "До";
            // 
            // idBox
            // 
            this.idBox.Controls.Add(this.idLess);
            this.idBox.Controls.Add(this.idMore);
            this.idBox.Controls.Add(this.idEqual);
            this.idBox.Controls.Add(this.id);
            this.idBox.Location = new System.Drawing.Point(12, 595);
            this.idBox.Name = "idBox";
            this.idBox.Size = new System.Drawing.Size(297, 172);
            this.idBox.TabIndex = 18;
            this.idBox.TabStop = false;
            this.idBox.Text = "По идентификационному номеру";
            // 
            // id
            // 
            this.id.Location = new System.Drawing.Point(23, 35);
            this.id.Maximum = new decimal(new int[] {
            10000000,
            0,
            0,
            0});
            this.id.Name = "id";
            this.id.Size = new System.Drawing.Size(245, 27);
            this.id.TabIndex = 0;
            // 
            // idEqual
            // 
            this.idEqual.AutoSize = true;
            this.idEqual.Location = new System.Drawing.Point(23, 68);
            this.idEqual.Name = "idEqual";
            this.idEqual.Size = new System.Drawing.Size(72, 24);
            this.idEqual.TabIndex = 1;
            this.idEqual.TabStop = true;
            this.idEqual.Tag = "Equals";
            this.idEqual.Text = "Равно";
            this.idEqual.UseVisualStyleBackColor = true;
            // 
            // idMore
            // 
            this.idMore.AutoSize = true;
            this.idMore.Location = new System.Drawing.Point(23, 98);
            this.idMore.Name = "idMore";
            this.idMore.Size = new System.Drawing.Size(84, 24);
            this.idMore.TabIndex = 2;
            this.idMore.TabStop = true;
            this.idMore.Tag = "GreaterThan";
            this.idMore.Text = "Больше";
            this.idMore.UseVisualStyleBackColor = true;
            // 
            // idLess
            // 
            this.idLess.AutoSize = true;
            this.idLess.Location = new System.Drawing.Point(23, 128);
            this.idLess.Name = "idLess";
            this.idLess.Size = new System.Drawing.Size(88, 24);
            this.idLess.TabIndex = 3;
            this.idLess.TabStop = true;
            this.idLess.Tag = "LesserThan";
            this.idLess.Text = "Меньше";
            this.idLess.UseVisualStyleBackColor = true;
            // 
            // typeBox
            // 
            this.typeBox.Controls.Add(this.actionDelete);
            this.typeBox.Controls.Add(this.actionUpdate);
            this.typeBox.Controls.Add(this.actionAdd);
            this.typeBox.Location = new System.Drawing.Point(335, 595);
            this.typeBox.Name = "typeBox";
            this.typeBox.Size = new System.Drawing.Size(301, 172);
            this.typeBox.TabIndex = 19;
            this.typeBox.TabStop = false;
            this.typeBox.Text = "По типу операции";
            // 
            // actionAdd
            // 
            this.actionAdd.AutoSize = true;
            this.actionAdd.Location = new System.Drawing.Point(23, 39);
            this.actionAdd.Name = "actionAdd";
            this.actionAdd.Size = new System.Drawing.Size(191, 24);
            this.actionAdd.TabIndex = 0;
            this.actionAdd.Text = "Операции добавления";
            this.actionAdd.UseVisualStyleBackColor = true;
            // 
            // actionUpdate
            // 
            this.actionUpdate.AutoSize = true;
            this.actionUpdate.Location = new System.Drawing.Point(23, 69);
            this.actionUpdate.Name = "actionUpdate";
            this.actionUpdate.Size = new System.Drawing.Size(193, 24);
            this.actionUpdate.TabIndex = 1;
            this.actionUpdate.Text = "Операции обновления";
            this.actionUpdate.UseVisualStyleBackColor = true;
            // 
            // actionDelete
            // 
            this.actionDelete.AutoSize = true;
            this.actionDelete.Location = new System.Drawing.Point(23, 99);
            this.actionDelete.Name = "actionDelete";
            this.actionDelete.Size = new System.Drawing.Size(172, 24);
            this.actionDelete.TabIndex = 2;
            this.actionDelete.Text = "Операции удаления";
            this.actionDelete.UseVisualStyleBackColor = true;
            // 
            // tableBox
            // 
            this.tableBox.Controls.Add(this.tableComboBox);
            this.tableBox.Location = new System.Drawing.Point(12, 784);
            this.tableBox.Name = "tableBox";
            this.tableBox.Size = new System.Drawing.Size(626, 79);
            this.tableBox.TabIndex = 20;
            this.tableBox.TabStop = false;
            this.tableBox.Text = "По таблице операции";
            // 
            // tableComboBox
            // 
            this.tableComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.tableComboBox.FormattingEnabled = true;
            this.tableComboBox.Location = new System.Drawing.Point(17, 35);
            this.tableComboBox.Name = "tableComboBox";
            this.tableComboBox.Size = new System.Drawing.Size(587, 28);
            this.tableComboBox.TabIndex = 0;
            // 
            // OperationFilter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(648, 926);
            this.Controls.Add(this.tableBox);
            this.Controls.Add(this.typeBox);
            this.Controls.Add(this.idBox);
            this.Controls.Add(this.dateBox);
            this.Controls.Add(this.actorBox);
            this.Controls.Add(this.close);
            this.Controls.Add(this.reset);
            this.Controls.Add(this.apply);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "OperationFilter";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Фильтры: Журнал операций";
            this.actorBox.ResumeLayout(false);
            this.actorBox.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.dateBox.ResumeLayout(false);
            this.dateBox.PerformLayout();
            this.idBox.ResumeLayout(false);
            this.idBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.id)).EndInit();
            this.typeBox.ResumeLayout(false);
            this.typeBox.PerformLayout();
            this.tableBox.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Button close;
        private Button reset;
        private Button apply;
        private GroupBox actorBox;
        private GroupBox groupBox2;
        private Label nameLabel;
        private Label surnameLabel;
        private Label patronymicLabel;
        private TextBox patronymic;
        private TextBox surname;
        private TextBox name;
        private Label orgComboBoxLabel;
        private ComboBox orgComboBox;
        private ComboBox privelegeComboBox;
        private Label privelegeLabel;
        private TextBox login;
        private Label loginLabel;
        private GroupBox dateBox;
        private DateTimePicker toDate;
        private DateTimePicker fromDate;
        private Label toLabel;
        private Label fromLabel;
        private GroupBox idBox;
        private RadioButton idEqual;
        private NumericUpDown id;
        private RadioButton idMore;
        private RadioButton idLess;
        private GroupBox typeBox;
        private CheckBox actionAdd;
        private CheckBox actionDelete;
        private CheckBox actionUpdate;
        private GroupBox tableBox;
        private ComboBox tableComboBox;
    }
}