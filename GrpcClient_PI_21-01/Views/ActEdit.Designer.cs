
namespace GrpcClient_PI_21_01.Views
{
    partial class ActEdit
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ActEdit));
            label1=new Label();
            Cancel=new Button();
            OK=new Button();
            label2=new Label();
            label3=new Label();
            label4=new Label();
            dateAct=new DateTimePicker();
            comboBoxOrganization=new ComboBox();
            comboBoxContract=new ComboBox();
            comboBoxApp=new ComboBox();
            label5=new Label();
            textBoxTarget=new TextBox();
            R=new Label();
            label7=new Label();
            Isus=new Label();
            numericUpDownDog=new NumericUpDown();
            numericUpDownCat=new NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)numericUpDownDog).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDownCat).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize=true;
            label1.Location=new Point(26, 310);
            label1.Margin=new Padding(6, 0, 6, 0);
            label1.Name="label1";
            label1.Size=new Size(66, 30);
            label1.TabIndex=0;
            label1.Text="Дата";
            // 
            // Cancel
            // 
            Cancel.BackColor=Color.Cornsilk;
            Cancel.DialogResult=DialogResult.Cancel;
            Cancel.FlatStyle=FlatStyle.Popup;
            Cancel.Location=new Point(377, 579);
            Cancel.Margin=new Padding(6, 9, 6, 9);
            Cancel.Name="Cancel";
            Cancel.Size=new Size(162, 61);
            Cancel.TabIndex=1;
            Cancel.Text="Cancel";
            Cancel.UseVisualStyleBackColor=false;
            // 
            // OK
            // 
            OK.BackColor=Color.Cornsilk;
            OK.FlatStyle=FlatStyle.Popup;
            OK.Location=new Point(202, 579);
            OK.Margin=new Padding(6, 9, 6, 9);
            OK.Name="OK";
            OK.Size=new Size(162, 61);
            OK.TabIndex=2;
            OK.Text="OK";
            OK.UseVisualStyleBackColor=false;
            OK.Click+=OK_Click;
            // 
            // label2
            // 
            label2.AutoSize=true;
            label2.Location=new Point(26, 229);
            label2.Margin=new Padding(6, 0, 6, 0);
            label2.Name="label2";
            label2.Size=new Size(124, 30);
            label2.TabIndex=7;
            label2.Text="Организация";
            // 
            // label3
            // 
            label3.AutoSize=true;
            label3.Location=new Point(26, 514);
            label3.Margin=new Padding(6, 0, 6, 0);
            label3.Name="label3";
            label3.Size=new Size(127, 30);
            label3.TabIndex=8;
            label3.Text="Контракты";
            // 
            // label4
            // 
            label4.AutoSize=true;
            label4.Location=new Point(26, 441);
            label4.Margin=new Padding(6, 0, 6, 0);
            label4.Name="label4";
            label4.Size=new Size(72, 30);
            label4.TabIndex=9;
            label4.Text="Заявка";
            // 
            // dateAct
            // 
            dateAct.CalendarMonthBackground=Color.Cornsilk;
            dateAct.CalendarTitleBackColor=Color.Cornsilk;
            dateAct.CalendarTrailingForeColor=SystemColors.ControlText;
            dateAct.Cursor=Cursors.PanNW;
            dateAct.Location=new Point(283, 294);
            dateAct.Margin=new Padding(6, 9, 6, 9);
            dateAct.Name="dateAct";
            dateAct.Size=new Size(250, 37);
            dateAct.TabIndex=11;
            dateAct.Value=new DateTime(2023, 6, 10, 0, 0, 0, 0);
            // 
            // comboBoxOrganization
            // 
            comboBoxOrganization.BackColor=Color.OldLace;
            comboBoxOrganization.Cursor=Cursors.PanNW;
            comboBoxOrganization.DropDownStyle=ComboBoxStyle.DropDownList;
            comboBoxOrganization.FlatStyle=FlatStyle.Popup;
            comboBoxOrganization.FormattingEnabled=true;
            comboBoxOrganization.Location=new Point(283, 220);
            comboBoxOrganization.Margin=new Padding(6, 9, 6, 9);
            comboBoxOrganization.Name="comboBoxOrganization";
            comboBoxOrganization.Size=new Size(250, 38);
            comboBoxOrganization.TabIndex=13;
            // 
            // comboBoxContract
            // 
            comboBoxContract.BackColor=Color.OldLace;
            comboBoxContract.Cursor=Cursors.PanNW;
            comboBoxContract.DropDownStyle=ComboBoxStyle.DropDownList;
            comboBoxContract.FlatStyle=FlatStyle.Popup;
            comboBoxContract.FormattingEnabled=true;
            comboBoxContract.Location=new Point(283, 506);
            comboBoxContract.Margin=new Padding(6, 9, 6, 9);
            comboBoxContract.Name="comboBoxContract";
            comboBoxContract.Size=new Size(251, 38);
            comboBoxContract.TabIndex=14;
            // 
            // comboBoxApp
            // 
            comboBoxApp.BackColor=Color.OldLace;
            comboBoxApp.Cursor=Cursors.PanNW;
            comboBoxApp.DropDownStyle=ComboBoxStyle.DropDownList;
            comboBoxApp.FlatStyle=FlatStyle.Popup;
            comboBoxApp.FormattingEnabled=true;
            comboBoxApp.Location=new Point(283, 434);
            comboBoxApp.Margin=new Padding(6, 9, 6, 9);
            comboBoxApp.Name="comboBoxApp";
            comboBoxApp.Size=new Size(251, 38);
            comboBoxApp.TabIndex=15;
            comboBoxApp.SelectedIndexChanged+=comboBoxApp_SelectedIndexChanged;
            // 
            // label5
            // 
            label5.AutoSize=true;
            label5.Location=new Point(26, 371);
            label5.Margin=new Padding(6, 0, 6, 0);
            label5.Name="label5";
            label5.Size=new Size(129, 30);
            label5.TabIndex=16;
            label5.Text="Цель отлова";
            // 
            // textBoxTarget
            // 
            textBoxTarget.BackColor=Color.OldLace;
            textBoxTarget.BorderStyle=BorderStyle.None;
            textBoxTarget.Location=new Point(283, 364);
            textBoxTarget.Margin=new Padding(6, 9, 6, 9);
            textBoxTarget.Name="textBoxTarget";
            textBoxTarget.Size=new Size(251, 30);
            textBoxTarget.TabIndex=17;
            // 
            // R
            // 
            R.AutoSize=true;
            R.Location=new Point(26, 159);
            R.Margin=new Padding(6, 0, 6, 0);
            R.Name="R";
            R.Size=new Size(183, 30);
            R.TabIndex=20;
            R.Text="Количество кошек";
            // 
            // label7
            // 
            label7.AutoSize=true;
            label7.Location=new Point(26, 89);
            label7.Margin=new Padding(6, 0, 6, 0);
            label7.Name="label7";
            label7.Size=new Size(177, 30);
            label7.TabIndex=21;
            label7.Text="Количество собак";
            // 
            // Isus
            // 
            Isus.AutoSize=true;
            Isus.Location=new Point(133, 24);
            Isus.Margin=new Padding(6, 0, 6, 0);
            Isus.Name="Isus";
            Isus.Size=new Size(55, 30);
            Isus.TabIndex=22;
            Isus.Text="Акт";
            // 
            // numericUpDownDog
            // 
            numericUpDownDog.BackColor=Color.OldLace;
            numericUpDownDog.Location=new Point(403, 86);
            numericUpDownDog.Margin=new Padding(6, 9, 6, 9);
            numericUpDownDog.Name="numericUpDownDog";
            numericUpDownDog.Size=new Size(136, 37);
            numericUpDownDog.TabIndex=23;
            // 
            // numericUpDownCat
            // 
            numericUpDownCat.BackColor=Color.OldLace;
            numericUpDownCat.Location=new Point(402, 150);
            numericUpDownCat.Margin=new Padding(6, 9, 6, 9);
            numericUpDownCat.Name="numericUpDownCat";
            numericUpDownCat.Size=new Size(136, 37);
            numericUpDownCat.TabIndex=24;
            // 
            // ActEdit
            // 
            AutoScaleDimensions=new SizeF(11F, 30F);
            AutoScaleMode=AutoScaleMode.Font;
            BackColor=Color.Wheat;
            ClientSize=new Size(555, 662);
            Controls.Add(numericUpDownCat);
            Controls.Add(numericUpDownDog);
            Controls.Add(Isus);
            Controls.Add(label7);
            Controls.Add(R);
            Controls.Add(textBoxTarget);
            Controls.Add(label5);
            Controls.Add(comboBoxApp);
            Controls.Add(comboBoxContract);
            Controls.Add(comboBoxOrganization);
            Controls.Add(dateAct);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(OK);
            Controls.Add(Cancel);
            Controls.Add(label1);
            Font=new Font("Segoe Print", 10F, FontStyle.Bold, GraphicsUnit.Point);
            Icon=(Icon)resources.GetObject("$this.Icon");
            Margin=new Padding(6, 9, 6, 9);
            Name="ActEdit";
            StartPosition=FormStartPosition.CenterScreen;
            Text="Акт";
            ((System.ComponentModel.ISupportInitialize)numericUpDownDog).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDownCat).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Button Cancel;
        private Button OK;
        private Label label2;
        private Label label3;
        private Label label4;
        private DateTimePicker dateAct;
        private ComboBox comboBoxOrganization;
        private ComboBox comboBoxContract;
        private ComboBox comboBoxApp;
        private Label label5;
        private TextBox textBoxTarget;
        private Label R;
        private Label label7;
        private Label Isus;
        private NumericUpDown numericUpDownDog;
        private NumericUpDown numericUpDownCat;
    }
}