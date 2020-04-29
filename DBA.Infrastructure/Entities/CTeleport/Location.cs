using Newtonsoft.Json;

namespace CTeleport.DBA.Infrastructure.Entities.CTeleport
{
    public class Location
    {
        [JsonProperty("lon")]
        public double Longitude { get; set; }
        [JsonProperty("lat")]
        public double Latitude { get; set; }
    }
}
