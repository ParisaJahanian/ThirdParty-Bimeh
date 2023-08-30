using Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Domain.Models.Fire
{
    public record FileReq:PublicLogData
    {
        [JsonPropertyName("InsuranceRequestId")]
        public string InsuranceRequestId { get; set; }
    }
}
