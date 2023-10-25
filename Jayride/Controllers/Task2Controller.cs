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
    public class Task2Controller : ControllerBase
    {

        [HttpGet]
        [Route("GetUserCityByIp")]
        public ActionResult<string> GetUserCityByIp(string ip)
        {
            LocationInformation locationInformation = new LocationInformation();
            try
            {
                string info = new WebClient().DownloadString("http://ipinfo.io/" + ip);
                locationInformation = JsonConvert.DeserializeObject<LocationInformation>(info);
                locationInformation.City = "City Name for IP " + ip + ": "+  locationInformation.City;
            }
            catch (Exception)
            {
                locationInformation.City = null;
            }
            return locationInformation.City;
        }
    }
}
