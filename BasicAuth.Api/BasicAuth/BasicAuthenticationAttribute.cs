using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Principal;
using System.Text;
using System.Threading;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace BasicAuth.Api.BasicAuth
{
    public class BasicAuthenticationAttribute : AuthorizationFilterAttribute
    {
        public override void OnAuthorization(HttpActionContext actionContext)
        {
            if (actionContext.Request.Headers.Authorization == null)
            {
                actionContext.Response = actionContext.Request.
                    CreateErrorResponse(HttpStatusCode.Unauthorized, "Login failed!");
            }
            else
            {
                string authToken = actionContext.Request.Headers.Authorization.Parameter;

                string decodedAuthToken =Encoding.UTF8.GetString(Convert.FromBase64String(authToken));
                string[] usernamepassword = decodedAuthToken.Split(':');
               
                string username = usernamepassword[0];
                string password = usernamepassword[1];

                if (ValidateUser.Login(username,password))
                {
                    Thread.CurrentPrincipal = new GenericPrincipal(new GenericIdentity (username),null);
                }
                else
                {
                    actionContext.Response = actionContext.Request.
                    CreateErrorResponse(HttpStatusCode.Unauthorized, "Login failed!");
                }

            }
            base.OnAuthorization(actionContext);
        }
    }
}