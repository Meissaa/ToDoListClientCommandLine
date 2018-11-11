using Microsoft.Practices.Unity.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using ToDoList.Business.Managers;
using ToDoList.Common.Managers;
using ToDoList.Common.Managers.Log;
using ToDoList.Managers.Log.Log4Net;
using Unity;
using Unity.Lifetime;

namespace ToDoList.WindowsApp
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
       // static IUnityContainer container;

        [STAThread]
        static void Main()
        {
            DependencyInjector.LoadConfiguration();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Authorization(DependencyInjector.Retrieve<ILogManager>(), DependencyInjector.Retrieve<ISecurityManager>(),
                DependencyInjector.Retrieve<IToDoListManager>(), DependencyInjector.Retrieve<UserManager>()));
        }
    }
}
