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
                var LoginResponse = LoginService.LoginUser(login);
                if(LoginResponse != null)
                    responseMessage = Request.CreateResponse(HttpStatusCode.OK, LoginResponse);
                else
                    responseMessage = Request.CreateResponse(HttpStatusCode.Unauthorized, "Given User Name or Password is wrong");
            }
            catch (Exception ex)
            {
                responseMessage = Request.CreateResponse(HttpStatusCode.InternalServerError, "Something is wrong, Please try after some time");
            }
            return responseMessage;
        }

        [HttpPost]
        public HttpResponseMessage ForgotPassword(Login login)
        {
            var responseMessage = new HttpResponseMessage();
            try
            {
                responseMessage = Request.CreateResponse(HttpStatusCode.OK, LoginService.ForgotPassword(login.LoginId));
            }
            catch (Exception ex)
            {
                responseMessage = Request.CreateResponse(HttpStatusCode.InternalServerError, new ResultMessage(ex));
            }
            return responseMessage;
        }
    }
}
