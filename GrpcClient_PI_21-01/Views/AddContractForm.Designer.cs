﻿namespace GrpcClient_PI_21_01.Views
{
    partial class AddContractForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddContractForm));
            label6=new Label();
            label2=new Label();
            label1=new Label();
            dateConclusion=new DateTimePicker();
            dateAction=new DateTimePicker();
            CancelcontEdit=new Button();
            OKcontAdd=new Button();
            label3=new Label();
            label4=new Label();
            label5=new Label();
            customerCombo=new ComboBox();
            executerCombo=new ComboBox();
            CostText=new TextBox();
            cityCombo=new ComboBox();
            button1=new Button();
            dataGridView1=new DataGridView();
            newCity=new Button();
            groupBox1=new GroupBox();
            groupBox2=new GroupBox();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            SuspendLayout();
            // 
            // label6
            // 
            label6.AutoSize=true;
            label6.Location=new Point(20, 88);
            label6.Margin=new Padding(4, 0, 4, 0);
            label6.Name="label6";
            label6.Size=new Size(160, 30);
            label6.TabIndex=31;
            label6.Text="Дата действия:";
            // 
            // label2
            // 
            label2.AutoSize=true;
            label2.Location=new Point(20, 176);
            label2.Margin=new Padding(4, 0, 4, 0);
            label2.Name="label2";
            label2.Size=new Size(70, 30);
            label2.TabIndex=29;
            label2.Text="Город:";
            // 
            // label1
            // 
            label1.AutoSize=true;
            label1.Location=new Point(20, 26);
            label1.Margin=new Padding(4, 0, 4, 0);
            label1.Name="label1";
            label1.Size=new Size(178, 30);
            label1.TabIndex=28;
            label1.Text="Дата заключения:";
            // 
            // dateConclusion
            // 
            dateConclusion.CalendarMonthBackground=Color.Cornsilk;
            dateConclusion.CalendarTitleBackColor=Color.Cornsilk;
            dateConclusion.Location=new Point(233, 26);
            dateConclusion.Margin=new Padding(4, 7, 4, 7);
            dateConclusion.Name="dateConclusion";
            dateConclusion.Size=new Size(322, 37);
            dateConclusion.TabIndex=32;
            // 
            // dateAction
            // 
            dateAction.CalendarMonthBackground=Color.Cornsilk;
            dateAction.CalendarTitleBackColor=Color.Cornsilk;
            dateAction.Location=new Point(233, 88);
            dateAction.Margin=new Padding(4, 7, 4, 7);
            dateAction.Name="dateAction";
            dateAction.Size=new Size(322, 37);
            dateAction.TabIndex=33;
            // 
            // CancelcontEdit
            // 
            CancelcontEdit.BackColor=Color.Cornsilk;
            CancelcontEdit.FlatStyle=FlatStyle.Popup;
            CancelcontEdit.Location=new Point(363, 477);
            CancelcontEdit.Margin=new Padding(4);
            CancelcontEdit.Name="CancelcontEdit";
            CancelcontEdit.Size=new Size(195, 74);
            CancelcontEdit.TabIndex=37;
            CancelcontEdit.Text="Отмена";
            CancelcontEdit.UseVisualStyleBackColor=false;
            CancelcontEdit.Click+=CancelcontEdit_Click;
            // 
            // OKcontAdd
            // 
            OKcontAdd.BackColor=Color.Cornsilk;
            OKcontAdd.FlatStyle=FlatStyle.Popup;
            OKcontAdd.Location=new Point(157, 477);
            OKcontAdd.Margin=new Padding(4);
            OKcontAdd.Name="OKcontAdd";
            OKcontAdd.Size=new Size(195, 74);
            OKcontAdd.TabIndex=36;
            OKcontAdd.Text="OK";
            OKcontAdd.UseVisualStyleBackColor=false;
            OKcontAdd.Click+=OKcontAdd_Click;
            // 
            // label3
            // 
            label3.AutoSize=true;
            label3.Location=new Point(20, 281);
            label3.Margin=new Padding(4, 0, 4, 0);
            label3.Name="label3";
            label3.Size=new Size(62, 30);
            label3.TabIndex=38;
            label3.Text="Цена:";
            // 
            // label4
            // 
            label4.AutoSize=true;
            label4.Location=new Point(20, 347);
            label4.Margin=new Padding(4, 0, 4, 0);
            label4.Name="label4";
            label4.Size=new Size(96, 30);
            label4.TabIndex=39;
            label4.Text="Заказчик:";
            // 
            // label5
            // 
            label5.AutoSize=true;
            label5.Location=new Point(20, 413);
            label5.Margin=new Padding(4, 0, 4, 0);
            label5.Name="label5";
            label5.Size=new Size(139, 30);
            label5.TabIndex=40;
            label5.Text="Исполнитель:";
            // 
            // customerCombo
            // 
            customerCombo.BackColor=Color.OldLace;
            customerCombo.FlatStyle=FlatStyle.Popup;
            customerCombo.FormattingEnabled=true;
            customerCombo.Location=new Point(233, 413);
            customerCombo.Margin=new Padding(4, 7, 4, 7);
            customerCombo.Name="customerCombo";
            customerCombo.Size=new Size(322, 38);
            customerCombo.TabIndex=44;
            // 
            // executerCombo
            // 
            executerCombo.BackColor=Color.OldLace;
            executerCombo.FlatStyle=FlatStyle.Popup;
            executerCombo.FormattingEnabled=true;
            executerCombo.Location=new Point(233, 347);
            executerCombo.Margin=new Padding(4, 7, 4, 7);
            executerCombo.Name="executerCombo";
            executerCombo.Size=new Size(322, 38);
            executerCombo.TabIndex=43;
            // 
            // CostText
            // 
            CostText.BackColor=Color.OldLace;
            CostText.BorderStyle=BorderStyle.None;
            CostText.Location=new Point(233, 286);
            CostText.Margin=new Padding(4, 7, 4, 7);
            CostText.Name="CostText";
            CostText.Size=new Size(322, 30);
            CostText.TabIndex=45;
            // 
            // cityCombo
            // 
            cityCombo.BackColor=Color.OldLace;
            cityCombo.DropDownStyle=ComboBoxStyle.DropDownList;
            cityCombo.FlatStyle=FlatStyle.Popup;
            cityCombo.FormattingEnabled=true;
            cityCombo.Location=new Point(205, 40);
            cityCombo.Margin=new Padding(4, 7, 4, 7);
            cityCombo.Name="cityCombo";
            cityCombo.Size=new Size(173, 38);
            cityCombo.TabIndex=41;
            // 
            // button1
            // 
            button1.BackColor=Color.Cornsilk;
            button1.FlatStyle=FlatStyle.Popup;
            button1.Location=new Point(264, 94);
            button1.Margin=new Padding(4);
            button1.Name="button1";
            button1.Size=new Size(114, 38);
            button1.TabIndex=46;
            button1.Text="Добавить";
            button1.UseVisualStyleBackColor=false;
            button1.Click+=button1_Click;
            // 
            // dataGridView1
            // 
            dataGridView1.AllowUserToAddRows=false;
            dataGridView1.AllowUserToDeleteRows=false;
            dataGridView1.AllowUserToResizeColumns=false;
            dataGridView1.AllowUserToResizeRows=false;
            dataGridView1.AutoSizeColumnsMode=DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.ColumnHeadersHeightSizeMode=DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location=new Point(6, 40);
            dataGridView1.MultiSelect=false;
            dataGridView1.Name="dataGridView1";
            dataGridView1.ReadOnly=true;
            dataGridView1.RowHeadersVisible=false;
            dataGridView1.RowHeadersWidth=51;
            dataGridView1.RowTemplate.Height=29;
            dataGridView1.Size=new Size(192, 92);
            dataGridView1.TabIndex=48;
            // 
            // newCity
            // 
            newCity.Location=new Point(6, 49);
            newCity.Name="newCity";
            newCity.Size=new Size(143, 70);
            newCity.TabIndex=49;
            newCity.Text="Добавить город";
            newCity.UseVisualStyleBackColor=true;
            newCity.Click+=newCity_Click;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(newCity);
            groupBox1.Location=new Point(640, 26);
            groupBox1.Name="groupBox1";
            groupBox1.Size=new Size(155, 126);
            groupBox1.TabIndex=50;
            groupBox1.TabStop=false;
            groupBox1.Text="(тестировка)";
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(dataGridView1);
            groupBox2.Controls.Add(cityCombo);
            groupBox2.Controls.Add(button1);
            groupBox2.Location=new Point(233, 135);
            groupBox2.Name="groupBox2";
            groupBox2.Size=new Size(388, 141);
            groupBox2.TabIndex=51;
            groupBox2.TabStop=false;
            groupBox2.Text="Добовление города";
            // 
            // AddContractForm
            // 
            AutoScaleDimensions=new SizeF(11F, 30F);
            AutoScaleMode=AutoScaleMode.Font;
            BackColor=Color.Wheat;
            ClientSize=new Size(801, 620);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Controls.Add(CostText);
            Controls.Add(customerCombo);
            Controls.Add(executerCombo);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(CancelcontEdit);
            Controls.Add(OKcontAdd);
            Controls.Add(dateAction);
            Controls.Add(dateConclusion);
            Controls.Add(label6);
            Controls.Add(label2);
            Controls.Add(label1);
            Font=new Font("Segoe Print", 10F, FontStyle.Bold, GraphicsUnit.Point);
            Icon=(Icon)resources.GetObject("$this.Icon");
            Margin=new Padding(4, 7, 4, 7);
            Name="AddContractForm";
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            groupBox1.ResumeLayout(false);
            groupBox2.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label6;
        private Label label2;
        private Label label1;
        private DateTimePicker dateConclusion;
        private DateTimePicker dateAction;
        private Button CancelcontEdit;
        private Button OKcontAdd;
        private Label label3;
        private Label label4;
        private Label label5;
        private ComboBox customerCombo;
        private ComboBox executerCombo;
        private TextBox CostText;
        private ComboBox cityCombo;
        private Button button1;
        private DataGridView dataGridView1;
        private Button newCity;
        private GroupBox groupBox1;
        private GroupBox groupBox2;
    }
}