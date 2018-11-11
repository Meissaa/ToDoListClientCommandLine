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
using ToDoList.Common.Managers.Log;
using ToDoList.Common.Entities;
using ToDoList.Common.Exceptions;
using ToDoList.Managers.Log.Log4Net;
using ToDoList.Common.Managers;

namespace ToDoList.WindowsApp
{
    public partial class UpdateTask : Form
    {
        private static ILogger _log;
        IToDoListManager _toDoListManager;
        string textTask;
        bool isCompleted;
        DateTime startDate, ednDate;
        int _idList, _idTask;


        public string TextTask { get { return textTask; } set { textTask = value; } }
        public bool IsCompleted { get { return isCompleted; } set { isCompleted = value; } }
        public DateTime StartDate { get { return startDate; } set { startDate = value; } }
        public DateTime? EndDate { get; set; }
        public UpdateTask(int _idList, int _idTask, ILogManager log, IToDoListManager toDoListManager)
        {
            InitializeComponent();
            this._idList = _idList;
            this._idTask = _idTask;
            _log = log.GetLogger(typeof(UpdateTask).FullName);
            _toDoListManager = toDoListManager;
            _log.Debug("Autocomplete Fields in form UpdateTask");
            AutocompleteFieldsUpdateTask();
            dateTimePickerEndDate.CustomFormat = " ";
            dateTimePickerEndDate.Format = DateTimePickerFormat.Custom;
        }


        private void buttonOk_Click(object sender, EventArgs e)
        {
            _log.Debug("Click button ok");
            _log.Debug("Value textask");
            TextTask = textBoxTextTask.Text;
            _log.Debug("Value iscompleted");
            IsCompleted = _toDoListManager.CheckIsCompletedTask(comboBoxIsCompleted.Text);
            _log.Debug("Value startdate");
            StartDate = dateTimePickerStartDate.Value.Date;
            _log.Debug("Value enddate");
            EndDate = dateTimePickerEndDate.Value.Date;
            this.DialogResult = DialogResult.OK;
            //this.Close();
        }

        private void buttonBack_Click(object sender, EventArgs e)
        {
            _log.Debug("Clicked button Back");
            this.DialogResult = DialogResult.Cancel;
        }

        public void AutocompleteFieldsUpdateTask()
        {
            try
            {
                _log.Debug("Get list item detail tasks");
                foreach (var item in _toDoListManager.GetListItemDetail(_idList).Tasks)
                {
                    if (item.Id == _idTask)
                    {
                        textBoxTextTask.Text = item.Text;

                        _log.Debug("Check task iscompleted");
                        if (item.IsCompleted == true)
                        {
                            comboBoxIsCompleted.Text = "Yes";
                        }
                        else
                        {
                            comboBoxIsCompleted.Text = "No";
                        }
                        _log.Debug("Value dateTimePickerStartDate");
                        dateTimePickerStartDate.Value = item.CreateDate;
                        if (item.CompleteDate != null)
                        {
                            _log.Debug("Value dateTimePickerEndDate ");
                            dateTimePickerEndDate.Value = Convert.ToDateTime(item.CompleteDate);
                        }
                    }
                }
            }
            catch (ToDoListException ex)
            {
                MessageBox.Show(" " + ex);
                _log.Error(ex);
            }
            catch (Exception ex)
            {
                MessageBox.Show(" " + ex);
                _log.Error(ex);
            }
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

    }
}
