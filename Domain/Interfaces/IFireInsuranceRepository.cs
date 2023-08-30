using Bimeh.Entities;
using Bimeh.Models;
using Domain.Entities;

namespace Domain.Interfaces
{
    public interface IFireInsuranceRepository
    {
        Task<string> GetToken();

        Task<AccessTokenEntity> AddOrUpdateTokenAsync(string? accesToken);
        Task<string> InsertFireResponseLog(FireResponseLogDTO fireResponseLog);
        Task<string> InsertFireRequestLog(FireRequestLogDTO fireRequestLog);
        Task<bool> InsertFireInuranceLog(FireInsuranceLog fireInsuranceLog);
    }
}
