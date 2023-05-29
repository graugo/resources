using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Ejercicio19_Subasta.Infrastructure.DTO.API
{
    public class EncounterApiDTO
    {
        [JsonPropertyName("location_area")]
        public LocationApiDTO Location { get; set; }
    }
}
