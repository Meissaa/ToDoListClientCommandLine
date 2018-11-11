using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using ToDoList.Business.Managers;
using ToDoList.Common.Entities;
using ToDoList.Common.Exceptions.Security;
using ToDoList.Common.Managers;
using ToDoList.Common.Managers.Log;
using ToDoList.WebApp.Models;



namespace ToDoList.WebApp.Controllers
{

    public class AuthController : Controller
    {
        //comment
        ILogger _log; 
        ISecurityManager _securityManager;
        
        public AuthController(ILogManager log, ISecurityManager securityManager)
        {
            _log = log.GetLogger(typeof(AuthController).FullName);
            _securityManager = securityManager; 
        }

        // GET: Auth
        public ActionResult Index()
        {
            _log.Debug("Open View Authorization");
            return View();
        }

        public ActionResult Login(LoginModel user)
        {
            _log.Debug("Check model is valid");
            if (ModelState.IsValid)
            {
                try
                {
                    _log.Debug("Login user");
                    _securityManager.Login(user.Username, user.Password);

                    _log.Debug("Check user is logged");
                    if (_securityManager.IsUserLogged())
                    {
                        _log.Debug("Open View Home");
                        return RedirectToAction("Index", "Home");
                        _log.InfoFormat("User logged. User_Id: {0} ",  _securityManager.GetLoggedUser().Id);
                    }
                }
                catch (LoginFailedException ex)
                {
                    _log.Error(ex);
                    ViewBag.Error = true;
                    TempData["Error"] = ex.Message;
                    _log.Debug("Open View Error");
                    return View("Index");
                }
                catch (SecurityException ex)
                {
                    _log.Error(ex);
                    TempData["Error"] = ex.Message;
                    _log.Debug("Open View Error");
                    return View("Error");
                }
                catch (Exception ex)
                {
                    _log.Error(ex);
                    TempData["Error"] = ex.Message;
                    _log.Debug("Open View Error");
                    return View("Error");
                }
            }

            _log.Debug("Open View Authorization");
            return View("Index");
        }

        public ActionResult Create()
        {
            _log.Debug("Open View Register");
            return View("~/Views/Register/Index.cshtml");
        }
    }
}