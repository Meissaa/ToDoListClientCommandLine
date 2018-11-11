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
using ToDoList.Data;
using ToDoList.Managers.Log.Log4Net;
using ToDoList.Common.Managers;

namespace ToDoList.WindowsApp
{
    public partial class HomeTask : Form
    {
        private static ILogger _log;
        IToDoListManager _toDoListManager;
        AddingTask _addingTask;
        UpdateTask _updateTask;
        ToDoListTask _toDoListTask;
        List<int> _listIdTask;
        int _indexCheckBoxList, _idTask;
        int _listId, _count;
        bool _iscompletedtask;
        int _taskId;
        public HomeTask(int _listId, ILogManager log, IToDoListManager toDoListManager)
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            this._listId = _listId;
            _log = log.GetLogger(typeof(HomeTask).FullName); ;
            _toDoListManager = toDoListManager;
            _log.Debug("Refreshing view tasks");
            ViewTasks(_listId);
            //ViewAllLists(_listId);
        }

        private void buttonBack_Click(object sender, EventArgs e)
        {
            _log.Debug("Clicked button Back");
            this.Close();
        }

        private void buttonAddTask_Click(object sender, EventArgs e)
        {
            _log.Debug("Clicked button AddTask");

            _addingTask = new AddingTask(DependencyInjector.Retrieve<ILogManager>(), DependencyInjector.Retrieve<IToDoListManager>());
            _log.Debug("Open form AddingTask");
            DialogResult dialogresult = _addingTask.ShowDialog(this);

            if (dialogresult == DialogResult.Cancel)
            {
                _log.Debug("Close form AddingTask");
                _addingTask.Close();
            }
            else if (dialogresult == DialogResult.OK)
            {
                try
                {
                    _log.Debug("Value texttask");
                    var texttask = _addingTask.TextTask;
                    _log.Debug("Value iscompleted");
                    var iscompleted = _addingTask.IsCompleted;
                    _log.Debug("Value createdate");
                    var createdate = _addingTask.StartDate;
                    _log.Debug("Value completedate");
                    var completedate = _addingTask.EndDate;
                    _log.Debug("Value listitemid");
                    var listitemid = _listId;

                    _log.Debug("Create new object ToDoListTask");
                    _toDoListTask = new ToDoListTask { Text = texttask, IsCompleted = iscompleted, CreateDate = createdate, CompleteDate = completedate };
                    _log.Debug("Add Task");
                    _toDoListManager.AddTaskToList(listitemid, _toDoListTask);
                    _log.Debug("Refreshing view tasks");
                    ViewTasks(_listId);
                    _log.Info("Added Task Id : " + _toDoListTask.Id);
                }
                catch (ToDoListException ex)
                {
                    MessageBox.Show(" " + ex);
                    _log.Error(ex);
                }
                catch (ArgumentNullException ex)
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
        }

        private void checkedListBoxDetailTask_SelectedIndexChanged(object sender, EventArgs e)
        {
            _log.Debug("Selected task");
            //_indexCheckBoxList = checkedListBoxDetailTask.SelectedIndex;
            //_idTask = _listIdTask[_indexCheckBoxList];
            _log.Debug("Value id_task");
            _idTask = ((ToDoListTask)checkedListBoxDetailTask.SelectedItem).Id;

            if (checkedListBoxDetailTask.GetItemChecked(_indexCheckBoxList) == true)
            {
                _iscompletedtask = true;

                //UpdateIsCompletedTask(_iscompletedtask);
            }
            if (checkedListBoxDetailTask.GetItemChecked(_indexCheckBoxList) == false)
            {
                _iscompletedtask = false;
                // UpdateIsCompletedTask(_iscompletedtask);
            }

            UpdateIsCompletedTask(_iscompletedtask);
        }

        public void UpdateIsCompletedTask(bool iscompleted)
        {
            try
            {
                _log.Debug("Get List Item Detail Tasks");
                foreach (var item in _toDoListManager.GetListItemDetail(_listId).Tasks)
                {
                    if (item.Id == _idTask)
                        _log.Debug("Create new object ToDoListTask");
                    _toDoListTask = new ToDoListTask { Id = item.Id, Text = item.Text, IsCompleted = _iscompletedtask, CreateDate = item.CreateDate, CompleteDate = item.CompleteDate };
                }
                _log.Debug("Update is completed task_Id " + _idTask);
                _toDoListManager.UpdateTask(_toDoListTask);

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
        private void buttonRemoveTask_Click(object sender, EventArgs e)
        {
            _log.Debug("Click button removeTask");

            try
            {
                _log.Debug("Remove task");
                _toDoListManager.RemoveTaskFromList(_listId, _idTask);
                _log.Debug("Refreshing view tasks");
                ViewTasks(_listId);
                _log.Info("Remove task_Id " + _idTask);
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


        private void buttonUpdateTask_Click(object sender, EventArgs e)
        {
            _log.Debug("Click button UpdateTask");
            if (checkedListBoxDetailTask.SelectedItem == null)
                return;

            _addingTask = new AddingTask(DependencyInjector.Retrieve<ILogManager>(), DependencyInjector.Retrieve<IToDoListManager>());
            _updateTask = new UpdateTask(_listId, _idTask, DependencyInjector.Retrieve<ILogManager>(),
                DependencyInjector.Retrieve<IToDoListManager>());
            _log.Debug("Open form UpdateTask");
            DialogResult dialogresult = _updateTask.ShowDialog(this);
            _log.Debug("Value idtask");
            //var idtask = ((ToDoListTask)checkedListBoxDetailTask.SelectedItem).Id; //Convert.ToInt32(dataGridViewAllTasks.SelectedRows[0].Cells[0].Value);

            if (dialogresult == DialogResult.Cancel)
            {
                _log.Debug("Close form UpdateTask");
                _updateTask.Close();
            }
            else if (dialogresult == DialogResult.OK)
            {

                try
                {
                    _log.Debug("Value texttask");
                    var texttask = _updateTask.TextTask;
                    _log.Debug("Value iscompleted task");
                    var iscompleted = _updateTask.IsCompleted;
                    _log.Debug("Value createdate task");
                    var createdate = _updateTask.StartDate;
                    _log.Debug("Value completedate task");
                    var completedate = _updateTask.EndDate;
                    _log.Debug("Value listId");
                    var listitemid = _listId;
                    // var idtask = _idTask;

                    _log.Debug("Create new object ToDoLisTask");
                    _toDoListTask = new ToDoListTask { Id = _idTask/*idtask*/, Text = texttask, IsCompleted = iscompleted, CreateDate = createdate, CompleteDate = completedate };
                    _log.Debug("Update task");
                    _toDoListManager.UpdateTask(_toDoListTask);
                    ViewTasks(_listId);
                    //MessageBox.Show(" " + idtask.ToString());
                    _log.Info("Updated task_Id " + _toDoListTask.Id);
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
        }

        //private void dataGridViewAllTasks_CellClick(object sender, DataGridViewCellEventArgs e)
        //{
        //    int index = dataGridViewAllTasks.SelectedRows[0].Index;

        //    UpdateIsCompletedTask(_iscompletedtask);
        //}

        private void ViewTasks(int listid)
        {
            _log.Debug("Value count");
            _count = 0;
            // _listIdTask = new List<int>();
            checkedListBoxDetailTask.Items.Clear();

            try
            {
                _log.Debug("Get list item detail tasks");
                foreach (var item in _toDoListManager.GetListItemDetail(listid).Tasks)
                {
                    checkedListBoxDetailTask.Items.Add(item);
                    //_listIdTask.Add(item.Id);

                    if (item.IsCompleted == true)
                    {
                        checkedListBoxDetailTask.SetItemChecked(_count, true);
                    }

                    _count++;
                }
                _log.Debug("Get all Task");
            }
            catch (ToDoListException ex)
            {
                MessageBox.Show(" " + ex);
            }
        }
    }
}
