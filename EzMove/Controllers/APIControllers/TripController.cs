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
    public class TripController : ApiController
    {
        private ITripService TripService;
        public TripController(ITripService TripService)
        {
            this.TripService = TripService;
        }

        [HttpPost]
        public HttpResponseMessage StartTrip(string TripID)
        {
            var responseMessage = new HttpResponseMessage();

            try
            {
                EzMoveIdentity ezMoveIdentity = (EzMoveIdentity)HttpContext.Current.User.Identity;
                TripService.StartTrip(TripID, ezMoveIdentity.loginResponse.UserID);
                responseMessage = Request.CreateResponse(HttpStatusCode.OK);
            }
            catch (Exception ex)
            {
                responseMessage = Request.CreateResponse(HttpStatusCode.InternalServerError, new ResultMessage(ex));
            }
            return responseMessage;
        }

        [HttpPost]
        public HttpResponseMessage StopTrip(string TripID)
        {
            var responseMessage = new HttpResponseMessage();

            try
            {
                EzMoveIdentity ezMoveIdentity = (EzMoveIdentity)HttpContext.Current.User.Identity;
                TripService.StopTrip(TripID, ezMoveIdentity.loginResponse.UserID);
                responseMessage = Request.CreateResponse(HttpStatusCode.OK);
            }
            catch (Exception ex)
            {
                responseMessage = Request.CreateResponse(HttpStatusCode.InternalServerError, new ResultMessage(ex));
            }
            return responseMessage;
        }

        [HttpPost]
        public HttpResponseMessage UpdateLocation(TripRequest tripRequest)
        {
            var responseMessage = new HttpResponseMessage();

            try
            {
                EzMoveIdentity ezMoveIdentity = (EzMoveIdentity)HttpContext.Current.User.Identity;
                TripService.UpdateLocation(tripRequest.TripID, tripRequest.location, ezMoveIdentity.loginResponse.UserID);
                responseMessage = Request.CreateResponse(HttpStatusCode.OK);
            }
            catch (Exception ex)
            {
                responseMessage = Request.CreateResponse(HttpStatusCode.InternalServerError, new ResultMessage(ex));
            }
            return responseMessage;
        }

        [HttpPost]
        public HttpResponseMessage UpdateTripPersonStatus(TripPersonUpdate tripPersonUpdate)
        {
            var responseMessage = new HttpResponseMessage();

            try
            {
                EzMoveIdentity ezMoveIdentity = (EzMoveIdentity)HttpContext.Current.User.Identity;
                TripService.UpdateTripPersonStatus(tripPersonUpdate.TripID, tripPersonUpdate.EmployeeID, tripPersonUpdate.Status, ezMoveIdentity.loginResponse.UserID);
                responseMessage = Request.CreateResponse(HttpStatusCode.OK);
            }
            catch (Exception ex)
            {
                responseMessage = Request.CreateResponse(HttpStatusCode.InternalServerError, new ResultMessage(ex));
            }
            return responseMessage;
        }

        [HttpPost]
        public HttpResponseMessage GetTripInfo(string TripID)
        {
            var responseMessage = new HttpResponseMessage();
            try
            {
                responseMessage = Request.CreateResponse(HttpStatusCode.OK, TripService.GetTripInfo(TripID));
            }
            catch (Exception ex)
            {
                responseMessage = Request.CreateResponse(HttpStatusCode.InternalServerError, new ResultMessage(ex));
            }
            return responseMessage;
        }
    }
}
