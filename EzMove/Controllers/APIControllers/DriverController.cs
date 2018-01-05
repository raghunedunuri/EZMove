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
    public class DriverController : ApiController
    {
        private IDriverService DriverService;
        public DriverController(IDriverService DriverService)
        {
            this.DriverService = DriverService;
        }

        [HttpGet]
        public HttpResponseMessage GetDriverInfo()
        {
            var responseMessage = new HttpResponseMessage();

            try
            {
                EzMoveIdentity ezMoveIdentity = (EzMoveIdentity)HttpContext.Current.User.Identity;
                responseMessage = Request.CreateResponse(HttpStatusCode.OK, DriverService.GetDriverInfo(ezMoveIdentity.loginResponse.UserID));
            }
            catch (Exception ex)
            {
                responseMessage = Request.CreateResponse(HttpStatusCode.InternalServerError, new ResultMessage(ex));
            }
            return responseMessage;
        }

        [HttpGet]
        public HttpResponseMessage GetDriverCurrentTrip()
        {
            var responseMessage = new HttpResponseMessage();

            try
            {
                EzMoveIdentity ezMoveIdentity = (EzMoveIdentity)HttpContext.Current.User.Identity;
                responseMessage = Request.CreateResponse(HttpStatusCode.OK, DriverService.GetDriverCurrentTrip(ezMoveIdentity.loginResponse.UserID));
            }
            catch (Exception ex)
            {
                responseMessage = Request.CreateResponse(HttpStatusCode.InternalServerError, new ResultMessage(ex));
            }
            return responseMessage;
        }
    }
}
