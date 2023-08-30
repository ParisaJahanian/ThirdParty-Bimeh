using Bimeh.Entities;

namespace CarElectronicTolls.Entities
{
    public class FireReqLog : BaseEntity<string>
    {
        public FireReqLog()
        {
            LogDateTime = DateTime.Now;
        }
        public DateTime LogDateTime { get; set; }
        public string JsonReq { get; set; }

        //***************//
        public string UserId { get; set; }
        public string PublicAppId { get; set; }
        public string ServiceId { get; set; }
        public string PublicReqId { get; set; }

        public ICollection<FireResLog> fireResLogs { get; set; }
    }
}
