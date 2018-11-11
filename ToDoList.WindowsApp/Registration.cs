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
using ToDoList.Common.Exceptions.Security;
using ToDoList.Common.Managers;
using ToDoList.Data;
using ToDoList.Managers.Log.Log4Net;

namespace ToDoList.WindowsApp
{
    public partial class Registration : Form
    {
        private static ILogger _log; 
        User _user;
        Authorization _authorization; 
        IUserManager _usermanager;
        public Registration(Authorization authorization, ILogManager log, IUserManager usermanager)
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            _authorization = authorization;
            _log = log.GetLogger(typeof(Registration).FullName);
            _usermanager = usermanager;
        }

        private void buttonRegister_Click(object sender, EventArgs e)
        {
            _log.Debug("Click register button");
                try
                {
                    _log.Debug("Value username");
                    var username = textBoxUsername.Text;
                    _log.Debug("Value password");
                    var password = textBoxPassword.Text;
                    _log.Debug("Value firstname");
                    var firstname = textBoxFirstName.Text;
                    _log.Debug("Value lastname");
                    var lastname = textBoxLastName.Text;
                    _log.Debug("Value emailaddress");
                    var emailaddress = textBoxEmailAddress.Text;

                    _log.Debug("Create object User");
                    _user = new User { Username = username, Password = password, FirstName = firstname, LastName = lastname, EmailAddress = emailaddress };
                    _log.Debug("Create User");
                    _usermanager.Create(_user);
                    this.Close();

                    _log.Info("User create account. User Id : " + _user.Id);

                }
                catch (CreateUserFailedException ex)
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

        private void buttonBack_Click(object sender, EventArgs e)
        {
            _log.Debug("Click button back");
            this.Close();
        }

        private void Registration_FormClosed(object sender, FormClosedEventArgs e)
        {
            _authorization.Visible = true;
            _log.Debug("Closed form registration.");
        }
    }
}
