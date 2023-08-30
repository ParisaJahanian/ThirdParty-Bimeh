using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models.Fire
{
    public record FileRes
    {
        public byte[]? Content { get; set; }
        public string? RequestId { get; set; }
        public string? StatusCode { get; set; }
        public bool IsSuccess { get; set; }
    }
}
