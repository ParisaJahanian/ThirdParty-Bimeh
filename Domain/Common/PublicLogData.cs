using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Domain.Common
{
    public record PublicLogData
    {
        public string UserId { get; set; }
        public string PublicAppId { get; set; }
        public string ServiceId { get; set; }
        public string PublicReqId { get; set; }
        public override string ToString()
        {
            return JsonSerializer.Serialize(this); ;
        }
    }
}
