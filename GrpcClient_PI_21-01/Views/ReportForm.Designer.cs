
namespace GrpcClient_PI_21_01.Views
{
    partial class ReportForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ReportForm));
            this.dateTimePickerStart = new System.Windows.Forms.DateTimePicker();
            this.dateTimePickerEnd = new System.Windows.Forms.DateTimePicker();
            this.comboBoxSity = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dataGridViewR = new System.Windows.Forms.DataGridView();
            this.НС = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ЗЗ = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ОЖ = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.С = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.textBoxSum = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewR)).BeginInit();
            this.SuspendLayout();
            // 
            // dateTimePickerStart
            // 
            this.dateTimePickerStart.Location = new System.Drawing.Point(32, 91);
            this.dateTimePickerStart.Margin = new System.Windows.Forms.Padding(6, 9, 6, 9);
            this.dateTimePickerStart.Name = "dateTimePickerStart";
            this.dateTimePickerStart.Size = new System.Drawing.Size(252, 43);
            this.dateTimePickerStart.TabIndex = 0;
            this.dateTimePickerStart.ValueChanged += new System.EventHandler(this.dateTimePickerStart_ValueChanged);
            // 
            // dateTimePickerEnd
            // 
            this.dateTimePickerEnd.Location = new System.Drawing.Point(303, 91);
            this.dateTimePickerEnd.Margin = new System.Windows.Forms.Padding(6, 9, 6, 9);
            this.dateTimePickerEnd.Name = "dateTimePickerEnd";
            this.dateTimePickerEnd.Size = new System.Drawing.Size(252, 43);
            this.dateTimePickerEnd.TabIndex = 1;
            this.dateTimePickerEnd.ValueChanged += new System.EventHandler(this.dateTimePickerStart_ValueChanged);
            // 
            // comboBoxSity
            // 
            this.comboBoxSity.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxSity.FormattingEnabled = true;
            this.comboBoxSity.Location = new System.Drawing.Point(1127, 382);
            this.comboBoxSity.Margin = new System.Windows.Forms.Padding(6, 9, 6, 9);
            this.comboBoxSity.Name = "comboBoxSity";
            this.comboBoxSity.Size = new System.Drawing.Size(252, 43);
            this.comboBoxSity.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(298, 24);
            this.label2.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(145, 35);
            this.label2.TabIndex = 4;
            this.label2.Text = "Дата конца";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(1121, 318);
            this.label3.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(75, 35);
            this.label3.TabIndex = 5;
            this.label3.Text = "Город";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(26, 24);
            this.label1.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(157, 35);
            this.label1.TabIndex = 3;
            this.label1.Text = "Дата начала";
            // 
            // dataGridViewR
            // 
            this.dataGridViewR.AllowUserToAddRows = false;
            this.dataGridViewR.AllowUserToDeleteRows = false;
            this.dataGridViewR.AllowUserToResizeColumns = false;
            this.dataGridViewR.AllowUserToResizeRows = false;
            this.dataGridViewR.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewR.BackgroundColor = System.Drawing.Color.OldLace;
            this.dataGridViewR.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewR.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.НС,
            this.ЗЗ,
            this.ОЖ,
            this.С});
            this.dataGridViewR.Location = new System.Drawing.Point(26, 161);
            this.dataGridViewR.Margin = new System.Windows.Forms.Padding(6, 9, 6, 9);
            this.dataGridViewR.MultiSelect = false;
            this.dataGridViewR.Name = "dataGridViewR";
            this.dataGridViewR.ReadOnly = true;
            this.dataGridViewR.RowHeadersVisible = false;
            this.dataGridViewR.RowHeadersWidth = 62;
            this.dataGridViewR.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewR.Size = new System.Drawing.Size(1034, 598);
            this.dataGridViewR.TabIndex = 7;
            // 
            // НС
            // 
            this.НС.HeaderText = "Населённый пункт";
            this.НС.MinimumWidth = 8;
            this.НС.Name = "НС";
            this.НС.ReadOnly = true;
            // 
            // ЗЗ
            // 
            this.ЗЗ.HeaderText = "Закрытые заявки";
            this.ЗЗ.MinimumWidth = 8;
            this.ЗЗ.Name = "ЗЗ";
            this.ЗЗ.ReadOnly = true;
            // 
            // ОЖ
            // 
            this.ОЖ.HeaderText = "Отловленные животные";
            this.ОЖ.MinimumWidth = 8;
            this.ОЖ.Name = "ОЖ";
            this.ОЖ.ReadOnly = true;
            // 
            // С
            // 
            this.С.HeaderText = "Стоимость";
            this.С.MinimumWidth = 8;
            this.С.Name = "С";
            this.С.ReadOnly = true;
            // 
            // textBoxSum
            // 
            this.textBoxSum.BackColor = System.Drawing.Color.Cornsilk;
            this.textBoxSum.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxSum.Location = new System.Drawing.Point(828, 808);
            this.textBoxSum.Margin = new System.Windows.Forms.Padding(6, 9, 6, 9);
            this.textBoxSum.Name = "textBoxSum";
            this.textBoxSum.ReadOnly = true;
            this.textBoxSum.Size = new System.Drawing.Size(212, 36);
            this.textBoxSum.TabIndex = 8;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(646, 816);
            this.label4.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(161, 35);
            this.label4.TabIndex = 9;
            this.label4.Text = "Общая сумма";
            // 
            // ReportForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(13F, 35F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Wheat;
            this.ClientSize = new System.Drawing.Size(1070, 894);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.textBoxSum);
            this.Controls.Add(this.dataGridViewR);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboBoxSity);
            this.Controls.Add(this.dateTimePickerEnd);
            this.Controls.Add(this.dateTimePickerStart);
            this.Font = new System.Drawing.Font("Segoe Print", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(6, 9, 6, 9);
            this.Name = "ReportForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Отчёт";
            this.Load += new System.EventHandler(this.ReportForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewR)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker dateTimePickerStart;
        private System.Windows.Forms.DateTimePicker dateTimePickerEnd;
        private System.Windows.Forms.ComboBox comboBoxSity;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dataGridViewR;
        private System.Windows.Forms.DataGridViewTextBoxColumn НС;
        private System.Windows.Forms.DataGridViewTextBoxColumn ЗЗ;
        private System.Windows.Forms.DataGridViewTextBoxColumn ОЖ;
        private System.Windows.Forms.DataGridViewTextBoxColumn С;
        private System.Windows.Forms.TextBox textBoxSum;
        private System.Windows.Forms.Label label4;
    }
}