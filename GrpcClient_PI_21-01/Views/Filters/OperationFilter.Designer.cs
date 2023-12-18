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
            close=new Button();
            reset=new Button();
            apply=new Button();
            actorBox=new GroupBox();
            loginLabel=new Label();
            login=new TextBox();
            privelegeComboBox=new ComboBox();
            privelegeLabel=new Label();
            orgComboBoxLabel=new Label();
            orgComboBox=new ComboBox();
            groupBox2=new GroupBox();
            nameLabel=new Label();
            surnameLabel=new Label();
            patronymicLabel=new Label();
            patronymic=new TextBox();
            surname=new TextBox();
            name=new TextBox();
            dateBox=new GroupBox();
            toLabel=new Label();
            fromLabel=new Label();
            toDate=new DateTimePicker();
            fromDate=new DateTimePicker();
            idBox=new GroupBox();
            idLess=new RadioButton();
            idMore=new RadioButton();
            idEqual=new RadioButton();
            id=new NumericUpDown();
            typeBox=new GroupBox();
            actionDelete=new CheckBox();
            actionUpdate=new CheckBox();
            actionAdd=new CheckBox();
            tableBox=new GroupBox();
            tableComboBox=new ComboBox();
            actorBox.SuspendLayout();
            groupBox2.SuspendLayout();
            dateBox.SuspendLayout();
            idBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)id).BeginInit();
            typeBox.SuspendLayout();
            tableBox.SuspendLayout();
            SuspendLayout();
            // 
            // close
            // 
            close.BackColor=Color.Wheat;
            close.FlatStyle=FlatStyle.Flat;
            close.Font=new Font("Segoe Print", 10F, FontStyle.Bold, GraphicsUnit.Point);
            close.Location=new Point(561, 926);
            close.Name="close";
            close.Size=new Size(141, 37);
            close.TabIndex=16;
            close.Text="Закрыть";
            close.UseVisualStyleBackColor=false;
            // 
            // reset
            // 
            reset.BackColor=Color.Wheat;
            reset.FlatStyle=FlatStyle.Flat;
            reset.Font=new Font("Segoe Print", 10F, FontStyle.Bold, GraphicsUnit.Point);
            reset.Location=new Point(280, 926);
            reset.Name="reset";
            reset.Size=new Size(141, 37);
            reset.TabIndex=15;
            reset.Text="Сбросить";
            reset.UseVisualStyleBackColor=false;
            // 
            // apply
            // 
            apply.BackColor=Color.Wheat;
            apply.FlatStyle=FlatStyle.Flat;
            apply.Font=new Font("Segoe Print", 10F, FontStyle.Bold, GraphicsUnit.Point);
            apply.Location=new Point(14, 926);
            apply.Name="apply";
            apply.Size=new Size(141, 37);
            apply.TabIndex=14;
            apply.Text="Применить";
            apply.UseVisualStyleBackColor=false;
            // 
            // actorBox
            // 
            actorBox.BackColor=Color.Wheat;
            actorBox.Controls.Add(loginLabel);
            actorBox.Controls.Add(login);
            actorBox.Controls.Add(privelegeComboBox);
            actorBox.Controls.Add(privelegeLabel);
            actorBox.Controls.Add(orgComboBoxLabel);
            actorBox.Controls.Add(orgComboBox);
            actorBox.Controls.Add(groupBox2);
            actorBox.Font=new Font("Segoe Print", 10F, FontStyle.Bold, GraphicsUnit.Point);
            actorBox.Location=new Point(12, 12);
            actorBox.Name="actorBox";
            actorBox.Size=new Size(690, 474);
            actorBox.TabIndex=17;
            actorBox.TabStop=false;
            actorBox.Text="По исполнителю операции";
            // 
            // loginLabel
            // 
            loginLabel.AutoSize=true;
            loginLabel.Font=new Font("Segoe Print", 10F, FontStyle.Bold, GraphicsUnit.Point);
            loginLabel.Location=new Point(16, 386);
            loginLabel.Name="loginLabel";
            loginLabel.Size=new Size(101, 30);
            loginLabel.TabIndex=6;
            loginLabel.Text="По логину";
            // 
            // login
            // 
            login.BackColor=Color.OldLace;
            login.Font=new Font("Segoe Print", 10F, FontStyle.Bold, GraphicsUnit.Point);
            login.Location=new Point(16, 419);
            login.Name="login";
            login.PlaceholderText="Если окно пустое, то фильтр не применяется";
            login.Size=new Size(668, 37);
            login.TabIndex=5;
            // 
            // privelegeComboBox
            // 
            privelegeComboBox.BackColor=Color.OldLace;
            privelegeComboBox.DropDownStyle=ComboBoxStyle.DropDownList;
            privelegeComboBox.FlatStyle=FlatStyle.Popup;
            privelegeComboBox.Font=new Font("Segoe Print", 10F, FontStyle.Bold, GraphicsUnit.Point);
            privelegeComboBox.FormattingEnabled=true;
            privelegeComboBox.Location=new Point(17, 333);
            privelegeComboBox.Name="privelegeComboBox";
            privelegeComboBox.Size=new Size(667, 38);
            privelegeComboBox.TabIndex=4;
            // 
            // privelegeLabel
            // 
            privelegeLabel.AutoSize=true;
            privelegeLabel.Font=new Font("Segoe Print", 10F, FontStyle.Bold, GraphicsUnit.Point);
            privelegeLabel.Location=new Point(16, 300);
            privelegeLabel.Name="privelegeLabel";
            privelegeLabel.Size=new Size(143, 30);
            privelegeLabel.TabIndex=3;
            privelegeLabel.Text="По должности";
            // 
            // orgComboBoxLabel
            // 
            orgComboBoxLabel.AutoSize=true;
            orgComboBoxLabel.Font=new Font("Segoe Print", 10F, FontStyle.Bold, GraphicsUnit.Point);
            orgComboBoxLabel.Location=new Point(16, 213);
            orgComboBoxLabel.Name="orgComboBoxLabel";
            orgComboBoxLabel.Size=new Size(150, 30);
            orgComboBoxLabel.TabIndex=2;
            orgComboBoxLabel.Text="По организации";
            // 
            // orgComboBox
            // 
            orgComboBox.BackColor=Color.OldLace;
            orgComboBox.DropDownStyle=ComboBoxStyle.DropDownList;
            orgComboBox.FlatStyle=FlatStyle.Popup;
            orgComboBox.Font=new Font("Segoe Print", 10F, FontStyle.Bold, GraphicsUnit.Point);
            orgComboBox.FormattingEnabled=true;
            orgComboBox.Location=new Point(16, 246);
            orgComboBox.Name="orgComboBox";
            orgComboBox.Size=new Size(667, 38);
            orgComboBox.TabIndex=1;
            // 
            // groupBox2
            // 
            groupBox2.BackColor=Color.Wheat;
            groupBox2.Controls.Add(nameLabel);
            groupBox2.Controls.Add(surnameLabel);
            groupBox2.Controls.Add(patronymicLabel);
            groupBox2.Controls.Add(patronymic);
            groupBox2.Controls.Add(surname);
            groupBox2.Controls.Add(name);
            groupBox2.Font=new Font("Segoe Print", 10F, FontStyle.Bold, GraphicsUnit.Point);
            groupBox2.Location=new Point(17, 26);
            groupBox2.Name="groupBox2";
            groupBox2.Size=new Size(667, 184);
            groupBox2.TabIndex=0;
            groupBox2.TabStop=false;
            groupBox2.Text="По ФИО";
            // 
            // nameLabel
            // 
            nameLabel.AutoSize=true;
            nameLabel.Font=new Font("Segoe Print", 10F, FontStyle.Bold, GraphicsUnit.Point);
            nameLabel.Location=new Point(6, 38);
            nameLabel.Name="nameLabel";
            nameLabel.Size=new Size(53, 30);
            nameLabel.TabIndex=5;
            nameLabel.Text="Имя";
            // 
            // surnameLabel
            // 
            surnameLabel.AutoSize=true;
            surnameLabel.Font=new Font("Segoe Print", 10F, FontStyle.Bold, GraphicsUnit.Point);
            surnameLabel.Location=new Point(6, 89);
            surnameLabel.Name="surnameLabel";
            surnameLabel.Size=new Size(92, 30);
            surnameLabel.TabIndex=4;
            surnameLabel.Text="Фамилия";
            // 
            // patronymicLabel
            // 
            patronymicLabel.AutoSize=true;
            patronymicLabel.Font=new Font("Segoe Print", 10F, FontStyle.Bold, GraphicsUnit.Point);
            patronymicLabel.Location=new Point(6, 138);
            patronymicLabel.Name="patronymicLabel";
            patronymicLabel.Size=new Size(108, 30);
            patronymicLabel.TabIndex=3;
            patronymicLabel.Text="Отчество";
            // 
            // patronymic
            // 
            patronymic.BackColor=Color.OldLace;
            patronymic.Font=new Font("Segoe Print", 10F, FontStyle.Bold, GraphicsUnit.Point);
            patronymic.Location=new Point(120, 135);
            patronymic.Name="patronymic";
            patronymic.PlaceholderText="Если окно пустое, то фильтр не применяется";
            patronymic.Size=new Size(541, 37);
            patronymic.TabIndex=2;
            // 
            // surname
            // 
            surname.BackColor=Color.OldLace;
            surname.Font=new Font("Segoe Print", 10F, FontStyle.Bold, GraphicsUnit.Point);
            surname.Location=new Point(120, 86);
            surname.Name="surname";
            surname.PlaceholderText="Если окно пустое, то фильтр не применяется";
            surname.Size=new Size(541, 37);
            surname.TabIndex=1;
            // 
            // name
            // 
            name.BackColor=Color.OldLace;
            name.Font=new Font("Segoe Print", 10F, FontStyle.Bold, GraphicsUnit.Point);
            name.Location=new Point(120, 35);
            name.Name="name";
            name.PlaceholderText="Если окно пустое, то фильтр не применяется";
            name.Size=new Size(541, 37);
            name.TabIndex=0;
            // 
            // dateBox
            // 
            dateBox.BackColor=Color.Wheat;
            dateBox.Controls.Add(toLabel);
            dateBox.Controls.Add(fromLabel);
            dateBox.Controls.Add(toDate);
            dateBox.Controls.Add(fromDate);
            dateBox.Font=new Font("Segoe Print", 10F, FontStyle.Bold, GraphicsUnit.Point);
            dateBox.Location=new Point(12, 504);
            dateBox.Name="dateBox";
            dateBox.Size=new Size(690, 96);
            dateBox.TabIndex=7;
            dateBox.TabStop=false;
            dateBox.Text="По дате";
            // 
            // toLabel
            // 
            toLabel.AutoSize=true;
            toLabel.Font=new Font("Segoe Print", 10F, FontStyle.Bold, GraphicsUnit.Point);
            toLabel.Location=new Point(346, 45);
            toLabel.Name="toLabel";
            toLabel.Size=new Size(39, 30);
            toLabel.TabIndex=3;
            toLabel.Text="До";
            // 
            // fromLabel
            // 
            fromLabel.AutoSize=true;
            fromLabel.Font=new Font("Segoe Print", 10F, FontStyle.Bold, GraphicsUnit.Point);
            fromLabel.Location=new Point(6, 45);
            fromLabel.Name="fromLabel";
            fromLabel.Size=new Size(45, 30);
            fromLabel.TabIndex=2;
            fromLabel.Text="От";
            // 
            // toDate
            // 
            toDate.CalendarMonthBackground=Color.OldLace;
            toDate.CustomFormat="dd/MM/yyyy";
            toDate.Font=new Font("Segoe Print", 10F, FontStyle.Bold, GraphicsUnit.Point);
            toDate.Format=DateTimePickerFormat.Custom;
            toDate.Location=new Point(391, 40);
            toDate.Name="toDate";
            toDate.Size=new Size(287, 37);
            toDate.TabIndex=1;
            // 
            // fromDate
            // 
            fromDate.CalendarMonthBackground=Color.OldLace;
            fromDate.CustomFormat="dd/MM/yyyy";
            fromDate.Font=new Font("Segoe Print", 10F, FontStyle.Bold, GraphicsUnit.Point);
            fromDate.Format=DateTimePickerFormat.Custom;
            fromDate.Location=new Point(57, 40);
            fromDate.MinDate=new DateTime(2020, 1, 1, 0, 0, 0, 0);
            fromDate.Name="fromDate";
            fromDate.Size=new Size(274, 37);
            fromDate.TabIndex=0;
            // 
            // idBox
            // 
            idBox.BackColor=Color.Wheat;
            idBox.Controls.Add(idLess);
            idBox.Controls.Add(idMore);
            idBox.Controls.Add(idEqual);
            idBox.Controls.Add(id);
            idBox.Font=new Font("Segoe Print", 10F, FontStyle.Bold, GraphicsUnit.Point);
            idBox.Location=new Point(14, 612);
            idBox.Name="idBox";
            idBox.Size=new Size(331, 193);
            idBox.TabIndex=18;
            idBox.TabStop=false;
            idBox.Text="По идентификационному номеру";
            // 
            // idLess
            // 
            idLess.AutoSize=true;
            idLess.Font=new Font("Segoe Print", 10F, FontStyle.Bold, GraphicsUnit.Point);
            idLess.Location=new Point(21, 153);
            idLess.Name="idLess";
            idLess.Size=new Size(103, 34);
            idLess.TabIndex=3;
            idLess.TabStop=true;
            idLess.Tag="LesserThan";
            idLess.Text="Меньше";
            idLess.UseVisualStyleBackColor=true;
            // 
            // idMore
            // 
            idMore.AutoSize=true;
            idMore.Font=new Font("Segoe Print", 10F, FontStyle.Bold, GraphicsUnit.Point);
            idMore.Location=new Point(21, 113);
            idMore.Name="idMore";
            idMore.Size=new Size(99, 34);
            idMore.TabIndex=2;
            idMore.TabStop=true;
            idMore.Tag="GreaterThan";
            idMore.Text="Больше";
            idMore.UseVisualStyleBackColor=true;
            // 
            // idEqual
            // 
            idEqual.AutoSize=true;
            idEqual.Font=new Font("Segoe Print", 10F, FontStyle.Bold, GraphicsUnit.Point);
            idEqual.Location=new Point(21, 78);
            idEqual.Name="idEqual";
            idEqual.Size=new Size(85, 34);
            idEqual.TabIndex=1;
            idEqual.TabStop=true;
            idEqual.Tag="Equals";
            idEqual.Text="Равно";
            idEqual.UseVisualStyleBackColor=true;
            // 
            // id
            // 
            id.BackColor=Color.OldLace;
            id.Font=new Font("Segoe Print", 10F, FontStyle.Bold, GraphicsUnit.Point);
            id.Location=new Point(21, 35);
            id.Maximum=new decimal(new int[] { 10000000, 0, 0, 0 });
            id.Name="id";
            id.Size=new Size(245, 37);
            id.TabIndex=0;
            // 
            // typeBox
            // 
            typeBox.BackColor=Color.Wheat;
            typeBox.Controls.Add(actionDelete);
            typeBox.Controls.Add(actionUpdate);
            typeBox.Controls.Add(actionAdd);
            typeBox.Font=new Font("Segoe Print", 10F, FontStyle.Bold, GraphicsUnit.Point);
            typeBox.Location=new Point(358, 612);
            typeBox.Name="typeBox";
            typeBox.Size=new Size(344, 193);
            typeBox.TabIndex=19;
            typeBox.TabStop=false;
            typeBox.Text="По типу операции";
            // 
            // actionDelete
            // 
            actionDelete.AutoSize=true;
            actionDelete.Font=new Font("Segoe Print", 10F, FontStyle.Bold, GraphicsUnit.Point);
            actionDelete.Location=new Point(22, 116);
            actionDelete.Name="actionDelete";
            actionDelete.Size=new Size(205, 34);
            actionDelete.TabIndex=2;
            actionDelete.Text="Операции удаления";
            actionDelete.UseVisualStyleBackColor=true;
            // 
            // actionUpdate
            // 
            actionUpdate.AutoSize=true;
            actionUpdate.Font=new Font("Segoe Print", 10F, FontStyle.Bold, GraphicsUnit.Point);
            actionUpdate.Location=new Point(21, 76);
            actionUpdate.Name="actionUpdate";
            actionUpdate.Size=new Size(224, 34);
            actionUpdate.TabIndex=1;
            actionUpdate.Text="Операции обновления";
            actionUpdate.UseVisualStyleBackColor=true;
            // 
            // actionAdd
            // 
            actionAdd.AutoSize=true;
            actionAdd.Font=new Font("Segoe Print", 10F, FontStyle.Bold, GraphicsUnit.Point);
            actionAdd.Location=new Point(22, 36);
            actionAdd.Name="actionAdd";
            actionAdd.Size=new Size(223, 34);
            actionAdd.TabIndex=0;
            actionAdd.Text="Операции добавления";
            actionAdd.UseVisualStyleBackColor=true;
            // 
            // tableBox
            // 
            tableBox.BackColor=Color.Wheat;
            tableBox.Controls.Add(tableComboBox);
            tableBox.Font=new Font("Segoe Print", 10F, FontStyle.Bold, GraphicsUnit.Point);
            tableBox.Location=new Point(12, 819);
            tableBox.Name="tableBox";
            tableBox.Size=new Size(690, 92);
            tableBox.TabIndex=20;
            tableBox.TabStop=false;
            tableBox.Text="По таблице операции";
            // 
            // tableComboBox
            // 
            tableComboBox.BackColor=Color.OldLace;
            tableComboBox.DropDownStyle=ComboBoxStyle.DropDownList;
            tableComboBox.FlatStyle=FlatStyle.Popup;
            tableComboBox.Font=new Font("Segoe Print", 10F, FontStyle.Bold, GraphicsUnit.Point);
            tableComboBox.FormattingEnabled=true;
            tableComboBox.Location=new Point(17, 35);
            tableComboBox.Name="tableComboBox";
            tableComboBox.Size=new Size(661, 38);
            tableComboBox.TabIndex=0;
            // 
            // OperationFilter
            // 
            AutoScaleDimensions=new SizeF(8F, 20F);
            AutoScaleMode=AutoScaleMode.Font;
            BackColor=Color.Tan;
            ClientSize=new Size(714, 975);
            Controls.Add(tableBox);
            Controls.Add(typeBox);
            Controls.Add(idBox);
            Controls.Add(dateBox);
            Controls.Add(actorBox);
            Controls.Add(close);
            Controls.Add(reset);
            Controls.Add(apply);
            Cursor=Cursors.PanNW;
            FormBorderStyle=FormBorderStyle.FixedSingle;
            MaximizeBox=false;
            Name="OperationFilter";
            ShowIcon=false;
            StartPosition=FormStartPosition.CenterParent;
            Text="Фильтры: Журнал операций";
            actorBox.ResumeLayout(false);
            actorBox.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            dateBox.ResumeLayout(false);
            dateBox.PerformLayout();
            idBox.ResumeLayout(false);
            idBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)id).EndInit();
            typeBox.ResumeLayout(false);
            typeBox.PerformLayout();
            tableBox.ResumeLayout(false);
            ResumeLayout(false);
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