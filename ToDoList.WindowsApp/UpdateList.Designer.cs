namespace ToDoList.WindowsApp
{
    partial class UpdateList
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
            this.textBoxEditNameList = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // buttonCancel
            // 
            this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancel.Location = new System.Drawing.Point(134, 98);
            this.buttonCancel.Margin = new System.Windows.Forms.Padding(2);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(76, 24);
            this.buttonCancel.TabIndex = 15;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // buttonOk
            // 
            this.buttonOk.Location = new System.Drawing.Point(235, 98);
            this.buttonOk.Margin = new System.Windows.Forms.Padding(2);
            this.buttonOk.Name = "buttonOk";
            this.buttonOk.Size = new System.Drawing.Size(76, 24);
            this.buttonOk.TabIndex = 14;
            this.buttonOk.Text = "Ok";
            this.buttonOk.UseVisualStyleBackColor = true;
            this.buttonOk.Click += new System.EventHandler(this.buttonOk_Click);
            // 
            // labelNameList
            // 
            this.labelNameList.AutoSize = true;
            this.labelNameList.Location = new System.Drawing.Point(22, 37);
            this.labelNameList.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelNameList.Name = "labelNameList";
            this.labelNameList.Size = new System.Drawing.Size(41, 13);
            this.labelNameList.TabIndex = 13;
            this.labelNameList.Text = "Name :";
            // 
            // textBoxEditNameList
            // 
            this.textBoxEditNameList.Location = new System.Drawing.Point(75, 34);
            this.textBoxEditNameList.Margin = new System.Windows.Forms.Padding(2);
            this.textBoxEditNameList.Name = "textBoxEditNameList";
            this.textBoxEditNameList.Size = new System.Drawing.Size(236, 20);
            this.textBoxEditNameList.TabIndex = 12;
            // 
            // UpdateList
            // 
            this.AcceptButton = this.buttonOk;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.buttonCancel;
            this.ClientSize = new System.Drawing.Size(349, 140);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonOk);
            this.Controls.Add(this.labelNameList);
            this.Controls.Add(this.textBoxEditNameList);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "UpdateList";
            this.Text = "UpdateList";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Button buttonOk;
        private System.Windows.Forms.Label labelNameList;
        private System.Windows.Forms.TextBox textBoxEditNameList;
    }
}