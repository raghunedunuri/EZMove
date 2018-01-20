using EzMove.Business;
using EzMove.Contracts;
using EzMove.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace EzMove.Controllers
{
    [BasicAuthentication]
    public class EmployeeController : ApiController
    {
        private IEmployeeService EmployeeService;
        private ILoginService LoginService;

        public EmployeeController(IEmployeeService EmployeeService, ILoginService LoginService)
        {
            this.EmployeeService = EmployeeService;
            this.LoginService = LoginService;
        }

        [HttpGet]
        public HttpResponseMessage GetEmployeeInfo( )
        {
            var responseMessage = new HttpResponseMessage();
            try
            {
                EzMoveIdentity ezMoveIdentity = (EzMoveIdentity)HttpContext.Current.User.Identity;
                responseMessage = Request.CreateResponse(HttpStatusCode.OK, EmployeeService.GetEmployeeInfo(ezMoveIdentity.loginResponse.UserID));
            }
            catch (Exception ex)
            {
                responseMessage = Request.CreateResponse(HttpStatusCode.InternalServerError, new ResultMessage(ex));
            }
            return responseMessage;
        }

        [HttpGet]
        public HttpResponseMessage GetEmployeeCurrentTrip()
        {
            var responseMessage = new HttpResponseMessage();
            try
            {
                EzMoveIdentity ezMoveIdentity = (EzMoveIdentity)HttpContext.Current.User.Identity;
                responseMessage = Request.CreateResponse(HttpStatusCode.OK, EmployeeService.GetEmployeeCurrentTrip(ezMoveIdentity.loginResponse.UserID));
            }
            catch (Exception ex)
            {
                responseMessage = Request.CreateResponse(HttpStatusCode.InternalServerError, new ResultMessage(ex));
            }
            return responseMessage;
        }

        [HttpPost]
        public HttpResponseMessage ChangeProfile(Profile profile)
        {
            var responseMessage = new HttpResponseMessage();
            try
            {
                EzMoveIdentity ezMoveIdentity = (EzMoveIdentity)HttpContext.Current.User.Identity;
                if (ezMoveIdentity != null && ezMoveIdentity.loginResponse != null)
                {
                    profile.LoginId = ezMoveIdentity.loginResponse.LoginID;
                    OpResponse opResponse = LoginService.ChangeProfile(profile);
                    responseMessage = Request.CreateResponse(HttpStatusCode.OK, opResponse );
                }
                else
                    responseMessage = Request.CreateResponse(HttpStatusCode.Unauthorized, "Given User Name or Password is wrong");
            }
            catch (Exception ex)
            {
                responseMessage = Request.CreateResponse(HttpStatusCode.InternalServerError, new ResultMessage(ex));
            }
            return responseMessage;
        }
    }
}
