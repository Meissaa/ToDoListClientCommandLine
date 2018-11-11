#define TEST
using log4net;
using log4net.Config;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoList.Clients.WebApi;

//[assembly: log4net.Config.XmlConfigurator(Watch = true)]
namespace ToDoList.Clients.ConsoleCommander
{
    class Program
    {
 
        private static readonly ILog _log = LogManager.GetLogger(typeof(Program).FullName);
        static WebApiClient _webApiClient = new WebApiClient("http://localhost/api/v1");
        static void Main(string[] args)
        {
            log4net.Config.BasicConfigurator.Configure();
            //_log.Debug("Console Main");
            //_log.Info("info");
           // TestMethod();
#if TEST
            //TestAllCommands("http://localhost/api/v1");
            TestClient();
#else
            ExecuteCommand(args);
#endif
        }

        private static void TestMethod()
        {
            //_log.Debug("Console Main");
            Console.Write("test");
            Console.ReadKey();
        }

        private static void ShowCommandUsage(string command)
        {
            switch (command)
            {
                case "LOGIN":
                    Console.WriteLine("ToDoList.Clients.ConsoleCommander.exe <BASE_API_URL> LOGIN <username> <passwrod>");
                    break;
                case "REGISTER":
                    Console.WriteLine("ToDoList.Clients.ConsoleCommander.exe <BASE_API_URL> REGISTER <username> <passwrod> <firstname> <lastname> <emailaddress>");
                    break;
                case "GETLISTS":
                    Console.WriteLine("ToDoList.Clients.ConsoleCommander.exe <BASE_API_URL> GETLISTS");
                    break;
                case "GETDETAILS":
                    Console.WriteLine("ToDoList.Clients.ConsoleCommander.exe <BASE_API_URL> GETDETAILS <listid>");
                    break;
                case "CREATELIST":
                    Console.WriteLine("ToDoList.Clients.ConsoleCommander.exe <BASE_API_URL> CREATELIST <name> <date>");
                    break;
                case "UPDATELIST":
                    Console.WriteLine("ToDoList.Clients.ConsoleCommander.exe <BASE_API_URL> UPDATELIST <listid> <name> <date>");
                    break;
                case "REMOVELIST":
                    Console.WriteLine("ToDoList.Clients.ConsoleCommander.exe <BASE_API_URL> REMOVELIST <listid>");
                    break;
                case "CREATETASK":
                    Console.WriteLine("ToDoList.Clients.ConsoleCommander.exe <BASE_API_URL> CREATETASK <listid> <text> <iscompleted> <createdate> (<completedate>)");
                    break;
                case "REMOVETASK":
                    Console.WriteLine("ToDoList.Clients.ConsoleCommander.exe <BASE_API_URL> REMOVETASK <listid> <taskid>");
                    break;
                case "UPDATETASK":
                    Console.WriteLine("ToDoList.Clients.ConsoleCommander.exe <BASE_API_URL> UPDATETASK <listid> <taskid> <listid> <text> <iscompleted> <createdate> (<completedate>)");
                    break;
            }
        }

        private static void ShowUsage()
        {
            Console.WriteLine("USAGE:");
            Console.WriteLine("ToDoList.Clients.ConsoleCommander.exe <BASE_API_URL> <COMMAND>");
            Console.WriteLine("<COMMAND>: LOGIN, LOGOUT");
            Console.WriteLine("COMMAND HELP: ToDoList.Clients.ConsoleCommander.exe <BASE_API_URL> <COMMAND> /h");
        }

