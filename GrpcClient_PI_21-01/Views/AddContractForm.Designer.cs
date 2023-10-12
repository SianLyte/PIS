namespace GrpcClient_PI_21_01.Views
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
            this.label6 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dateConclusion = new System.Windows.Forms.DateTimePicker();
            this.dateAction = new System.Windows.Forms.DateTimePicker();
            this.CancelcontEdit = new System.Windows.Forms.Button();
            this.OKcontAdd = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.customerCombo = new System.Windows.Forms.ComboBox();
            this.executerCombo = new System.Windows.Forms.ComboBox();
            this.CostText = new System.Windows.Forms.TextBox();
            this.cityCombo = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(20, 88);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(188, 35);
            this.label6.TabIndex = 31;
            this.label6.Text = "Дата действия:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(20, 149);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(81, 35);
            this.label2.TabIndex = 29;
            this.label2.Text = "Город:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(20, 26);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(211, 35);
            this.label1.TabIndex = 28;
            this.label1.Text = "Дата заключения:";
            // 
            // dateConclusion
            // 
            this.dateConclusion.CalendarMonthBackground = System.Drawing.Color.Cornsilk;
            this.dateConclusion.CalendarTitleBackColor = System.Drawing.Color.Cornsilk;
            this.dateConclusion.Location = new System.Drawing.Point(233, 26);
            this.dateConclusion.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            this.dateConclusion.Name = "dateConclusion";
            this.dateConclusion.Size = new System.Drawing.Size(322, 43);
            this.dateConclusion.TabIndex = 32;
            // 
            // dateAction
            // 
            this.dateAction.CalendarMonthBackground = System.Drawing.Color.Cornsilk;
            this.dateAction.CalendarTitleBackColor = System.Drawing.Color.Cornsilk;
            this.dateAction.Location = new System.Drawing.Point(233, 88);
            this.dateAction.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            this.dateAction.Name = "dateAction";
            this.dateAction.Size = new System.Drawing.Size(322, 43);
            this.dateAction.TabIndex = 33;
            // 
            // CancelcontEdit
            // 
            this.CancelcontEdit.BackColor = System.Drawing.Color.Cornsilk;
            this.CancelcontEdit.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.CancelcontEdit.Location = new System.Drawing.Point(363, 410);
            this.CancelcontEdit.Margin = new System.Windows.Forms.Padding(4);
            this.CancelcontEdit.Name = "CancelcontEdit";
            this.CancelcontEdit.Size = new System.Drawing.Size(195, 74);
            this.CancelcontEdit.TabIndex = 37;
            this.CancelcontEdit.Text = "Отмена";
            this.CancelcontEdit.UseVisualStyleBackColor = false;
            this.CancelcontEdit.Click += new System.EventHandler(this.CancelcontEdit_Click);
            // 
            // OKcontAdd
            // 
            this.OKcontAdd.BackColor = System.Drawing.Color.Cornsilk;
            this.OKcontAdd.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.OKcontAdd.Location = new System.Drawing.Point(157, 410);
            this.OKcontAdd.Margin = new System.Windows.Forms.Padding(4);
            this.OKcontAdd.Name = "OKcontAdd";
            this.OKcontAdd.Size = new System.Drawing.Size(195, 74);
            this.OKcontAdd.TabIndex = 36;
            this.OKcontAdd.Text = "OK";
            this.OKcontAdd.UseVisualStyleBackColor = false;
            this.OKcontAdd.Click += new System.EventHandler(this.OKcontAdd_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(20, 214);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(73, 35);
            this.label3.TabIndex = 38;
            this.label3.Text = "Цена:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(20, 280);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(114, 35);
            this.label4.TabIndex = 39;
            this.label4.Text = "Заказчик:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(20, 346);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(163, 35);
            this.label5.TabIndex = 40;
            this.label5.Text = "Исполнитель:";
            // 
            // customerCombo
            // 
            this.customerCombo.BackColor = System.Drawing.Color.OldLace;
            this.customerCombo.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.customerCombo.FormattingEnabled = true;
            this.customerCombo.Location = new System.Drawing.Point(233, 346);
            this.customerCombo.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            this.customerCombo.Name = "customerCombo";
            this.customerCombo.Size = new System.Drawing.Size(322, 43);
            this.customerCombo.TabIndex = 44;
            // 
            // executerCombo
            // 
            this.executerCombo.BackColor = System.Drawing.Color.OldLace;
            this.executerCombo.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.executerCombo.FormattingEnabled = true;
            this.executerCombo.Location = new System.Drawing.Point(233, 280);
            this.executerCombo.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            this.executerCombo.Name = "executerCombo";
            this.executerCombo.Size = new System.Drawing.Size(322, 43);
            this.executerCombo.TabIndex = 43;
            // 
            // CostText
            // 
            this.CostText.BackColor = System.Drawing.Color.OldLace;
            this.CostText.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.CostText.Location = new System.Drawing.Point(233, 219);
            this.CostText.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            this.CostText.Name = "CostText";
            this.CostText.Size = new System.Drawing.Size(322, 36);
            this.CostText.TabIndex = 45;
            // 
            // cityCombo
            // 
            this.cityCombo.BackColor = System.Drawing.Color.OldLace;
            this.cityCombo.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cityCombo.FormattingEnabled = true;
            this.cityCombo.Location = new System.Drawing.Point(233, 149);
            this.cityCombo.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            this.cityCombo.Name = "cityCombo";
            this.cityCombo.Size = new System.Drawing.Size(173, 43);
            this.cityCombo.TabIndex = 41;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Cornsilk;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button1.Location = new System.Drawing.Point(417, 149);
            this.button1.Margin = new System.Windows.Forms.Padding(4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(140, 52);
            this.button1.TabIndex = 46;
            this.button1.Text = "Добавить";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // AddContractForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(13F, 35F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Wheat;
            this.ClientSize = new System.Drawing.Size(575, 506);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.CostText);
            this.Controls.Add(this.customerCombo);
            this.Controls.Add(this.executerCombo);
            this.Controls.Add(this.cityCombo);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.CancelcontEdit);
            this.Controls.Add(this.OKcontAdd);
            this.Controls.Add(this.dateAction);
            this.Controls.Add(this.dateConclusion);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Segoe Print", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            this.Name = "AddContractForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dateConclusion;
        private System.Windows.Forms.DateTimePicker dateAction;
        private System.Windows.Forms.Button CancelcontEdit;
        private System.Windows.Forms.Button OKcontAdd;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox customerCombo;
        private System.Windows.Forms.ComboBox executerCombo;
        private System.Windows.Forms.TextBox CostText;
        private System.Windows.Forms.ComboBox cityCombo;
        private System.Windows.Forms.Button button1;
    }
}