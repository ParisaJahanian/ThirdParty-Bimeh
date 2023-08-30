namespace Bimeh.Models
{
    public record FireResponseLogDTO(string publicRequestId, string jsonResponse,
        string carTollHttpResponseCode, string carTollsRequestId, string carTollsResCode);
}
