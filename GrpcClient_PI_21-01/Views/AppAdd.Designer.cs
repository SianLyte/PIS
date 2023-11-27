namespace GrpcClient_PI_21_01.Views
{
    partial class AppAdd
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AppAdd));
            this.Cancel = new System.Windows.Forms.Button();
            this.OkAppAdd = new System.Windows.Forms.Button();
            this.descrip = new System.Windows.Forms.TextBox();
            this.urgency = new System.Windows.Forms.TextBox();
            this.animalHabbiat = new System.Windows.Forms.TextBox();
            this.territory = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.locality = new System.Windows.Forms.ComboBox();
            this.category = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // Cancel
            // 
            this.Cancel.BackColor = System.Drawing.Color.Cornsilk;
            this.Cancel.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.Cancel.Location = new System.Drawing.Point(650, 860);
            this.Cancel.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Cancel.Name = "Cancel";
            this.Cancel.Size = new System.Drawing.Size(191, 93);
            this.Cancel.TabIndex = 31;
            this.Cancel.Text = "Отмена";
            this.Cancel.UseVisualStyleBackColor = false;
            this.Cancel.Click += new System.EventHandler(this.Cancel_Click);
            // 
            // OkAppAdd
            // 
            this.OkAppAdd.BackColor = System.Drawing.Color.Cornsilk;
            this.OkAppAdd.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.OkAppAdd.Location = new System.Drawing.Point(141, 860);
            this.OkAppAdd.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.OkAppAdd.Name = "OkAppAdd";
            this.OkAppAdd.Size = new System.Drawing.Size(191, 93);
            this.OkAppAdd.TabIndex = 30;
            this.OkAppAdd.Text = "OK";
            this.OkAppAdd.UseVisualStyleBackColor = false;
            this.OkAppAdd.Click += new System.EventHandler(this.OkAppAdd_Click);
            // 
            // descrip
            // 
            this.descrip.BackColor = System.Drawing.Color.Cornsilk;
            this.descrip.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.descrip.Location = new System.Drawing.Point(383, 519);
            this.descrip.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.descrip.MaxLength = 50;
            this.descrip.Multiline = true;
            this.descrip.Name = "descrip";
            this.descrip.Size = new System.Drawing.Size(510, 207);
            this.descrip.TabIndex = 28;
            // 
            // urgency
            // 
            this.urgency.BackColor = System.Drawing.Color.Cornsilk;
            this.urgency.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.urgency.Location = new System.Drawing.Point(383, 421);
            this.urgency.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.urgency.MaxLength = 15;
            this.urgency.Name = "urgency";
            this.urgency.Size = new System.Drawing.Size(510, 30);
            this.urgency.TabIndex = 27;
            // 
            // animalHabbiat
            // 
            this.animalHabbiat.BackColor = System.Drawing.Color.Cornsilk;
            this.animalHabbiat.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.animalHabbiat.Location = new System.Drawing.Point(383, 315);
            this.animalHabbiat.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.animalHabbiat.MaxLength = 30;
            this.animalHabbiat.Name = "animalHabbiat";
            this.animalHabbiat.Size = new System.Drawing.Size(510, 30);
            this.animalHabbiat.TabIndex = 26;
            // 
            // territory
            // 
            this.territory.BackColor = System.Drawing.Color.Cornsilk;
            this.territory.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.territory.Location = new System.Drawing.Point(383, 223);
            this.territory.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.territory.MaxLength = 30;
            this.territory.Name = "territory";
            this.territory.Size = new System.Drawing.Size(510, 30);
            this.territory.TabIndex = 25;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(43, 765);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(211, 30);
            this.label7.TabIndex = 22;
            this.label7.Text = "Категория заявителя";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(43, 522);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(203, 30);
            this.label6.TabIndex = 21;
            this.label6.Text = "Описание животного";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(43, 418);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(215, 30);
            this.label5.TabIndex = 20;
            this.label5.Text = "Срочность исполнения";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(43, 312);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(273, 30);
            this.label4.TabIndex = 19;
            this.label4.Text = "Место обитания животного";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(43, 220);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(122, 30);
            this.label3.TabIndex = 18;
            this.label3.Text = "Территория";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(43, 126);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(182, 30);
            this.label2.TabIndex = 17;
            this.label2.Text = "Населенный пункт";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(43, 23);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(132, 30);
            this.label1.TabIndex = 16;
            this.label1.Text = "Дата подачи";
            // 
            // dateTimePicker
            // 
            this.dateTimePicker.CalendarMonthBackground = System.Drawing.Color.Cornsilk;
            this.dateTimePicker.CalendarTitleBackColor = System.Drawing.Color.Cornsilk;
            this.dateTimePicker.CalendarTrailingForeColor = System.Drawing.SystemColors.ControlText;
            this.dateTimePicker.Cursor = System.Windows.Forms.Cursors.PanNW;
            this.dateTimePicker.Location = new System.Drawing.Point(383, 23);
            this.dateTimePicker.Margin = new System.Windows.Forms.Padding(6, 9, 6, 9);
            this.dateTimePicker.Name = "dateTimePicker";
            this.dateTimePicker.Size = new System.Drawing.Size(250, 37);
            this.dateTimePicker.TabIndex = 33;
            this.dateTimePicker.Value = new System.DateTime(2023, 6, 10, 0, 0, 0, 0);
            // 
            // locality
            // 
            this.locality.BackColor = System.Drawing.Color.Cornsilk;
            this.locality.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.locality.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.locality.Font = new System.Drawing.Font("Segoe Print", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.locality.FormattingEnabled = true;
            this.locality.Location = new System.Drawing.Point(383, 126);
            this.locality.Name = "locality";
            this.locality.Size = new System.Drawing.Size(510, 34);
            this.locality.TabIndex = 34;
            // 
            // category
            // 
            this.category.BackColor = System.Drawing.Color.Cornsilk;
            this.category.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.category.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.category.Font = new System.Drawing.Font("Segoe Print", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.category.FormattingEnabled = true;
            this.category.Location = new System.Drawing.Point(383, 765);
            this.category.Name = "category";
            this.category.Size = new System.Drawing.Size(510, 34);
            this.category.TabIndex = 35;
            // 
            // AppAdd
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 30F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Wheat;
            this.ClientSize = new System.Drawing.Size(1015, 1017);
            this.Controls.Add(this.category);
            this.Controls.Add(this.locality);
            this.Controls.Add(this.dateTimePicker);
            this.Controls.Add(this.Cancel);
            this.Controls.Add(this.OkAppAdd);
            this.Controls.Add(this.descrip);
            this.Controls.Add(this.urgency);
            this.Controls.Add(this.animalHabbiat);
            this.Controls.Add(this.territory);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Segoe Print", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "AppAdd";
            this.Text = "Добавление заявки на отлов";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Button Cancel;
        private Button OkAppAdd;
        private TextBox descrip;
        private TextBox urgency;
        private TextBox animalHabbiat;
        private TextBox territory;
        private Label label7;
        private Label label6;
        private Label label5;
        private Label label4;
        private Label label3;
        private Label label2;
        private Label label1;
        private DateTimePicker dateTimePicker;
        private ComboBox locality;
        private ComboBox category;
    }
}