using log4net;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;

namespace ToDoList.Clients.WebApi
{
    public class WebApiClient
    {
        private static readonly ILog _log = LogManager.GetLogger(typeof(WebApiClient));
        private string _baseUrl;
        private string _token;
        private string _receiveUrl;

        public string BaseUrl { get { return _baseUrl; } set { _baseUrl = value; } }
        public string Token { get { return _token; } set { _token = value; } }

        public WebApiClient(string baseUrl)
            : this(baseUrl, null)
        {
        }

        public WebApiClient(string baseUrl, string token)
        {
            BaseUrl = baseUrl;
            Token = token;
        }

        public string GetToken(string username, string password)
        {
            _log.Debug("GetToken");

            _receiveUrl = "auth/login";
            string json = new JavaScriptSerializer().Serialize(new
            {
                Username = username,
                Password = password
            });
            var token = JObject.Parse(ServiceRest(_receiveUrl, "POST", json)).SelectToken("SessionToken").ToString();
            return token;
        }

        public string Login(string username, string password)
        {
            _log.Debug("Login");

            _receiveUrl = "auth/login";
            string json = new JavaScriptSerializer().Serialize(new
            {
                Username = username,
                Password = password
            });
            var token = JObject.Parse(ServiceRest(_receiveUrl, "POST", json)).SelectToken("SessionToken").ToString();
            return token;
        }

        public string Register(string username, string password, string firstname, string lastname, string emailAddress)
        {
            _log.Debug("Register");
            _receiveUrl = "registeruser";
            string json = new JavaScriptSerializer().Serialize(new
            {
                Username = username,
                Password = password,
                FirstName = firstname,
                LastName = lastname,
                EmailAddress = emailAddress
            });
            return ServiceRest(_receiveUrl, "POST", json).ToString();
        }

        public string GetAllLists()
        {
            _receiveUrl = "todolist";
            return ServiceRest(_receiveUrl, "GET", "").ToString();
        }

        public string GetDetails(int id)
        {

            _receiveUrl = "todolist/" + id;
            return ServiceRest(_receiveUrl, "GET", "").ToString();
        }

        public string CreateList(string name, DateTime createDate)
        {
            _receiveUrl = "todolist";
            string json = new JavaScriptSerializer().Serialize(new
            {
                Name = name,
                CreateDate = createDate
            });
            return ServiceRest(_receiveUrl, "POST", json).ToString();
        }

        public string UpdateList(int id, string name, DateTime createDate)
        {
            _receiveUrl = "todolist";
            string json = new JavaScriptSerializer().Serialize(new
            {
                Id = id,
                Name = name,
                CreateDate = createDate
            });
            return ServiceRest(_receiveUrl, "PUT", json).ToString();
        }

        public string RemoveList(int id)
        {
            _receiveUrl = "todolist/" + id;
            return ServiceRest(_receiveUrl, "DELETE", "").ToString();
        }

        public string CreateTask(int listId, string text, bool iscompleted, DateTime createDate, DateTime? completeDate)
        {
            _receiveUrl = "todolist/" + listId + "/task";
            string json = new JavaScriptSerializer().Serialize(new
            {
                Text = text,
                IsCompleted = iscompleted,
                CreateDate = createDate,
                CompleteDate = completeDate
            });
            return ServiceRest(_receiveUrl, "POST", json).ToString();
        }

        public string RemoveTask(int listId, int taskId)
        {
            _receiveUrl = "todolist/" + listId + "/task/" + taskId;
            return ServiceRest(_receiveUrl, "DELETE", "").ToString();
        }

        public string UpdateTask(int listId, int idTask, string text, bool iscompleted, DateTime createDate, DateTime? completeDate)
        {
            _receiveUrl = "todolist/" + listId + "/task/";
            string json = new JavaScriptSerializer().Serialize(new
            {
                Id = idTask,
                Text = text,
                CreateDate = createDate
            });
            return ServiceRest(_receiveUrl, "PUT", json).ToString();
        }

        public string ServiceRest(string receiveUrl, string methodHttp, string json)
        {
            var result = "";
            var httpWebRequest = (HttpWebRequest)WebRequest.Create(_baseUrl + "/" + receiveUrl);
            httpWebRequest.Method = methodHttp;
            httpWebRequest.ContentType = "application/json";
            httpWebRequest.Headers.Add("Authorization", "Custom " + Token);

            if (methodHttp != "GET" && methodHttp != "DELETE")
            {
                using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
                {
                    streamWriter.Write(json);
                }
            }
            using (var response = (HttpWebResponse)httpWebRequest.GetResponse())
            {
                using (var streamReader = new StreamReader(response.GetResponseStream()))
                {
                    result = streamReader.ReadToEnd();
                }
                return result;
            }
        }
    }
}

