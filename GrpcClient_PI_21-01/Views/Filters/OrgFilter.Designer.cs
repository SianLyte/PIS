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
            regBox=new GroupBox();
            regComboBox=new ComboBox();
            typeComboBox=new ComboBox();
            typeBox=new GroupBox();
            statusBox=new GroupBox();
            statusAll=new RadioButton();
            statusIndividual=new RadioButton();
            statusJuridical=new RadioButton();
            close=new Button();
            reset=new Button();
            apply=new Button();
            regBox.SuspendLayout();
            typeBox.SuspendLayout();
            statusBox.SuspendLayout();
            SuspendLayout();
            // 
            // regBox
            // 
            regBox.BackColor=Color.Wheat;
            regBox.Controls.Add(regComboBox);
            regBox.Font=new Font("Segoe Print", 10F, FontStyle.Bold, GraphicsUnit.Point);
            regBox.Location=new Point(12, 12);
            regBox.Name="regBox";
            regBox.Size=new Size(624, 91);
            regBox.TabIndex=0;
            regBox.TabStop=false;
            regBox.Text="По адресу регистрации";
            // 
            // regComboBox
            // 
            regComboBox.BackColor=Color.OldLace;
            regComboBox.DropDownStyle=ComboBoxStyle.DropDownList;
            regComboBox.FlatStyle=FlatStyle.Popup;
            regComboBox.Font=new Font("Segoe Print", 10F, FontStyle.Bold, GraphicsUnit.Point);
            regComboBox.FormattingEnabled=true;
            regComboBox.Location=new Point(17, 35);
            regComboBox.Name="regComboBox";
            regComboBox.Size=new Size(586, 38);
            regComboBox.TabIndex=0;
            // 
            // typeComboBox
            // 
            typeComboBox.BackColor=Color.OldLace;
            typeComboBox.DropDownStyle=ComboBoxStyle.DropDownList;
            typeComboBox.FlatStyle=FlatStyle.Popup;
            typeComboBox.Font=new Font("Segoe Print", 10F, FontStyle.Bold, GraphicsUnit.Point);
            typeComboBox.FormattingEnabled=true;
            typeComboBox.Location=new Point(17, 35);
            typeComboBox.Name="typeComboBox";
            typeComboBox.Size=new Size(586, 38);
            typeComboBox.TabIndex=0;
            // 
            // typeBox
            // 
            typeBox.BackColor=Color.Wheat;
            typeBox.Controls.Add(typeComboBox);
            typeBox.Font=new Font("Segoe Print", 10F, FontStyle.Bold, GraphicsUnit.Point);
            typeBox.Location=new Point(12, 132);
            typeBox.Name="typeBox";
            typeBox.Size=new Size(624, 91);
            typeBox.TabIndex=1;
            typeBox.TabStop=false;
            typeBox.Text="По типу организации";
            // 
            // statusBox
            // 
            statusBox.BackColor=Color.Wheat;
            statusBox.Controls.Add(statusAll);
            statusBox.Controls.Add(statusIndividual);
            statusBox.Controls.Add(statusJuridical);
            statusBox.Font=new Font("Segoe Print", 10F, FontStyle.Bold, GraphicsUnit.Point);
            statusBox.Location=new Point(12, 246);
            statusBox.Name="statusBox";
            statusBox.Size=new Size(624, 150);
            statusBox.TabIndex=2;
            statusBox.TabStop=false;
            statusBox.Text="По статусу";
            // 
            // statusAll
            // 
            statusAll.AutoSize=true;
            statusAll.Font=new Font("Segoe Print", 10F, FontStyle.Bold, GraphicsUnit.Point);
            statusAll.Location=new Point(17, 36);
            statusAll.Name="statusAll";
            statusAll.Size=new Size(65, 34);
            statusAll.TabIndex=2;
            statusAll.TabStop=true;
            statusAll.Text="Все";
            statusAll.UseVisualStyleBackColor=true;
            // 
            // statusIndividual
            // 
            statusIndividual.AutoSize=true;
            statusIndividual.Font=new Font("Segoe Print", 10F, FontStyle.Bold, GraphicsUnit.Point);
            statusIndividual.Location=new Point(17, 110);
            statusIndividual.Name="statusIndividual";
            statusIndividual.Size=new Size(348, 34);
            statusIndividual.TabIndex=1;
            statusIndividual.TabStop=true;
            statusIndividual.Text="Индивидуальный предприниматель";
            statusIndividual.UseVisualStyleBackColor=true;
            // 
            // statusJuridical
            // 
            statusJuridical.AutoSize=true;
            statusJuridical.Font=new Font("Segoe Print", 10F, FontStyle.Bold, GraphicsUnit.Point);
            statusJuridical.Location=new Point(17, 70);
            statusJuridical.Name="statusJuridical";
            statusJuridical.Size=new Size(194, 34);
            statusJuridical.TabIndex=0;
            statusJuridical.TabStop=true;
            statusJuridical.Text="Юридическое лицо";
            statusJuridical.UseVisualStyleBackColor=true;
            // 
            // close
            // 
            close.BackColor=Color.Wheat;
            close.FlatStyle=FlatStyle.Flat;
            close.Font=new Font("Segoe Print", 10F, FontStyle.Bold, GraphicsUnit.Point);
            close.Location=new Point(495, 429);
            close.Name="close";
            close.Size=new Size(141, 40);
            close.TabIndex=16;
            close.Text="Закрыть";
            close.UseVisualStyleBackColor=false;
            // 
            // reset
            // 
            reset.BackColor=Color.Wheat;
            reset.FlatStyle=FlatStyle.Flat;
            reset.Font=new Font("Segoe Print", 10F, FontStyle.Bold, GraphicsUnit.Point);
            reset.Location=new Point(257, 429);
            reset.Name="reset";
            reset.Size=new Size(141, 40);
            reset.TabIndex=15;
            reset.Text="Сбросить";
            reset.UseVisualStyleBackColor=false;
            // 
            // apply
            // 
            apply.BackColor=Color.Wheat;
            apply.FlatStyle=FlatStyle.Flat;
            apply.Font=new Font("Segoe Print", 10F, FontStyle.Bold, GraphicsUnit.Point);
            apply.Location=new Point(12, 429);
            apply.Name="apply";
            apply.Size=new Size(141, 40);
            apply.TabIndex=14;
            apply.Text="Применить";
            apply.UseVisualStyleBackColor=false;
            // 
            // OrgFilter
            // 
            AutoScaleDimensions=new SizeF(8F, 20F);
            AutoScaleMode=AutoScaleMode.Font;
            BackColor=Color.Tan;
            ClientSize=new Size(648, 489);
            Controls.Add(close);
            Controls.Add(reset);
            Controls.Add(apply);
            Controls.Add(statusBox);
            Controls.Add(typeBox);
            Controls.Add(regBox);
            Cursor=Cursors.PanNW;
            FormBorderStyle=FormBorderStyle.FixedSingle;
            MaximizeBox=false;
            Name="OrgFilter";
            ShowIcon=false;
            StartPosition=FormStartPosition.CenterParent;
            Text="Фильтры: Организации";
            regBox.ResumeLayout(false);
            typeBox.ResumeLayout(false);
            statusBox.ResumeLayout(false);
            statusBox.PerformLayout();
            ResumeLayout(false);
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