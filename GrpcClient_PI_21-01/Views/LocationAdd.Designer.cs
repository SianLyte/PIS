namespace GrpcClient_PI_21_01.Views
{
    partial class LocationAdd
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LocationAdd));
            this.CityText = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.CancelcontEdit = new System.Windows.Forms.Button();
            this.OKcontAdd = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // CityText
            // 
            this.CityText.BackColor = System.Drawing.Color.OldLace;
            this.CityText.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.CityText.Location = new System.Drawing.Point(108, 26);
            this.CityText.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            this.CityText.Name = "CityText";
            this.CityText.Size = new System.Drawing.Size(218, 36);
            this.CityText.TabIndex = 49;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(20, 33);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(81, 35);
            this.label3.TabIndex = 48;
            this.label3.Text = "Город:";
            // 
            // CancelcontEdit
            // 
            this.CancelcontEdit.BackColor = System.Drawing.Color.Cornsilk;
            this.CancelcontEdit.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.CancelcontEdit.Location = new System.Drawing.Point(178, 86);
            this.CancelcontEdit.Margin = new System.Windows.Forms.Padding(4);
            this.CancelcontEdit.Name = "CancelcontEdit";
            this.CancelcontEdit.Size = new System.Drawing.Size(153, 74);
            this.CancelcontEdit.TabIndex = 47;
            this.CancelcontEdit.Text = "Отмена";
            this.CancelcontEdit.UseVisualStyleBackColor = false;
            this.CancelcontEdit.Click += new System.EventHandler(this.CancelcontEdit_Click);
            // 
            // OKcontAdd
            // 
            this.OKcontAdd.BackColor = System.Drawing.Color.Cornsilk;
            this.OKcontAdd.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.OKcontAdd.Location = new System.Drawing.Point(14, 86);
            this.OKcontAdd.Margin = new System.Windows.Forms.Padding(4);
            this.OKcontAdd.Name = "OKcontAdd";
            this.OKcontAdd.Size = new System.Drawing.Size(153, 74);
            this.OKcontAdd.TabIndex = 46;
            this.OKcontAdd.Text = "OK";
            this.OKcontAdd.UseVisualStyleBackColor = false;
            this.OKcontAdd.Click += new System.EventHandler(this.OKcontAdd_Click);
            // 
            // LocationAdd
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(13F, 35F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Wheat;
            this.ClientSize = new System.Drawing.Size(360, 182);
            this.Controls.Add(this.CityText);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.CancelcontEdit);
            this.Controls.Add(this.OKcontAdd);
            this.Font = new System.Drawing.Font("Segoe Print", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            this.Name = "LocationAdd";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox CityText;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button CancelcontEdit;
        private System.Windows.Forms.Button OKcontAdd;
    }
}