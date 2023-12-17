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
            dateBox=new GroupBox();
            toDateLabel=new Label();
            toDate=new DateTimePicker();
            fromDateLabel=new Label();
            fromDate=new DateTimePicker();
            localityBox=new GroupBox();
            localityComboBox=new ComboBox();
            applicantBox=new GroupBox();
            applicantComboBox=new ComboBox();
            statusBox=new GroupBox();
            statusComboBox=new ComboBox();
            close=new Button();
            reset=new Button();
            apply=new Button();
            dateBox.SuspendLayout();
            localityBox.SuspendLayout();
            applicantBox.SuspendLayout();
            statusBox.SuspendLayout();
            SuspendLayout();
            // 
            // dateBox
            // 
            dateBox.BackColor=Color.Wheat;
            dateBox.Controls.Add(toDateLabel);
            dateBox.Controls.Add(toDate);
            dateBox.Controls.Add(fromDateLabel);
            dateBox.Controls.Add(fromDate);
            dateBox.Cursor=Cursors.PanNW;
            dateBox.Font=new Font("Segoe Print", 10F, FontStyle.Bold, GraphicsUnit.Point);
            dateBox.Location=new Point(12, 12);
            dateBox.Name="dateBox";
            dateBox.Size=new Size(624, 89);
            dateBox.TabIndex=6;
            dateBox.TabStop=false;
            dateBox.Text="По дате заявки";
            // 
            // toDateLabel
            // 
            toDateLabel.AutoSize=true;
            toDateLabel.Font=new Font("Segoe Print", 10F, FontStyle.Bold, GraphicsUnit.Point);
            toDateLabel.Location=new Point(331, 42);
            toDateLabel.Name="toDateLabel";
            toDateLabel.Size=new Size(44, 30);
            toDateLabel.TabIndex=3;
            toDateLabel.Text="До:";
            // 
            // toDate
            // 
            toDate.CalendarMonthBackground=Color.OldLace;
            toDate.Font=new Font("Segoe Print", 10F, FontStyle.Bold, GraphicsUnit.Point);
            toDate.Location=new Point(381, 37);
            toDate.Name="toDate";
            toDate.Size=new Size(221, 37);
            toDate.TabIndex=2;
            // 
            // fromDateLabel
            // 
            fromDateLabel.AutoSize=true;
            fromDateLabel.Font=new Font("Segoe Print", 10F, FontStyle.Bold, GraphicsUnit.Point);
            fromDateLabel.Location=new Point(19, 42);
            fromDateLabel.Name="fromDateLabel";
            fromDateLabel.Size=new Size(50, 30);
            fromDateLabel.TabIndex=1;
            fromDateLabel.Text="От:";
            // 
            // fromDate
            // 
            fromDate.CalendarMonthBackground=Color.OldLace;
            fromDate.Font=new Font("Segoe Print", 10F, FontStyle.Bold, GraphicsUnit.Point);
            fromDate.Location=new Point(75, 37);
            fromDate.Name="fromDate";
            fromDate.Size=new Size(221, 37);
            fromDate.TabIndex=0;
            // 
            // localityBox
            // 
            localityBox.BackColor=Color.Wheat;
            localityBox.Controls.Add(localityComboBox);
            localityBox.Cursor=Cursors.PanNW;
            localityBox.Font=new Font("Segoe Print", 10F, FontStyle.Bold, GraphicsUnit.Point);
            localityBox.Location=new Point(12, 119);
            localityBox.Name="localityBox";
            localityBox.Size=new Size(624, 74);
            localityBox.TabIndex=7;
            localityBox.TabStop=false;
            localityBox.Text="По населенному пункту";
            // 
            // localityComboBox
            // 
            localityComboBox.BackColor=Color.OldLace;
            localityComboBox.DropDownStyle=ComboBoxStyle.DropDownList;
            localityComboBox.FlatStyle=FlatStyle.Popup;
            localityComboBox.Font=new Font("Segoe Print", 10F, FontStyle.Bold, GraphicsUnit.Point);
            localityComboBox.FormattingEnabled=true;
            localityComboBox.Location=new Point(19, 26);
            localityComboBox.Name="localityComboBox";
            localityComboBox.Size=new Size(583, 38);
            localityComboBox.TabIndex=0;
            // 
            // applicantBox
            // 
            applicantBox.BackColor=Color.Wheat;
            applicantBox.Controls.Add(applicantComboBox);
            applicantBox.Cursor=Cursors.PanNW;
            applicantBox.Font=new Font("Segoe Print", 10F, FontStyle.Bold, GraphicsUnit.Point);
            applicantBox.Location=new Point(12, 212);
            applicantBox.Name="applicantBox";
            applicantBox.Size=new Size(624, 74);
            applicantBox.TabIndex=8;
            applicantBox.TabStop=false;
            applicantBox.Text="По категории заявителя";
            // 
            // applicantComboBox
            // 
            applicantComboBox.BackColor=Color.OldLace;
            applicantComboBox.DropDownStyle=ComboBoxStyle.DropDownList;
            applicantComboBox.FlatStyle=FlatStyle.Popup;
            applicantComboBox.Font=new Font("Segoe Print", 10F, FontStyle.Bold, GraphicsUnit.Point);
            applicantComboBox.FormattingEnabled=true;
            applicantComboBox.Location=new Point(19, 26);
            applicantComboBox.Name="applicantComboBox";
            applicantComboBox.Size=new Size(583, 38);
            applicantComboBox.TabIndex=0;
            // 
            // statusBox
            // 
            statusBox.BackColor=Color.Wheat;
            statusBox.Controls.Add(statusComboBox);
            statusBox.Cursor=Cursors.PanNW;
            statusBox.Font=new Font("Segoe Print", 10F, FontStyle.Bold, GraphicsUnit.Point);
            statusBox.Location=new Point(12, 305);
            statusBox.Name="statusBox";
            statusBox.Size=new Size(624, 74);
            statusBox.TabIndex=8;
            statusBox.TabStop=false;
            statusBox.Text="По статусу заявки";
            // 
            // statusComboBox
            // 
            statusComboBox.BackColor=Color.OldLace;
            statusComboBox.DropDownStyle=ComboBoxStyle.DropDownList;
            statusComboBox.FlatStyle=FlatStyle.Popup;
            statusComboBox.Font=new Font("Segoe Print", 10F, FontStyle.Bold, GraphicsUnit.Point);
            statusComboBox.FormattingEnabled=true;
            statusComboBox.Location=new Point(19, 26);
            statusComboBox.Name="statusComboBox";
            statusComboBox.Size=new Size(583, 38);
            statusComboBox.TabIndex=0;
            // 
            // close
            // 
            close.BackColor=Color.Wheat;
            close.Cursor=Cursors.PanNW;
            close.FlatStyle=FlatStyle.Flat;
            close.Font=new Font("Segoe Print", 10F, FontStyle.Bold, GraphicsUnit.Point);
            close.Location=new Point(495, 399);
            close.Name="close";
            close.Size=new Size(141, 40);
            close.TabIndex=13;
            close.Text="Закрыть";
            close.UseVisualStyleBackColor=false;
            // 
            // reset
            // 
            reset.BackColor=Color.Wheat;
            reset.Cursor=Cursors.PanNW;
            reset.FlatStyle=FlatStyle.Flat;
            reset.Font=new Font("Segoe Print", 10F, FontStyle.Bold, GraphicsUnit.Point);
            reset.Location=new Point(257, 399);
            reset.Name="reset";
            reset.Size=new Size(141, 40);
            reset.TabIndex=12;
            reset.Text="Сбросить";
            reset.UseVisualStyleBackColor=false;
            // 
            // apply
            // 
            apply.BackColor=Color.Wheat;
            apply.Cursor=Cursors.PanNW;
            apply.FlatStyle=FlatStyle.Flat;
            apply.Font=new Font("Segoe Print", 10F, FontStyle.Bold, GraphicsUnit.Point);
            apply.Location=new Point(12, 399);
            apply.Name="apply";
            apply.Size=new Size(141, 40);
            apply.TabIndex=11;
            apply.Text="Применить";
            apply.UseVisualStyleBackColor=false;
            // 
            // AppFilter
            // 
            AutoScaleDimensions=new SizeF(8F, 20F);
            AutoScaleMode=AutoScaleMode.Font;
            BackColor=Color.Tan;
            ClientSize=new Size(648, 456);
            Controls.Add(close);
            Controls.Add(reset);
            Controls.Add(apply);
            Controls.Add(statusBox);
            Controls.Add(applicantBox);
            Controls.Add(localityBox);
            Controls.Add(dateBox);
            FormBorderStyle=FormBorderStyle.FixedSingle;
            MaximizeBox=false;
            Name="AppFilter";
            ShowIcon=false;
            StartPosition=FormStartPosition.CenterParent;
            Text="Фильтры: Заявки на отлов";
            dateBox.ResumeLayout(false);
            dateBox.PerformLayout();
            localityBox.ResumeLayout(false);
            applicantBox.ResumeLayout(false);
            statusBox.ResumeLayout(false);
            ResumeLayout(false);
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