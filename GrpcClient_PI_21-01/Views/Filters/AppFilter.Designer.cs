namespace GrpcClient_PI_21_01.Views.Filters
{
    partial class AppFilter
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
            this.dateBox = new System.Windows.Forms.GroupBox();
            this.toDateLabel = new System.Windows.Forms.Label();
            this.toDate = new System.Windows.Forms.DateTimePicker();
            this.fromDateLabel = new System.Windows.Forms.Label();
            this.fromDate = new System.Windows.Forms.DateTimePicker();
            this.localityBox = new System.Windows.Forms.GroupBox();
            this.localityComboBox = new System.Windows.Forms.ComboBox();
            this.applicantBox = new System.Windows.Forms.GroupBox();
            this.applicantComboBox = new System.Windows.Forms.ComboBox();
            this.statusBox = new System.Windows.Forms.GroupBox();
            this.statusComboBox = new System.Windows.Forms.ComboBox();
            this.close = new System.Windows.Forms.Button();
            this.reset = new System.Windows.Forms.Button();
            this.apply = new System.Windows.Forms.Button();
            this.dateBox.SuspendLayout();
            this.localityBox.SuspendLayout();
            this.applicantBox.SuspendLayout();
            this.statusBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // dateBox
            // 
            this.dateBox.Controls.Add(this.toDateLabel);
            this.dateBox.Controls.Add(this.toDate);
            this.dateBox.Controls.Add(this.fromDateLabel);
            this.dateBox.Controls.Add(this.fromDate);
            this.dateBox.Location = new System.Drawing.Point(12, 12);
            this.dateBox.Name = "dateBox";
            this.dateBox.Size = new System.Drawing.Size(624, 88);
            this.dateBox.TabIndex = 6;
            this.dateBox.TabStop = false;
            this.dateBox.Text = "По дате заявки";
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
            // localityBox
            // 
            this.localityBox.Controls.Add(this.localityComboBox);
            this.localityBox.Location = new System.Drawing.Point(12, 119);
            this.localityBox.Name = "localityBox";
            this.localityBox.Size = new System.Drawing.Size(624, 74);
            this.localityBox.TabIndex = 7;
            this.localityBox.TabStop = false;
            this.localityBox.Text = "По населенному пункту";
            // 
            // localityComboBox
            // 
            this.localityComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.localityComboBox.FormattingEnabled = true;
            this.localityComboBox.Location = new System.Drawing.Point(19, 26);
            this.localityComboBox.Name = "localityComboBox";
            this.localityComboBox.Size = new System.Drawing.Size(583, 28);
            this.localityComboBox.TabIndex = 0;
            // 
            // applicantBox
            // 
            this.applicantBox.Controls.Add(this.applicantComboBox);
            this.applicantBox.Location = new System.Drawing.Point(12, 212);
            this.applicantBox.Name = "applicantBox";
            this.applicantBox.Size = new System.Drawing.Size(624, 74);
            this.applicantBox.TabIndex = 8;
            this.applicantBox.TabStop = false;
            this.applicantBox.Text = "По категории заявителя";
            // 
            // applicantComboBox
            // 
            this.applicantComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.applicantComboBox.FormattingEnabled = true;
            this.applicantComboBox.Location = new System.Drawing.Point(19, 26);
            this.applicantComboBox.Name = "applicantComboBox";
            this.applicantComboBox.Size = new System.Drawing.Size(583, 28);
            this.applicantComboBox.TabIndex = 0;
            // 
            // statusBox
            // 
            this.statusBox.Controls.Add(this.statusComboBox);
            this.statusBox.Location = new System.Drawing.Point(12, 305);
            this.statusBox.Name = "statusBox";
            this.statusBox.Size = new System.Drawing.Size(624, 74);
            this.statusBox.TabIndex = 8;
            this.statusBox.TabStop = false;
            this.statusBox.Text = "По статусу заявки";
            // 
            // statusComboBox
            // 
            this.statusComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.statusComboBox.FormattingEnabled = true;
            this.statusComboBox.Location = new System.Drawing.Point(19, 26);
            this.statusComboBox.Name = "statusComboBox";
            this.statusComboBox.Size = new System.Drawing.Size(583, 28);
            this.statusComboBox.TabIndex = 0;
            // 
            // close
            // 
            this.close.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.close.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.close.Location = new System.Drawing.Point(495, 399);
            this.close.Name = "close";
            this.close.Size = new System.Drawing.Size(141, 29);
            this.close.TabIndex = 13;
            this.close.Text = "Закрыть";
            this.close.UseVisualStyleBackColor = false;
            // 
            // reset
            // 
            this.reset.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(200)))));
            this.reset.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.reset.Location = new System.Drawing.Point(257, 399);
            this.reset.Name = "reset";
            this.reset.Size = new System.Drawing.Size(141, 29);
            this.reset.TabIndex = 12;
            this.reset.Text = "Сбросить";
            this.reset.UseVisualStyleBackColor = false;
            // 
            // apply
            // 
            this.apply.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(255)))), ((int)(((byte)(200)))));
            this.apply.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.apply.Location = new System.Drawing.Point(12, 399);
            this.apply.Name = "apply";
            this.apply.Size = new System.Drawing.Size(141, 29);
            this.apply.TabIndex = 11;
            this.apply.Text = "Применить";
            this.apply.UseVisualStyleBackColor = false;
            // 
            // AppFilter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(648, 445);
            this.Controls.Add(this.close);
            this.Controls.Add(this.reset);
            this.Controls.Add(this.apply);
            this.Controls.Add(this.statusBox);
            this.Controls.Add(this.applicantBox);
            this.Controls.Add(this.localityBox);
            this.Controls.Add(this.dateBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "AppFilter";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Фильтры: Заявки на отлов";
            this.dateBox.ResumeLayout(false);
            this.dateBox.PerformLayout();
            this.localityBox.ResumeLayout(false);
            this.applicantBox.ResumeLayout(false);
            this.statusBox.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private GroupBox dateBox;
        private Label toDateLabel;
        private DateTimePicker toDate;
        private Label fromDateLabel;
        private DateTimePicker fromDate;
        private GroupBox localityBox;
        private ComboBox localityComboBox;
        private GroupBox applicantBox;
        private ComboBox applicantComboBox;
        private GroupBox statusBox;
        private ComboBox statusComboBox;
        private Button close;
        private Button reset;
        private Button apply;
    }
}