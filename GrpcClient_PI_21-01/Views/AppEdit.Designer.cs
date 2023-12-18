namespace GrpcClient_PI_21_01.Views
{
    partial class AppEdit
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AppEdit));
            label1=new Label();
            label2=new Label();
            label3=new Label();
            label4=new Label();
            label5=new Label();
            label6=new Label();
            label7=new Label();
            territory=new TextBox();
            animalHabbiat=new TextBox();
            urgency=new TextBox();
            descrip=new TextBox();
            OkAppEdit=new Button();
            Cancel=new Button();
            dateTime=new DateTimePicker();
            locality=new ComboBox();
            category=new ComboBox();
            label8=new Label();
            textBoxStatus=new TextBox();
            buttonCloseApp=new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize=true;
            label1.Location=new Point(39, 44);
            label1.Margin=new Padding(4, 0, 4, 0);
            label1.Name="label1";
            label1.Size=new Size(132, 30);
            label1.TabIndex=0;
            label1.Text="Дата подачи";
            // 
            // label2
            // 
            label2.AutoSize=true;
            label2.Location=new Point(41, 112);
            label2.Margin=new Padding(4, 0, 4, 0);
            label2.Name="label2";
            label2.Size=new Size(182, 30);
            label2.TabIndex=1;
            label2.Text="Населенный пункт";
            // 
            // label3
            // 
            label3.AutoSize=true;
            label3.Location=new Point(41, 183);
            label3.Margin=new Padding(4, 0, 4, 0);
            label3.Name="label3";
            label3.Size=new Size(122, 30);
            label3.TabIndex=2;
            label3.Text="Территория";
            // 
            // label4
            // 
            label4.AutoSize=true;
            label4.Location=new Point(41, 256);
            label4.Margin=new Padding(4, 0, 4, 0);
            label4.Name="label4";
            label4.Size=new Size(273, 30);
            label4.TabIndex=3;
            label4.Text="Место обитания животного";
            // 
            // label5
            // 
            label5.AutoSize=true;
            label5.Location=new Point(41, 328);
            label5.Margin=new Padding(4, 0, 4, 0);
            label5.Name="label5";
            label5.Size=new Size(215, 30);
            label5.TabIndex=4;
            label5.Text="Срочность исполнения";
            // 
            // label6
            // 
            label6.AutoSize=true;
            label6.Location=new Point(41, 397);
            label6.Margin=new Padding(4, 0, 4, 0);
            label6.Name="label6";
            label6.Size=new Size(203, 30);
            label6.TabIndex=5;
            label6.Text="Описание животного";
            // 
            // label7
            // 
            label7.AutoSize=true;
            label7.Location=new Point(41, 618);
            label7.Margin=new Padding(4, 0, 4, 0);
            label7.Name="label7";
            label7.Size=new Size(211, 30);
            label7.TabIndex=6;
            label7.Text="Категория заявителя";
            // 
            // territory
            // 
            territory.BackColor=Color.Cornsilk;
            territory.BorderStyle=BorderStyle.None;
            territory.Location=new Point(470, 183);
            territory.Margin=new Padding(4, 5, 4, 5);
            territory.MaxLength=30;
            territory.Name="territory";
            territory.Size=new Size(510, 30);
            territory.TabIndex=9;
            // 
            // animalHabbiat
            // 
            animalHabbiat.BackColor=Color.Cornsilk;
            animalHabbiat.BorderStyle=BorderStyle.None;
            animalHabbiat.Location=new Point(470, 256);
            animalHabbiat.Margin=new Padding(4, 5, 4, 5);
            animalHabbiat.MaxLength=30;
            animalHabbiat.Name="animalHabbiat";
            animalHabbiat.Size=new Size(510, 30);
            animalHabbiat.TabIndex=10;
            // 
            // urgency
            // 
            urgency.BackColor=Color.Cornsilk;
            urgency.BorderStyle=BorderStyle.None;
            urgency.Location=new Point(470, 328);
            urgency.Margin=new Padding(4, 5, 4, 5);
            urgency.MaxLength=15;
            urgency.Name="urgency";
            urgency.Size=new Size(510, 30);
            urgency.TabIndex=11;
            // 
            // descrip
            // 
            descrip.BackColor=Color.Cornsilk;
            descrip.BorderStyle=BorderStyle.None;
            descrip.Location=new Point(470, 392);
            descrip.Margin=new Padding(4, 5, 4, 5);
            descrip.MaxLength=50;
            descrip.Multiline=true;
            descrip.Name="descrip";
            descrip.Size=new Size(510, 207);
            descrip.TabIndex=12;
            // 
            // OkAppEdit
            // 
            OkAppEdit.BackColor=Color.Cornsilk;
            OkAppEdit.FlatStyle=FlatStyle.Popup;
            OkAppEdit.Location=new Point(170, 790);
            OkAppEdit.Margin=new Padding(4, 5, 4, 5);
            OkAppEdit.Name="OkAppEdit";
            OkAppEdit.Size=new Size(191, 54);
            OkAppEdit.TabIndex=14;
            OkAppEdit.Text="OK";
            OkAppEdit.UseVisualStyleBackColor=false;
            OkAppEdit.Click+=OkAppEdit_Click;
            // 
            // Cancel
            // 
            Cancel.BackColor=Color.Cornsilk;
            Cancel.FlatStyle=FlatStyle.Popup;
            Cancel.Location=new Point(760, 790);
            Cancel.Margin=new Padding(4, 5, 4, 5);
            Cancel.Name="Cancel";
            Cancel.Size=new Size(191, 54);
            Cancel.TabIndex=15;
            Cancel.Text="Отмена";
            Cancel.UseVisualStyleBackColor=false;
            Cancel.Click+=Cancel_Click;
            // 
            // dateTime
            // 
            dateTime.CalendarMonthBackground=Color.Cornsilk;
            dateTime.CalendarTitleBackColor=Color.Cornsilk;
            dateTime.CalendarTrailingForeColor=SystemColors.ControlText;
            dateTime.Cursor=Cursors.PanNW;
            dateTime.Location=new Point(470, 37);
            dateTime.Margin=new Padding(6, 9, 6, 9);
            dateTime.Name="dateTime";
            dateTime.Size=new Size(250, 37);
            dateTime.TabIndex=16;
            dateTime.Value=new DateTime(2023, 6, 10, 0, 0, 0, 0);
            // 
            // locality
            // 
            locality.BackColor=Color.Cornsilk;
            locality.DropDownStyle=ComboBoxStyle.DropDownList;
            locality.FlatStyle=FlatStyle.Popup;
            locality.Font=new Font("Segoe Print", 9F, FontStyle.Bold, GraphicsUnit.Point);
            locality.FormattingEnabled=true;
            locality.Location=new Point(470, 112);
            locality.Name="locality";
            locality.Size=new Size(510, 34);
            locality.TabIndex=35;
            // 
            // category
            // 
            category.BackColor=Color.Cornsilk;
            category.DropDownStyle=ComboBoxStyle.DropDownList;
            category.FlatStyle=FlatStyle.Popup;
            category.Font=new Font("Segoe Print", 9F, FontStyle.Bold, GraphicsUnit.Point);
            category.FormattingEnabled=true;
            category.Location=new Point(470, 618);
            category.Name="category";
            category.Size=new Size(510, 34);
            category.TabIndex=36;
            // 
            // label8
            // 
            label8.AutoSize=true;
            label8.Location=new Point(41, 676);
            label8.Margin=new Padding(4, 0, 4, 0);
            label8.Name="label8";
            label8.Size=new Size(88, 30);
            label8.TabIndex=37;
            label8.Text="Статус";
            // 
            // textBoxStatus
            // 
            textBoxStatus.BackColor=Color.Cornsilk;
            textBoxStatus.BorderStyle=BorderStyle.None;
            textBoxStatus.Location=new Point(470, 676);
            textBoxStatus.Margin=new Padding(4, 5, 4, 5);
            textBoxStatus.MaxLength=15;
            textBoxStatus.Name="textBoxStatus";
            textBoxStatus.ReadOnly=true;
            textBoxStatus.Size=new Size(510, 30);
            textBoxStatus.TabIndex=38;
            // 
            // buttonCloseApp
            // 
            buttonCloseApp.BackColor=Color.Cornsilk;
            buttonCloseApp.FlatStyle=FlatStyle.Popup;
            buttonCloseApp.Location=new Point(789, 726);
            buttonCloseApp.Margin=new Padding(4, 5, 4, 5);
            buttonCloseApp.Name="buttonCloseApp";
            buttonCloseApp.Size=new Size(191, 54);
            buttonCloseApp.TabIndex=39;
            buttonCloseApp.Text="Закрыть заявку";
            buttonCloseApp.UseVisualStyleBackColor=false;
            buttonCloseApp.Click+=ButtonCloseApp_Click;
            // 
            // AppEdit
            // 
            AutoScaleDimensions=new SizeF(11F, 30F);
            AutoScaleMode=AutoScaleMode.Font;
            BackColor=Color.Wheat;
            ClientSize=new Size(1106, 858);
            Controls.Add(buttonCloseApp);
            Controls.Add(textBoxStatus);
            Controls.Add(label8);
            Controls.Add(category);
            Controls.Add(locality);
            Controls.Add(dateTime);
            Controls.Add(Cancel);
            Controls.Add(OkAppEdit);
            Controls.Add(descrip);
            Controls.Add(urgency);
            Controls.Add(animalHabbiat);
            Controls.Add(territory);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Font=new Font("Segoe Print", 10F, FontStyle.Bold, GraphicsUnit.Point);
            Icon=(Icon)resources.GetObject("$this.Icon");
            Margin=new Padding(4, 5, 4, 5);
            Name="AppEdit";
            Text="Изменение заявки на отлов";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private Label label7;
        private TextBox territory;
        private TextBox animalHabbiat;
        private TextBox urgency;
        private TextBox descrip;
        private Button OkAppEdit;
        private Button Cancel;
        private DateTimePicker dateTime;
        private ComboBox locality;
        private ComboBox category;
        private Label label8;
        private TextBox textBoxStatus;
        private Button buttonCloseApp;
    }
}