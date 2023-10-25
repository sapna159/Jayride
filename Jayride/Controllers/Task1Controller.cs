using Jayride.Model;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Globalization;
using System.Net;
using System.Runtime;
using System.Text.Json.Nodes;

namespace Jayride.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class Task1Controller : ControllerBase
    {
        [HttpGet]
        [Route("GetCandidateInformation")]
        public dynamic GetCandidateInformation(int Id)
        {

            List<CandidateInformation> candidateInformation = new List<CandidateInformation>();
            CandidateInformation responseObj = new CandidateInformation();

            //Adding custom data for records.
            candidateInformation.Add(
                new CandidateInformation
                {
                    Id = 1,
                    Name = "Sapna",
                    Phone = "9687232345"
                }
            );

            candidateInformation.Add(
                new CandidateInformation
                {
                    Id = 2,
                    Name = "Yash",
                    Phone = "4567232345"
                }
            );

            candidateInformation.Add(
                new CandidateInformation
                {
                    Id = 3,
                    Name = "Micheal",
                    Phone = "3487232345"
                }
            );

            responseObj = candidateInformation.Where(x => x.Id == Id).FirstOrDefault();

            if (responseObj != null)
            {
                return new { name = responseObj.Name, phone = responseObj.Phone };

            }
            return "Data not found!";
        }

    }
}
