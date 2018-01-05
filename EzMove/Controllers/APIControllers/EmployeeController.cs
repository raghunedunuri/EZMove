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
        public EmployeeController(IEmployeeService EmployeeService)
        {
            this.EmployeeService = EmployeeService;
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

    }
}
