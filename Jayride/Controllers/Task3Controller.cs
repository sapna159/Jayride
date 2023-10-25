using Jayride.Model;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Globalization;
using System.Net;
using System.Runtime;

namespace Jayride.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class Task3Controller : ControllerBase
    {

        [HttpGet]
        [Route("GetPriceListByPassenger")]
        public ResponseModel GetPriceListByPassenger(int noOfPassenger)
        {
            ResponseModel response = new ResponseModel();
            MainListings listings = new MainListings();
            try
            {
                string info = new WebClient().DownloadString("https://jayridechallengeapi.azurewebsites.net/api/QuoteRequest");
                listings = JsonConvert.DeserializeObject<MainListings>(info);

                if (listings != null && listings.Listings != null && noOfPassenger > 0)
                {
                    List<Listings> filterListings = listings.Listings.Where(x => x.VehicleType.MaxPassengers > noOfPassenger).ToList();
                    if (filterListings.Count > 0)
                    {
                        foreach (var listings1 in filterListings)
                        {
                            listings1.TotalPrice = listings1.PricePerPassenger * noOfPassenger;
                        }
                        filterListings = filterListings.OrderBy(x => x.TotalPrice).ToList();
                        response.Data = filterListings;
                        response.Status = true;
                        response.Message = "Find the below sorted list.";
                    }
                    else
                    {
                        response.Data = null;
                        response.Status = false;
                        response.Message = "No records found.";

                    }

                }
                else
                {
                    response.Data = null;
                    response.Status = false;
                    response.Message = "Invalid record.";
                }
            }
            catch (Exception ex)
            {
                response.Status = false;
                response.Message = ex.Message;
                response.Data = null;
            }
            return response;
        }
    }
}
