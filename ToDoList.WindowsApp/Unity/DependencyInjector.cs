using Microsoft.Practices.Unity.Configuration;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity;
using Unity.Lifetime;

namespace ToDoList.WindowsApp
{
    public class DependencyInjector
    {
        private static IUnityContainer _container = new UnityContainer();
        public static void LoadConfiguration()
        {
            var fileMap = new ExeConfigurationFileMap { ExeConfigFilename = "Unity.config" };
            System.Configuration.Configuration configuration =
            ConfigurationManager.OpenMappedExeConfiguration(fileMap, ConfigurationUserLevel.None);
            var unitySection = (UnityConfigurationSection)configuration.GetSection("unity");

            _container.LoadConfiguration(unitySection);
        }

        public static T Retrieve<T>()
        {
            if (_container == null)
            {
                throw new ArgumentNullException("_container");
            }
            return _container.Resolve<T>();
        }

    }
}
