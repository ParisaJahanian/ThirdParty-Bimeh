namespace Bimeh.Models
{
    public record FireRequestLogDTO(string publicRequestId, string jsonRequest, 
        string userId, string publicAppId, string serviceId);
   
}
