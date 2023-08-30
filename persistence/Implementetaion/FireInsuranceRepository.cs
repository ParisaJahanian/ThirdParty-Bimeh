using Bimeh.Entities;
using Bimeh.ErrorHandling;
using Bimeh.Models;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using persistence;
using Persistence.ErrorHandling;

namespace Persistence.Implementetaion
{
    public class FireInsuranceRepository : IFireInsuranceRepository
    {
        public IConfiguration _configuration { get; }
        private readonly ILogger<FireInsuranceRepository> _logger;
        private readonly FireDbContext _dbContext;
        public FireInsuranceRepository()
        {

        }
        public async Task<string?> GetToken()
        {
            var query = _dbContext.AccessTokens.SingleOrDefault(i => i.Id == "5");
            if (query is null)
            {
                await AddOrUpdateTokenAsync(null);
            }
            return query?.AccessToken;

        }
        public async Task<AccessTokenEntity> AddOrUpdateTokenAsync(string? accesToken)
        {
            var query = _dbContext.AccessTokens.SingleOrDefault(i => i.Id == "5");
            if (query is null)
            {
                query = new AccessTokenEntity();
                query.Id = "5";
                await _dbContext.AccessTokens.AddAsync(query).ConfigureAwait(false);
            }
            query.AccessToken = accesToken;
            query.TokenDateTime = DateTime.UtcNow;
            try
            {
                await _dbContext.SaveChangesAsync().ConfigureAwait(false);
            }
            catch (Exception e)
            {
                _logger.LogError(e,
                    $"{nameof(AddOrUpdateTokenAsync)} -> applyUpdateToken in AddOrUpdateTokenAsync couldn't update.");
                throw new RamzNegarException(ErrorCode.InternalDBModificationError, $"Exception occurred while: {nameof(AddOrUpdateTokenAsync)}");
            }

            return query;
        }

      

        public async Task<bool> InsertFireInuranceLog(FireInsuranceLog fireInsuranceLog)
        {
            throw new NotImplementedException();
        }

        public async Task<string> InsertFireRequestLog(FireRequestLogDTO fireRequestLog)
        {
            throw new NotImplementedException();
        }

        public async Task<string> InsertFireResponseLog(FireResponseLogDTO fireResponseLog)
        {
            throw new NotImplementedException();
        }

     
    }
}
