namespace GrpcClient_PI_21_01.Views.Filters
{
    partial class OrgFilter
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
            this.regBox = new System.Windows.Forms.GroupBox();
            this.regComboBox = new System.Windows.Forms.ComboBox();
            this.typeComboBox = new System.Windows.Forms.ComboBox();
            this.typeBox = new System.Windows.Forms.GroupBox();
            this.statusBox = new System.Windows.Forms.GroupBox();
            this.statusJuridical = new System.Windows.Forms.RadioButton();
            this.statusIndividual = new System.Windows.Forms.RadioButton();
            this.statusAll = new System.Windows.Forms.RadioButton();
            this.close = new System.Windows.Forms.Button();
            this.reset = new System.Windows.Forms.Button();
            this.apply = new System.Windows.Forms.Button();
            this.regBox.SuspendLayout();
            this.typeBox.SuspendLayout();
            this.statusBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // regBox
            // 
            this.regBox.Controls.Add(this.regComboBox);
            this.regBox.Location = new System.Drawing.Point(12, 12);
            this.regBox.Name = "regBox";
            this.regBox.Size = new System.Drawing.Size(624, 91);
            this.regBox.TabIndex = 0;
            this.regBox.TabStop = false;
            this.regBox.Text = "По адресу регистрации";
            // 
            // regComboBox
            // 
            this.regComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.regComboBox.FormattingEnabled = true;
            this.regComboBox.Location = new System.Drawing.Point(17, 35);
            this.regComboBox.Name = "regComboBox";
            this.regComboBox.Size = new System.Drawing.Size(586, 28);
            this.regComboBox.TabIndex = 0;
            // 
            // typeComboBox
            // 
            this.typeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.typeComboBox.FormattingEnabled = true;
            this.typeComboBox.Location = new System.Drawing.Point(17, 35);
            this.typeComboBox.Name = "typeComboBox";
            this.typeComboBox.Size = new System.Drawing.Size(586, 28);
            this.typeComboBox.TabIndex = 0;
            // 
            // typeBox
            // 
            this.typeBox.Controls.Add(this.typeComboBox);
            this.typeBox.Location = new System.Drawing.Point(12, 119);
            this.typeBox.Name = "typeBox";
            this.typeBox.Size = new System.Drawing.Size(624, 91);
            this.typeBox.TabIndex = 1;
            this.typeBox.TabStop = false;
            this.typeBox.Text = "По типу организации";
            // 
            // statusBox
            // 
            this.statusBox.Controls.Add(this.statusAll);
            this.statusBox.Controls.Add(this.statusIndividual);
            this.statusBox.Controls.Add(this.statusJuridical);
            this.statusBox.Location = new System.Drawing.Point(12, 229);
            this.statusBox.Name = "statusBox";
            this.statusBox.Size = new System.Drawing.Size(624, 132);
            this.statusBox.TabIndex = 2;
            this.statusBox.TabStop = false;
            this.statusBox.Text = "По статусу";
            // 
            // statusJuridical
            // 
            this.statusJuridical.AutoSize = true;
            this.statusJuridical.Location = new System.Drawing.Point(17, 56);
            this.statusJuridical.Name = "statusJuridical";
            this.statusJuridical.Size = new System.Drawing.Size(166, 24);
            this.statusJuridical.TabIndex = 0;
            this.statusJuridical.TabStop = true;
            this.statusJuridical.Text = "Юридическое лицо";
            this.statusJuridical.UseVisualStyleBackColor = true;
            // 
            // statusIndividual
            // 
            this.statusIndividual.AutoSize = true;
            this.statusIndividual.Location = new System.Drawing.Point(17, 86);
            this.statusIndividual.Name = "statusIndividual";
            this.statusIndividual.Size = new System.Drawing.Size(284, 24);
            this.statusIndividual.TabIndex = 1;
            this.statusIndividual.TabStop = true;
            this.statusIndividual.Text = "Индивидуальный предприниматель";
            this.statusIndividual.UseVisualStyleBackColor = true;
            // 
            // statusAll
            // 
            this.statusAll.AutoSize = true;
            this.statusAll.Location = new System.Drawing.Point(17, 26);
            this.statusAll.Name = "statusAll";
            this.statusAll.Size = new System.Drawing.Size(54, 24);
            this.statusAll.TabIndex = 2;
            this.statusAll.TabStop = true;
            this.statusAll.Text = "Все";
            this.statusAll.UseVisualStyleBackColor = true;
            // 
            // close
            // 
            this.close.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.close.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.close.Location = new System.Drawing.Point(495, 383);
            this.close.Name = "close";
            this.close.Size = new System.Drawing.Size(141, 29);
            this.close.TabIndex = 16;
            this.close.Text = "Закрыть";
            this.close.UseVisualStyleBackColor = false;
            // 
            // reset
            // 
            this.reset.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(200)))));
            this.reset.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.reset.Location = new System.Drawing.Point(257, 383);
            this.reset.Name = "reset";
            this.reset.Size = new System.Drawing.Size(141, 29);
            this.reset.TabIndex = 15;
            this.reset.Text = "Сбросить";
            this.reset.UseVisualStyleBackColor = false;
            // 
            // apply
            // 
            this.apply.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(255)))), ((int)(((byte)(200)))));
            this.apply.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.apply.Location = new System.Drawing.Point(12, 383);
            this.apply.Name = "apply";
            this.apply.Size = new System.Drawing.Size(141, 29);
            this.apply.TabIndex = 14;
            this.apply.Text = "Применить";
            this.apply.UseVisualStyleBackColor = false;
            // 
            // OrgFilter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(648, 433);
            this.Controls.Add(this.close);
            this.Controls.Add(this.reset);
            this.Controls.Add(this.apply);
            this.Controls.Add(this.statusBox);
            this.Controls.Add(this.typeBox);
            this.Controls.Add(this.regBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "OrgFilter";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Фильтры: Организации";
            this.regBox.ResumeLayout(false);
            this.typeBox.ResumeLayout(false);
            this.statusBox.ResumeLayout(false);
            this.statusBox.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private GroupBox regBox;
        private ComboBox regComboBox;
        private ComboBox typeComboBox;
        private GroupBox typeBox;
        private GroupBox statusBox;
        private RadioButton statusIndividual;
        private RadioButton statusJuridical;
        private RadioButton statusAll;
        private Button close;
        private Button reset;
        private Button apply;
    }
}