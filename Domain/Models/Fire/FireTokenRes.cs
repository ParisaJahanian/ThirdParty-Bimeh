using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Domain.Models.Fire
{
    public sealed class BimehTokenRes
    {
        [JsonPropertyName("JWT")]
        public string JWT { get; set; }
    }
}
