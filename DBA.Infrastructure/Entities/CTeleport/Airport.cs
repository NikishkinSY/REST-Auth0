using Newtonsoft.Json;

namespace CTeleport.DBA.Infrastructure.Entities.CTeleport
{
    public class Airport
    {
        [JsonProperty("iata")]
        public string Code { get; set; }
        [JsonProperty("location")]
        public Location Location { get; set; }
    }
}
