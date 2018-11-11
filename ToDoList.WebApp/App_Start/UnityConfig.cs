using Microsoft.Practices.Unity.Configuration;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Unity;
using Unity.Injection;

namespace ToDoList.WebApp.App_Start
{
    public class UnityConfig
    {
        private static IUnityContainer _container = new UnityContainer();
        public static void ConfiguredContainer()
        {
            _container.LoadConfiguration();
            //RegisterTypes(container);
            DependencyResolver.SetResolver(new UnityDependencyResolver(_container));
        }
    }
}