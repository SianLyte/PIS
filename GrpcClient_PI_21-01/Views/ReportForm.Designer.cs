
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
            this.dateTimePickerStart = new System.Windows.Forms.DateTimePicker();
            this.dateTimePickerEnd = new System.Windows.Forms.DateTimePicker();
            this.comboBoxSity = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxSum = new System.Windows.Forms.TextBox();
            this.totalLabel = new System.Windows.Forms.Label();
            this.actorLabel = new System.Windows.Forms.Label();
            this.actorName = new System.Windows.Forms.TextBox();
            this.closedAppLabel = new System.Windows.Forms.Label();
            this.closedAppsCount = new System.Windows.Forms.NumericUpDown();
            this.animalCount = new System.Windows.Forms.NumericUpDown();
            this.animalCountLabel = new System.Windows.Forms.Label();
            this.updatedAtLabel = new System.Windows.Forms.Label();
            this.updatedAt = new System.Windows.Forms.TextBox();
            this.createdAtLabel = new System.Windows.Forms.Label();
            this.createdAt = new System.Windows.Forms.TextBox();
            this.saveButton = new System.Windows.Forms.Button();
            this.closeButton = new System.Windows.Forms.Button();
            this.reportStatusLabel = new System.Windows.Forms.Label();
            this.reportStatus = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.closedAppsCount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.animalCount)).BeginInit();
            this.SuspendLayout();
            // 
            // dateTimePickerStart
            // 
            this.dateTimePickerStart.CalendarMonthBackground = System.Drawing.Color.Cornsilk;
            this.dateTimePickerStart.Location = new System.Drawing.Point(32, 91);
            this.dateTimePickerStart.Margin = new System.Windows.Forms.Padding(6, 9, 6, 9);
            this.dateTimePickerStart.Name = "dateTimePickerStart";
            this.dateTimePickerStart.Size = new System.Drawing.Size(252, 37);
            this.dateTimePickerStart.TabIndex = 0;
            // 
            // dateTimePickerEnd
            // 
            this.dateTimePickerEnd.CalendarMonthBackground = System.Drawing.Color.Cornsilk;
            this.dateTimePickerEnd.Location = new System.Drawing.Point(431, 91);
            this.dateTimePickerEnd.Margin = new System.Windows.Forms.Padding(6, 9, 6, 9);
            this.dateTimePickerEnd.Name = "dateTimePickerEnd";
            this.dateTimePickerEnd.Size = new System.Drawing.Size(252, 37);
            this.dateTimePickerEnd.TabIndex = 1;
            // 
            // comboBoxSity
            // 
            this.comboBoxSity.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxSity.FormattingEnabled = true;
            this.comboBoxSity.Location = new System.Drawing.Point(1127, 382);
            this.comboBoxSity.Margin = new System.Windows.Forms.Padding(6, 9, 6, 9);
            this.comboBoxSity.Name = "comboBoxSity";
            this.comboBoxSity.Size = new System.Drawing.Size(252, 38);
            this.comboBoxSity.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(431, 24);
            this.label2.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(123, 30);
            this.label2.TabIndex = 4;
            this.label2.Text = "Дата конца";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(1121, 318);
            this.label3.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 30);
            this.label3.TabIndex = 5;
            this.label3.Text = "Город";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(26, 24);
            this.label1.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(132, 30);
            this.label1.TabIndex = 3;
            this.label1.Text = "Дата начала";
            // 
            // textBoxSum
            // 
            this.textBoxSum.BackColor = System.Drawing.Color.Cornsilk;
            this.textBoxSum.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxSum.Location = new System.Drawing.Point(182, 227);
            this.textBoxSum.Margin = new System.Windows.Forms.Padding(6, 9, 6, 9);
            this.textBoxSum.Name = "textBoxSum";
            this.textBoxSum.ReadOnly = true;
            this.textBoxSum.Size = new System.Drawing.Size(501, 30);
            this.textBoxSum.TabIndex = 8;
            // 
            // totalLabel
            // 
            this.totalLabel.AutoSize = true;
            this.totalLabel.Location = new System.Drawing.Point(32, 227);
            this.totalLabel.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.totalLabel.Name = "totalLabel";
            this.totalLabel.Size = new System.Drawing.Size(148, 30);
            this.totalLabel.TabIndex = 9;
            this.totalLabel.Text = "Доход в рублях";
            // 
            // actorLabel
            // 
            this.actorLabel.AutoSize = true;
            this.actorLabel.Location = new System.Drawing.Point(32, 162);
            this.actorLabel.Name = "actorLabel";
            this.actorLabel.Size = new System.Drawing.Size(107, 30);
            this.actorLabel.TabIndex = 10;
            this.actorLabel.Text = "Создатель";
            // 
            // actorName
            // 
            this.actorName.BackColor = System.Drawing.Color.Cornsilk;
            this.actorName.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.actorName.Location = new System.Drawing.Point(182, 162);
            this.actorName.Margin = new System.Windows.Forms.Padding(6, 9, 6, 9);
            this.actorName.Name = "actorName";
            this.actorName.ReadOnly = true;
            this.actorName.Size = new System.Drawing.Size(501, 30);
            this.actorName.TabIndex = 11;
            // 
            // closedAppLabel
            // 
            this.closedAppLabel.AutoSize = true;
            this.closedAppLabel.Location = new System.Drawing.Point(32, 291);
            this.closedAppLabel.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.closedAppLabel.Name = "closedAppLabel";
            this.closedAppLabel.Size = new System.Drawing.Size(240, 30);
            this.closedAppLabel.TabIndex = 13;
            this.closedAppLabel.Text = "Кол-во закрытых заявок";
            // 
            // closedAppsCount
            // 
            this.closedAppsCount.BackColor = System.Drawing.Color.Cornsilk;
            this.closedAppsCount.Enabled = false;
            this.closedAppsCount.Location = new System.Drawing.Point(360, 289);
            this.closedAppsCount.Name = "closedAppsCount";
            this.closedAppsCount.ReadOnly = true;
            this.closedAppsCount.Size = new System.Drawing.Size(323, 37);
            this.closedAppsCount.TabIndex = 14;
            // 
            // animalCount
            // 
            this.animalCount.BackColor = System.Drawing.Color.Cornsilk;
            this.animalCount.Enabled = false;
            this.animalCount.Location = new System.Drawing.Point(360, 352);
            this.animalCount.Name = "animalCount";
            this.animalCount.ReadOnly = true;
            this.animalCount.Size = new System.Drawing.Size(323, 37);
            this.animalCount.TabIndex = 16;
            // 
            // animalCountLabel
            // 
            this.animalCountLabel.AutoSize = true;
            this.animalCountLabel.Location = new System.Drawing.Point(32, 354);
            this.animalCountLabel.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.animalCountLabel.Name = "animalCountLabel";
            this.animalCountLabel.Size = new System.Drawing.Size(303, 30);
            this.animalCountLabel.TabIndex = 15;
            this.animalCountLabel.Text = "Кол-во отловленных животных";
            // 
            // updatedAtLabel
            // 
            this.updatedAtLabel.AutoSize = true;
            this.updatedAtLabel.Location = new System.Drawing.Point(32, 423);
            this.updatedAtLabel.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.updatedAtLabel.Name = "updatedAtLabel";
            this.updatedAtLabel.Size = new System.Drawing.Size(105, 30);
            this.updatedAtLabel.TabIndex = 18;
            this.updatedAtLabel.Text = "Обновлено";
            // 
            // updatedAt
            // 
            this.updatedAt.BackColor = System.Drawing.Color.Cornsilk;
            this.updatedAt.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.updatedAt.Location = new System.Drawing.Point(182, 423);
            this.updatedAt.Margin = new System.Windows.Forms.Padding(6, 9, 6, 9);
            this.updatedAt.Name = "updatedAt";
            this.updatedAt.ReadOnly = true;
            this.updatedAt.Size = new System.Drawing.Size(501, 30);
            this.updatedAt.TabIndex = 17;
            // 
            // createdAtLabel
            // 
            this.createdAtLabel.AutoSize = true;
            this.createdAtLabel.Location = new System.Drawing.Point(32, 485);
            this.createdAtLabel.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.createdAtLabel.Name = "createdAtLabel";
            this.createdAtLabel.Size = new System.Drawing.Size(82, 30);
            this.createdAtLabel.TabIndex = 20;
            this.createdAtLabel.Text = "Создано";
            // 
            // createdAt
            // 
            this.createdAt.BackColor = System.Drawing.Color.Cornsilk;
            this.createdAt.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.createdAt.Location = new System.Drawing.Point(182, 485);
            this.createdAt.Margin = new System.Windows.Forms.Padding(6, 9, 6, 9);
            this.createdAt.Name = "createdAt";
            this.createdAt.ReadOnly = true;
            this.createdAt.Size = new System.Drawing.Size(501, 30);
            this.createdAt.TabIndex = 19;
            // 
            // saveButton
            // 
            this.saveButton.BackColor = System.Drawing.Color.Cornsilk;
            this.saveButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.saveButton.Location = new System.Drawing.Point(32, 614);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(160, 41);
            this.saveButton.TabIndex = 21;
            this.saveButton.Text = "Сохранить";
            this.saveButton.UseVisualStyleBackColor = false;
            // 
            // closeButton
            // 
            this.closeButton.BackColor = System.Drawing.Color.Cornsilk;
            this.closeButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.closeButton.Location = new System.Drawing.Point(523, 614);
            this.closeButton.Name = "closeButton";
            this.closeButton.Size = new System.Drawing.Size(160, 41);
            this.closeButton.TabIndex = 22;
            this.closeButton.Text = "Закрыть";
            this.closeButton.UseVisualStyleBackColor = false;
            // 
            // reportStatusLabel
            // 
            this.reportStatusLabel.AutoSize = true;
            this.reportStatusLabel.Location = new System.Drawing.Point(32, 549);
            this.reportStatusLabel.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.reportStatusLabel.Name = "reportStatusLabel";
            this.reportStatusLabel.Size = new System.Drawing.Size(88, 30);
            this.reportStatusLabel.TabIndex = 24;
            this.reportStatusLabel.Text = "Статус";
            // 
            // reportStatus
            // 
            this.reportStatus.BackColor = System.Drawing.Color.Cornsilk;
            this.reportStatus.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.reportStatus.Location = new System.Drawing.Point(182, 549);
            this.reportStatus.Margin = new System.Windows.Forms.Padding(6, 9, 6, 9);
            this.reportStatus.Name = "reportStatus";
            this.reportStatus.ReadOnly = true;
            this.reportStatus.Size = new System.Drawing.Size(501, 30);
            this.reportStatus.TabIndex = 23;
            // 
            // ReportForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 30F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Wheat;
            this.ClientSize = new System.Drawing.Size(729, 667);
            this.Controls.Add(this.reportStatusLabel);
            this.Controls.Add(this.reportStatus);
            this.Controls.Add(this.closeButton);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.createdAtLabel);
            this.Controls.Add(this.createdAt);
            this.Controls.Add(this.updatedAtLabel);
            this.Controls.Add(this.updatedAt);
            this.Controls.Add(this.animalCount);
            this.Controls.Add(this.animalCountLabel);
            this.Controls.Add(this.closedAppsCount);
            this.Controls.Add(this.closedAppLabel);
            this.Controls.Add(this.actorName);
            this.Controls.Add(this.actorLabel);
            this.Controls.Add(this.totalLabel);
            this.Controls.Add(this.textBoxSum);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboBoxSity);
            this.Controls.Add(this.dateTimePickerEnd);
            this.Controls.Add(this.dateTimePickerStart);
            this.Font = new System.Drawing.Font("Segoe Print", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(6, 9, 6, 9);
            this.Name = "ReportForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Отчёт";
            ((System.ComponentModel.ISupportInitialize)(this.closedAppsCount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.animalCount)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker dateTimePickerStart;
        private System.Windows.Forms.DateTimePicker dateTimePickerEnd;
        private System.Windows.Forms.ComboBox comboBoxSity;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxSum;
        private System.Windows.Forms.Label totalLabel;
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
    }
}