namespace ToDoList.WindowsApp
{
    partial class UpdateTask
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
            this.comboBoxIsCompleted = new System.Windows.Forms.ComboBox();
            this.labelIsCompleted = new System.Windows.Forms.Label();
            this.buttonOk = new System.Windows.Forms.Button();
            this.labelStartDate = new System.Windows.Forms.Label();
            this.dateTimePickerStartDate = new System.Windows.Forms.DateTimePicker();
            this.labelTextTask = new System.Windows.Forms.Label();
            this.textBoxTextTask = new System.Windows.Forms.TextBox();
            this.checkBoxEndDate = new System.Windows.Forms.CheckBox();
            this.dateTimePickerEndDate = new System.Windows.Forms.DateTimePicker();
            this.buttonBack = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // comboBoxIsCompleted
            // 
            this.comboBoxIsCompleted.FormattingEnabled = true;
            this.comboBoxIsCompleted.Items.AddRange(new object[] {
            "Yes",
            "No"});
            this.comboBoxIsCompleted.Location = new System.Drawing.Point(79, 66);
            this.comboBoxIsCompleted.Name = "comboBoxIsCompleted";
            this.comboBoxIsCompleted.Size = new System.Drawing.Size(121, 21);
            this.comboBoxIsCompleted.TabIndex = 30;
            // 
            // labelIsCompleted
            // 
            this.labelIsCompleted.AutoSize = true;
            this.labelIsCompleted.Location = new System.Drawing.Point(2, 69);
            this.labelIsCompleted.Name = "labelIsCompleted";
            this.labelIsCompleted.Size = new System.Drawing.Size(68, 13);
            this.labelIsCompleted.TabIndex = 29;
            this.labelIsCompleted.Text = "IsCompleted:";
            // 
            // buttonOk
            // 
            this.buttonOk.Location = new System.Drawing.Point(202, 212);
            this.buttonOk.Name = "buttonOk";
            this.buttonOk.Size = new System.Drawing.Size(75, 23);
            this.buttonOk.TabIndex = 28;
            this.buttonOk.Text = "Ok";
            this.buttonOk.UseVisualStyleBackColor = true;
            this.buttonOk.Click += new System.EventHandler(this.buttonOk_Click);
            // 
            // labelStartDate
            // 
            this.labelStartDate.AutoSize = true;
            this.labelStartDate.Location = new System.Drawing.Point(9, 102);
            this.labelStartDate.Name = "labelStartDate";
            this.labelStartDate.Size = new System.Drawing.Size(58, 13);
            this.labelStartDate.TabIndex = 25;
            this.labelStartDate.Text = "Start Date:";
            // 
            // dateTimePickerStartDate
            // 
            this.dateTimePickerStartDate.CustomFormat = "";
            this.dateTimePickerStartDate.Location = new System.Drawing.Point(79, 96);
            this.dateTimePickerStartDate.Name = "dateTimePickerStartDate";
            this.dateTimePickerStartDate.Size = new System.Drawing.Size(198, 20);
            this.dateTimePickerStartDate.TabIndex = 24;
            this.dateTimePickerStartDate.Value = new System.DateTime(2018, 6, 15, 13, 16, 3, 0);
            // 
            // labelTextTask
            // 
            this.labelTextTask.AutoSize = true;
            this.labelTextTask.Location = new System.Drawing.Point(26, 38);
            this.labelTextTask.Name = "labelTextTask";
            this.labelTextTask.Size = new System.Drawing.Size(31, 13);
            this.labelTextTask.TabIndex = 23;
            this.labelTextTask.Text = "Text:";
            // 
            // textBoxTextTask
            // 
            this.textBoxTextTask.Location = new System.Drawing.Point(79, 40);
            this.textBoxTextTask.Name = "textBoxTextTask";
            this.textBoxTextTask.Size = new System.Drawing.Size(198, 20);
            this.textBoxTextTask.TabIndex = 22;
            // 
            // checkBoxEndDate
            // 
            this.checkBoxEndDate.AutoSize = true;
            this.checkBoxEndDate.Location = new System.Drawing.Point(5, 140);
            this.checkBoxEndDate.Name = "checkBoxEndDate";
            this.checkBoxEndDate.Size = new System.Drawing.Size(68, 17);
            this.checkBoxEndDate.TabIndex = 32;
            this.checkBoxEndDate.Text = "EndDate";
            this.checkBoxEndDate.UseVisualStyleBackColor = true;
            this.checkBoxEndDate.CheckedChanged += new System.EventHandler(this.checkBoxEndDate_CheckedChanged);
            // 
            // dateTimePickerEndDate
            // 
            this.dateTimePickerEndDate.CustomFormat = "";
            this.dateTimePickerEndDate.Enabled = false;
            this.dateTimePickerEndDate.Location = new System.Drawing.Point(79, 137);
            this.dateTimePickerEndDate.Name = "dateTimePickerEndDate";
            this.dateTimePickerEndDate.Size = new System.Drawing.Size(198, 20);
            this.dateTimePickerEndDate.TabIndex = 31;
            this.dateTimePickerEndDate.Value = new System.DateTime(2018, 6, 18, 11, 14, 53, 0);
            // 
            // buttonBack
            // 
            this.buttonBack.Location = new System.Drawing.Point(100, 212);
            this.buttonBack.Name = "buttonBack";
            this.buttonBack.Size = new System.Drawing.Size(75, 23);
            this.buttonBack.TabIndex = 33;
            this.buttonBack.Text = "Back";
            this.buttonBack.UseVisualStyleBackColor = true;
            this.buttonBack.Click += new System.EventHandler(this.buttonBack_Click);
            // 
            // UpdateTask
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(304, 256);
            this.Controls.Add(this.buttonBack);
            this.Controls.Add(this.checkBoxEndDate);
            this.Controls.Add(this.dateTimePickerEndDate);
            this.Controls.Add(this.comboBoxIsCompleted);
            this.Controls.Add(this.labelIsCompleted);
            this.Controls.Add(this.buttonOk);
            this.Controls.Add(this.labelStartDate);
            this.Controls.Add(this.dateTimePickerStartDate);
            this.Controls.Add(this.labelTextTask);
            this.Controls.Add(this.textBoxTextTask);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "UpdateTask";
            this.Text = "UpdateTask";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBoxIsCompleted;
        private System.Windows.Forms.Label labelIsCompleted;
        private System.Windows.Forms.Button buttonOk;
        private System.Windows.Forms.Label labelStartDate;
        private System.Windows.Forms.DateTimePicker dateTimePickerStartDate;
        private System.Windows.Forms.Label labelTextTask;
        private System.Windows.Forms.TextBox textBoxTextTask;
        private System.Windows.Forms.CheckBox checkBoxEndDate;
        private System.Windows.Forms.DateTimePicker dateTimePickerEndDate;
        private System.Windows.Forms.Button buttonBack;
    }
}