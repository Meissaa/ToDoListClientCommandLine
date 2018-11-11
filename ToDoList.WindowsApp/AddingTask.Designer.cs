namespace ToDoList.WindowsApp
{
    partial class AddingTask
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
            this.dateTimePickerEndDate = new System.Windows.Forms.DateTimePicker();
            this.labelStartDate = new System.Windows.Forms.Label();
            this.dateTimePickerStartDate = new System.Windows.Forms.DateTimePicker();
            this.labelTextTask = new System.Windows.Forms.Label();
            this.textBoxTextTask = new System.Windows.Forms.TextBox();
            this.checkBoxEndDate = new System.Windows.Forms.CheckBox();
            this.buttonBack = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // comboBoxIsCompleted
            // 
            this.comboBoxIsCompleted.AutoCompleteCustomSource.AddRange(new string[] {
            "True",
            "False"});
            this.comboBoxIsCompleted.FormattingEnabled = true;
            this.comboBoxIsCompleted.Items.AddRange(new object[] {
            "Yes",
            "No"});
            this.comboBoxIsCompleted.Location = new System.Drawing.Point(82, 66);
            this.comboBoxIsCompleted.Name = "comboBoxIsCompleted";
            this.comboBoxIsCompleted.Size = new System.Drawing.Size(121, 21);
            this.comboBoxIsCompleted.TabIndex = 21;
            // 
            // labelIsCompleted
            // 
            this.labelIsCompleted.AutoSize = true;
            this.labelIsCompleted.Location = new System.Drawing.Point(5, 69);
            this.labelIsCompleted.Name = "labelIsCompleted";
            this.labelIsCompleted.Size = new System.Drawing.Size(68, 13);
            this.labelIsCompleted.TabIndex = 20;
            this.labelIsCompleted.Text = "IsCompleted:";
            // 
            // buttonOk
            // 
            this.buttonOk.Location = new System.Drawing.Point(205, 200);
            this.buttonOk.Name = "buttonOk";
            this.buttonOk.Size = new System.Drawing.Size(75, 23);
            this.buttonOk.TabIndex = 19;
            this.buttonOk.Text = "Ok";
            this.buttonOk.UseVisualStyleBackColor = true;
            this.buttonOk.Click += new System.EventHandler(this.buttonOk_Click);
            // 
            // dateTimePickerEndDate
            // 
            this.dateTimePickerEndDate.CustomFormat = "";
            this.dateTimePickerEndDate.Enabled = false;
            this.dateTimePickerEndDate.Location = new System.Drawing.Point(82, 137);
            this.dateTimePickerEndDate.Name = "dateTimePickerEndDate";
            this.dateTimePickerEndDate.Size = new System.Drawing.Size(198, 20);
            this.dateTimePickerEndDate.TabIndex = 18;
            this.dateTimePickerEndDate.Value = new System.DateTime(2018, 6, 18, 11, 14, 53, 0);
            // 
            // labelStartDate
            // 
            this.labelStartDate.AutoSize = true;
            this.labelStartDate.Location = new System.Drawing.Point(12, 102);
            this.labelStartDate.Name = "labelStartDate";
            this.labelStartDate.Size = new System.Drawing.Size(58, 13);
            this.labelStartDate.TabIndex = 16;
            this.labelStartDate.Text = "Start Date:";
            // 
            // dateTimePickerStartDate
            // 
            this.dateTimePickerStartDate.Location = new System.Drawing.Point(82, 96);
            this.dateTimePickerStartDate.Name = "dateTimePickerStartDate";
            this.dateTimePickerStartDate.Size = new System.Drawing.Size(198, 20);
            this.dateTimePickerStartDate.TabIndex = 15;
            // 
            // labelTextTask
            // 
            this.labelTextTask.AutoSize = true;
            this.labelTextTask.Location = new System.Drawing.Point(29, 38);
            this.labelTextTask.Name = "labelTextTask";
            this.labelTextTask.Size = new System.Drawing.Size(31, 13);
            this.labelTextTask.TabIndex = 14;
            this.labelTextTask.Text = "Text:";
            // 
            // textBoxTextTask
            // 
            this.textBoxTextTask.Location = new System.Drawing.Point(82, 40);
            this.textBoxTextTask.Name = "textBoxTextTask";
            this.textBoxTextTask.Size = new System.Drawing.Size(198, 20);
            this.textBoxTextTask.TabIndex = 13;
            // 
            // checkBoxEndDate
            // 
            this.checkBoxEndDate.AutoSize = true;
            this.checkBoxEndDate.Location = new System.Drawing.Point(8, 140);
            this.checkBoxEndDate.Name = "checkBoxEndDate";
            this.checkBoxEndDate.Size = new System.Drawing.Size(68, 17);
            this.checkBoxEndDate.TabIndex = 22;
            this.checkBoxEndDate.Text = "EndDate";
            this.checkBoxEndDate.UseVisualStyleBackColor = true;
            this.checkBoxEndDate.CheckedChanged += new System.EventHandler(this.checkBoxEndDate_CheckedChanged);
            // 
            // buttonBack
            // 
            this.buttonBack.Location = new System.Drawing.Point(111, 200);
            this.buttonBack.Name = "buttonBack";
            this.buttonBack.Size = new System.Drawing.Size(75, 23);
            this.buttonBack.TabIndex = 23;
            this.buttonBack.Text = "Back";
            this.buttonBack.UseVisualStyleBackColor = true;
            this.buttonBack.Click += new System.EventHandler(this.buttonBack_Click_1);
            // 
            // AddingTask
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(309, 246);
            this.Controls.Add(this.buttonBack);
            this.Controls.Add(this.checkBoxEndDate);
            this.Controls.Add(this.comboBoxIsCompleted);
            this.Controls.Add(this.labelIsCompleted);
            this.Controls.Add(this.buttonOk);
            this.Controls.Add(this.dateTimePickerEndDate);
            this.Controls.Add(this.labelStartDate);
            this.Controls.Add(this.dateTimePickerStartDate);
            this.Controls.Add(this.labelTextTask);
            this.Controls.Add(this.textBoxTextTask);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "AddingTask";
            this.Text = "AddingTask";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ComboBox comboBoxIsCompleted;
        private System.Windows.Forms.Label labelIsCompleted;
        private System.Windows.Forms.Button buttonOk;
        private System.Windows.Forms.DateTimePicker dateTimePickerEndDate;
        private System.Windows.Forms.Label labelStartDate;
        private System.Windows.Forms.DateTimePicker dateTimePickerStartDate;
        private System.Windows.Forms.Label labelTextTask;
        private System.Windows.Forms.TextBox textBoxTextTask;
        private System.Windows.Forms.CheckBox checkBoxEndDate;
        private System.Windows.Forms.Button buttonBack;
    }
}