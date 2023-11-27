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
            CancelOrgEdit=new Button();
            OKorgAdd=new Button();
            label5=new Label();
            label4=new Label();
            label3=new Label();
            label2=new Label();
            label1=new Label();
            Status=new TextBox();
            Type=new TextBox();
            KPP=new TextBox();
            label6=new Label();
            INN=new TextBox();
            AdressReg=new ComboBox();
            name=new ComboBox();
            SuspendLayout();
            // 
            // CancelOrgEdit
            // 
            CancelOrgEdit.BackColor=Color.Cornsilk;
            CancelOrgEdit.FlatStyle=FlatStyle.Popup;
            CancelOrgEdit.Location=new Point(402, 501);
            CancelOrgEdit.Margin=new Padding(4, 5, 4, 5);
            CancelOrgEdit.Name="CancelOrgEdit";
            CancelOrgEdit.Size=new Size(195, 74);
            CancelOrgEdit.TabIndex=23;
            CancelOrgEdit.Text="Отмена";
            CancelOrgEdit.UseVisualStyleBackColor=false;
            CancelOrgEdit.Click+=CancelOrgEdit_Click;
            // 
            // OKorgAdd
            // 
            OKorgAdd.BackColor=Color.Cornsilk;
            OKorgAdd.FlatStyle=FlatStyle.Popup;
            OKorgAdd.Location=new Point(114, 501);
            OKorgAdd.Margin=new Padding(4, 5, 4, 5);
            OKorgAdd.Name="OKorgAdd";
            OKorgAdd.Size=new Size(195, 74);
            OKorgAdd.TabIndex=22;
            OKorgAdd.Text="OK";
            OKorgAdd.UseVisualStyleBackColor=false;
            OKorgAdd.Click+=OKorgAdd_Click;
            // 
            // label5
            // 
            label5.AutoSize=true;
            label5.Location=new Point(42, 401);
            label5.Margin=new Padding(4, 0, 4, 0);
            label5.Name="label5";
            label5.Size=new Size(88, 30);
            label5.TabIndex=21;
            label5.Text="Статус";
            // 
            // label4
            // 
            label4.AutoSize=true;
            label4.Location=new Point(55, 323);
            label4.Margin=new Padding(4, 0, 4, 0);
            label4.Name="label4";
            label4.Size=new Size(45, 30);
            label4.TabIndex=20;
            label4.Text="Тип";
            // 
            // label3
            // 
            label3.AutoSize=true;
            label3.Location=new Point(42, 253);
            label3.Margin=new Padding(4, 0, 4, 0);
            label3.Name="label3";
            label3.Size=new Size(188, 30);
            label3.TabIndex=19;
            label3.Text="Адрес регистрации";
            // 
            // label2
            // 
            label2.AutoSize=true;
            label2.Location=new Point(42, 181);
            label2.Margin=new Padding(4, 0, 4, 0);
            label2.Name="label2";
            label2.Size=new Size(55, 30);
            label2.TabIndex=18;
            label2.Text="КПП";
            // 
            // label1
            // 
            label1.AutoSize=true;
            label1.Location=new Point(42, 37);
            label1.Margin=new Padding(4, 0, 4, 0);
            label1.Name="label1";
            label1.Size=new Size(139, 30);
            label1.TabIndex=17;
            label1.Text="Наименование";
            // 
            // Status
            // 
            Status.BackColor=Color.OldLace;
            Status.BorderStyle=BorderStyle.None;
            Status.Location=new Point(298, 391);
            Status.Margin=new Padding(4, 5, 4, 5);
            Status.Name="Status";
            Status.Size=new Size(349, 30);
            Status.TabIndex=16;
            // 
            // Type
            // 
            Type.BackColor=Color.OldLace;
            Type.BorderStyle=BorderStyle.None;
            Type.Location=new Point(298, 315);
            Type.Margin=new Padding(4, 5, 4, 5);
            Type.Name="Type";
            Type.Size=new Size(349, 30);
            Type.TabIndex=15;
            // 
            // KPP
            // 
            KPP.BackColor=Color.OldLace;
            KPP.BorderStyle=BorderStyle.None;
            KPP.Location=new Point(298, 175);
            KPP.Margin=new Padding(4, 5, 4, 5);
            KPP.Name="KPP";
            KPP.Size=new Size(349, 30);
            KPP.TabIndex=13;
            // 
            // label6
            // 
            label6.AutoSize=true;
            label6.Location=new Point(42, 112);
            label6.Margin=new Padding(4, 0, 4, 0);
            label6.Name="label6";
            label6.Size=new Size(57, 30);
            label6.TabIndex=25;
            label6.Text="ИНН";
            // 
            // INN
            // 
            INN.BackColor=Color.OldLace;
            INN.BorderStyle=BorderStyle.None;
            INN.Location=new Point(298, 104);
            INN.Margin=new Padding(4, 5, 4, 5);
            INN.Name="INN";
            INN.Size=new Size(349, 30);
            INN.TabIndex=24;
            // 
            // AdressReg
            // 
            AdressReg.BackColor=Color.OldLace;
            AdressReg.DrawMode=DrawMode.OwnerDrawVariable;
            AdressReg.FlatStyle=FlatStyle.Popup;
            AdressReg.FormattingEnabled=true;
            AdressReg.Location=new Point(298, 253);
            AdressReg.Name="AdressReg";
            AdressReg.Size=new Size(349, 38);
            AdressReg.TabIndex=26;
            // 
            // name
            // 
            name.BackColor=Color.OldLace;
            name.DrawMode=DrawMode.OwnerDrawVariable;
            name.FlatStyle=FlatStyle.Popup;
            name.FormattingEnabled=true;
            name.Location=new Point(298, 37);
            name.Name="name";
            name.Size=new Size(349, 38);
            name.TabIndex=27;
            // 
            // OrgAdd
            // 
            AutoScaleDimensions=new SizeF(11F, 30F);
            AutoScaleMode=AutoScaleMode.Font;
            BackColor=Color.Wheat;
            ClientSize=new Size(735, 641);
            Controls.Add(name);
            Controls.Add(AdressReg);
            Controls.Add(label6);
            Controls.Add(INN);
            Controls.Add(CancelOrgEdit);
            Controls.Add(OKorgAdd);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(Status);
            Controls.Add(Type);
            Controls.Add(KPP);
            Font=new Font("Segoe Print", 10F, FontStyle.Bold, GraphicsUnit.Point);
            Icon=(Icon)resources.GetObject("$this.Icon");
            Margin=new Padding(4, 5, 4, 5);
            Name="OrgAdd";
            Text="Добавление организации";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button CancelOrgEdit;
        private Button OKorgAdd;
        private Label label5;
        private Label label4;
        private Label label3;
        private Label label2;
        private Label label1;
        private TextBox Status;
        private TextBox Type;
        private TextBox KPP;
        private Label label6;
        private TextBox INN;
        private ComboBox AdressReg;
        private ComboBox name;
    }
}