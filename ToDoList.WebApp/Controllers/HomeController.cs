using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ToDoList.Business.Managers;
using ToDoList.Common.Entities;
using ToDoList.Common.Exceptions;
using ToDoList.Common.Exceptions.Security;
using ToDoList.Common.Managers;
using ToDoList.Common.Managers.Log;
using ToDoList.WebApp.Models;


namespace ToDoList.WebApp.Controllers
{
    [CustomAuthorize]
    public class HomeController : Controller
    {
        ILogger _log;
        ISecurityManager _securityManager;
        IToDoListManager _toDoListManager;

        public HomeController(ILogManager log, ISecurityManager securityManager, IToDoListManager toDoListManager)
        {
            _log = log.GetLogger(typeof(HomeController).FullName);
            _securityManager = securityManager; 
            _toDoListManager = toDoListManager; 
        }

        public ActionResult Index()
        {
            try
            {
                _log.Debug("Get todolists");
                IList<ToDoListItem> lists = _toDoListManager.GetListItems();
                _log.Debug("Open view Home");
                return View(Mapper.Map<IList<ToDoListItemModel>>(lists));
            }
            catch (ToDoListException ex)
            {
                _log.Error(ex);
                TempData["Error"] = ex.Message;
                _log.Debug("Open view Error");
                return View("Error");
            }
            catch (Exception ex)
            {
                _log.Error(ex);
                TempData["Error"] = ex.Message;
                _log.Debug("Open view Error");
                return View("Error");
            }
        }

        public ActionResult CreateListView()
        {
            _log.Debug("Open view CreateList");
            return View();
        }

        public ActionResult CreateList(ToDoListItemModel item)
        {

            try
            {
                _log.Debug("Create list");
                _toDoListManager.CreateList(Mapper.Map<ToDoListItem>(item));
                _log.InfoFormat("Create list. ListId: {0} ", item.Id);
                _log.Debug("Refresh Home");
                return RedirectToAction("Index");

            }
            catch (ToDoListException ex)
            {
                _log.Error(ex);
                TempData["Error"] = ex.Message;
                _log.Debug("Open view Error");
                return View("Error");
            }
            catch (Exception ex)
            {
                _log.Error(ex);
                TempData["Error"] = ex.Message;
                _log.Debug("Open view Error");
                return View("Error");
            }

        }

        public ActionResult RemoveListView(int id)
        {
            try
            {
                _log.Debug("Get list item detail");
                var listDetail = _toDoListManager.GetListItemDetail(id);
                _log.Debug("Open view RemoveList");
                return View(Mapper.Map<ToDoListItemModel>(listDetail));
            }
            catch (ToDoListException ex)
            {
                _log.Error(ex);
                TempData["Error"] = ex.Message;
                _log.Debug("Open view Error");
                return View("Error");

            }
            catch (Exception ex)
            {
                _log.Error(ex);
                TempData["Error"] = ex.Message;
                _log.Debug("Open view Error");
                return View("Error");
            }

        }

        public ActionResult RemoveList(int id)
        {
            try
            {
                _log.Debug("Remove list");
                _toDoListManager.RemoveList(id);
                _log.Debug("Refresh view Home");
                return RedirectToAction("Index");
                _log.InfoFormat("User remove list_Id: {0} ", id);
            }
            catch (ToDoListException ex)
            {
                _log.Error(ex);
                TempData["Error"] = ex.Message;
                _log.Debug("Open view Error");
                return View("Error");
            }
            catch (Exception ex)
            {
                _log.Error(ex);
                TempData["Error"] = ex.Message;
                _log.Debug("Open view Error");
                return View("Error");
            }
        }

        public ActionResult EditListView(int id)
        {
            try
            {
                _log.Debug("Get list item detail");
                var listdetail = _toDoListManager.GetListItemDetail(id);
                _log.Debug("Open view EditList");
                return View(Mapper.Map<ToDoListItemModel>(listdetail));
            }
            catch (ToDoListException ex)
            {
                _log.Error(ex);
                TempData["Error"] = ex.Message;
                _log.Debug("Open view Error");
                return View("Error");
            }
            catch (Exception ex)
            {
                _log.Error(ex);
                TempData["Error"] = ex.Message;
                _log.Debug("Open view Error");
                return View("Error");
            }
        }

        public ActionResult EditList(ToDoListItemModel item)
        {
            try
            {
                _log.Debug("Update list");
                _toDoListManager.UpdateList(Mapper.Map<ToDoListItem>(item));
                _log.InfoFormat("Update List. ListId: {0} ",item.Id);
                _log.Debug("Refresh view Home");
                return RedirectToAction("Index");
            }
            catch (ToDoListException ex)
            {
                _log.Error(ex);
                TempData["Error"] = ex.Message;
                _log.Debug("Open view Error");
                return View("Error");
            }
            catch (Exception ex)
            {
                _log.Error(ex);
                TempData["Error"] = ex.Message;
                _log.Debug("Open view Error");
                return View("Error");
            }
        }


        public ActionResult DetailsView(int id)
        {
            _log.Debug("Open view Details");
            return RedirectToAction("DetailsView", "ToDoListTask", new { id = id });
        }

        public ActionResult Logout()
        {
            try
            {
                _log.Debug("Logout user");
                _securityManager.Logout();
                _log.Debug("Check user is logged");
                if (!_securityManager.IsUserLogged())
                {
                    _log.Debug("Open view Authorization");
                    return View("~/Views/Auth/Index.cshtml");
                    _log.Info("User logout");
                }
            }
            catch (SecurityException ex)
            {
                _log.Error(ex);
                TempData["Error"] = ex.Message;
                _log.Debug("Open view Error");
                return View("Error");
            }
            catch (Exception ex)
            {
                _log.Error(ex);
                TempData["Error"] = ex.Message;
                _log.Debug("Open view Error");
                return View("Error");
            }

            _log.Debug("Refresh view Home");
            return View("Index");
        }
    }
}