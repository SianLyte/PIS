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
            dateBox=new GroupBox();
            enableExpirationDateFilter=new CheckBox();
            expDateBox=new GroupBox();
            expLess=new RadioButton();
            expMore=new RadioButton();
            expEqual=new RadioButton();
            expDate=new DateTimePicker();
            enableRegistrationDateFilter=new CheckBox();
            regDateBox=new GroupBox();
            regLess=new RadioButton();
            regMore=new RadioButton();
            regEqual=new RadioButton();
            regDate=new DateTimePicker();
            showContractExpired=new RadioButton();
            showContractActive=new RadioButton();
            showContractAll=new RadioButton();
            performerBox=new GroupBox();
            performerComboBox=new ComboBox();
            customerBox=new GroupBox();
            customerComboBox=new ComboBox();
            close=new Button();
            reset=new Button();
            apply=new Button();
            dateBox.SuspendLayout();
            expDateBox.SuspendLayout();
            regDateBox.SuspendLayout();
            performerBox.SuspendLayout();
            customerBox.SuspendLayout();
            SuspendLayout();
            // 
            // dateBox
            // 
            dateBox.BackColor=Color.Wheat;
            dateBox.Controls.Add(enableExpirationDateFilter);
            dateBox.Controls.Add(expDateBox);
            dateBox.Controls.Add(enableRegistrationDateFilter);
            dateBox.Controls.Add(regDateBox);
            dateBox.Controls.Add(showContractExpired);
            dateBox.Controls.Add(showContractActive);
            dateBox.Controls.Add(showContractAll);
            dateBox.FlatStyle=FlatStyle.Popup;
            dateBox.Font=new Font("Segoe Print", 10F, FontStyle.Bold, GraphicsUnit.Point);
            dateBox.Location=new Point(12, 12);
            dateBox.Name="dateBox";
            dateBox.Size=new Size(624, 385);
            dateBox.TabIndex=0;
            dateBox.TabStop=false;
            dateBox.Text="По дате контракта";
            // 
            // enableExpirationDateFilter
            // 
            enableExpirationDateFilter.AutoSize=true;
            enableExpirationDateFilter.Font=new Font("Segoe Print", 10F, FontStyle.Bold, GraphicsUnit.Point);
            enableExpirationDateFilter.Location=new Point(346, 146);
            enableExpirationDateFilter.Name="enableExpirationDateFilter";
            enableExpirationDateFilter.Size=new Size(207, 34);
            enableExpirationDateFilter.TabIndex=8;
            enableExpirationDateFilter.Text="Включить фильтр";
            enableExpirationDateFilter.UseVisualStyleBackColor=true;
            enableExpirationDateFilter.CheckedChanged+=enableExpirationDateFilter_CheckedChanged_1;
            // 
            // expDateBox
            // 
            expDateBox.BackColor=Color.Wheat;
            expDateBox.Controls.Add(expLess);
            expDateBox.Controls.Add(expMore);
            expDateBox.Controls.Add(expEqual);
            expDateBox.Controls.Add(expDate);
            expDateBox.FlatStyle=FlatStyle.Popup;
            expDateBox.Font=new Font("Segoe Print", 10F, FontStyle.Bold, GraphicsUnit.Point);
            expDateBox.Location=new Point(346, 186);
            expDateBox.Name="expDateBox";
            expDateBox.Size=new Size(252, 187);
            expDateBox.TabIndex=7;
            expDateBox.TabStop=false;
            expDateBox.Text="Дата истечения";
            // 
            // expLess
            // 
            expLess.AutoSize=true;
            expLess.Font=new Font("Segoe Print", 10F, FontStyle.Bold, GraphicsUnit.Point);
            expLess.Location=new Point(21, 147);
            expLess.Name="expLess";
            expLess.Size=new Size(103, 34);
            expLess.TabIndex=6;
            expLess.TabStop=true;
            expLess.Tag="LesserThan";
            expLess.Text="Меньше";
            expLess.UseVisualStyleBackColor=true;
            // 
            // expMore
            // 
            expMore.AutoSize=true;
            expMore.Font=new Font("Segoe Print", 10F, FontStyle.Bold, GraphicsUnit.Point);
            expMore.Location=new Point(21, 107);
            expMore.Name="expMore";
            expMore.Size=new Size(99, 34);
            expMore.TabIndex=5;
            expMore.TabStop=true;
            expMore.Tag="GreaterThan";
            expMore.Text="Больше";
            expMore.UseVisualStyleBackColor=true;
            // 
            // expEqual
            // 
            expEqual.AutoSize=true;
            expEqual.Font=new Font("Segoe Print", 10F, FontStyle.Bold, GraphicsUnit.Point);
            expEqual.Location=new Point(21, 69);
            expEqual.Name="expEqual";
            expEqual.Size=new Size(85, 34);
            expEqual.TabIndex=4;
            expEqual.TabStop=true;
            expEqual.Tag="Equals";
            expEqual.Text="Равно";
            expEqual.UseVisualStyleBackColor=true;
            // 
            // expDate
            // 
            expDate.CalendarMonthBackground=Color.OldLace;
            expDate.Font=new Font("Segoe Print", 10F, FontStyle.Bold, GraphicsUnit.Point);
            expDate.Location=new Point(21, 31);
            expDate.Name="expDate";
            expDate.Size=new Size(225, 37);
            expDate.TabIndex=3;
            // 
            // enableRegistrationDateFilter
            // 
            enableRegistrationDateFilter.AutoSize=true;
            enableRegistrationDateFilter.Font=new Font("Segoe Print", 10F, FontStyle.Bold, GraphicsUnit.Point);
            enableRegistrationDateFilter.Location=new Point(25, 146);
            enableRegistrationDateFilter.Name="enableRegistrationDateFilter";
            enableRegistrationDateFilter.Size=new Size(207, 34);
            enableRegistrationDateFilter.TabIndex=5;
            enableRegistrationDateFilter.Text="Включить фильтр";
            enableRegistrationDateFilter.UseVisualStyleBackColor=true;
            // 
            // regDateBox
            // 
            regDateBox.BackColor=Color.Wheat;
            regDateBox.Controls.Add(regLess);
            regDateBox.Controls.Add(regMore);
            regDateBox.Controls.Add(regEqual);
            regDateBox.Controls.Add(regDate);
            regDateBox.FlatStyle=FlatStyle.Popup;
            regDateBox.Font=new Font("Segoe Print", 10F, FontStyle.Bold, GraphicsUnit.Point);
            regDateBox.Location=new Point(25, 186);
            regDateBox.Name="regDateBox";
            regDateBox.Size=new Size(252, 187);
            regDateBox.TabIndex=4;
            regDateBox.TabStop=false;
            regDateBox.Text="Дата регистрации";
            // 
            // regLess
            // 
            regLess.AutoSize=true;
            regLess.Font=new Font("Segoe Print", 10F, FontStyle.Bold, GraphicsUnit.Point);
            regLess.Location=new Point(21, 147);
            regLess.Name="regLess";
            regLess.Size=new Size(103, 34);
            regLess.TabIndex=6;
            regLess.TabStop=true;
            regLess.Tag="LesserThan";
            regLess.Text="Меньше";
            regLess.UseVisualStyleBackColor=true;
            // 
            // regMore
            // 
            regMore.AutoSize=true;
            regMore.Font=new Font("Segoe Print", 10F, FontStyle.Bold, GraphicsUnit.Point);
            regMore.Location=new Point(21, 107);
            regMore.Name="regMore";
            regMore.Size=new Size(99, 34);
            regMore.TabIndex=5;
            regMore.TabStop=true;
            regMore.Tag="GreaterThan";
            regMore.Text="Больше";
            regMore.UseVisualStyleBackColor=true;
            // 
            // regEqual
            // 
            regEqual.AutoSize=true;
            regEqual.Font=new Font("Segoe Print", 10F, FontStyle.Bold, GraphicsUnit.Point);
            regEqual.Location=new Point(21, 69);
            regEqual.Name="regEqual";
            regEqual.Size=new Size(85, 34);
            regEqual.TabIndex=4;
            regEqual.TabStop=true;
            regEqual.Tag="Equals";
            regEqual.Text="Равно";
            regEqual.UseVisualStyleBackColor=true;
            // 
            // regDate
            // 
            regDate.CalendarMonthBackground=Color.OldLace;
            regDate.Font=new Font("Segoe Print", 10F, FontStyle.Bold, GraphicsUnit.Point);
            regDate.Location=new Point(21, 31);
            regDate.Name="regDate";
            regDate.Size=new Size(225, 37);
            regDate.TabIndex=3;
            // 
            // showContractExpired
            // 
            showContractExpired.AutoSize=true;
            showContractExpired.Font=new Font("Segoe Print", 10F, FontStyle.Bold, GraphicsUnit.Point);
            showContractExpired.Location=new Point(25, 106);
            showContractExpired.Name="showContractExpired";
            showContractExpired.Size=new Size(427, 34);
            showContractExpired.TabIndex=2;
            showContractExpired.Text="Показывать только истекшие контракты";
            showContractExpired.UseVisualStyleBackColor=true;
            // 
            // showContractActive
            // 
            showContractActive.AutoSize=true;
            showContractActive.Font=new Font("Segoe Print", 10F, FontStyle.Bold, GraphicsUnit.Point);
            showContractActive.Location=new Point(25, 66);
            showContractActive.Name="showContractActive";
            showContractActive.Size=new Size(461, 34);
            showContractActive.TabIndex=1;
            showContractActive.Text="Показывать только действующие контракты";
            showContractActive.UseVisualStyleBackColor=true;
            // 
            // showContractAll
            // 
            showContractAll.AutoSize=true;
            showContractAll.Font=new Font("Segoe Print", 10F, FontStyle.Bold, GraphicsUnit.Point);
            showContractAll.Location=new Point(25, 26);
            showContractAll.Name="showContractAll";
            showContractAll.Size=new Size(292, 34);
            showContractAll.TabIndex=0;
            showContractAll.Text="Показывать все контракты";
            showContractAll.UseVisualStyleBackColor=true;
            // 
            // performerBox
            // 
            performerBox.BackColor=Color.Wheat;
            performerBox.Controls.Add(performerComboBox);
            performerBox.FlatStyle=FlatStyle.Popup;
            performerBox.Font=new Font("Segoe Print", 10F, FontStyle.Bold, GraphicsUnit.Point);
            performerBox.Location=new Point(12, 415);
            performerBox.Name="performerBox";
            performerBox.Size=new Size(624, 83);
            performerBox.TabIndex=1;
            performerBox.TabStop=false;
            performerBox.Text="По исполнителю";
            // 
            // performerComboBox
            // 
            performerComboBox.BackColor=Color.OldLace;
            performerComboBox.Cursor=Cursors.PanNW;
            performerComboBox.DropDownStyle=ComboBoxStyle.DropDownList;
            performerComboBox.FlatStyle=FlatStyle.Popup;
            performerComboBox.Font=new Font("Segoe Print", 10F, FontStyle.Bold, GraphicsUnit.Point);
            performerComboBox.FormattingEnabled=true;
            performerComboBox.Location=new Point(25, 32);
            performerComboBox.Name="performerComboBox";
            performerComboBox.Size=new Size(573, 38);
            performerComboBox.TabIndex=0;
            // 
            // customerBox
            // 
            customerBox.BackColor=Color.Wheat;
            customerBox.Controls.Add(customerComboBox);
            customerBox.FlatStyle=FlatStyle.Popup;
            customerBox.Font=new Font("Segoe Print", 10F, FontStyle.Bold, GraphicsUnit.Point);
            customerBox.Location=new Point(12, 517);
            customerBox.Name="customerBox";
            customerBox.Size=new Size(624, 97);
            customerBox.TabIndex=2;
            customerBox.TabStop=false;
            customerBox.Text="По заказчику";
            // 
            // customerComboBox
            // 
            customerComboBox.BackColor=Color.OldLace;
            customerComboBox.Cursor=Cursors.PanNW;
            customerComboBox.DropDownStyle=ComboBoxStyle.DropDownList;
            customerComboBox.FlatStyle=FlatStyle.Popup;
            customerComboBox.Font=new Font("Segoe Print", 10F, FontStyle.Bold, GraphicsUnit.Point);
            customerComboBox.FormattingEnabled=true;
            customerComboBox.Location=new Point(25, 40);
            customerComboBox.Name="customerComboBox";
            customerComboBox.Size=new Size(573, 38);
            customerComboBox.TabIndex=0;
            // 
            // close
            // 
            close.BackColor=Color.Wheat;
            close.FlatStyle=FlatStyle.Flat;
            close.Font=new Font("Segoe Print", 10F, FontStyle.Bold, GraphicsUnit.Point);
            close.Location=new Point(495, 620);
            close.Name="close";
            close.Size=new Size(141, 39);
            close.TabIndex=13;
            close.Text="Закрыть";
            close.UseVisualStyleBackColor=false;
            // 
            // reset
            // 
            reset.BackColor=Color.Wheat;
            reset.FlatStyle=FlatStyle.Flat;
            reset.Font=new Font("Segoe Print", 10F, FontStyle.Bold, GraphicsUnit.Point);
            reset.Location=new Point(253, 620);
            reset.Name="reset";
            reset.Size=new Size(141, 39);
            reset.TabIndex=12;
            reset.Text="Сбросить";
            reset.UseVisualStyleBackColor=false;
            // 
            // apply
            // 
            apply.BackColor=Color.Wheat;
            apply.FlatStyle=FlatStyle.Flat;
            apply.Font=new Font("Segoe Print", 10F, FontStyle.Bold, GraphicsUnit.Point);
            apply.Location=new Point(12, 620);
            apply.Name="apply";
            apply.Size=new Size(141, 39);
            apply.TabIndex=11;
            apply.Text="Применить";
            apply.UseVisualStyleBackColor=false;
            // 
            // ContractFilter
            // 
            AutoScaleDimensions=new SizeF(8F, 20F);
            AutoScaleMode=AutoScaleMode.Font;
            BackColor=Color.Tan;
            ClientSize=new Size(648, 674);
            Controls.Add(close);
            Controls.Add(reset);
            Controls.Add(apply);
            Controls.Add(customerBox);
            Controls.Add(performerBox);
            Controls.Add(dateBox);
            Cursor=Cursors.PanNW;
            FormBorderStyle=FormBorderStyle.FixedSingle;
            MaximizeBox=false;
            Name="ContractFilter";
            ShowIcon=false;
            StartPosition=FormStartPosition.CenterParent;
            Text="Фильтры: Контракты";
            dateBox.ResumeLayout(false);
            dateBox.PerformLayout();
            expDateBox.ResumeLayout(false);
            expDateBox.PerformLayout();
            regDateBox.ResumeLayout(false);
            regDateBox.PerformLayout();
            performerBox.ResumeLayout(false);
            customerBox.ResumeLayout(false);
            ResumeLayout(false);
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