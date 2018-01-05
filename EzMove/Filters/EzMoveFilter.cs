using EzMove.Cache;
using EzMove.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Principal;
using System.Text;
using System.Web;
using System.Web.Http.Filters;

namespace EzMove.Filters
{
    public class EzMoveIdentity : IIdentity
    {
        public LoginResponse loginResponse { get; set; }
        public EzMoveIdentity(LoginResponse lr)
        {
            loginResponse = lr;
        }
        public string Name { get { return ""; }  }

        public string AuthenticationType { get { return "Forms"; } }

        public bool IsAuthenticated { get { return true; } }
    }

    public class EzMovePrinicpal : IPrincipal
    {
        public EzMovePrinicpal(IIdentity identity)
        {
            Identity = identity;
        }

        public EzMovePrinicpal(EzMoveIdentity identity)
        {
            Identity = identity;
        }

        public bool IsInRole(string role) { return true;  }

        public IIdentity Identity { get; private set; }

    }

   public class BasicAuthenticationAttribute : AuthorizationFilterAttribute
   {
        public override void OnAuthorization(System.Web.Http.Controllers.HttpActionContext actionContext)
        {
            if (actionContext.Request.Headers.Authorization == null)
            {
                actionContext.Response = actionContext.Request.CreateResponse(HttpStatusCode.Unauthorized);
            }
            else
            {
                string authenticationString = actionContext.Request.Headers.Authorization.Parameter;
                string token = Encoding.UTF8.GetString(Convert.FromBase64String(authenticationString));

                LoginResponse lr = CacheImplementor.GetUserInfo(token);
                if (lr == null)
                {
                    actionContext.Response = actionContext.Request.CreateResponse(HttpStatusCode.Unauthorized);
                }
                else
                {
                    HttpContext.Current.User = new EzMovePrinicpal(new EzMoveIdentity( lr) );
                }
            }
        }
    }
}