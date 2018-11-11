namespace ToDoList.WindowsApp
{
    partial class AddingList
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
            this.buttonCancel = new System.Windows.Forms.Button();
            this.buttonOk = new System.Windows.Forms.Button();
            this.labelNameList = new System.Windows.Forms.Label();
            this.textBoxNameList = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // buttonCancel
            // 
            this.buttonCancel.Location = new System.Drawing.Point(129, 93);
            this.buttonCancel.Margin = new System.Windows.Forms.Padding(2);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(76, 24);
            this.buttonCancel.TabIndex = 7;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // buttonOk
            // 
            this.buttonOk.Location = new System.Drawing.Point(230, 93);
            this.buttonOk.Margin = new System.Windows.Forms.Padding(2);
            this.buttonOk.Name = "buttonOk";
            this.buttonOk.Size = new System.Drawing.Size(76, 24);
            this.buttonOk.TabIndex = 6;
            this.buttonOk.Text = "Ok";
            this.buttonOk.UseVisualStyleBackColor = true;
            this.buttonOk.Click += new System.EventHandler(this.buttonOk_Click);
            // 
            // labelNameList
            // 
            this.labelNameList.AutoSize = true;
            this.labelNameList.Location = new System.Drawing.Point(17, 32);
            this.labelNameList.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelNameList.Name = "labelNameList";
            this.labelNameList.Size = new System.Drawing.Size(41, 13);
            this.labelNameList.TabIndex = 5;
            this.labelNameList.Text = "Name :";
            // 
            // textBoxNameList
            // 
            this.textBoxNameList.Location = new System.Drawing.Point(71, 30);
            this.textBoxNameList.Margin = new System.Windows.Forms.Padding(2);
            this.textBoxNameList.Name = "textBoxNameList";
            this.textBoxNameList.Size = new System.Drawing.Size(236, 20);
            this.textBoxNameList.TabIndex = 4;
            // 
            // AddingList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(351, 128);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonOk);
            this.Controls.Add(this.labelNameList);
            this.Controls.Add(this.textBoxNameList);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "AddingList";
            this.Text = "AddingList";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.AddingList_FormClosed);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Button buttonOk;
        private System.Windows.Forms.Label labelNameList;
        private System.Windows.Forms.TextBox textBoxNameList;
    }
}