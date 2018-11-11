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
using ToDoList.Common.Exceptions;
using ToDoList.Common.Managers.Log;

namespace ToDoList.WindowsApp
{
    public partial class AddingList : Form
    {
        private static ILogger _log;
        string _nameList;

        public AddingList(ILogManager log) {

            InitializeComponent();
            _log = log.GetLogger(typeof(AddingList).FullName);
        }

        public string NameList{ get { return _nameList;} set  { _nameList = value;}}

        private void buttonOk_Click(object sender, EventArgs e)
        {
            //this.DialogResult = DialogResult.OK;
            NameList = textBoxNameList.Text;
            _log.Debug("Clicked button Ok");
            this.DialogResult = DialogResult.OK;
            //this.Close();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            _log.Debug("Clicked button Cancel");
        }

        private void AddingList_FormClosed(object sender, FormClosedEventArgs e)
        {
            //this.DialogResult = DialogResult.Cancel;
            _log.Debug("Form addingList closed");
        }
    }
    
}
