
namespace GrpcClient_PI_21_01.Views
{
    partial class ReportForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ReportForm));
            dateTimePickerStart=new DateTimePicker();
            dateTimePickerEnd=new DateTimePicker();
            comboBoxSity=new ComboBox();
            label2=new Label();
            label3=new Label();
            label1=new Label();
            textBoxSum=new TextBox();
            totalLabel=new Label();
            actorLabel=new Label();
            actorName=new TextBox();
            closedAppLabel=new Label();
            closedAppsCount=new NumericUpDown();
            animalCount=new NumericUpDown();
            animalCountLabel=new Label();
            updatedAtLabel=new Label();
            updatedAt=new TextBox();
            createdAtLabel=new Label();
            createdAt=new TextBox();
            saveButton=new Button();
            closeButton=new Button();
            reportStatusLabel=new Label();
            reportStatus=new TextBox();
            reportStatuses=new ComboBox();
            ((System.ComponentModel.ISupportInitialize)closedAppsCount).BeginInit();
            ((System.ComponentModel.ISupportInitialize)animalCount).BeginInit();
            SuspendLayout();
            // 
            // dateTimePickerStart
            // 
            dateTimePickerStart.CalendarMonthBackground=Color.Cornsilk;
            dateTimePickerStart.Location=new Point(32, 91);
            dateTimePickerStart.Margin=new Padding(6, 9, 6, 9);
            dateTimePickerStart.Name="dateTimePickerStart";
            dateTimePickerStart.Size=new Size(252, 37);
            dateTimePickerStart.TabIndex=0;
            // 
            // dateTimePickerEnd
            // 
            dateTimePickerEnd.CalendarMonthBackground=Color.Cornsilk;
            dateTimePickerEnd.Location=new Point(431, 91);
            dateTimePickerEnd.Margin=new Padding(6, 9, 6, 9);
            dateTimePickerEnd.Name="dateTimePickerEnd";
            dateTimePickerEnd.Size=new Size(252, 37);
            dateTimePickerEnd.TabIndex=1;
            // 
            // comboBoxSity
            // 
            comboBoxSity.DropDownStyle=ComboBoxStyle.DropDownList;
            comboBoxSity.FormattingEnabled=true;
            comboBoxSity.Location=new Point(1127, 382);
            comboBoxSity.Margin=new Padding(6, 9, 6, 9);
            comboBoxSity.Name="comboBoxSity";
            comboBoxSity.Size=new Size(252, 38);
            comboBoxSity.TabIndex=2;
            // 
            // label2
            // 
            label2.AutoSize=true;
            label2.Location=new Point(431, 24);
            label2.Margin=new Padding(6, 0, 6, 0);
            label2.Name="label2";
            label2.Size=new Size(123, 30);
            label2.TabIndex=4;
            label2.Text="Дата конца";
            // 
            // label3
            // 
            label3.AutoSize=true;
            label3.Location=new Point(1121, 318);
            label3.Margin=new Padding(6, 0, 6, 0);
            label3.Name="label3";
            label3.Size=new Size(65, 30);
            label3.TabIndex=5;
            label3.Text="Город";
            // 
            // label1
            // 
            label1.AutoSize=true;
            label1.Location=new Point(26, 24);
            label1.Margin=new Padding(6, 0, 6, 0);
            label1.Name="label1";
            label1.Size=new Size(132, 30);
            label1.TabIndex=3;
            label1.Text="Дата начала";
            // 
            // textBoxSum
            // 
            textBoxSum.BackColor=Color.Cornsilk;
            textBoxSum.BorderStyle=BorderStyle.None;
            textBoxSum.Location=new Point(182, 227);
            textBoxSum.Margin=new Padding(6, 9, 6, 9);
            textBoxSum.Name="textBoxSum";
            textBoxSum.ReadOnly=true;
            textBoxSum.Size=new Size(501, 30);
            textBoxSum.TabIndex=8;
            // 
            // totalLabel
            // 
            totalLabel.AutoSize=true;
            totalLabel.Location=new Point(32, 227);
            totalLabel.Margin=new Padding(6, 0, 6, 0);
            totalLabel.Name="totalLabel";
            totalLabel.Size=new Size(148, 30);
            totalLabel.TabIndex=9;
            totalLabel.Text="Доход в рублях";
            // 
            // actorLabel
            // 
            actorLabel.AutoSize=true;
            actorLabel.Location=new Point(32, 162);
            actorLabel.Name="actorLabel";
            actorLabel.Size=new Size(107, 30);
            actorLabel.TabIndex=10;
            actorLabel.Text="Создатель";
            // 
            // actorName
            // 
            actorName.BackColor=Color.Cornsilk;
            actorName.BorderStyle=BorderStyle.None;
            actorName.Location=new Point(182, 162);
            actorName.Margin=new Padding(6, 9, 6, 9);
            actorName.Name="actorName";
            actorName.ReadOnly=true;
            actorName.Size=new Size(501, 30);
            actorName.TabIndex=11;
            // 
            // closedAppLabel
            // 
            closedAppLabel.AutoSize=true;
            closedAppLabel.Location=new Point(32, 291);
            closedAppLabel.Margin=new Padding(6, 0, 6, 0);
            closedAppLabel.Name="closedAppLabel";
            closedAppLabel.Size=new Size(240, 30);
            closedAppLabel.TabIndex=13;
            closedAppLabel.Text="Кол-во закрытых заявок";
            // 
            // closedAppsCount
            // 
            closedAppsCount.BackColor=Color.Cornsilk;
            closedAppsCount.Enabled=false;
            closedAppsCount.Location=new Point(360, 289);
            closedAppsCount.Name="closedAppsCount";
            closedAppsCount.ReadOnly=true;
            closedAppsCount.Size=new Size(323, 37);
            closedAppsCount.TabIndex=14;
            // 
            // animalCount
            // 
            animalCount.BackColor=Color.Cornsilk;
            animalCount.Enabled=false;
            animalCount.Location=new Point(360, 352);
            animalCount.Name="animalCount";
            animalCount.ReadOnly=true;
            animalCount.Size=new Size(323, 37);
            animalCount.TabIndex=16;
            // 
            // animalCountLabel
            // 
            animalCountLabel.AutoSize=true;
            animalCountLabel.Location=new Point(32, 354);
            animalCountLabel.Margin=new Padding(6, 0, 6, 0);
            animalCountLabel.Name="animalCountLabel";
            animalCountLabel.Size=new Size(303, 30);
            animalCountLabel.TabIndex=15;
            animalCountLabel.Text="Кол-во отловленных животных";
            // 
            // updatedAtLabel
            // 
            updatedAtLabel.AutoSize=true;
            updatedAtLabel.Location=new Point(32, 423);
            updatedAtLabel.Margin=new Padding(6, 0, 6, 0);
            updatedAtLabel.Name="updatedAtLabel";
            updatedAtLabel.Size=new Size(105, 30);
            updatedAtLabel.TabIndex=18;
            updatedAtLabel.Text="Обновлено";
            // 
            // updatedAt
            // 
            updatedAt.BackColor=Color.Cornsilk;
            updatedAt.BorderStyle=BorderStyle.None;
            updatedAt.Location=new Point(182, 423);
            updatedAt.Margin=new Padding(6, 9, 6, 9);
            updatedAt.Name="updatedAt";
            updatedAt.ReadOnly=true;
            updatedAt.Size=new Size(501, 30);
            updatedAt.TabIndex=17;
            // 
            // createdAtLabel
            // 
            createdAtLabel.AutoSize=true;
            createdAtLabel.Location=new Point(32, 485);
            createdAtLabel.Margin=new Padding(6, 0, 6, 0);
            createdAtLabel.Name="createdAtLabel";
            createdAtLabel.Size=new Size(82, 30);
            createdAtLabel.TabIndex=20;
            createdAtLabel.Text="Создано";
            // 
            // createdAt
            // 
            createdAt.BackColor=Color.Cornsilk;
            createdAt.BorderStyle=BorderStyle.None;
            createdAt.Location=new Point(182, 485);
            createdAt.Margin=new Padding(6, 9, 6, 9);
            createdAt.Name="createdAt";
            createdAt.ReadOnly=true;
            createdAt.Size=new Size(501, 30);
            createdAt.TabIndex=19;
            // 
            // saveButton
            // 
            saveButton.BackColor=Color.Cornsilk;
            saveButton.FlatStyle=FlatStyle.Flat;
            saveButton.Location=new Point(32, 614);
            saveButton.Name="saveButton";
            saveButton.Size=new Size(160, 41);
            saveButton.TabIndex=21;
            saveButton.Text="Сохранить";
            saveButton.UseVisualStyleBackColor=false;
            // 
            // closeButton
            // 
            closeButton.BackColor=Color.Cornsilk;
            closeButton.FlatStyle=FlatStyle.Flat;
            closeButton.Location=new Point(523, 614);
            closeButton.Name="closeButton";
            closeButton.Size=new Size(160, 41);
            closeButton.TabIndex=22;
            closeButton.Text="Закрыть";
            closeButton.UseVisualStyleBackColor=false;
            // 
            // reportStatusLabel
            // 
            reportStatusLabel.AutoSize=true;
            reportStatusLabel.Location=new Point(32, 549);
            reportStatusLabel.Margin=new Padding(6, 0, 6, 0);
            reportStatusLabel.Name="reportStatusLabel";
            reportStatusLabel.Size=new Size(88, 30);
            reportStatusLabel.TabIndex=24;
            reportStatusLabel.Text="Статус";
            // 
            // reportStatus
            // 
            reportStatus.BackColor=Color.Cornsilk;
            reportStatus.BorderStyle=BorderStyle.None;
            reportStatus.Location=new Point(182, 519);
            reportStatus.Margin=new Padding(6, 9, 6, 9);
            reportStatus.Name="reportStatus";
            reportStatus.ReadOnly=true;
            reportStatus.Size=new Size(501, 30);
            reportStatus.TabIndex=23;
            // 
            // reportStatuses
            // 
            reportStatuses.BackColor=Color.Cornsilk;
            reportStatuses.FormattingEnabled=true;
            reportStatuses.Location=new Point(182, 561);
            reportStatuses.Name="reportStatuses";
            reportStatuses.Size=new Size(501, 38);
            reportStatuses.TabIndex=25;
            // 
            // ReportForm
            // 
            AutoScaleDimensions=new SizeF(11F, 30F);
            AutoScaleMode=AutoScaleMode.Font;
            BackColor=Color.Wheat;
            ClientSize=new Size(729, 667);
            Controls.Add(reportStatuses);
            Controls.Add(reportStatusLabel);
            Controls.Add(reportStatus);
            Controls.Add(closeButton);
            Controls.Add(saveButton);
            Controls.Add(createdAtLabel);
            Controls.Add(createdAt);
            Controls.Add(updatedAtLabel);
            Controls.Add(updatedAt);
            Controls.Add(animalCount);
            Controls.Add(animalCountLabel);
            Controls.Add(closedAppsCount);
            Controls.Add(closedAppLabel);
            Controls.Add(actorName);
            Controls.Add(actorLabel);
            Controls.Add(totalLabel);
            Controls.Add(textBoxSum);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(comboBoxSity);
            Controls.Add(dateTimePickerEnd);
            Controls.Add(dateTimePickerStart);
            Font=new Font("Segoe Print", 10F, FontStyle.Bold, GraphicsUnit.Point);
            FormBorderStyle=FormBorderStyle.FixedSingle;
            Icon=(Icon)resources.GetObject("$this.Icon");
            Margin=new Padding(6, 9, 6, 9);
            Name="ReportForm";
            StartPosition=FormStartPosition.CenterScreen;
            Text="Отчёт";
            ((System.ComponentModel.ISupportInitialize)closedAppsCount).EndInit();
            ((System.ComponentModel.ISupportInitialize)animalCount).EndInit();
            ResumeLayout(false);
            PerformLayout();

        }

        #endregion

        private DateTimePicker dateTimePickerStart;
        private DateTimePicker dateTimePickerEnd;
        private ComboBox comboBoxSity;
        private Label label2;
        private Label label3;
        private Label label1;
        private TextBox textBoxSum;
        private Label totalLabel;
        private Label actorLabel;
        private TextBox actorName;
        private Label closedAppLabel;
        private NumericUpDown closedAppsCount;
        private NumericUpDown animalCount;
        private Label animalCountLabel;
        private Label updatedAtLabel;
        private TextBox updatedAt;
        private Label createdAtLabel;
        private TextBox createdAt;
        private Button saveButton;
        private Button closeButton;
        private Label reportStatusLabel;
        private TextBox reportStatus;
        private ComboBox reportStatuses;
    }
}