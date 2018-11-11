using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ToDoList.Business.Managers;
using ToDoList.Common.Entities;
using ToDoList.Common.Exceptions.Security;
using ToDoList.Common.Managers;
using ToDoList.Common.Managers.Log;
using ToDoList.WebApp.Models;

namespace ToDoList.WebApp.Controllers
{
    public class RegisterController : Controller
    {
        ILogger _log;
        IUserManager _userManager;
        User _user;
        public RegisterController(ILogManager log, IUserManager userManager)
        {
            _log = log.GetLogger(typeof(RegisterController).FullName);
            _userManager = userManager;
        }
        // GET: Register
        public ActionResult Index()
        {
            _log.Debug("Open view Register");
            return View();
        }

        public ActionResult Create(RegisterModel user)
        {
            try
            {
                _log.Debug("Create object User");
                _user = new User
                {
                    Username = user.Username,
                    Password = user.Password,
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    EmailAddress = user.EmailAddress
                };
                _log.Debug("Create User");
                _userManager.Create(_user);
                _log.InfoFormat("User create account. User Id : {0}", _user.Id);

            }
            catch (CreateUserFailedException ex)
            {
                _log.Error(ex);
                ViewBag.Error = true;
                TempData["Error"] = ex.Message;
                _log.Debug("Open view Error");
                return View("Index");
            }
            catch (Exception ex)
            {
                _log.Error(ex);
                TempData["Error"] = ex.Message;
                _log.Debug("Open view Error");
                return View("Error");
            }

            ViewBag.Error = false;
            _log.Debug("Refresh view Register");
            return View("Index");
        }
    }
}