        private static void ExecuteCommand(string[] args)
        {

            if (args.Length < 2)
            {
                ShowUsage();
                return;
            }

            var baseUrl = args[0];
            var command = args[1];

            switch (command)
            {
                case "LOGIN":

                    if (args.Length < 4)
                    {
                        Console.WriteLine("Invalid parameters for command LOGIN");
                        ShowCommandUsage(command);
                    }

                    if (args[2] == "/h")
                    {
                        ShowCommandUsage(command);
                        return;
                    }

                    try
                    {
                        var username = args[2];
                        var password = args[3];
                        string tokenSession = _webApiClient.Login(username, password);
                        _webApiClient.Token = tokenSession;
                        Console.WriteLine("Token" + tokenSession);
                        Console.ReadKey();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex);
                    }
                    return;
                case "REGISTER":
                    if (args.Length < 7)
                    {
                        Console.WriteLine("Invalid parameters for command REGISTER");
                        ShowCommandUsage(command);
                    }

                    if (args[2] == "/h")
                    {
                        ShowCommandUsage(command);
                        return;
                    }

                    try
                    {
                        var username = args[2];
                        var password = args[3];
                        var firstname = args[4];
                        var lastname = args[5];
                        var emailAddress = args[6];
                        Console.WriteLine(_webApiClient.Register(username, password, firstname, lastname, emailAddress));
                        Console.ReadKey();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex);
                    }
                    return;
                case "GETLISTS":

                    try
                    {
                        Console.WriteLine(_webApiClient.GetAllLists());
                        Console.ReadKey();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex);
                    }
                    return;
                case "GETDETAILS":

