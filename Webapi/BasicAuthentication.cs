using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;
using System.Net;
using System.Text;
using System.Threading;
using System.Security.Principal;

namespace WebAoi
{
    public class BasicAuthentication:AuthorizationFilterAttribute
    {
        public override void OnAuthorization(HttpActionContext actionContext)
        {
            if(actionContext.Request.Headers.Authorization==null)
            {

                actionContext.Response == actionContext.Request.CreateResponse(HttpStatusCode.Unauthorized);

            }
            else
            {
                string authentiatecationToken = actionContext.Request.Headers.Authorization.Parameter;
                string decodedauthentiatecationToken=Encoding.UTF8.GetString(Convert.FromBase64String(authentiatecationToken));
                string[] usernamePasswordarray = decodedauthentiatecationToken.Split(':');
                string username = usernamePasswordarray[0];
                string password = usernamePasswordarray[1];

                if(Loginsecurity.login(username,password))
                {
                    Thread.CurrentPrincipal = new GenericPrincipal(new GenericIdentity(username),null);

                }
                else
                {
                    actionContext.Response == actionContext.Request.CreateResponse(HttpStatusCode.Unauthorized);
                }
            }
        }  
    }
}