using Bimeh.ErrorHandling;
using Bimeh.Infratructure.Extension;
using Bimeh.Models;

using Domain.Interfaces;
using Newtonsoft.Json;
using Persistence.ErrorHandling;

namespace FireInsuranceApi
{
    public class BaseLog
    {
        public IFireInsuranceRepository _fireInsuranceRepository{ get; }
        public BaseLog(IFireInsuranceRepository fireInsuranceRepository)
        {
            _fireInsuranceRepository = fireInsuranceRepository;
        }
        public T ApiResponseSuccessByCodeProvider<T>(string response, string statusCode, string RequestId, string publicReqId) where T : new()
        {
            _fireInsuranceRepository.InsertFireResponseLog(new FireResponseLogDTO(publicReqId, Convert.ToString(response), statusCode, RequestId, statusCode));
            var responseResult = JsonConvert.DeserializeObject<T>(response);
            return responseResult;
        }
        public ErrorResult ApiResponeFailByCodeProvider<T>(string response, string statusCode, string RequestId, string publicReqId) where T : new()
        {
            var codeProvider = new ErrorCodesProvider();
            codeProvider = codeProvider.errorCodesResponseResult(statusCode.ToString());
            _fireInsuranceRepository.InsertFireResponseLog(new FireResponseLogDTO
                (publicReqId, Convert.ToString(response), codeProvider?.OutReponseCode.ToString(),
                RequestId, codeProvider?.SafeReponseCode.ToString()));
            return ServiceHelperExtension.GenerateApiErrorResponse<ErrorResult>(codeProvider);
        }


    }
}
