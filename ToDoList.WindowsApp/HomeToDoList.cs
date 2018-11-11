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
using ToDoList.Common.Entities;
using ToDoList.Common.Exceptions;
using ToDoList.Common.Exceptions.Security;
using ToDoList.Common.Managers;
using ToDoList.Common.Managers.Log;
using ToDoList.Data;
using ToDoList.Managers.Log.Log4Net;

namespace ToDoList.WindowsApp
{

    public partial class HomeToDoList : Form
    {
        private static ILogger _log;
        ISecurityManager _securityManager;
        IToDoListManager _toDoListManager;
        Authorization _authorization;
        UpdateList _updateList;
        AddingList _addingList;
        ToDoListItem _list;
        HomeTask _homeTask;
        //List<int> _listIdList;
        int _listId;

        public HomeToDoList(Authorization authorization, ILogManager log, ISecurityManager securityManager,
         IToDoListManager toDoListManager)
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
            _log = log.GetLogger(typeof(HomeToDoList).FullName);
            _authorization = authorization;
            _securityManager = securityManager;
            _toDoListManager = toDoListManager;
            ViewUserName();
            ViewAllLists();
        }


        private void ViewUserName()
        {
            _log.Debug("Value labelUserName");
            labelUserName.Text = "Hello " + _securityManager.GetLoggedUser().Username + " !";

        }

        private void buttonLogout_Click(object sender, EventArgs e)
        {
            _log.Debug("Clicked button Logout");
            try
            {
                _log.Debug("Logout user");
                _securityManager.Logout();

                _log.Debug("Check user is logged");
                if (_securityManager.IsUserLogged() == false)
                {
                    // _authorization.Visible = true;
                    this.Close();
                    _log.Info("User logout");
                }
            }
            catch (SecurityException ex)
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

        private void buttonAddList_Click(object sender, EventArgs e)
        {
            _log.Debug("Clicked button AddList");
            _addingList = new AddingList(DependencyInjector.Retrieve<ILogManager>());
            _log.Debug("Open from addingList");
            DialogResult dialogresult = _addingList.ShowDialog(this);

            if (dialogresult == DialogResult.Cancel)
            {
                _log.Debug("Close from addingList");
                _addingList.Close();
            }
            else if (dialogresult == DialogResult.OK)
            {
                try
                {
                    _log.Debug("listname value");
                    var listname = _addingList.NameList;
                    _log.Debug("createdate value");
                    var createdate = DateTime.Now;

                    _log.Debug("Create object ToDoListItem");
                    _list = new ToDoListItem { Name = listname, CreateDate = createdate };
                    _log.Debug("Create list");
                    _toDoListManager.CreateList(_list);
                    _log.Info("User add list_Id: " + _list.Id);
                    _log.Debug("Refreshing list view");
                    ViewAllLists();
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
            _addingList.Dispose();
        }

        private void ViewAllLists()
        {
            dataGridViewAllLists.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewAllLists.Rows.Clear();
            dataGridViewAllLists.ColumnCount = 4;
            dataGridViewAllLists.Columns[0].Name = "Id";
            dataGridViewAllLists.Columns[0].Visible = false;
            dataGridViewAllLists.Columns[1].Name = "List Name";
            dataGridViewAllLists.Columns[2].Name = "Create date";
            dataGridViewAllLists.Columns[3].Name = "Is Not Completed Task";

            //_listIdList = new List<int>(); 
            try
            {
                _log.Debug("Get all lists");
                foreach (var item in _toDoListManager.GetListItems())
                {
                    dataGridViewAllLists.Rows.Add(item.Id, item.Name, item.CreateDate, CountIsNotcompletedTasks(item.Id));
                    //_listIdList.Add(item.Id);
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
            _log.Debug("Refreshing datagridViewAllLists");
            dataGridViewAllLists.Refresh();
        }


        public int CountIsNotcompletedTasks(int listid)
        {
            int count = 0;
            try
            {
                _log.Debug("Value Count tasks is not completed");
                if (_toDoListManager.GetListItemDetail(listid).Tasks != null) {
                    count = _toDoListManager.GetListItemDetail(listid).Tasks.Count(t => t.IsCompleted == false);
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

            return count;
        }


        private void buttonRemoveList_Click(object sender, EventArgs e)
        {
            _log.Debug("Clicked button RemoveList");
            _log.Debug("Value _listId");
            _listId = Convert.ToInt32(dataGridViewAllLists.SelectedRows[0].Cells[0].Value);

            try
            {
                _log.Debug("Remove list");
                _toDoListManager.RemoveList(_listId);
                _log.Debug("Refreshing list view");
                ViewAllLists();
                _log.Info("User remove list_Id: " + _listId);
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

        private void buttonUpdateList_Click(object sender, EventArgs e)
        {
            _log.Debug("Clicked button UpdateList");

            if (dataGridViewAllLists.SelectedRows.Count < 1)
            {
                MessageBox.Show("Select one list");
                return;
            }

            _log.Debug("Value listId");
            _listId = Convert.ToInt32(dataGridViewAllLists.SelectedRows[0].Cells[0].Value);

            _updateList = new UpdateList(_listId, DependencyInjector.Retrieve<ILogManager>(),
                DependencyInjector.Retrieve<ToDoListManager>());
            _log.Debug("Open from updateList");
            DialogResult dialogresult = _updateList.ShowDialog(this);

            if (dialogresult == DialogResult.Cancel)
            {
                _log.Debug("Close from updateList");
                _updateList.Close();
            }
            else if (dialogresult == DialogResult.OK)
            {
                try
                {
                    _log.Debug("listname value");
                    var listname = _updateList.NameList;
                    _log.Debug("createdate value");
                    var createdate = DateTime.Now;

                    _log.Debug("Create object ToDoListItem");
                    _list = new ToDoListItem { Id = _listId, Name = listname, CreateDate = createdate };
                    _log.Debug("Update list");
                    _toDoListManager.UpdateList(_list);
                    _log.Debug("Refreshing list view");
                    ViewAllLists();
                    _log.Info("List_Id: " + _list.Id + " updated");
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

        private void HomeToDoList_FormClosed(object sender, FormClosedEventArgs e)
        {
            _authorization.Visible = true;
            _log.Debug("Close form HomeToDoList");
        }

        private void buttonTask_Click(object sender, EventArgs e)
        {
            _log.Debug("Clicked button Task");
            if (dataGridViewAllLists.SelectedRows.Count < 1)
            {
                MessageBox.Show("Select one list");
                return;
            }

            _log.Debug("Value _listId");
            _listId = Convert.ToInt32(dataGridViewAllLists.SelectedRows[0].Cells[0].Value);

            try
            {
                _homeTask = new HomeTask(_listId, DependencyInjector.Retrieve<ILogManager>(),
                    DependencyInjector.Retrieve<ToDoListManager>());
                _log.Debug("Open form HomeTask");
                _homeTask.ShowDialog();
                _log.Debug("Refreshing list view");
                ViewAllLists();
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
}
