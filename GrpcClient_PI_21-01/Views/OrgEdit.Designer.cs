namespace GrpcClient_PI_21_01.Views
{
    partial class OrgEdit
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OrgEdit));
            KPP=new TextBox();
            Type=new TextBox();
            Status=new TextBox();
            label1=new Label();
            label2=new Label();
            label3=new Label();
            label4=new Label();
            label5=new Label();
            OKorgEdit=new Button();
            CancelOrgEdit=new Button();
            label6=new Label();
            INN=new TextBox();
            name=new ComboBox();
            AdressReg=new ComboBox();
            SuspendLayout();
            // 
            // KPP
            // 
            KPP.BackColor=Color.OldLace;
            KPP.BorderStyle=BorderStyle.None;
            KPP.Location=new Point(274, 167);
            KPP.Margin=new Padding(4, 5, 4, 5);
            KPP.Name="KPP";
            KPP.Size=new Size(349, 30);
            KPP.TabIndex=1;
            // 
            // Type
            // 
            Type.BackColor=Color.OldLace;
            Type.BorderStyle=BorderStyle.None;
            Type.Location=new Point(274, 301);
            Type.Margin=new Padding(4, 5, 4, 5);
            Type.Name="Type";
            Type.Size=new Size(349, 30);
            Type.TabIndex=3;
            // 
            // Status
            // 
            Status.BackColor=Color.OldLace;
            Status.BorderStyle=BorderStyle.None;
            Status.Location=new Point(274, 370);
            Status.Margin=new Padding(4, 5, 4, 5);
            Status.Name="Status";
            Status.Size=new Size(349, 30);
            Status.TabIndex=4;
            // 
            // label1
            // 
            label1.AutoSize=true;
            label1.Location=new Point(19, 47);
            label1.Margin=new Padding(4, 0, 4, 0);
            label1.Name="label1";
            label1.Size=new Size(139, 30);
            label1.TabIndex=5;
            label1.Text="Наименование";
            // 
            // label2
            // 
            label2.AutoSize=true;
            label2.Location=new Point(19, 172);
            label2.Margin=new Padding(4, 0, 4, 0);
            label2.Name="label2";
            label2.Size=new Size(55, 30);
            label2.TabIndex=6;
            label2.Text="КПП";
            // 
            // label3
            // 
            label3.AutoSize=true;
            label3.Location=new Point(19, 248);
            label3.Margin=new Padding(4, 0, 4, 0);
            label3.Name="label3";
            label3.Size=new Size(188, 30);
            label3.TabIndex=7;
            label3.Text="Адрес регистрации";
            // 
            // label4
            // 
            label4.AutoSize=true;
            label4.Location=new Point(19, 311);
            label4.Margin=new Padding(4, 0, 4, 0);
            label4.Name="label4";
            label4.Size=new Size(45, 30);
            label4.TabIndex=8;
            label4.Text="Тип";
            // 
            // label5
            // 
            label5.AutoSize=true;
            label5.Location=new Point(19, 381);
            label5.Margin=new Padding(4, 0, 4, 0);
            label5.Name="label5";
            label5.Size=new Size(88, 30);
            label5.TabIndex=9;
            label5.Text="Статус";
            // 
            // OKorgEdit
            // 
            OKorgEdit.BackColor=Color.Cornsilk;
            OKorgEdit.FlatStyle=FlatStyle.Popup;
            OKorgEdit.Location=new Point(79, 479);
            OKorgEdit.Margin=new Padding(4, 5, 4, 5);
            OKorgEdit.Name="OKorgEdit";
            OKorgEdit.Size=new Size(195, 74);
            OKorgEdit.TabIndex=10;
            OKorgEdit.Text="OK";
            OKorgEdit.UseVisualStyleBackColor=false;
            OKorgEdit.Click+=OKorgEdit_Click;
            // 
            // CancelOrgEdit
            // 
            CancelOrgEdit.BackColor=Color.Cornsilk;
            CancelOrgEdit.FlatStyle=FlatStyle.Popup;
            CancelOrgEdit.Location=new Point(371, 479);
            CancelOrgEdit.Margin=new Padding(4, 5, 4, 5);
            CancelOrgEdit.Name="CancelOrgEdit";
            CancelOrgEdit.Size=new Size(195, 74);
            CancelOrgEdit.TabIndex=11;
            CancelOrgEdit.Text="Отмена";
            CancelOrgEdit.UseVisualStyleBackColor=false;
            CancelOrgEdit.Click+=CancelOrgEdit_Click;
            // 
            // label6
            // 
            label6.AutoSize=true;
            label6.Location=new Point(19, 102);
            label6.Margin=new Padding(4, 0, 4, 0);
            label6.Name="label6";
            label6.Size=new Size(57, 30);
            label6.TabIndex=13;
            label6.Text="ИНН";
            // 
            // INN
            // 
            INN.BackColor=Color.OldLace;
            INN.BorderStyle=BorderStyle.None;
            INN.Location=new Point(274, 102);
            INN.Margin=new Padding(4, 5, 4, 5);
            INN.Name="INN";
            INN.Size=new Size(349, 30);
            INN.TabIndex=12;
            // 
            // name
            // 
            name.BackColor=Color.OldLace;
            name.DrawMode=DrawMode.OwnerDrawVariable;
            name.FlatStyle=FlatStyle.Popup;
            name.FormattingEnabled=true;
            name.Location=new Point(271, 39);
            name.Name="name";
            name.Size=new Size(352, 38);
            name.TabIndex=14;
            // 
            // AdressReg
            // 
            AdressReg.BackColor=Color.OldLace;
            AdressReg.DrawMode=DrawMode.OwnerDrawVariable;
            AdressReg.FlatStyle=FlatStyle.Popup;
            AdressReg.FormattingEnabled=true;
            AdressReg.Location=new Point(274, 227);
            AdressReg.Name="AdressReg";
            AdressReg.Size=new Size(352, 38);
            AdressReg.TabIndex=15;
            // 
            // OrgEdit
            // 
            AutoScaleDimensions=new SizeF(11F, 30F);
            AutoScaleMode=AutoScaleMode.Font;
            BackColor=Color.Wheat;
            ClientSize=new Size(669, 601);
            Controls.Add(AdressReg);
            Controls.Add(name);
            Controls.Add(label6);
            Controls.Add(INN);
            Controls.Add(CancelOrgEdit);
            Controls.Add(OKorgEdit);
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
            Name="OrgEdit";
            Text="Изменение организации";
            Load+=OrgEdit_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private TextBox KPP;
        private TextBox Type;
        private TextBox Status;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Button OKorgEdit;
        private Button CancelOrgEdit;
        private Label label6;
        private TextBox INN;
        private ComboBox name;
        private ComboBox AdressReg;
    }
}