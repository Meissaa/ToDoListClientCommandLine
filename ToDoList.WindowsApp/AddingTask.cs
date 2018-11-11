using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ToDoList.Business.Managers;
using ToDoList.Common.Managers;
using ToDoList.Common.Managers.Log;

namespace ToDoList.WindowsApp
{
    public partial class AddingTask : Form
    {
        private static ILogger _log;
        IToDoListManager _toDoListManager;
        string textTask;
        bool isCompleted;
        DateTime startDate, ednDate;

        public string TextTask { get { return textTask; } set { textTask = value; } }
        public bool IsCompleted { get { return isCompleted; } set { isCompleted = value; } }
        public DateTime StartDate { get { return startDate; } set { startDate = value; } }

        public DateTime? EndDate { get; set; }



        public AddingTask(ILogManager log, IToDoListManager toDoListManager)
        {
            InitializeComponent();
            _log = log.GetLogger(typeof(AddingTask).FullName);
            _toDoListManager = toDoListManager;
            dateTimePickerEndDate.CustomFormat = " ";
            dateTimePickerEndDate.Format = DateTimePickerFormat.Custom;

        }

        private void checkBoxEndDate_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxEndDate.Checked == true)
            {
                _log.Debug("checked checkBoxEndDate ");
                dateTimePickerEndDate.Enabled = true;
                dateTimePickerEndDate.Format = DateTimePickerFormat.Long;
                EndDate = dateTimePickerEndDate.Value.Date;
            }
            else
            {
                _log.Debug("unchecked checkBoxEndDate ");
                dateTimePickerEndDate.Enabled = false;
                dateTimePickerEndDate.CustomFormat = " ";
                dateTimePickerEndDate.Format = DateTimePickerFormat.Custom;
                EndDate = null;
            }
        }


        private void buttonBack_Click_1(object sender, EventArgs e)
        {
            _log.Debug("Click button back");
            this.DialogResult = DialogResult.Cancel;
            //this.Close();

        }

        private void buttonOk_Click(object sender, EventArgs e)
        {
            _log.Debug("Click button ok");
            this.DialogResult = DialogResult.OK;
            TextTask = textBoxTextTask.Text;
            IsCompleted = _toDoListManager.CheckIsCompletedTask(comboBoxIsCompleted.Text);
            StartDate = dateTimePickerStartDate.Value.Date;
            _log.Debug("Close form AddingTask");
            this.Close();
        }

    }
}
