using EzMove.Business;
using EzMove.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace EzMove.Controllers.APIControllers
{
    public class UserLoginController : ApiController
    {
        private ILoginService LoginService;
        public UserLoginController(ILoginService LoginService)
        {
            this.LoginService = LoginService;
        }

        [HttpPost]
        public HttpResponseMessage Login(Login login)
        {
            var responseMessage = new HttpResponseMessage();

            try
            {
                responseMessage = Request.CreateResponse(HttpStatusCode.OK, LoginService.LoginUser(login));
            }
            catch (Exception ex)
            {
                responseMessage = Request.CreateResponse(HttpStatusCode.InternalServerError, new ResultMessage(ex));
            }
            return responseMessage;
        }
    }
}
