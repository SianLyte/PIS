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
            orgBox=new GroupBox();
            orgComboBox=new ComboBox();
            animalBox=new GroupBox();
            enableCatFilter=new CheckBox();
            enableDogFilter=new CheckBox();
            catBox=new GroupBox();
            catNotLess=new RadioButton();
            catNotMore=new RadioButton();
            catLess=new RadioButton();
            catMore=new RadioButton();
            catEqual=new RadioButton();
            catCount=new NumericUpDown();
            dogBox=new GroupBox();
            dogNotLess=new RadioButton();
            dogNotMore=new RadioButton();
            dogLess=new RadioButton();
            dogMore=new RadioButton();
            dogEqual=new RadioButton();
            dogCount=new NumericUpDown();
            goalBox=new GroupBox();
            goalTextBox=new TextBox();
            groupBox1=new GroupBox();
            toDateLabel=new Label();
            toDate=new DateTimePicker();
            fromDateLabel=new Label();
            fromDate=new DateTimePicker();
            contractBox=new GroupBox();
            contractComboBox=new ComboBox();
            applicationBox=new GroupBox();
            addApplication=new Button();
            appListLabel=new Label();
            removeApplication=new Button();
            appComboBox=new ComboBox();
            applications=new ListBox();
            apply=new Button();
            reset=new Button();
            close=new Button();
            orgBox.SuspendLayout();
            animalBox.SuspendLayout();
            catBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)catCount).BeginInit();
            dogBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dogCount).BeginInit();
            goalBox.SuspendLayout();
            groupBox1.SuspendLayout();
            contractBox.SuspendLayout();
            applicationBox.SuspendLayout();
            SuspendLayout();
            // 
            // orgBox
            // 
            orgBox.BackColor=Color.Wheat;
            orgBox.Controls.Add(orgComboBox);
            orgBox.Font=new Font("Segoe Print", 10F, FontStyle.Bold, GraphicsUnit.Point);
            orgBox.Location=new Point(21, 12);
            orgBox.Name="orgBox";
            orgBox.Size=new Size(753, 77);
            orgBox.TabIndex=2;
            orgBox.TabStop=false;
            orgBox.Text="По организации";
            // 
            // orgComboBox
            // 
            orgComboBox.BackColor=Color.OldLace;
            orgComboBox.Cursor=Cursors.PanNW;
            orgComboBox.DropDownStyle=ComboBoxStyle.DropDownList;
            orgComboBox.FlatStyle=FlatStyle.Popup;
            orgComboBox.Font=new Font("Segoe Print", 10F, FontStyle.Bold, GraphicsUnit.Point);
            orgComboBox.FormattingEnabled=true;
            orgComboBox.Location=new Point(15, 26);
            orgComboBox.Name="orgComboBox";
            orgComboBox.Size=new Size(729, 38);
            orgComboBox.TabIndex=0;
            // 
            // animalBox
            // 
            animalBox.BackColor=Color.Wheat;
            animalBox.Controls.Add(enableCatFilter);
            animalBox.Controls.Add(enableDogFilter);
            animalBox.Controls.Add(catBox);
            animalBox.Controls.Add(dogBox);
            animalBox.Font=new Font("Segoe Print", 10F, FontStyle.Bold, GraphicsUnit.Point);
            animalBox.Location=new Point(21, 103);
            animalBox.Name="animalBox";
            animalBox.Size=new Size(753, 312);
            animalBox.TabIndex=3;
            animalBox.TabStop=false;
            animalBox.Text="По количеству отловленных животных";
            // 
            // enableCatFilter
            // 
            enableCatFilter.AutoSize=true;
            enableCatFilter.Font=new Font("Segoe Print", 10F, FontStyle.Bold, GraphicsUnit.Point);
            enableCatFilter.Location=new Point(399, 43);
            enableCatFilter.Name="enableCatFilter";
            enableCatFilter.Size=new Size(207, 34);
            enableCatFilter.TabIndex=7;
            enableCatFilter.Text="Включить фильтр";
            enableCatFilter.UseVisualStyleBackColor=true;
            // 
            // enableDogFilter
            // 
            enableDogFilter.AutoSize=true;
            enableDogFilter.Font=new Font("Segoe Print", 10F, FontStyle.Bold, GraphicsUnit.Point);
            enableDogFilter.Location=new Point(16, 43);
            enableDogFilter.Name="enableDogFilter";
            enableDogFilter.Size=new Size(207, 34);
            enableDogFilter.TabIndex=4;
            enableDogFilter.Text="Включить фильтр";
            enableDogFilter.UseVisualStyleBackColor=true;
            // 
            // catBox
            // 
            catBox.BackColor=Color.Wheat;
            catBox.Controls.Add(catNotLess);
            catBox.Controls.Add(catNotMore);
            catBox.Controls.Add(catLess);
            catBox.Controls.Add(catMore);
            catBox.Controls.Add(catEqual);
            catBox.Controls.Add(catCount);
            catBox.Enabled=false;
            catBox.Font=new Font("Segoe Print", 10F, FontStyle.Bold, GraphicsUnit.Point);
            catBox.Location=new Point(399, 73);
            catBox.Name="catBox";
            catBox.Size=new Size(345, 233);
            catBox.TabIndex=6;
            catBox.TabStop=false;
            catBox.Text="Количество отловленных кошек";
            // 
            // catNotLess
            // 
            catNotLess.AutoSize=true;
            catNotLess.Font=new Font("Segoe Print", 10F, FontStyle.Bold, GraphicsUnit.Point);
            catNotLess.Location=new Point(20, 197);
            catNotLess.Name="catNotLess";
            catNotLess.Size=new Size(116, 34);
            catNotLess.TabIndex=5;
            catNotLess.TabStop=true;
            catNotLess.Text="Не менее";
            catNotLess.UseVisualStyleBackColor=true;
            // 
            // catNotMore
            // 
            catNotMore.AutoSize=true;
            catNotMore.Font=new Font("Segoe Print", 10F, FontStyle.Bold, GraphicsUnit.Point);
            catNotMore.Location=new Point(20, 167);
            catNotMore.Name="catNotMore";
            catNotMore.Size=new Size(111, 34);
            catNotMore.TabIndex=4;
            catNotMore.TabStop=true;
            catNotMore.Text="Не более";
            catNotMore.UseVisualStyleBackColor=true;
            // 
            // catLess
            // 
            catLess.AutoSize=true;
            catLess.Font=new Font("Segoe Print", 10F, FontStyle.Bold, GraphicsUnit.Point);
            catLess.Location=new Point(20, 137);
            catLess.Name="catLess";
            catLess.Size=new Size(103, 34);
            catLess.TabIndex=3;
            catLess.TabStop=true;
            catLess.Text="Меньше";
            catLess.UseVisualStyleBackColor=true;
            // 
            // catMore
            // 
            catMore.AutoSize=true;
            catMore.Font=new Font("Segoe Print", 10F, FontStyle.Bold, GraphicsUnit.Point);
            catMore.Location=new Point(20, 107);
            catMore.Name="catMore";
            catMore.Size=new Size(99, 34);
            catMore.TabIndex=2;
            catMore.TabStop=true;
            catMore.Text="Больше";
            catMore.UseVisualStyleBackColor=true;
            // 
            // catEqual
            // 
            catEqual.AutoSize=true;
            catEqual.Font=new Font("Segoe Print", 10F, FontStyle.Bold, GraphicsUnit.Point);
            catEqual.Location=new Point(20, 77);
            catEqual.Name="catEqual";
            catEqual.Size=new Size(85, 34);
            catEqual.TabIndex=1;
            catEqual.TabStop=true;
            catEqual.Text="Равно";
            catEqual.UseVisualStyleBackColor=true;
            // 
            // catCount
            // 
            catCount.BackColor=Color.OldLace;
            catCount.Font=new Font("Segoe Print", 10F, FontStyle.Bold, GraphicsUnit.Point);
            catCount.Location=new Point(20, 36);
            catCount.Name="catCount";
            catCount.Size=new Size(211, 37);
            catCount.TabIndex=0;
            // 
            // dogBox
            // 
            dogBox.BackColor=Color.Wheat;
            dogBox.Controls.Add(dogNotLess);
            dogBox.Controls.Add(dogNotMore);
            dogBox.Controls.Add(dogLess);
            dogBox.Controls.Add(dogMore);
            dogBox.Controls.Add(dogEqual);
            dogBox.Controls.Add(dogCount);
            dogBox.Enabled=false;
            dogBox.Font=new Font("Segoe Print", 10F, FontStyle.Bold, GraphicsUnit.Point);
            dogBox.Location=new Point(6, 73);
            dogBox.Name="dogBox";
            dogBox.Size=new Size(345, 231);
            dogBox.TabIndex=1;
            dogBox.TabStop=false;
            dogBox.Text="Количество отловленных собак";
            // 
            // dogNotLess
            // 
            dogNotLess.AutoSize=true;
            dogNotLess.Font=new Font("Segoe Print", 10F, FontStyle.Bold, GraphicsUnit.Point);
            dogNotLess.Location=new Point(20, 199);
            dogNotLess.Name="dogNotLess";
            dogNotLess.Size=new Size(116, 34);
            dogNotLess.TabIndex=5;
            dogNotLess.TabStop=true;
            dogNotLess.Text="Не менее";
            dogNotLess.UseVisualStyleBackColor=true;
            // 
            // dogNotMore
            // 
            dogNotMore.AutoSize=true;
            dogNotMore.Font=new Font("Segoe Print", 10F, FontStyle.Bold, GraphicsUnit.Point);
            dogNotMore.Location=new Point(20, 169);
            dogNotMore.Name="dogNotMore";
            dogNotMore.Size=new Size(111, 34);
            dogNotMore.TabIndex=4;
            dogNotMore.TabStop=true;
            dogNotMore.Text="Не более";
            dogNotMore.UseVisualStyleBackColor=true;
            // 
            // dogLess
            // 
            dogLess.AutoSize=true;
            dogLess.Font=new Font("Segoe Print", 10F, FontStyle.Bold, GraphicsUnit.Point);
            dogLess.Location=new Point(20, 139);
            dogLess.Name="dogLess";
            dogLess.Size=new Size(103, 34);
            dogLess.TabIndex=3;
            dogLess.TabStop=true;
            dogLess.Text="Меньше";
            dogLess.UseVisualStyleBackColor=true;
            // 
            // dogMore
            // 
            dogMore.AutoSize=true;
            dogMore.Font=new Font("Segoe Print", 10F, FontStyle.Bold, GraphicsUnit.Point);
            dogMore.Location=new Point(20, 109);
            dogMore.Name="dogMore";
            dogMore.Size=new Size(99, 34);
            dogMore.TabIndex=2;
            dogMore.TabStop=true;
            dogMore.Text="Больше";
            dogMore.UseVisualStyleBackColor=true;
            // 
            // dogEqual
            // 
            dogEqual.AutoSize=true;
            dogEqual.Font=new Font("Segoe Print", 10F, FontStyle.Bold, GraphicsUnit.Point);
            dogEqual.Location=new Point(20, 79);
            dogEqual.Name="dogEqual";
            dogEqual.Size=new Size(85, 34);
            dogEqual.TabIndex=1;
            dogEqual.TabStop=true;
            dogEqual.Text="Равно";
            dogEqual.UseVisualStyleBackColor=true;
            // 
            // dogCount
            // 
            dogCount.BackColor=Color.OldLace;
            dogCount.Font=new Font("Segoe Print", 10F, FontStyle.Bold, GraphicsUnit.Point);
            dogCount.Location=new Point(20, 36);
            dogCount.Name="dogCount";
            dogCount.Size=new Size(211, 37);
            dogCount.TabIndex=0;
            // 
            // goalBox
            // 
            goalBox.BackColor=Color.Wheat;
            goalBox.Controls.Add(goalTextBox);
            goalBox.Font=new Font("Segoe Print", 10F, FontStyle.Bold, GraphicsUnit.Point);
            goalBox.Location=new Point(21, 434);
            goalBox.Name="goalBox";
            goalBox.Size=new Size(753, 77);
            goalBox.TabIndex=4;
            goalBox.TabStop=false;
            goalBox.Text="По цели отлова";
            // 
            // goalTextBox
            // 
            goalTextBox.BackColor=Color.OldLace;
            goalTextBox.Font=new Font("Segoe Print", 10F, FontStyle.Bold, GraphicsUnit.Point);
            goalTextBox.Location=new Point(15, 35);
            goalTextBox.Name="goalTextBox";
            goalTextBox.PlaceholderText="Если окно ввода текста пустое, то фильтр не применяется";
            goalTextBox.Size=new Size(729, 37);
            goalTextBox.TabIndex=0;
            // 
            // groupBox1
            // 
            groupBox1.BackColor=Color.Wheat;
            groupBox1.Controls.Add(toDateLabel);
            groupBox1.Controls.Add(toDate);
            groupBox1.Controls.Add(fromDateLabel);
            groupBox1.Controls.Add(fromDate);
            groupBox1.Font=new Font("Segoe Print", 10F, FontStyle.Bold, GraphicsUnit.Point);
            groupBox1.Location=new Point(21, 529);
            groupBox1.Name="groupBox1";
            groupBox1.Size=new Size(753, 76);
            groupBox1.TabIndex=5;
            groupBox1.TabStop=false;
            groupBox1.Text="По дате отлова";
            // 
            // toDateLabel
            // 
            toDateLabel.AutoSize=true;
            toDateLabel.Font=new Font("Segoe Print", 10F, FontStyle.Bold, GraphicsUnit.Point);
            toDateLabel.Location=new Point(476, 24);
            toDateLabel.Name="toDateLabel";
            toDateLabel.Size=new Size(44, 30);
            toDateLabel.TabIndex=3;
            toDateLabel.Text="До:";
            // 
            // toDate
            // 
            toDate.CalendarMonthBackground=Color.OldLace;
            toDate.Font=new Font("Segoe Print", 10F, FontStyle.Bold, GraphicsUnit.Point);
            toDate.Location=new Point(526, 19);
            toDate.Name="toDate";
            toDate.Size=new Size(221, 37);
            toDate.TabIndex=2;
            // 
            // fromDateLabel
            // 
            fromDateLabel.AutoSize=true;
            fromDateLabel.Font=new Font("Segoe Print", 10F, FontStyle.Bold, GraphicsUnit.Point);
            fromDateLabel.Location=new Point(6, 33);
            fromDateLabel.Name="fromDateLabel";
            fromDateLabel.Size=new Size(50, 30);
            fromDateLabel.TabIndex=1;
            fromDateLabel.Text="От:";
            // 
            // fromDate
            // 
            fromDate.CalendarMonthBackground=Color.OldLace;
            fromDate.Font=new Font("Segoe Print", 10F, FontStyle.Bold, GraphicsUnit.Point);
            fromDate.Location=new Point(62, 28);
            fromDate.Name="fromDate";
            fromDate.Size=new Size(221, 37);
            fromDate.TabIndex=0;
            // 
            // contractBox
            // 
            contractBox.BackColor=Color.Wheat;
            contractBox.Controls.Add(contractComboBox);
            contractBox.Font=new Font("Segoe Print", 10F, FontStyle.Bold, GraphicsUnit.Point);
            contractBox.Location=new Point(21, 633);
            contractBox.Name="contractBox";
            contractBox.Size=new Size(753, 77);
            contractBox.TabIndex=6;
            contractBox.TabStop=false;
            contractBox.Text="По муниципальному контракту";
            // 
            // contractComboBox
            // 
            contractComboBox.BackColor=Color.OldLace;
            contractComboBox.DropDownStyle=ComboBoxStyle.DropDownList;
            contractComboBox.FlatStyle=FlatStyle.Popup;
            contractComboBox.Font=new Font("Segoe Print", 10F, FontStyle.Bold, GraphicsUnit.Point);
            contractComboBox.FormattingEnabled=true;
            contractComboBox.Location=new Point(16, 26);
            contractComboBox.Name="contractComboBox";
            contractComboBox.Size=new Size(728, 38);
            contractComboBox.TabIndex=0;
            // 
            // applicationBox
            // 
            applicationBox.BackColor=Color.Wheat;
            applicationBox.Controls.Add(addApplication);
            applicationBox.Controls.Add(appListLabel);
            applicationBox.Controls.Add(removeApplication);
            applicationBox.Controls.Add(appComboBox);
            applicationBox.Controls.Add(applications);
            applicationBox.Font=new Font("Segoe Print", 10F, FontStyle.Bold, GraphicsUnit.Point);
            applicationBox.Location=new Point(21, 723);
            applicationBox.Name="applicationBox";
            applicationBox.Size=new Size(753, 224);
            applicationBox.TabIndex=7;
            applicationBox.TabStop=false;
            applicationBox.Text="По заявкам";
            // 
            // addApplication
            // 
            addApplication.BackColor=Color.Cornsilk;
            addApplication.FlatStyle=FlatStyle.Popup;
            addApplication.Font=new Font("Segoe Print", 10F, FontStyle.Bold, GraphicsUnit.Point);
            addApplication.ForeColor=Color.Black;
            addApplication.Location=new Point(603, 178);
            addApplication.Name="addApplication";
            addApplication.Size=new Size(141, 40);
            addApplication.TabIndex=2;
            addApplication.Text="Добавить заявку";
            addApplication.UseVisualStyleBackColor=false;
            // 
            // appListLabel
            // 
            appListLabel.AutoSize=true;
            appListLabel.Font=new Font("Segoe Print", 10F, FontStyle.Bold, GraphicsUnit.Point);
            appListLabel.Location=new Point(399, 33);
            appListLabel.Name="appListLabel";
            appListLabel.Size=new Size(155, 30);
            appListLabel.TabIndex=4;
            appListLabel.Text="Перечень заявок";
            // 
            // removeApplication
            // 
            removeApplication.BackColor=Color.Cornsilk;
            removeApplication.FlatStyle=FlatStyle.Popup;
            removeApplication.Font=new Font("Segoe Print", 10F, FontStyle.Bold, GraphicsUnit.Point);
            removeApplication.ForeColor=Color.Black;
            removeApplication.Location=new Point(6, 180);
            removeApplication.Name="removeApplication";
            removeApplication.Size=new Size(141, 38);
            removeApplication.TabIndex=3;
            removeApplication.Text="Убрать заявку";
            removeApplication.UseVisualStyleBackColor=false;
            // 
            // appComboBox
            // 
            appComboBox.BackColor=Color.OldLace;
            appComboBox.DropDownStyle=ComboBoxStyle.DropDownList;
            appComboBox.FlatStyle=FlatStyle.Popup;
            appComboBox.Font=new Font("Segoe Print", 10F, FontStyle.Bold, GraphicsUnit.Point);
            appComboBox.FormattingEnabled=true;
            appComboBox.Location=new Point(399, 66);
            appComboBox.Name="appComboBox";
            appComboBox.Size=new Size(348, 38);
            appComboBox.TabIndex=1;
            // 
            // applications
            // 
            applications.BackColor=Color.OldLace;
            applications.Font=new Font("Segoe Print", 10F, FontStyle.Bold, GraphicsUnit.Point);
            applications.FormattingEnabled=true;
            applications.ItemHeight=30;
            applications.Location=new Point(6, 33);
            applications.Name="applications";
            applications.Size=new Size(345, 124);
            applications.TabIndex=0;
            // 
            // apply
            // 
            apply.BackColor=Color.Wheat;
            apply.FlatStyle=FlatStyle.Flat;
            apply.Font=new Font("Segoe Print", 10F, FontStyle.Bold, GraphicsUnit.Point);
            apply.Location=new Point(27, 974);
            apply.Name="apply";
            apply.Size=new Size(141, 40);
            apply.TabIndex=8;
            apply.Text="Применить";
            apply.UseVisualStyleBackColor=false;
            // 
            // reset
            // 
            reset.BackColor=Color.Wheat;
            reset.FlatStyle=FlatStyle.Flat;
            reset.Font=new Font("Segoe Print", 10F, FontStyle.Bold, GraphicsUnit.Point);
            reset.Location=new Point(313, 974);
            reset.Name="reset";
            reset.Size=new Size(141, 40);
            reset.TabIndex=9;
            reset.Text="Сбросить";
            reset.UseVisualStyleBackColor=false;
            // 
            // close
            // 
            close.BackColor=Color.Wheat;
            close.FlatStyle=FlatStyle.Flat;
            close.Font=new Font("Segoe Print", 10F, FontStyle.Bold, GraphicsUnit.Point);
            close.Location=new Point(624, 974);
            close.Name="close";
            close.Size=new Size(141, 40);
            close.TabIndex=10;
            close.Text="Закрыть";
            close.UseVisualStyleBackColor=false;
            // 
            // ActFilter
            // 
            AutoScaleDimensions=new SizeF(8F, 20F);
            AutoScaleMode=AutoScaleMode.Font;
            BackColor=Color.Tan;
            ClientSize=new Size(789, 1026);
            Controls.Add(close);
            Controls.Add(reset);
            Controls.Add(apply);
            Controls.Add(applicationBox);
            Controls.Add(contractBox);
            Controls.Add(groupBox1);
            Controls.Add(goalBox);
            Controls.Add(animalBox);
            Controls.Add(orgBox);
            Cursor=Cursors.PanNW;
            FormBorderStyle=FormBorderStyle.FixedSingle;
            MaximizeBox=false;
            Name="ActFilter";
            ShowIcon=false;
            StartPosition=FormStartPosition.CenterParent;
            Text="Фильтры: Акты Отлова";
            orgBox.ResumeLayout(false);
            animalBox.ResumeLayout(false);
            animalBox.PerformLayout();
            catBox.ResumeLayout(false);
            catBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)catCount).EndInit();
            dogBox.ResumeLayout(false);
            dogBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dogCount).EndInit();
            goalBox.ResumeLayout(false);
            goalBox.PerformLayout();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            contractBox.ResumeLayout(false);
            applicationBox.ResumeLayout(false);
            applicationBox.PerformLayout();
            ResumeLayout(false);
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