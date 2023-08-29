using Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Domain.Models.Fire
{
    public record CreateReqDTO :PublicLogData
    {
        [JsonPropertyName("uniqueId")]
        public string UniqueId { get; set; }
    }
}
