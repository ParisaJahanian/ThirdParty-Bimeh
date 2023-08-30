using Bimeh.Entities;

namespace CarElectronicTolls.Entities
{
    public class FireResLog : BaseEntity<string>
    {
        public string ResCode { get; set; }
        public string HTTPStatusCode { get; set; }
        public string JsonRes { get; set; }
        public string PublicReqId { get; set; }
        //***********//
        public string ReqLogId { get; set; }
        public FireReqLog CarTollsReqLog { get; set; }

    }
}
