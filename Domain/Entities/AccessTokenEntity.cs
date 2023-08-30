using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public sealed class AccessTokenEntity
    {
        public string Id { get; set; }
        public DateTime TokenDateTime { get; set; }
        public string AccessToken { get; set; }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
