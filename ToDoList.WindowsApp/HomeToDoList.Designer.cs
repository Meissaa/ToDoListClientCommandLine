namespace ToDoList.WindowsApp
{
    partial class HomeToDoList
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
            this.labelUserName = new System.Windows.Forms.Label();
            this.buttonLogout = new System.Windows.Forms.Button();
            this.buttonAddList = new System.Windows.Forms.Button();
            this.dataGridViewAllLists = new System.Windows.Forms.DataGridView();
            this.buttonRemoveList = new System.Windows.Forms.Button();
            this.buttonUpdateList = new System.Windows.Forms.Button();
            this.buttonTask = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewAllLists)).BeginInit();
            this.SuspendLayout();
            // 
            // labelUserName
            // 
            this.labelUserName.AutoSize = true;
            this.labelUserName.Location = new System.Drawing.Point(21, 20);
            this.labelUserName.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelUserName.Name = "labelUserName";
            this.labelUserName.Size = new System.Drawing.Size(35, 13);
            this.labelUserName.TabIndex = 6;
            this.labelUserName.Text = "label1";
            // 
            // buttonLogout
            // 
            this.buttonLogout.Location = new System.Drawing.Point(417, 14);
            this.buttonLogout.Margin = new System.Windows.Forms.Padding(2);
            this.buttonLogout.Name = "buttonLogout";
            this.buttonLogout.Size = new System.Drawing.Size(82, 24);
            this.buttonLogout.TabIndex = 7;
            this.buttonLogout.Text = "Logout";
            this.buttonLogout.UseVisualStyleBackColor = true;
            this.buttonLogout.Click += new System.EventHandler(this.buttonLogout_Click);
            // 
            // buttonAddList
            // 
            this.buttonAddList.Location = new System.Drawing.Point(24, 63);
            this.buttonAddList.Margin = new System.Windows.Forms.Padding(2);
            this.buttonAddList.Name = "buttonAddList";
            this.buttonAddList.Size = new System.Drawing.Size(75, 28);
            this.buttonAddList.TabIndex = 8;
            this.buttonAddList.Text = "Add List";
            this.buttonAddList.UseVisualStyleBackColor = true;
            this.buttonAddList.Click += new System.EventHandler(this.buttonAddList_Click);
            // 
            // dataGridViewAllLists
            // 
            this.dataGridViewAllLists.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewAllLists.Location = new System.Drawing.Point(80, 107);
            this.dataGridViewAllLists.Name = "dataGridViewAllLists";
            this.dataGridViewAllLists.Size = new System.Drawing.Size(343, 250);
            this.dataGridViewAllLists.TabIndex = 10;
            // 
            // buttonRemoveList
            // 
            this.buttonRemoveList.Location = new System.Drawing.Point(189, 378);
            this.buttonRemoveList.Margin = new System.Windows.Forms.Padding(2);
            this.buttonRemoveList.Name = "buttonRemoveList";
            this.buttonRemoveList.Size = new System.Drawing.Size(91, 28);
            this.buttonRemoveList.TabIndex = 12;
            this.buttonRemoveList.Text = "Remove List";
            this.buttonRemoveList.UseVisualStyleBackColor = true;
            this.buttonRemoveList.Click += new System.EventHandler(this.buttonRemoveList_Click);
            // 
            // buttonUpdateList
            // 
            this.buttonUpdateList.Location = new System.Drawing.Point(205, 63);
            this.buttonUpdateList.Margin = new System.Windows.Forms.Padding(2);
            this.buttonUpdateList.Name = "buttonUpdateList";
            this.buttonUpdateList.Size = new System.Drawing.Size(75, 28);
            this.buttonUpdateList.TabIndex = 13;
            this.buttonUpdateList.Text = "UpdateList";
            this.buttonUpdateList.UseVisualStyleBackColor = true;
            this.buttonUpdateList.Click += new System.EventHandler(this.buttonUpdateList_Click);
            // 
            // buttonTask
            // 
            this.buttonTask.Location = new System.Drawing.Point(399, 63);
            this.buttonTask.Margin = new System.Windows.Forms.Padding(2);
            this.buttonTask.Name = "buttonTask";
            this.buttonTask.Size = new System.Drawing.Size(75, 28);
            this.buttonTask.TabIndex = 14;
            this.buttonTask.Text = "Task";
            this.buttonTask.UseVisualStyleBackColor = true;
            this.buttonTask.Click += new System.EventHandler(this.buttonTask_Click);
            // 
            // HomeToDoList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(510, 433);
            this.Controls.Add(this.buttonTask);
            this.Controls.Add(this.buttonUpdateList);
            this.Controls.Add(this.buttonRemoveList);
            this.Controls.Add(this.dataGridViewAllLists);
            this.Controls.Add(this.buttonAddList);
            this.Controls.Add(this.buttonLogout);
            this.Controls.Add(this.labelUserName);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "HomeToDoList";
            this.Text = "HomeToDoList";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.HomeToDoList_FormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewAllLists)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelUserName;
        private System.Windows.Forms.Button buttonLogout;
        private System.Windows.Forms.Button buttonAddList;
        private System.Windows.Forms.DataGridView dataGridViewAllLists;
        private System.Windows.Forms.Button buttonRemoveList;
        private System.Windows.Forms.Button buttonUpdateList;
        private System.Windows.Forms.Button buttonTask;
    }
}