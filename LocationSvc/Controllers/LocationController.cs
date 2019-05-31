using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Claims;
using System.Web.Http;

namespace LocationSvc.Controllers
{
    [Authorize]
    public class LocationController : ApiController
    {
        // https://localhost:44300/api/location?cityName=dc
        public Models.Location GetLocation(string cityName)
        {
            if (ClaimsPrincipal.Current.FindFirst("http://schemas.microsoft.com/identity/claims/scope").Value != "user_impersonation")
            {
                throw new HttpResponseException(new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.Unauthorized,
                    ReasonPhrase = "The Scope claim does not contain 'user_impersonation' or scope claim not found"
                });
            }

            return new Models.Location() { Latitude = 10, Longitude = 20, UserName = ClaimsPrincipal.Current.Identity.Name };
        }
    }
}