                    try
                    {
                        var id = args[2];
                        Console.WriteLine(_webApiClient.GetDetails(Convert.ToInt32(id)));
                        Console.ReadKey();

                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex);
                    }
                    return;
                case "CREATELIST":

                    if (args.Length < 4)
                    {
                        Console.WriteLine("Invalid parameters for command CREATELIST");
                        ShowCommandUsage(command);
                    }

                    if (args[2] == "/h")
                    {
                        ShowCommandUsage(command);
                        return;
                    }

                    try
                    {
                        var name = args[2];
                        DateTime createDate = Convert.ToDateTime(args[3]);
                        Console.WriteLine(_webApiClient.CreateList(name, createDate));
                        Console.ReadKey();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex);
                    }
                    return;
                case "UPDATELIST":

                    if (args.Length < 5)
                    {
                        Console.WriteLine("Invalid parameters for command UPDATELIST");
                        ShowCommandUsage(command);
                    }

                    if (args[2] == "/h")
                    {
                        ShowCommandUsage(command);
                        return;
                    }

                    try
                    {
                        var idList = args[2];
                        var name = args[3];
                        DateTime createDate = DateTime.Now; //args[4];
                        Console.WriteLine(_webApiClient.UpdateList(Convert.ToInt32(idList), name, createDate));
                        Console.ReadKey();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex);
                    }
                    return;
                case "REMOVELIST":

                    if (args.Length < 3)
                    {
                        Console.WriteLine("Invalid parameters for command REMOVELIST");
                        ShowCommandUsage(command);
                    }

                    if (args[2] == "/h")
                    {
                        ShowCommandUsage(command);
                        return;
                    }

                    try
                    {
                        var idList = args[2];
                        Console.WriteLine(_webApiClient.RemoveList(Convert.ToInt32(idList)));
                        Console.ReadKey();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex);
                    }
                    return;
                case "CREATETASK":

                    if (args.Length < 6)
                    {
                        Console.WriteLine("Invalid parameters for command CREATETASK");
                        ShowCommandUsage(command);
                    }

                    if (args[2] == "/h")
                    {
                        ShowCommandUsage(command);
                        return;
                    }

                    try
                    {
                        var listId = args[2];
                        var text = args[3];
                        var iscompleted = Convert.ToBoolean(args[4]);
                        DateTime createDate = Convert.ToDateTime(args[5]);
                        Console.WriteLine(_webApiClient.CreateTask(Convert.ToInt32(listId), text, iscompleted, createDate, null));
                        Console.ReadKey();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex);
                    }
                    return;
                case "REMOVETASK":

                    if (args.Length < 4)
                    {
                        Console.WriteLine("Invalid parameters for command REMOVETASK");
                        ShowCommandUsage(command);
                    }

                    if (args[2] == "/h")
                    {
                        ShowCommandUsage(command);
                        return;
                    }

                    try
                    {
                        var idList = args[2];
                        var idTask = args[3];
                        Console.WriteLine(_webApiClient.RemoveTask(Convert.ToInt32(idList), Convert.ToInt32(idTask)));
                        Console.ReadKey();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex);
                    }
                    return;
                case "UPDATETASK":

                    if (args.Length < 8)
                    {
                        Console.WriteLine("Invalid parameters for command UPDATETASK");
                        ShowCommandUsage(command);
                    }

                    if (args[2] == "/h")
                    {
                        ShowCommandUsage(command);
                        return;
                    }

                    try
                    {
                        var listId = args[2];
                        var taskId = args[3];
                        var text = args[4];
                        var iscompleted = Convert.ToBoolean(args[5]);
                        DateTime createDate = Convert.ToDateTime(args[6]);
                        Console.WriteLine(_webApiClient.UpdateTask(Convert.ToInt32(listId), Convert.ToInt32(taskId), text, iscompleted, createDate, null));
                        Console.ReadKey();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex);
                    }
                    return;
                default:
                    Console.WriteLine("Invalid command");
                    ShowUsage();
                    return;
            }
        }

        public static void TestAllCommands(string baseUrl)
        {
            _log.Debug("Console");
            string token = _webApiClient.GetToken("kar", "test1234");
            _webApiClient.Token = token;

            ExecuteCommand(new string[] { baseUrl, "REGISTER", "Anna", "test1234", "Anna", "Chojnacka", "chojna@wp.pl" });

            ExecuteCommand(new string[] { baseUrl, "GETLISTS", token});

        }

        public static void TestClient()
        {
            string token = _webApiClient.GetToken("kar", "test1234");
            _webApiClient.Token = token;

            List<string> command = new List<string> { "REGISTER","GETLISTS","GETDETAILS","CREATELIST",
                "UPDATELIST","REMOVELIST","CREATETASK","REMOVETASK","UPDATETASK" };

            for (int i = 0; i < command.Count; i++)
            {
                switch (command[i])
                {
                    case "REGISTER":
                        try
                        {
                            Console.WriteLine(_webApiClient.Register("Anna", "test1234", "Anna", "Chojnacka", "chojna@wp.pl"));
                            Console.ReadKey();
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex);
                        }
                        break;
                    case "GETLISTS":
                        try
                        {
                            Console.WriteLine(_webApiClient.GetAllLists());
                            Console.ReadKey();
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex);
                        }
                        break;
                    case "GETDETAILS":
                        try
                        {
                            Console.WriteLine(_webApiClient.GetDetails(95));
                            Console.ReadKey();

                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex);
                        }
                        break;
                    case "CREATELIST":
                        try
                        {
                            Console.WriteLine(_webApiClient.CreateList("listalo", DateTime.Now));
                            Console.ReadKey();
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex);
                        }
                        break;
                    case "UPDATELIST":
                        try
                        {
                            Console.WriteLine(_webApiClient.UpdateList(182, "listaloUpdate", DateTime.Now));
                            Console.ReadKey();
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex);
                        }
                        break;
                    case "REMOVELIST":
                        try
                        {
                            Console.WriteLine(_webApiClient.RemoveList(187));
                            Console.ReadKey();
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex);
                        }
                        break;
                    case "CREATETASK":
                        try
                        {
                            Console.WriteLine(_webApiClient.CreateTask(134, "lalala", true, DateTime.Now, null));
                            Console.ReadKey();
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex);
                        }
                        break;
                    case "REMOVETASK":
                        try
                        {
                            Console.WriteLine(_webApiClient.RemoveTask(179, 119));
                            Console.ReadKey();
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex);
                        }
                        break;
                    case "UPDATETASK":
                        try
                        {
                            Console.WriteLine(_webApiClient.UpdateTask(95, 100, "testtasik", true, DateTime.Now, null));
                            Console.ReadKey();
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex);
                        }
                        break;
                    default:
                        Console.WriteLine("Invalid command");
                        ShowUsage();
                        break;
                }
            }
        }
    }
}
