
namespace GrpcClient_PI_21_01.Views
{
    partial class AnimalCardForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AnimalCardForm));
            groupBox1=new GroupBox();
            female=new RadioButton();
            male=new RadioButton();
            textBoxFurType=new TextBox();
            label12=new Label();
            numericUpDownSize=new NumericUpDown();
            label11=new Label();
            label7=new Label();
            label9=new Label();
            label10=new Label();
            textBoxKategori=new TextBox();
            textBoxPoroda=new TextBox();
            label3=new Label();
            label2=new Label();
            label1=new Label();
            textBoxTail=new TextBox();
            textBoxEars=new TextBox();
            textBoxColor=new TextBox();
            label4=new Label();
            label5=new Label();
            label6=new Label();
            label8=new Label();
            Cancel=new Button();
            OK=new Button();
            God=new Label();
            textBoxIdentificationLabel=new TextBox();
            textBoxSpicialSigns=new TextBox();
            label13=new Label();
            comboBoxLocation=new ComboBox();
            GITLER=new Label();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numericUpDownSize).BeginInit();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(female);
            groupBox1.Controls.Add(male);
            groupBox1.Controls.Add(textBoxFurType);
            groupBox1.Controls.Add(label12);
            groupBox1.Controls.Add(numericUpDownSize);
            groupBox1.Controls.Add(label11);
            groupBox1.Controls.Add(label7);
            groupBox1.Controls.Add(label9);
            groupBox1.Controls.Add(label10);
            groupBox1.Controls.Add(textBoxKategori);
            groupBox1.Controls.Add(textBoxPoroda);
            groupBox1.Location=new Point(26, 110);
            groupBox1.Margin=new Padding(6, 9, 6, 9);
            groupBox1.Name="groupBox1";
            groupBox1.Padding=new Padding(6, 9, 6, 9);
            groupBox1.Size=new Size(433, 252);
            groupBox1.TabIndex=0;
            groupBox1.TabStop=false;
            groupBox1.Text="Характеристики животного";
            // 
            // female
            // 
            female.AutoSize=true;
            female.Location=new Point(273, 75);
            female.Name="female";
            female.Size=new Size(51, 34);
            female.TabIndex=22;
            female.Text="Ж";
            female.UseVisualStyleBackColor=true;
            // 
            // male
            // 
            male.AutoSize=true;
            male.Checked=true;
            male.Location=new Point(204, 75);
            male.Name="male";
            male.Size=new Size(51, 34);
            male.TabIndex=21;
            male.TabStop=true;
            male.Text="М";
            male.UseVisualStyleBackColor=true;
            // 
            // textBoxFurType
            // 
            textBoxFurType.BackColor=Color.OldLace;
            textBoxFurType.BorderStyle=BorderStyle.None;
            textBoxFurType.Location=new Point(204, 206);
            textBoxFurType.Margin=new Padding(6, 9, 6, 9);
            textBoxFurType.Name="textBoxFurType";
            textBoxFurType.Size=new Size(212, 30);
            textBoxFurType.TabIndex=20;
            // 
            // label12
            // 
            label12.AutoSize=true;
            label12.Location=new Point(12, 206);
            label12.Margin=new Padding(6, 0, 6, 0);
            label12.Name="label12";
            label12.Size=new Size(89, 30);
            label12.TabIndex=19;
            label12.Text="Шерсть";
            // 
            // numericUpDownSize
            // 
            numericUpDownSize.BackColor=Color.OldLace;
            numericUpDownSize.BorderStyle=BorderStyle.None;
            numericUpDownSize.Cursor=Cursors.PanNW;
            numericUpDownSize.Location=new Point(204, 161);
            numericUpDownSize.Margin=new Padding(6, 9, 6, 9);
            numericUpDownSize.Minimum=new decimal(new int[] { 1, 0, 0, 0 });
            numericUpDownSize.Name="numericUpDownSize";
            numericUpDownSize.Size=new Size(217, 33);
            numericUpDownSize.TabIndex=18;
            numericUpDownSize.Value=new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // label11
            // 
            label11.AutoSize=true;
            label11.Location=new Point(12, 164);
            label11.Margin=new Padding(6, 0, 6, 0);
            label11.Name="label11";
            label11.Size=new Size(78, 30);
            label11.TabIndex=17;
            label11.Text="Размер";
            // 
            // label7
            // 
            label7.AutoSize=true;
            label7.Location=new Point(12, 128);
            label7.Margin=new Padding(6, 0, 6, 0);
            label7.Name="label7";
            label7.Size=new Size(76, 30);
            label7.TabIndex=15;
            label7.Text="Порода";
            // 
            // label9
            // 
            label9.AutoSize=true;
            label9.Location=new Point(12, 86);
            label9.Margin=new Padding(6, 0, 6, 0);
            label9.Name="label9";
            label9.Size=new Size(46, 30);
            label9.TabIndex=14;
            label9.Text="Пол";
            // 
            // label10
            // 
            label10.AutoSize=true;
            label10.Location=new Point(12, 44);
            label10.Margin=new Padding(6, 0, 6, 0);
            label10.Name="label10";
            label10.Size=new Size(113, 30);
            label10.TabIndex=13;
            label10.Text="Категория";
            // 
            // textBoxKategori
            // 
            textBoxKategori.BackColor=Color.OldLace;
            textBoxKategori.BorderStyle=BorderStyle.None;
            textBoxKategori.Location=new Point(202, 35);
            textBoxKategori.Margin=new Padding(6, 9, 6, 9);
            textBoxKategori.Name="textBoxKategori";
            textBoxKategori.ReadOnly=true;
            textBoxKategori.Size=new Size(212, 30);
            textBoxKategori.TabIndex=10;
            // 
            // textBoxPoroda
            // 
            textBoxPoroda.BackColor=Color.OldLace;
            textBoxPoroda.BorderStyle=BorderStyle.None;
            textBoxPoroda.Location=new Point(202, 119);
            textBoxPoroda.Margin=new Padding(6, 9, 6, 9);
            textBoxPoroda.Name="textBoxPoroda";
            textBoxPoroda.Size=new Size(212, 30);
            textBoxPoroda.TabIndex=12;
            // 
            // label3
            // 
            label3.AutoSize=true;
            label3.Location=new Point(472, 238);
            label3.Margin=new Padding(6, 0, 6, 0);
            label3.Name="label3";
            label3.Size=new Size(70, 30);
            label3.TabIndex=5;
            label3.Text="Хвост";
            // 
            // label2
            // 
            label2.AutoSize=true;
            label2.Location=new Point(472, 196);
            label2.Margin=new Padding(6, 0, 6, 0);
            label2.Name="label2";
            label2.Size=new Size(50, 30);
            label2.TabIndex=4;
            label2.Text="Уши";
            // 
            // label1
            // 
            label1.AutoSize=true;
            label1.Location=new Point(472, 154);
            label1.Margin=new Padding(6, 0, 6, 0);
            label1.Name="label1";
            label1.Size=new Size(68, 30);
            label1.TabIndex=3;
            label1.Text="Окрас";
            // 
            // textBoxTail
            // 
            textBoxTail.BackColor=Color.OldLace;
            textBoxTail.BorderStyle=BorderStyle.None;
            textBoxTail.Location=new Point(679, 229);
            textBoxTail.Margin=new Padding(6, 9, 6, 9);
            textBoxTail.Name="textBoxTail";
            textBoxTail.Size=new Size(212, 30);
            textBoxTail.TabIndex=2;
            // 
            // textBoxEars
            // 
            textBoxEars.BackColor=Color.OldLace;
            textBoxEars.BorderStyle=BorderStyle.None;
            textBoxEars.Location=new Point(679, 187);
            textBoxEars.Margin=new Padding(6, 9, 6, 9);
            textBoxEars.Name="textBoxEars";
            textBoxEars.Size=new Size(212, 30);
            textBoxEars.TabIndex=1;
            // 
            // textBoxColor
            // 
            textBoxColor.BackColor=Color.OldLace;
            textBoxColor.BorderStyle=BorderStyle.None;
            textBoxColor.Location=new Point(679, 145);
            textBoxColor.Margin=new Padding(6, 9, 6, 9);
            textBoxColor.Name="textBoxColor";
            textBoxColor.Size=new Size(212, 30);
            textBoxColor.TabIndex=0;
            // 
            // label4
            // 
            label4.AutoSize=true;
            label4.Location=new Point(22, 380);
            label4.Margin=new Padding(6, 0, 6, 0);
            label4.Name="label4";
            label4.Size=new Size(171, 30);
            label4.TabIndex=2;
            label4.Text="Особые приметы";
            // 
            // label5
            // 
            label5.AutoSize=true;
            label5.Location=new Point(22, 422);
            label5.Margin=new Padding(6, 0, 6, 0);
            label5.Name="label5";
            label5.Size=new Size(266, 30);
            label5.TabIndex=3;
            label5.Text="Идентификационная метка";
            // 
            // label6
            // 
            label6.AutoSize=true;
            label6.Location=new Point(22, 467);
            label6.Margin=new Padding(6, 0, 6, 0);
            label6.Name="label6";
            label6.Size=new Size(182, 30);
            label6.TabIndex=4;
            label6.Text="Населённый пункт";
            // 
            // label8
            // 
            label8.AutoSize=true;
            label8.Location=new Point(22, 538);
            label8.Margin=new Padding(6, 0, 6, 0);
            label8.Name="label8";
            label8.Size=new Size(276, 30);
            label8.TabIndex=6;
            label8.Text="Материалы с места отлова";
            label8.Visible=false;
            // 
            // Cancel
            // 
            Cancel.BackColor=Color.Cornsilk;
            Cancel.DialogResult=DialogResult.Cancel;
            Cancel.FlatStyle=FlatStyle.Popup;
            Cancel.Location=new Point(786, 589);
            Cancel.Margin=new Padding(6, 9, 6, 9);
            Cancel.Name="Cancel";
            Cancel.Size=new Size(162, 61);
            Cancel.TabIndex=7;
            Cancel.Text="Cancel";
            Cancel.UseVisualStyleBackColor=false;
            // 
            // OK
            // 
            OK.BackColor=Color.Cornsilk;
            OK.FlatStyle=FlatStyle.Popup;
            OK.Location=new Point(610, 587);
            OK.Margin=new Padding(6, 9, 6, 9);
            OK.Name="OK";
            OK.Size=new Size(162, 61);
            OK.TabIndex=8;
            OK.Text="OK";
            OK.UseVisualStyleBackColor=false;
            OK.Click+=OK_Click;
            // 
            // God
            // 
            God.AutoSize=true;
            God.Location=new Point(26, 24);
            God.Margin=new Padding(6, 0, 6, 0);
            God.Name="God";
            God.Size=new Size(60, 30);
            God.TabIndex=9;
            God.Text="Акт:";
            // 
            // textBoxIdentificationLabel
            // 
            textBoxIdentificationLabel.BackColor=Color.OldLace;
            textBoxIdentificationLabel.BorderStyle=BorderStyle.None;
            textBoxIdentificationLabel.Location=new Point(299, 422);
            textBoxIdentificationLabel.Margin=new Padding(6, 9, 6, 9);
            textBoxIdentificationLabel.Name="textBoxIdentificationLabel";
            textBoxIdentificationLabel.Size=new Size(212, 30);
            textBoxIdentificationLabel.TabIndex=11;
            // 
            // textBoxSpicialSigns
            // 
            textBoxSpicialSigns.BackColor=Color.OldLace;
            textBoxSpicialSigns.BorderStyle=BorderStyle.None;
            textBoxSpicialSigns.Location=new Point(299, 380);
            textBoxSpicialSigns.Margin=new Padding(6, 9, 6, 9);
            textBoxSpicialSigns.Name="textBoxSpicialSigns";
            textBoxSpicialSigns.Size=new Size(212, 30);
            textBoxSpicialSigns.TabIndex=10;
            // 
            // label13
            // 
            label13.AutoSize=true;
            label13.Location=new Point(46, 766);
            label13.Margin=new Padding(6, 0, 6, 0);
            label13.Name="label13";
            label13.Size=new Size(0, 30);
            label13.TabIndex=12;
            // 
            // comboBoxLocation
            // 
            comboBoxLocation.BackColor=Color.OldLace;
            comboBoxLocation.Cursor=Cursors.PanNW;
            comboBoxLocation.DropDownStyle=ComboBoxStyle.DropDownList;
            comboBoxLocation.FlatStyle=FlatStyle.Popup;
            comboBoxLocation.FormattingEnabled=true;
            comboBoxLocation.Location=new Point(299, 464);
            comboBoxLocation.Margin=new Padding(6, 9, 6, 9);
            comboBoxLocation.Name="comboBoxLocation";
            comboBoxLocation.Size=new Size(212, 38);
            comboBoxLocation.TabIndex=13;
            // 
            // GITLER
            // 
            GITLER.AutoSize=true;
            GITLER.Location=new Point(367, 21);
            GITLER.Margin=new Padding(6, 0, 6, 0);
            GITLER.Name="GITLER";
            GITLER.Size=new Size(56, 30);
            GITLER.TabIndex=14;
            GITLER.Text="Кот";
            // 
            // AnimalCardForm
            // 
            AutoScaleDimensions=new SizeF(11F, 30F);
            AutoScaleMode=AutoScaleMode.Font;
            BackColor=Color.Wheat;
            ClientSize=new Size(959, 657);
            Controls.Add(GITLER);
            Controls.Add(comboBoxLocation);
            Controls.Add(label13);
            Controls.Add(textBoxIdentificationLabel);
            Controls.Add(textBoxSpicialSigns);
            Controls.Add(label3);
            Controls.Add(God);
            Controls.Add(label2);
            Controls.Add(OK);
            Controls.Add(label1);
            Controls.Add(label4);
            Controls.Add(Cancel);
            Controls.Add(textBoxTail);
            Controls.Add(label8);
            Controls.Add(textBoxEars);
            Controls.Add(label6);
            Controls.Add(textBoxColor);
            Controls.Add(label5);
            Controls.Add(groupBox1);
            Font=new Font("Segoe Print", 10F, FontStyle.Bold, GraphicsUnit.Point);
            Icon=(Icon)resources.GetObject("$this.Icon");
            Margin=new Padding(6, 9, 6, 9);
            Name="AnimalCardForm";
            StartPosition=FormStartPosition.CenterScreen;
            Text="Карточка животного";
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numericUpDownSize).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private GroupBox groupBox1;
        private Label label3;
        private Label label2;
        private Label label1;
        private TextBox textBoxTail;
        private TextBox textBoxEars;
        private TextBox textBoxColor;
        private Label label4;
        private Label label5;
        private Label label6;
        private Label label8;
        private Button Cancel;
        private Button OK;
        private Label God;
        private Label label11;
        private Label label7;
        private Label label9;
        private Label label10;
        private TextBox textBoxKategori;
        private TextBox textBoxPoroda;
        private TextBox textBoxFurType;
        private Label label12;
        private NumericUpDown numericUpDownSize;
        private TextBox textBoxIdentificationLabel;
        private TextBox textBoxSpicialSigns;
        private Label label13;
        private ComboBox comboBoxLocation;
        private Label GITLER;
        private RadioButton female;
        private RadioButton male;
    }
}