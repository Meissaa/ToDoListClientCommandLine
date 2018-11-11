using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ToDoList.Business.Managers;
using ToDoList.Common.Entities;
using ToDoList.Common.Exceptions;
using ToDoList.Common.Managers;
using ToDoList.Common.Managers.Log;
using ToDoList.WebApp.Models;

namespace ToDoList.WebApp.Controllers
{
    [CustomAuthorize]
    public class ToDoListTaskController : Controller
    {
        ILogger _log;
        IToDoListManager _toDoListManager;
        public ToDoListTaskController(ILogManager log, IToDoListManager toDoListManager)
        {
            _log = log.GetLogger(typeof(ToDoListTaskController).FullName);
            _toDoListManager = toDoListManager; 
        }

        public ActionResult DetailsView(int id)
        {
            try
            {
                _log.Debug("Get list item detail");
                var listitem = _toDoListManager.GetListItemDetail(id);
                _log.Debug("Open view Details");
                return View(Mapper.Map<ToDoListItemModel>(listitem));
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

        public ActionResult CreateTaskView(int listId)
        {
            try
            {
                _log.Debug("Get list item detail");
                var listitem = _toDoListManager.GetListItemDetail(listId);
                _log.Debug("Open view CreateTask");
                return View(new ToDoListTaskModel { ToDoListItem = listitem });
            }
            catch (ToDoListException ex)
            {
                _log.Error(ex);
                TempData["Error"] = ex.Message;
                _log.Debug("Open view Error");
                return View("Error");
            }
            catch (ArgumentNullException ex)
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

        public ActionResult CreateTask(ToDoListTaskModel task)
        {
            try
            {
                _log.Debug("Create Task");
                _toDoListManager.AddTaskToList(task.ToDoListItem.Id, Mapper.Map<ToDoListTask>(task));
                _log.InfoFormat("Added Task. Task_Id : {0} ", task.Id);
                _log.Debug("Refresh view Details");
                return RedirectToAction("DetailsView", new { id = task.ToDoListItem.Id });
            }
            catch (ToDoListException ex)
            {
                _log.Error(ex);
                TempData["Error"] = ex.Message;
                _log.Debug("Open view Error");
                return View("Error");
            }
            catch (ArgumentNullException ex)
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

        public ActionResult RemoveTask(int listid, int taskid)
        {
            try
            {
                _log.Debug("Remove Task");
                _toDoListManager.RemoveTaskFromList(listid, taskid);
                _log.InfoFormat("Remove task. Task_Id " + taskid);

            }
            catch (ToDoListException ex)
            {
                _log.Error(ex);
                TempData["Error"] = ex.Message;
                _log.Debug("Open view Error");
                return View("Error");
            }
            catch (ArgumentNullException ex)
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

            _log.Debug("Refresh view Details");
            return RedirectToAction("DetailsView", new { id = listid });
        }

        public ActionResult EditTaskView(int taskid, int listid)
        {
            _log.Debug("Get list item detail");
            var list = _toDoListManager.GetListItemDetail(listid);
            _log.Debug("Get task");
            var task = list.Tasks.FirstOrDefault(t => t.Id == taskid);
            _log.Debug("Check value task is null");
            if (task == null)
            {
                _log.Error("Task not found");
                TempData["Error"] = "Task not found";
                _log.Debug("Open view Error");
                return View("Error");
            }

            _log.Debug("Open view EditTask");
            return View(Mapper.Map<ToDoListTaskModel>(task));
        }

        public ActionResult EditTask(ToDoListTaskModel task)
        {
            try
            {
                _log.Debug("Update task");
                _toDoListManager.UpdateTask(Mapper.Map<ToDoListTask>(task));
                _log.InfoFormat("Updated task. Task_Id {0} ", task.Id );
                _log.Debug("Refresh view Details");
                return RedirectToAction("DetailsView", new { id = task.ToDoListItem.Id });
            }
            catch (ToDoListException ex)
            {
                _log.Error(ex);
                TempData["Error"] = ex.Message;
                _log.Debug("Open view Error");
                return View("Error");
            }
            catch (ArgumentNullException ex)
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

        public ActionResult EditIsCompleted(int listid, int taskid, bool iscompleted)
        {
            _log.Debug("Get list item detail");
            var list = _toDoListManager.GetListItemDetail(listid);
            _log.Debug("Get task");
            var task = list.Tasks.FirstOrDefault(t => t.Id == taskid);
            _log.Debug("Check value task is null");
            if (task == null)
            {
                _log.Error("Task not found");
                TempData["Error"] = "Task not found";
                _log.Debug("Open view Error");
                return View("Error");
            }
            _log.Debug("Value task.IsCompleted");
            task.IsCompleted = iscompleted;
            _log.Debug("Update task.IsCompleted");
            _toDoListManager.UpdateTask(task);
            _log.InfoFormat("Updated task.IsCompleted. Task_Id {0} ", taskid);
            return null;
        }

    }
}