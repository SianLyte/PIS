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
            appListLabel=new Label();
            removeApplication=new Button();
            addApplication=new Button();
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
            orgBox.Controls.Add(orgComboBox);
            orgBox.Location=new Point(21, 12);
            orgBox.Name="orgBox";
            orgBox.Size=new Size(606, 69);
            orgBox.TabIndex=2;
            orgBox.TabStop=false;
            orgBox.Text="По организации";
            // 
            // orgComboBox
            // 
            orgComboBox.DropDownStyle=ComboBoxStyle.DropDownList;
            orgComboBox.FormattingEnabled=true;
            orgComboBox.Location=new Point(15, 26);
            orgComboBox.Name="orgComboBox";
            orgComboBox.Size=new Size(572, 28);
            orgComboBox.TabIndex=0;
            // 
            // animalBox
            // 
            animalBox.Controls.Add(enableCatFilter);
            animalBox.Controls.Add(enableDogFilter);
            animalBox.Controls.Add(catBox);
            animalBox.Controls.Add(dogBox);
            animalBox.Location=new Point(21, 103);
            animalBox.Name="animalBox";
            animalBox.Size=new Size(606, 313);
            animalBox.TabIndex=3;
            animalBox.TabStop=false;
            animalBox.Text="По количеству отловленных животных";
            // 
            // enableCatFilter
            // 
            enableCatFilter.AutoSize=true;
            enableCatFilter.Location=new Point(325, 43);
            enableCatFilter.Name="enableCatFilter";
            enableCatFilter.Size=new Size(152, 24);
            enableCatFilter.TabIndex=7;
            enableCatFilter.Text="Включить фильтр";
            enableCatFilter.UseVisualStyleBackColor=true;
            // 
            // enableDogFilter
            // 
            enableDogFilter.AutoSize=true;
            enableDogFilter.Location=new Point(15, 43);
            enableDogFilter.Name="enableDogFilter";
            enableDogFilter.Size=new Size(152, 24);
            enableDogFilter.TabIndex=4;
            enableDogFilter.Text="Включить фильтр";
            enableDogFilter.UseVisualStyleBackColor=true;
            // 
            // catBox
            // 
            catBox.Controls.Add(catNotLess);
            catBox.Controls.Add(catNotMore);
            catBox.Controls.Add(catLess);
            catBox.Controls.Add(catMore);
            catBox.Controls.Add(catEqual);
            catBox.Controls.Add(catCount);
            catBox.Enabled=false;
            catBox.Location=new Point(325, 73);
            catBox.Name="catBox";
            catBox.Size=new Size(262, 221);
            catBox.TabIndex=6;
            catBox.TabStop=false;
            catBox.Text="Количество отловленных кошек";
            // 
            // catNotLess
            // 
            catNotLess.AutoSize=true;
            catNotLess.Location=new Point(20, 179);
            catNotLess.Name="catNotLess";
            catNotLess.Size=new Size(97, 24);
            catNotLess.TabIndex=5;
            catNotLess.TabStop=true;
            catNotLess.Text="Не менее";
            catNotLess.UseVisualStyleBackColor=true;
            // 
            // catNotMore
            // 
            catNotMore.AutoSize=true;
            catNotMore.Location=new Point(20, 149);
            catNotMore.Name="catNotMore";
            catNotMore.Size=new Size(95, 24);
            catNotMore.TabIndex=4;
            catNotMore.TabStop=true;
            catNotMore.Text="Не более";
            catNotMore.UseVisualStyleBackColor=true;
            // 
            // catLess
            // 
            catLess.AutoSize=true;
            catLess.Location=new Point(20, 119);
            catLess.Name="catLess";
            catLess.Size=new Size(88, 24);
            catLess.TabIndex=3;
            catLess.TabStop=true;
            catLess.Text="Меньше";
            catLess.UseVisualStyleBackColor=true;
            // 
            // catMore
            // 
            catMore.AutoSize=true;
            catMore.Location=new Point(20, 89);
            catMore.Name="catMore";
            catMore.Size=new Size(84, 24);
            catMore.TabIndex=2;
            catMore.TabStop=true;
            catMore.Text="Больше";
            catMore.UseVisualStyleBackColor=true;
            // 
            // catEqual
            // 
            catEqual.AutoSize=true;
            catEqual.Location=new Point(20, 59);
            catEqual.Name="catEqual";
            catEqual.Size=new Size(72, 24);
            catEqual.TabIndex=1;
            catEqual.TabStop=true;
            catEqual.Text="Равно";
            catEqual.UseVisualStyleBackColor=true;
            // 
            // catCount
            // 
            catCount.Location=new Point(20, 26);
            catCount.Name="catCount";
            catCount.Size=new Size(211, 27);
            catCount.TabIndex=0;
            // 
            // dogBox
            // 
            dogBox.Controls.Add(dogNotLess);
            dogBox.Controls.Add(dogNotMore);
            dogBox.Controls.Add(dogLess);
            dogBox.Controls.Add(dogMore);
            dogBox.Controls.Add(dogEqual);
            dogBox.Controls.Add(dogCount);
            dogBox.Enabled=false;
            dogBox.Location=new Point(15, 73);
            dogBox.Name="dogBox";
            dogBox.Size=new Size(262, 221);
            dogBox.TabIndex=1;
            dogBox.TabStop=false;
            dogBox.Text="Количество отловленных собак";
            // 
            // dogNotLess
            // 
            dogNotLess.AutoSize=true;
            dogNotLess.Location=new Point(20, 179);
            dogNotLess.Name="dogNotLess";
            dogNotLess.Size=new Size(97, 24);
            dogNotLess.TabIndex=5;
            dogNotLess.TabStop=true;
            dogNotLess.Text="Не менее";
            dogNotLess.UseVisualStyleBackColor=true;
            // 
            // dogNotMore
            // 
            dogNotMore.AutoSize=true;
            dogNotMore.Location=new Point(20, 149);
            dogNotMore.Name="dogNotMore";
            dogNotMore.Size=new Size(95, 24);
            dogNotMore.TabIndex=4;
            dogNotMore.TabStop=true;
            dogNotMore.Text="Не более";
            dogNotMore.UseVisualStyleBackColor=true;
            // 
            // dogLess
            // 
            dogLess.AutoSize=true;
            dogLess.Location=new Point(20, 119);
            dogLess.Name="dogLess";
            dogLess.Size=new Size(88, 24);
            dogLess.TabIndex=3;
            dogLess.TabStop=true;
            dogLess.Text="Меньше";
            dogLess.UseVisualStyleBackColor=true;
            // 
            // dogMore
            // 
            dogMore.AutoSize=true;
            dogMore.Location=new Point(20, 89);
            dogMore.Name="dogMore";
            dogMore.Size=new Size(84, 24);
            dogMore.TabIndex=2;
            dogMore.TabStop=true;
            dogMore.Text="Больше";
            dogMore.UseVisualStyleBackColor=true;
            // 
            // dogEqual
            // 
            dogEqual.AutoSize=true;
            dogEqual.Location=new Point(20, 59);
            dogEqual.Name="dogEqual";
            dogEqual.Size=new Size(72, 24);
            dogEqual.TabIndex=1;
            dogEqual.TabStop=true;
            dogEqual.Text="Равно";
            dogEqual.UseVisualStyleBackColor=true;
            // 
            // dogCount
            // 
            dogCount.Location=new Point(20, 26);
            dogCount.Name="dogCount";
            dogCount.Size=new Size(211, 27);
            dogCount.TabIndex=0;
            // 
            // goalBox
            // 
            goalBox.Controls.Add(goalTextBox);
            goalBox.Location=new Point(21, 434);
            goalBox.Name="goalBox";
            goalBox.Size=new Size(606, 78);
            goalBox.TabIndex=4;
            goalBox.TabStop=false;
            goalBox.Text="По цели отлова";
            // 
            // goalTextBox
            // 
            goalTextBox.Location=new Point(15, 35);
            goalTextBox.Name="goalTextBox";
            goalTextBox.PlaceholderText="Если окно ввода текста пустое, то фильтр не применяется";
            goalTextBox.Size=new Size(572, 27);
            goalTextBox.TabIndex=0;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(toDateLabel);
            groupBox1.Controls.Add(toDate);
            groupBox1.Controls.Add(fromDateLabel);
            groupBox1.Controls.Add(fromDate);
            groupBox1.Location=new Point(21, 529);
            groupBox1.Name="groupBox1";
            groupBox1.Size=new Size(606, 88);
            groupBox1.TabIndex=5;
            groupBox1.TabStop=false;
            groupBox1.Text="По дате отлова";
            // 
            // toDateLabel
            // 
            toDateLabel.AutoSize=true;
            toDateLabel.Location=new Point(310, 42);
            toDateLabel.Name="toDateLabel";
            toDateLabel.Size=new Size(31, 20);
            toDateLabel.TabIndex=3;
            toDateLabel.Text="До:";
            // 
            // toDate
            // 
            toDate.Location=new Point(345, 39);
            toDate.Name="toDate";
            toDate.Size=new Size(221, 27);
            toDate.TabIndex=2;
            // 
            // fromDateLabel
            // 
            fromDateLabel.AutoSize=true;
            fromDateLabel.Location=new Point(37, 42);
            fromDateLabel.Name="fromDateLabel";
            fromDateLabel.Size=new Size(29, 20);
            fromDateLabel.TabIndex=1;
            fromDateLabel.Text="От:";
            // 
            // fromDate
            // 
            fromDate.Location=new Point(70, 39);
            fromDate.Name="fromDate";
            fromDate.Size=new Size(221, 27);
            fromDate.TabIndex=0;
            // 
            // contractBox
            // 
            contractBox.Controls.Add(contractComboBox);
            contractBox.Location=new Point(21, 633);
            contractBox.Name="contractBox";
            contractBox.Size=new Size(606, 72);
            contractBox.TabIndex=6;
            contractBox.TabStop=false;
            contractBox.Text="По муниципальному контракту";
            // 
            // contractComboBox
            // 
            contractComboBox.DropDownStyle=ComboBoxStyle.DropDownList;
            contractComboBox.FormattingEnabled=true;
            contractComboBox.Location=new Point(16, 26);
            contractComboBox.Name="contractComboBox";
            contractComboBox.Size=new Size(571, 28);
            contractComboBox.TabIndex=0;
            // 
            // applicationBox
            // 
            applicationBox.Controls.Add(appListLabel);
            applicationBox.Controls.Add(removeApplication);
            applicationBox.Controls.Add(addApplication);
            applicationBox.Controls.Add(appComboBox);
            applicationBox.Controls.Add(applications);
            applicationBox.Location=new Point(21, 723);
            applicationBox.Name="applicationBox";
            applicationBox.Size=new Size(606, 165);
            applicationBox.TabIndex=7;
            applicationBox.TabStop=false;
            applicationBox.Text="По заявкам";
            // 
            // appListLabel
            // 
            appListLabel.AutoSize=true;
            appListLabel.Location=new Point(190, 26);
            appListLabel.Name="appListLabel";
            appListLabel.Size=new Size(129, 20);
            appListLabel.TabIndex=4;
            appListLabel.Text="Перечень заявок";
            // 
            // removeApplication
            // 
            removeApplication.Location=new Point(16, 121);
            removeApplication.Name="removeApplication";
            removeApplication.Size=new Size(149, 29);
            removeApplication.TabIndex=3;
            removeApplication.Text="Убрать заявку";
            removeApplication.UseVisualStyleBackColor=true;
            // 
            // addApplication
            // 
            addApplication.Location=new Point(430, 83);
            addApplication.Name="addApplication";
            addApplication.Size=new Size(157, 29);
            addApplication.TabIndex=2;
            addApplication.Text="Добавить заявку";
            addApplication.UseVisualStyleBackColor=true;
            // 
            // appComboBox
            // 
            appComboBox.DropDownStyle=ComboBoxStyle.DropDownList;
            appComboBox.FormattingEnabled=true;
            appComboBox.Location=new Point(190, 49);
            appComboBox.Name="appComboBox";
            appComboBox.Size=new Size(397, 28);
            appComboBox.TabIndex=1;
            // 
            // applications
            // 
            applications.FormattingEnabled=true;
            applications.ItemHeight=20;
            applications.Location=new Point(15, 26);
            applications.Name="applications";
            applications.Size=new Size(150, 84);
            applications.TabIndex=0;
            // 
            // apply
            // 
            apply.BackColor=Color.FromArgb(200, 255, 200);
            apply.FlatStyle=FlatStyle.Flat;
            apply.Location=new Point(21, 905);
            apply.Name="apply";
            apply.Size=new Size(141, 29);
            apply.TabIndex=8;
            apply.Text="Применить";
            apply.UseVisualStyleBackColor=false;
            apply.Click+=apply_Click;
            // 
            // reset
            // 
            reset.BackColor=Color.FromArgb(255, 255, 200);
            reset.FlatStyle=FlatStyle.Flat;
            reset.Location=new Point(257, 905);
            reset.Name="reset";
            reset.Size=new Size(141, 29);
            reset.TabIndex=9;
            reset.Text="Сбросить";
            reset.UseVisualStyleBackColor=false;
            // 
            // close
            // 
            close.BackColor=Color.FromArgb(255, 200, 200);
            close.FlatStyle=FlatStyle.Flat;
            close.Location=new Point(486, 905);
            close.Name="close";
            close.Size=new Size(141, 29);
            close.TabIndex=10;
            close.Text="Закрыть";
            close.UseVisualStyleBackColor=false;
            // 
            // ActFilter
            // 
            AutoScaleDimensions=new SizeF(8F, 20F);
            AutoScaleMode=AutoScaleMode.Font;
            ClientSize=new Size(646, 946);
            Controls.Add(close);
            Controls.Add(reset);
            Controls.Add(apply);
            Controls.Add(applicationBox);
            Controls.Add(contractBox);
            Controls.Add(groupBox1);
            Controls.Add(goalBox);
            Controls.Add(animalBox);
            Controls.Add(orgBox);
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