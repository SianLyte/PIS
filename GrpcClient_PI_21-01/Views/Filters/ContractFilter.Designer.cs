namespace GrpcClient_PI_21_01.Views.Filters
{
    partial class ContractFilter
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
            this.showContractAll = new System.Windows.Forms.RadioButton();
            this.showContractActive = new System.Windows.Forms.RadioButton();
            this.showContractExpired = new System.Windows.Forms.RadioButton();
            this.regDate = new System.Windows.Forms.DateTimePicker();
            this.regDateBox = new System.Windows.Forms.GroupBox();
            this.regEqual = new System.Windows.Forms.RadioButton();
            this.regMore = new System.Windows.Forms.RadioButton();
            this.regLess = new System.Windows.Forms.RadioButton();
            this.enableRegistrationDateFilter = new System.Windows.Forms.CheckBox();
            this.expDateBox = new System.Windows.Forms.GroupBox();
            this.expLess = new System.Windows.Forms.RadioButton();
            this.expMore = new System.Windows.Forms.RadioButton();
            this.expEqual = new System.Windows.Forms.RadioButton();
            this.expDate = new System.Windows.Forms.DateTimePicker();
            this.enableExpirationDateFilter = new System.Windows.Forms.CheckBox();
            this.performerBox = new System.Windows.Forms.GroupBox();
            this.performerComboBox = new System.Windows.Forms.ComboBox();
            this.customerBox = new System.Windows.Forms.GroupBox();
            this.customerComboBox = new System.Windows.Forms.ComboBox();
            this.close = new System.Windows.Forms.Button();
            this.reset = new System.Windows.Forms.Button();
            this.apply = new System.Windows.Forms.Button();
            this.dateBox.SuspendLayout();
            this.regDateBox.SuspendLayout();
            this.expDateBox.SuspendLayout();
            this.performerBox.SuspendLayout();
            this.customerBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // dateBox
            // 
            this.dateBox.Controls.Add(this.enableExpirationDateFilter);
            this.dateBox.Controls.Add(this.expDateBox);
            this.dateBox.Controls.Add(this.enableRegistrationDateFilter);
            this.dateBox.Controls.Add(this.regDateBox);
            this.dateBox.Controls.Add(this.showContractExpired);
            this.dateBox.Controls.Add(this.showContractActive);
            this.dateBox.Controls.Add(this.showContractAll);
            this.dateBox.Location = new System.Drawing.Point(12, 12);
            this.dateBox.Name = "dateBox";
            this.dateBox.Size = new System.Drawing.Size(624, 354);
            this.dateBox.TabIndex = 0;
            this.dateBox.TabStop = false;
            this.dateBox.Text = "По дате контракта";
            // 
            // showContractAll
            // 
            this.showContractAll.AutoSize = true;
            this.showContractAll.Location = new System.Drawing.Point(25, 26);
            this.showContractAll.Name = "showContractAll";
            this.showContractAll.Size = new System.Drawing.Size(216, 24);
            this.showContractAll.TabIndex = 0;
            this.showContractAll.Text = "Показывать все контракты";
            this.showContractAll.UseVisualStyleBackColor = true;
            // 
            // showContractActive
            // 
            this.showContractActive.AutoSize = true;
            this.showContractActive.Location = new System.Drawing.Point(25, 56);
            this.showContractActive.Name = "showContractActive";
            this.showContractActive.Size = new System.Drawing.Size(338, 24);
            this.showContractActive.TabIndex = 1;
            this.showContractActive.Text = "Показывать только действующие контракты";
            this.showContractActive.UseVisualStyleBackColor = true;
            // 
            // showContractExpired
            // 
            this.showContractExpired.AutoSize = true;
            this.showContractExpired.Location = new System.Drawing.Point(25, 86);
            this.showContractExpired.Name = "showContractExpired";
            this.showContractExpired.Size = new System.Drawing.Size(310, 24);
            this.showContractExpired.TabIndex = 2;
            this.showContractExpired.Text = "Показывать только истекшие контракты";
            this.showContractExpired.UseVisualStyleBackColor = true;
            // 
            // regDate
            // 
            this.regDate.Location = new System.Drawing.Point(21, 26);
            this.regDate.Name = "regDate";
            this.regDate.Size = new System.Drawing.Size(177, 27);
            this.regDate.TabIndex = 3;
            // 
            // regDateBox
            // 
            this.regDateBox.Controls.Add(this.regLess);
            this.regDateBox.Controls.Add(this.regMore);
            this.regDateBox.Controls.Add(this.regEqual);
            this.regDateBox.Controls.Add(this.regDate);
            this.regDateBox.Location = new System.Drawing.Point(25, 174);
            this.regDateBox.Name = "regDateBox";
            this.regDateBox.Size = new System.Drawing.Size(252, 160);
            this.regDateBox.TabIndex = 4;
            this.regDateBox.TabStop = false;
            this.regDateBox.Text = "Дата регистрации";
            // 
            // regEqual
            // 
            this.regEqual.AutoSize = true;
            this.regEqual.Location = new System.Drawing.Point(21, 59);
            this.regEqual.Name = "regEqual";
            this.regEqual.Size = new System.Drawing.Size(72, 24);
            this.regEqual.TabIndex = 4;
            this.regEqual.TabStop = true;
            this.regEqual.Tag = "Equals";
            this.regEqual.Text = "Равно";
            this.regEqual.UseVisualStyleBackColor = true;
            // 
            // regMore
            // 
            this.regMore.AutoSize = true;
            this.regMore.Location = new System.Drawing.Point(21, 89);
            this.regMore.Name = "regMore";
            this.regMore.Size = new System.Drawing.Size(84, 24);
            this.regMore.TabIndex = 5;
            this.regMore.TabStop = true;
            this.regMore.Tag = "GreaterThan";
            this.regMore.Text = "Больше";
            this.regMore.UseVisualStyleBackColor = true;
            // 
            // regLess
            // 
            this.regLess.AutoSize = true;
            this.regLess.Location = new System.Drawing.Point(21, 119);
            this.regLess.Name = "regLess";
            this.regLess.Size = new System.Drawing.Size(88, 24);
            this.regLess.TabIndex = 6;
            this.regLess.TabStop = true;
            this.regLess.Tag = "LesserThan";
            this.regLess.Text = "Меньше";
            this.regLess.UseVisualStyleBackColor = true;
            // 
            // enableRegistrationDateFilter
            // 
            this.enableRegistrationDateFilter.AutoSize = true;
            this.enableRegistrationDateFilter.Location = new System.Drawing.Point(25, 144);
            this.enableRegistrationDateFilter.Name = "enableRegistrationDateFilter";
            this.enableRegistrationDateFilter.Size = new System.Drawing.Size(152, 24);
            this.enableRegistrationDateFilter.TabIndex = 5;
            this.enableRegistrationDateFilter.Text = "Включить фильтр";
            this.enableRegistrationDateFilter.UseVisualStyleBackColor = true;
            // 
            // expDateBox
            // 
            this.expDateBox.Controls.Add(this.expLess);
            this.expDateBox.Controls.Add(this.expMore);
            this.expDateBox.Controls.Add(this.expEqual);
            this.expDateBox.Controls.Add(this.expDate);
            this.expDateBox.Location = new System.Drawing.Point(346, 174);
            this.expDateBox.Name = "expDateBox";
            this.expDateBox.Size = new System.Drawing.Size(252, 160);
            this.expDateBox.TabIndex = 7;
            this.expDateBox.TabStop = false;
            this.expDateBox.Text = "Дата истечения";
            // 
            // expLess
            // 
            this.expLess.AutoSize = true;
            this.expLess.Location = new System.Drawing.Point(21, 119);
            this.expLess.Name = "expLess";
            this.expLess.Size = new System.Drawing.Size(88, 24);
            this.expLess.TabIndex = 6;
            this.expLess.TabStop = true;
            this.expLess.Tag = "LesserThan";
            this.expLess.Text = "Меньше";
            this.expLess.UseVisualStyleBackColor = true;
            // 
            // expMore
            // 
            this.expMore.AutoSize = true;
            this.expMore.Location = new System.Drawing.Point(21, 89);
            this.expMore.Name = "expMore";
            this.expMore.Size = new System.Drawing.Size(84, 24);
            this.expMore.TabIndex = 5;
            this.expMore.TabStop = true;
            this.expMore.Tag = "GreaterThan";
            this.expMore.Text = "Больше";
            this.expMore.UseVisualStyleBackColor = true;
            // 
            // expEqual
            // 
            this.expEqual.AutoSize = true;
            this.expEqual.Location = new System.Drawing.Point(21, 59);
            this.expEqual.Name = "expEqual";
            this.expEqual.Size = new System.Drawing.Size(72, 24);
            this.expEqual.TabIndex = 4;
            this.expEqual.TabStop = true;
            this.expEqual.Tag = "Equals";
            this.expEqual.Text = "Равно";
            this.expEqual.UseVisualStyleBackColor = true;
            // 
            // expDate
            // 
            this.expDate.Location = new System.Drawing.Point(21, 26);
            this.expDate.Name = "expDate";
            this.expDate.Size = new System.Drawing.Size(177, 27);
            this.expDate.TabIndex = 3;
            // 
            // enableExpirationDateFilter
            // 
            this.enableExpirationDateFilter.AutoSize = true;
            this.enableExpirationDateFilter.Location = new System.Drawing.Point(346, 144);
            this.enableExpirationDateFilter.Name = "enableExpirationDateFilter";
            this.enableExpirationDateFilter.Size = new System.Drawing.Size(152, 24);
            this.enableExpirationDateFilter.TabIndex = 8;
            this.enableExpirationDateFilter.Text = "Включить фильтр";
            this.enableExpirationDateFilter.UseVisualStyleBackColor = true;
            // 
            // performerBox
            // 
            this.performerBox.Controls.Add(this.performerComboBox);
            this.performerBox.Location = new System.Drawing.Point(12, 387);
            this.performerBox.Name = "performerBox";
            this.performerBox.Size = new System.Drawing.Size(624, 83);
            this.performerBox.TabIndex = 1;
            this.performerBox.TabStop = false;
            this.performerBox.Text = "По исполнителю";
            // 
            // performerComboBox
            // 
            this.performerComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.performerComboBox.FormattingEnabled = true;
            this.performerComboBox.Location = new System.Drawing.Point(25, 32);
            this.performerComboBox.Name = "performerComboBox";
            this.performerComboBox.Size = new System.Drawing.Size(573, 28);
            this.performerComboBox.TabIndex = 0;
            // 
            // customerBox
            // 
            this.customerBox.Controls.Add(this.customerComboBox);
            this.customerBox.Location = new System.Drawing.Point(12, 489);
            this.customerBox.Name = "customerBox";
            this.customerBox.Size = new System.Drawing.Size(624, 97);
            this.customerBox.TabIndex = 2;
            this.customerBox.TabStop = false;
            this.customerBox.Text = "По заказчику";
            // 
            // customerComboBox
            // 
            this.customerComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.customerComboBox.FormattingEnabled = true;
            this.customerComboBox.Location = new System.Drawing.Point(25, 40);
            this.customerComboBox.Name = "customerComboBox";
            this.customerComboBox.Size = new System.Drawing.Size(573, 28);
            this.customerComboBox.TabIndex = 0;
            // 
            // close
            // 
            this.close.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.close.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.close.Location = new System.Drawing.Point(495, 607);
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
            this.reset.Location = new System.Drawing.Point(253, 607);
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
            this.apply.Location = new System.Drawing.Point(12, 607);
            this.apply.Name = "apply";
            this.apply.Size = new System.Drawing.Size(141, 29);
            this.apply.TabIndex = 11;
            this.apply.Text = "Применить";
            this.apply.UseVisualStyleBackColor = false;
            // 
            // ContractFilter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(648, 652);
            this.Controls.Add(this.close);
            this.Controls.Add(this.reset);
            this.Controls.Add(this.apply);
            this.Controls.Add(this.customerBox);
            this.Controls.Add(this.performerBox);
            this.Controls.Add(this.dateBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "ContractFilter";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Фильтры: Контракты";
            this.dateBox.ResumeLayout(false);
            this.dateBox.PerformLayout();
            this.regDateBox.ResumeLayout(false);
            this.regDateBox.PerformLayout();
            this.expDateBox.ResumeLayout(false);
            this.expDateBox.PerformLayout();
            this.performerBox.ResumeLayout(false);
            this.customerBox.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private GroupBox dateBox;
        private RadioButton showContractExpired;
        private RadioButton showContractActive;
        private RadioButton showContractAll;
        private GroupBox regDateBox;
        private RadioButton regEqual;
        private DateTimePicker regDate;
        private CheckBox enableRegistrationDateFilter;
        private RadioButton regLess;
        private RadioButton regMore;
        private GroupBox expDateBox;
        private RadioButton expLess;
        private RadioButton expMore;
        private RadioButton expEqual;
        private DateTimePicker expDate;
        private CheckBox enableExpirationDateFilter;
        private GroupBox performerBox;
        private ComboBox performerComboBox;
        private GroupBox customerBox;
        private ComboBox customerComboBox;
        private Button close;
        private Button reset;
        private Button apply;
    }
}