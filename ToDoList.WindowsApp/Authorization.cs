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
using ToDoList.Data;
using ToDoList.Business;
using ToDoList.Common.Exceptions.Security;
using ToDoList.Managers.Log.Log4Net;
using ToDoList.Common.Managers;

namespace ToDoList.WindowsApp
{
    public partial class Authorization : Form
    {
        private static ILogger _log;
        ISecurityManager _securityManager;
        IToDoListManager _toDoListManager;
        IUserManager _userManager;
        HomeToDoList _homeToDoList;
        Registration _registration;

        public Authorization(ILogManager log, ISecurityManager securityManager,
            IToDoListManager toDoListManager, IUserManager userManager)
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            _log = log.GetLogger(typeof(Authorization).FullName);
            _securityManager = securityManager;
            _toDoListManager = toDoListManager;
            _userManager = userManager;

        }

        private void buttonLogin_Click(object sender, EventArgs e)
        {
            _log.Debug("Click login button");
            try
            {
                _log.Debug("Value username");
                var username = textBoxUsername.Text;
                _log.Debug("Value password");
                var password = textBoxPassword.Text;

                _log.Debug("Login user");
                _securityManager.Login(username, password);

                _log.Debug("Check user is logged");
                if (_securityManager.IsUserLogged() == true)
                {
                    _homeToDoList = new HomeToDoList(this, DependencyInjector.Retrieve<ILogManager>(),
                        DependencyInjector.Retrieve<ISecurityManager>(),
                    DependencyInjector.Retrieve<IToDoListManager>());

                    this.Visible = false;
                    _log.Debug("Open form HomeToDoList");
                    _homeToDoList.Show();
                    _log.Info("User_Id: " + _securityManager.GetLoggedUser().Id + " logged");
                }

                _log.Debug("Clear field username");
                textBoxUsername.Text = "";
                _log.Debug("Clear field password");
                textBoxPassword.Text = "";
            }
            catch (LoginFailedException ex)
            {
                MessageBox.Show(" " + ex);
                _log.Error(ex);
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

        private void buttonCreateAccount_Click(object sender, EventArgs e)
        {
            _log.Debug("Click button create account");
            _registration = new Registration(this, DependencyInjector.Retrieve<ILogManager>(), DependencyInjector.Retrieve<IUserManager>());
            this.Visible = false;
            _log.Debug("Open form Registration");
            _registration.Show();
        }
    }
}
