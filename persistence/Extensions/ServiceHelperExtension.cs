
using System.Text.Json.Serialization;
using System.Text.Json;
using Microsoft.OpenApi.Extensions;
using Persistence.ErrorHandling;
using Domain.Common;
using Bimeh.ErrorHandling;

namespace Bimeh.Infratructure.Extension
{
    public static class ServiceHelperExtension
    {
        public static readonly JsonSerializerOptions JsonSerializerOptions = new JsonSerializerOptions
        {
            AllowTrailingCommas = true,
            DictionaryKeyPolicy = JsonNamingPolicy.CamelCase,
            NumberHandling = JsonNumberHandling.AllowReadingFromString,
            PropertyNameCaseInsensitive = true,
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
            ReadCommentHandling = JsonCommentHandling.Skip,
            IgnoreNullValues = true
        };
        public static void AddCommonHeader(this HttpRequestMessage request)
        {
            request.Headers.Add("Accept", "application/json");
        }
        public static void AddFireInsuranceCommonHeader(this HttpRequestMessage request, string token, string businessToken)
        {
            request.Headers.Add("Accept", "application/json");
            request.Headers.Add("Authorization", token);
            request.Headers.Add("business-token", businessToken);
        }
        public static FormUrlEncodedContent FormUrlEncodedContent(string UserName, string Password)
        {
            var result = new Dictionary<string, string>
            {
                {"UserName", UserName},
                {"Password", Password},
            };
            var formUrlEncodedContent = new FormUrlEncodedContent(result);
            return formUrlEncodedContent;
        }
        public static T GenerateApiErrorResponse<T>(ErrorCodesProvider errorCode) where T : ErrorResult, new()
        {
            return new T
            {
                StatusCode = errorCode.OutReponseCode.ToString(),
                IsSuccess = false,
                ResultMessage = errorCode?.SafeReponseMesageDecription,

            };
        }

        public static T GenerateErrorMethodResponse<T>(ErrorCode errorCode, string RequestId) where T : OutputModel, new()
        {
            return new T
            {
                StatusCode = errorCode.ToString(),
                RequestId = RequestId,
                Content = errorCode.GetDisplayName(),
            };
        }

    }

}
