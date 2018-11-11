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
using ToDoList.Common.Exceptions;
using ToDoList.Managers.Log.Log4Net;
using ToDoList.Common.Managers;

namespace ToDoList.WindowsApp
{
    public partial class UpdateList : Form
    {
        private static ILogger _log;
        IToDoListManager _toDoListManager;
        string _nameList;
        int _listId;
        public UpdateList(int _listId, ILogManager log, IToDoListManager toDoListManager)
        {
            InitializeComponent();
            this._listId = _listId;
            _log = log.GetLogger(typeof(UpdateList).FullName);
            _toDoListManager = toDoListManager;
            _log.Debug("Autocomplete Name List");
            AutocompleteNameList();
        }

        public string NameList
        {
            get
            {
                return _nameList;
            }

            set
            {
                _nameList = value;
            }
        }

        private void buttonOk_Click(object sender, EventArgs e)
        {
            _log.Debug("Clicked button Ok");

            if (!string.IsNullOrEmpty(textBoxEditNameList.Text))
            {
                this.DialogResult = DialogResult.OK;
                _log.Debug("namelist value");
                NameList = textBoxEditNameList.Text;
                
            }
            else
            {
                MessageBox.Show("List name is empty");
                _log.Error("List name is empty");
            }

            _log.Debug("Close form updateList");
            this.Close();

        }

        private void AutocompleteNameList()
        { 
                try
                {
                    _log.Debug("Get list items");
                    foreach (var item in _toDoListManager.GetListItems())
                    {

                        if (item.Id == _listId)
                            textBoxEditNameList.Text = item.Name;
                    }

                    _log.Debug("Get list name");
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

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            _log.Debug("Clicked button Cancel");
            this.DialogResult = DialogResult.Cancel;
           
        }
    }
}
