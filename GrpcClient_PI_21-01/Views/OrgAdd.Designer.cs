namespace GrpcClient_PI_21_01.Views
{
    partial class OrgAdd
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OrgAdd));
            this.CancelOrgEdit = new System.Windows.Forms.Button();
            this.OKorgAdd = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.KPP = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.INN = new System.Windows.Forms.TextBox();
            this.AdressReg = new System.Windows.Forms.ComboBox();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.orgTypes = new System.Windows.Forms.ComboBox();
            this.orgName = new System.Windows.Forms.TextBox();
            this.statusOrg = new System.Windows.Forms.RadioButton();
            this.statusIndividual = new System.Windows.Forms.RadioButton();
            this.status = new System.Windows.Forms.GroupBox();
            this.status.SuspendLayout();
            this.SuspendLayout();
            // 
            // CancelOrgEdit
            // 
            this.CancelOrgEdit.BackColor = System.Drawing.Color.Cornsilk;
            this.CancelOrgEdit.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.CancelOrgEdit.Location = new System.Drawing.Point(403, 553);
            this.CancelOrgEdit.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.CancelOrgEdit.Name = "CancelOrgEdit";
            this.CancelOrgEdit.Size = new System.Drawing.Size(195, 74);
            this.CancelOrgEdit.TabIndex = 23;
            this.CancelOrgEdit.Text = "Отмена";
            this.CancelOrgEdit.UseVisualStyleBackColor = false;
            // 
            // OKorgAdd
            // 
            this.OKorgAdd.BackColor = System.Drawing.Color.Cornsilk;
            this.OKorgAdd.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.OKorgAdd.Location = new System.Drawing.Point(113, 553);
            this.OKorgAdd.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.OKorgAdd.Name = "OKorgAdd";
            this.OKorgAdd.Size = new System.Drawing.Size(195, 74);
            this.OKorgAdd.TabIndex = 22;
            this.OKorgAdd.Text = "OK";
            this.OKorgAdd.UseVisualStyleBackColor = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(42, 338);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(45, 30);
            this.label4.TabIndex = 20;
            this.label4.Text = "Тип";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(42, 253);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(188, 30);
            this.label3.TabIndex = 19;
            this.label3.Text = "Адрес регистрации";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(42, 181);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 30);
            this.label2.TabIndex = 18;
            this.label2.Text = "КПП";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(42, 37);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(139, 30);
            this.label1.TabIndex = 17;
            this.label1.Text = "Наименование";
            // 
            // KPP
            // 
            this.KPP.BackColor = System.Drawing.Color.OldLace;
            this.KPP.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.KPP.Location = new System.Drawing.Point(298, 181);
            this.KPP.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.KPP.Name = "KPP";
            this.KPP.Size = new System.Drawing.Size(349, 30);
            this.KPP.TabIndex = 13;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(42, 112);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(57, 30);
            this.label6.TabIndex = 25;
            this.label6.Text = "ИНН";
            // 
            // INN
            // 
            this.INN.BackColor = System.Drawing.Color.OldLace;
            this.INN.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.INN.Location = new System.Drawing.Point(298, 112);
            this.INN.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.INN.Name = "INN";
            this.INN.Size = new System.Drawing.Size(349, 30);
            this.INN.TabIndex = 24;
            // 
            // AdressReg
            // 
            this.AdressReg.BackColor = System.Drawing.Color.OldLace;
            this.AdressReg.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.AdressReg.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.AdressReg.FormattingEnabled = true;
            this.AdressReg.Location = new System.Drawing.Point(298, 253);
            this.AdressReg.Name = "AdressReg";
            this.AdressReg.Size = new System.Drawing.Size(349, 38);
            this.AdressReg.TabIndex = 26;
            // 
            // orgTypes
            // 
            this.orgTypes.BackColor = System.Drawing.Color.OldLace;
            this.orgTypes.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.orgTypes.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.orgTypes.FormattingEnabled = true;
            this.orgTypes.Location = new System.Drawing.Point(298, 335);
            this.orgTypes.Name = "orgTypes";
            this.orgTypes.Size = new System.Drawing.Size(349, 38);
            this.orgTypes.TabIndex = 28;
            // 
            // orgName
            // 
            this.orgName.BackColor = System.Drawing.Color.OldLace;
            this.orgName.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.orgName.Location = new System.Drawing.Point(298, 37);
            this.orgName.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.orgName.Name = "orgName";
            this.orgName.Size = new System.Drawing.Size(349, 30);
            this.orgName.TabIndex = 29;
            // 
            // statusOrg
            // 
            this.statusOrg.AutoSize = true;
            this.statusOrg.Checked = true;
            this.statusOrg.Location = new System.Drawing.Point(26, 36);
            this.statusOrg.Name = "statusOrg";
            this.statusOrg.Size = new System.Drawing.Size(194, 34);
            this.statusOrg.TabIndex = 30;
            this.statusOrg.TabStop = true;
            this.statusOrg.Text = "Юридическое лицо";
            this.statusOrg.UseVisualStyleBackColor = true;
            // 
            // statusIndividual
            // 
            this.statusIndividual.AutoSize = true;
            this.statusIndividual.Location = new System.Drawing.Point(26, 76);
            this.statusIndividual.Name = "statusIndividual";
            this.statusIndividual.Size = new System.Drawing.Size(348, 34);
            this.statusIndividual.TabIndex = 31;
            this.statusIndividual.Text = "Индивидуальный предприниматель";
            this.statusIndividual.UseVisualStyleBackColor = true;
            // 
            // status
            // 
            this.status.BackColor = System.Drawing.Color.Wheat;
            this.status.Controls.Add(this.statusIndividual);
            this.status.Controls.Add(this.statusOrg);
            this.status.Location = new System.Drawing.Point(42, 396);
            this.status.Name = "status";
            this.status.Size = new System.Drawing.Size(604, 137);
            this.status.TabIndex = 32;
            this.status.TabStop = false;
            this.status.Text = "Статус";
            // 
            // OrgAdd
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 30F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Wheat;
            this.ClientSize = new System.Drawing.Size(735, 641);
            this.Controls.Add(this.status);
            this.Controls.Add(this.orgName);
            this.Controls.Add(this.orgTypes);
            this.Controls.Add(this.AdressReg);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.INN);
            this.Controls.Add(this.CancelOrgEdit);
            this.Controls.Add(this.OKorgAdd);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.KPP);
            this.Font = new System.Drawing.Font("Segoe Print", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "OrgAdd";
            this.Text = "Добавление организации";
            this.status.ResumeLayout(false);
            this.status.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Button CancelOrgEdit;
        private Button OKorgAdd;
        private Label label4;
        private Label label3;
        private Label label2;
        private Label label1;
        private TextBox KPP;
        private Label label6;
        private TextBox INN;
        private ComboBox AdressReg;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private ComboBox orgTypes;
        private TextBox orgName;
        private RadioButton statusOrg;
        private RadioButton statusIndividual;
        private GroupBox status;
    }
}