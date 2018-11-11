namespace ToDoList.WindowsApp
{
    partial class HomeTask
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
            this.checkedListBoxDetailTask = new System.Windows.Forms.CheckedListBox();
            this.buttonBack = new System.Windows.Forms.Button();
            this.buttonAddTask = new System.Windows.Forms.Button();
            this.buttonUpdateTask = new System.Windows.Forms.Button();
            this.buttonRemoveTask = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // checkedListBoxDetailTask
            // 
            this.checkedListBoxDetailTask.FormattingEnabled = true;
            this.checkedListBoxDetailTask.Location = new System.Drawing.Point(12, 83);
            this.checkedListBoxDetailTask.Name = "checkedListBoxDetailTask";
            this.checkedListBoxDetailTask.Size = new System.Drawing.Size(420, 229);
            this.checkedListBoxDetailTask.TabIndex = 3;
            this.checkedListBoxDetailTask.SelectedIndexChanged += new System.EventHandler(this.checkedListBoxDetailTask_SelectedIndexChanged);
            // 
            // buttonBack
            // 
            this.buttonBack.Location = new System.Drawing.Point(11, 328);
            this.buttonBack.Margin = new System.Windows.Forms.Padding(2);
            this.buttonBack.Name = "buttonBack";
            this.buttonBack.Size = new System.Drawing.Size(68, 28);
            this.buttonBack.TabIndex = 13;
            this.buttonBack.Text = "Back";
            this.buttonBack.UseVisualStyleBackColor = true;
            this.buttonBack.Click += new System.EventHandler(this.buttonBack_Click);
            // 
            // buttonAddTask
            // 
            this.buttonAddTask.Location = new System.Drawing.Point(12, 25);
            this.buttonAddTask.Name = "buttonAddTask";
            this.buttonAddTask.Size = new System.Drawing.Size(94, 31);
            this.buttonAddTask.TabIndex = 14;
            this.buttonAddTask.Text = "Add  Task";
            this.buttonAddTask.UseVisualStyleBackColor = true;
            this.buttonAddTask.Click += new System.EventHandler(this.buttonAddTask_Click);
            // 
            // buttonUpdateTask
            // 
            this.buttonUpdateTask.Location = new System.Drawing.Point(338, 25);
            this.buttonUpdateTask.Name = "buttonUpdateTask";
            this.buttonUpdateTask.Size = new System.Drawing.Size(94, 31);
            this.buttonUpdateTask.TabIndex = 15;
            this.buttonUpdateTask.Text = "Update Task";
            this.buttonUpdateTask.UseVisualStyleBackColor = true;
            this.buttonUpdateTask.Click += new System.EventHandler(this.buttonUpdateTask_Click);
            // 
            // buttonRemoveTask
            // 
            this.buttonRemoveTask.Location = new System.Drawing.Point(171, 25);
            this.buttonRemoveTask.Name = "buttonRemoveTask";
            this.buttonRemoveTask.Size = new System.Drawing.Size(94, 31);
            this.buttonRemoveTask.TabIndex = 16;
            this.buttonRemoveTask.Text = "Remove Task";
            this.buttonRemoveTask.UseVisualStyleBackColor = true;
            this.buttonRemoveTask.Click += new System.EventHandler(this.buttonRemoveTask_Click);
            // 
            // HomeTask
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(470, 367);
            this.Controls.Add(this.buttonRemoveTask);
            this.Controls.Add(this.buttonUpdateTask);
            this.Controls.Add(this.buttonAddTask);
            this.Controls.Add(this.buttonBack);
            this.Controls.Add(this.checkedListBoxDetailTask);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "HomeTask";
            this.Text = "Task";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.CheckedListBox checkedListBoxDetailTask;
        private System.Windows.Forms.Button buttonBack;
        private System.Windows.Forms.Button buttonAddTask;
        private System.Windows.Forms.Button buttonUpdateTask;
        private System.Windows.Forms.Button buttonRemoveTask;
    }
}