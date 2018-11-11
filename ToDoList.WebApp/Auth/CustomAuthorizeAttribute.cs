using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Filters;
using System.Web.Routing;
using System.Web.Security;
using ToDoList.Business.Managers;
using ToDoList.Common.Managers;


namespace ToDoList.WebApp
{
    public class CustomAuthorizeAttribute : FilterAttribute, IAuthenticationFilter
    {
        
        public void OnAuthentication(AuthenticationContext filterContext)
        {
            if (string.IsNullOrEmpty(Convert.ToString(filterContext.HttpContext.Session["User"])))
            {
                filterContext.Result = new HttpUnauthorizedResult();
            }
        }

        public void OnAuthenticationChallenge(AuthenticationChallengeContext filterContext)
        {
            if (filterContext.Result == null || filterContext.Result is HttpUnauthorizedResult)
            {
                filterContext.Result = new RedirectToRouteResult(
                       new RouteValueDictionary{{ "controller", "Auth" },
                                      { "action", "Index" },
                                      {"returnUrl", filterContext.HttpContext.Request.RawUrl }
                        });
            }
        }
    }
}

