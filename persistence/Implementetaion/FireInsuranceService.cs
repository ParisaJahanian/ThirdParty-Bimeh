using Bimeh.Infratructure.Extension;
using Bimeh.Models;
using Domain.Common;
using Domain.Interfaces;
using Domain.Models.Fire;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using persistence;
using System.Text;
using System.Text.Json;

namespace Persistence.Implementetaion
{
    public class FireInsuranceService : IFireInsuranceService
    {
        private readonly HttpClient _httpClient;

        private readonly ILogger<FireInsuranceService> _logger;
        private IConfiguration _configuration { get; set; }
        public IFireInsuranceRepository _insuranceRepository { get; }
        public readonly FireInsuranceOptions _fireInsuranceOptions;

        //public IWebHostEnvironment _webHostEnvironment { get; }
        public FireInsuranceService(HttpClient httpClient, ILogger<FireInsuranceService> logger, 
            IConfiguration configuration, IFireInsuranceRepository insuranceRepository, IOptions<FireInsuranceOptions> options)
        {
            _httpClient = httpClient;
            _logger = logger;
            _configuration = configuration;
            _insuranceRepository = insuranceRepository;
            _fireInsuranceOptions = options.Value;
        }

        public async Task<OutputModel> GetTokenAsync(PublicLogData basePublicLog)
        {
            _logger.LogInformation($"{nameof(GetTokenAsync)} request start - input is: \r\n {basePublicLog} for getting token manually.");
            FireRequestLogDTO fireRequest = new FireRequestLogDTO(basePublicLog?.PublicReqId, basePublicLog.ToString(),
                basePublicLog?.UserId, basePublicLog?.PublicAppId, basePublicLog?.ServiceId);
            string SportRequestId = await _insuranceRepository.InsertFireRequestLog(fireRequest);
            var url = new Uri(_fireInsuranceOptions.TokenAddress, UriKind.Absolute);
            var request = new HttpRequestMessage(HttpMethod.Post, url);
            request.Headers.Add("business-token", _fireInsuranceOptions?.BusinessToken);
            request.Content = FireFormUrlEncodedContent(_fireInsuranceOptions);
            var response = await _httpClient.SendAsync(request);
            var responseContent = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
            _logger.LogInformation($"{nameof(GetTokenAsync)} request sent - response is: \r\n {responseContent}.");
            if (response.IsSuccessStatusCode)
            {
                var accessToken = JsonSerializer.Deserialize<BimehTokenRes>(responseContent);
                _ = await _insuranceRepository.AddOrUpdateTokenAsync(accessToken?.JWT);
            }
            return new OutputModel
            {
                StatusCode = response.StatusCode.ToString(),
                RequestId = SportRequestId,
                Content = responseContent
            };
        }
        public async Task<OutputModel> GetBasicDataAsync(BasicDataReq basicDataReq)
        {
            _logger.LogInformation($"{nameof(GetBasicDataAsync)} request start - input is: \r\n {basicDataReq}.");
            FireRequestLogDTO fireRequest = new FireRequestLogDTO(basicDataReq?.PublicReqId, basicDataReq.ToString(),
                   basicDataReq?.UserId, basicDataReq?.PublicAppId, basicDataReq?.ServiceId);
            string SportRequestId = await _insuranceRepository.InsertFireRequestLog(fireRequest);
            var token = await _insuranceRepository.GetToken();
            var url = new Uri(_fireInsuranceOptions.BasicDataAddress, UriKind.Absolute);
            var request = new HttpRequestMessage(HttpMethod.Get, url);
            request.AddFireInsuranceCommonHeader(token, _fireInsuranceOptions?.BusinessToken);
            request.Content = new StringContent(JsonSerializer.Serialize(basicDataReq), Encoding.UTF8, "application/json");
            var response = await _httpClient.SendAsync(request);
            var responseContent = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
            _logger.LogInformation($"{nameof(GetBasicDataAsync)} request sent - response is: \r\n {responseContent}.");
            return new OutputModel
            {
                StatusCode = response.StatusCode.ToString(),
                RequestId = SportRequestId,
                Content = responseContent
            };
        }
        public async Task<OutputModel> CreateAsync(CreateReqDTO createReq)
        {
            throw new NotImplementedException();
        }
        public async Task<FileRes> GetFileAsync(FileReq userFileReq)
        {
            throw new NotImplementedException();
        }

        public async Task<OutputModel> InquiryAsync(InquiryReqDTO inquiryReqDTO)
        {
            throw new NotImplementedException();
        }

        #region private
        private static FormUrlEncodedContent FireFormUrlEncodedContent(FireInsuranceOptions options)
        {
            var result = new Dictionary<string, string>
            {
                {"UserName", options.UserName},
                {"Password", options.Password},
            };
            var formUrlEncodedContent = new FormUrlEncodedContent(result);
            return formUrlEncodedContent;
        }


        #endregion
    }
}
