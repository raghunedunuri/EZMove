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

namespace EzMove.Controllers.APIControllers
{
    [BasicAuthentication]
    public class ShiftController : ApiController
    {
        private IShiftService ShiftService;
        public ShiftController(IShiftService ShiftService)
        {
            this.ShiftService = ShiftService;
        }

        [HttpPost]
        public HttpResponseMessage GetEmployeeShift( string Date )
        {
            var responseMessage = new HttpResponseMessage();
            try
            {
                EzMoveIdentity ezMoveIdentity = (EzMoveIdentity)HttpContext.Current.User.Identity;
                if (ezMoveIdentity != null && ezMoveIdentity.loginResponse != null)
                {
                    ShiftService.GetEmployeeeShift(ezMoveIdentity.loginResponse.UserID, Date);
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
