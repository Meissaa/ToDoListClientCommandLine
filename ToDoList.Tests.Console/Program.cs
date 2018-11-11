using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoList.Data;
using ToDoList.Business;
using ToDoList.Business.Managers;
using ToDoList.Common.Entities;
using System.Threading;
using ToDoList.Common.Managers;
using ToDoList.Common.Managers.Log;
using Unity;
using Microsoft.Practices.Unity.Configuration;

namespace ToDoList.Tests.Console
{
    class Program
    {
        static ISecurityManager _securityManager;
        static IToDoListManager _toDoListManager;
        static IUserManager _userManager;
        static ILogger _log;
        static int _id = 35, _idlist = 95, _idtask = 49;
       
        static void Main(string[] args)
        {
            DependencyInjector.LoadConfiguration();
            _securityManager = DependencyInjector.Retrieve<ISecurityManager>();
            _toDoListManager = DependencyInjector.Retrieve<IToDoListManager>();
            _userManager = DependencyInjector.Retrieve<IUserManager>();
            //_log = DependencyInjector.Retrieve<ILogManager>().GetLogger(typeof(Program).FullName);


            //TestCreate(userManager);
            TestLogin(_securityManager);
            System.Console.WriteLine(_securityManager.IsUserLogged());
            //System.Console.WriteLine(securityManager.GetLoggedUser().Username);
            //TestCreateList(_toDoListManager);
            //TestRemoveList(toDoListManager);
            TestAddTaskToList(_toDoListManager);
            TestUpdateList(_toDoListManager);
            TestUpdateTask(_toDoListManager);
            TestGetListItems(_toDoListManager);
            GetListItemDetail(_toDoListManager);
            _securityManager.Logout();
            System.Console.WriteLine(_securityManager.IsUserLogged());


            System.Console.ReadKey();


        }


        public static void TestCreate(IUserManager usermanager)
        {

            User user;


            using (var db = new ToDoListDbContext())
            {
                var username = "lolo";
                var password = "test1234";
                var firstname = "monika";
                var lastname = "kozlowska";
                var emailaddress = "monia@wp.pl";

                user = new User { Username = username, Password = password, FirstName = firstname, LastName = lastname, EmailAddress = emailaddress };
                usermanager.Create(user);

                var query = from b in db.Users
                            where b.Username == username
                            select b.Username;

                if (query != null)
                    System.Console.WriteLine("Create account");

            }
        }

        public static void TestLogin(ISecurityManager securitymanager)
        {

            using (var db = new ToDoListDbContext())
            {
                var username = "kar";
                var password = "test1234";

                securitymanager.Login(username, password);
                System.Console.WriteLine("Your Id: " + securitymanager.GetLoggedUser().Id.ToString() + "  Username: " + securitymanager.GetLoggedUser().Username);
            }
        }

        public static void TestCreateList(IToDoListManager todolistmanager)
        {
            ToDoListItem list;

            using (var db = new ToDoListDbContext())
            {
                var listname = "listNew";
                var createdate = DateTime.Now;

                list = new ToDoListItem { Name = listname, CreateDate = createdate };
                todolistmanager.CreateList(list);

                var query = from b in db.ToDoListItems
                            where b.User.Id == _id && b.Name == listname && b.Id == list.Id
                            select b;

                if (query != null)
                {
                    System.Console.WriteLine("Create list");
                }

            }

        }

        public static void TestRemoveList(IToDoListManager todolistmanager)
        {

            using (var db = new ToDoListDbContext())
            {
                todolistmanager.RemoveList(_idlist);
                System.Console.WriteLine("Remove list");
            }

            TestCreateList(todolistmanager);
        }

        public static void TestUpdateList(IToDoListManager todolistmanager)
        {
            ToDoListItem list;
            using (var db = new ToDoListDbContext())
            {

                var listname = "listTwo";
                var createdate = DateTime.Now;
                var listId = _idlist;

                list = new ToDoListItem { Id = listId, Name = listname, CreateDate = createdate };
                todolistmanager.UpdateList(list);

                var query = from b in db.ToDoListItems
                            where b.User.Id == _id && b.Name == listname && b.CreateDate == createdate
                            select b;

                if (query != null)
                    System.Console.WriteLine("Update list");

            }
        }

        public static void TestGetListItems(IToDoListManager todolistmanager)
        {
            System.Console.WriteLine("Lists: ");

            foreach (var item in todolistmanager.GetListItems())
            {
                System.Console.WriteLine(item.Name);
            }


        }

        public static void TestAddTaskToList(IToDoListManager todolistmanager)
        {
            ToDoListTask task;
            using (var db = new ToDoListDbContext())
            {
                var texttask = "task";
                var iscompleted = true;
                var createdate = Convert.ToDateTime("2018-09-01").Date;
                var completedate = Convert.ToDateTime("2018-09-10").Date;
                var listitemid = _idlist;

                task = new ToDoListTask { Text = texttask, IsCompleted = iscompleted, CreateDate = createdate, CompleteDate = completedate };
                todolistmanager.AddTaskToList(listitemid, task);

                var query = from b in db.ToDoListTasks
                            where b.Id == task.Id && b.ToDoListItem.Id == _idlist && b.CreateDate == createdate && b.CompleteDate == completedate
                            select b;

                if (query != null)
                    System.Console.WriteLine("Add task");

            }

        }

        public static void TestUpdateTask(IToDoListManager todolistmanager)
        {
            ToDoListTask task;

            using (var db = new ToDoListDbContext())
            {

                var texttask = "taskUpdate";
                var iscompleted = false;
                var createdate = Convert.ToDateTime("2018-10-01").Date;
                var completedate = Convert.ToDateTime("2018-10-20").Date;
                var listitemid = _idlist;
                var taskid = _idtask;


                task = new ToDoListTask { Id = taskid, Text = texttask, IsCompleted = iscompleted, CreateDate = createdate, CompleteDate = completedate };
                todolistmanager.UpdateTask(task);

                var query = from b in db.ToDoListTasks
                            where b.Id == task.Id && b.ToDoListItem.Id == _idlist && b.CreateDate == createdate && b.CompleteDate == completedate
                            select b;

                if (query != null)
                    System.Console.WriteLine("update list");

            }
        }

        public static void GetListItemDetail(IToDoListManager todolistmanager)
        {

            System.Console.WriteLine("Id : " + todolistmanager.GetListItemDetail(_idlist).Id);
            System.Console.WriteLine("Name : " + todolistmanager.GetListItemDetail(_idlist).Name);
            System.Console.WriteLine("Create Date : " + todolistmanager.GetListItemDetail(_idlist).CreateDate);
            foreach (var item in todolistmanager.GetListItemDetail(_idlist).Tasks)
            {
                System.Console.WriteLine("Id : " + item.Id);
                System.Console.WriteLine("Text : " + item.Text);
                System.Console.WriteLine("IsCompleted : " + item.IsCompleted);
                System.Console.WriteLine("CreateDate : " + item.CreateDate);
                System.Console.WriteLine("CompleteDate : " + item.CompleteDate);


            }


        }


    }
}
