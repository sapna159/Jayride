using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Jayride.Model
{
    public class MainListings
    {
        [JsonProperty("from")]
        public string From { get; set; }

        [JsonProperty("to")]
        public string To { get; set; }

        [JsonProperty("listings")]
        public List<Listings> Listings { get; set; }
    }

    public class Listings
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("pricePerPassenger")]
        public decimal PricePerPassenger { get; set; }

        [JsonProperty("vehicleType")]
        public VehicleType VehicleType { get; set; }

        public static explicit operator Listings(JToken? v)
        {
            throw new NotImplementedException();
        }
        public decimal TotalPrice { get; set; }

    }

    public class VehicleType
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("maxPassengers")]
        public int MaxPassengers { get; set; }

    }
}
