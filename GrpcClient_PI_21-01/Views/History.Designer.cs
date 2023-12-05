namespace GrpcClient_PI_21_01.Views
{
    partial class HistoryForm
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
            button1=new Button();
            dataGridView1=new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // button1
            // 
            button1.DialogResult=DialogResult.OK;
            button1.Location=new Point(1379, 845);
            button1.Margin=new Padding(4);
            button1.Name="button1";
            button1.Size=new Size(129, 44);
            button1.TabIndex=1;
            button1.Text="OK";
            button1.UseVisualStyleBackColor=true;
            // 
            // dataGridView1
            // 
            dataGridView1.AllowUserToAddRows=false;
            dataGridView1.AllowUserToDeleteRows=false;
            dataGridView1.AllowUserToResizeColumns=false;
            dataGridView1.AllowUserToResizeRows=false;
            dataGridView1.AutoSizeColumnsMode=DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.BackgroundColor=Color.OldLace;
            dataGridView1.CellBorderStyle=DataGridViewCellBorderStyle.RaisedVertical;
            dataGridView1.ColumnHeadersHeightSizeMode=DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location=new Point(12, 12);
            dataGridView1.MultiSelect=false;
            dataGridView1.Name="dataGridView1";
            dataGridView1.ReadOnly=true;
            dataGridView1.RowHeadersVisible=false;
            dataGridView1.RowHeadersWidth=51;
            dataGridView1.RowTemplate.Height=29;
            dataGridView1.SelectionMode=DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.Size=new Size(1497, 826);
            dataGridView1.TabIndex=14;
            // 
            // HistoryForm
            // 
            AutoScaleMode=AutoScaleMode.Inherit;
            BackColor=Color.Wheat;
            ClientSize=new Size(1521, 902);
            Controls.Add(dataGridView1);
            Controls.Add(button1);
            Font=new Font("Segoe Print", 10F, FontStyle.Bold, GraphicsUnit.Point);
            FormBorderStyle=FormBorderStyle.FixedToolWindow;
            Margin=new Padding(4);
            Name="HistoryForm";
            StartPosition=FormStartPosition.CenterScreen;
            Text="History";
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
        }

        #endregion
        private Button button1;
        private DataGridView dataGridView1;
    }
}