using Bimeh.ErrorHandling;
using Domain.Common;
using Domain.Interfaces;
using Domain.Models.Fire;
using Domain.Models.Fire.BimehApi.Models.SportsInsurance;
using FireInsuranceApi.Filters;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Persistence.ErrorHandling;

namespace FireInsuranceApi.Controllers
{
    [ApiController]
    [ApiVersion("1")]
    [Route("Bimeh/Fire/v1/[controller]")]
    [ApiExplorerSettings]
    [ApiResultFilterAttribute]
    public class FireInsuranceController : ControllerBase
    {
        private IFireInsuranceService _fireInsuranceService { get; }
        private IConfiguration _configuration { get; }
        private ILogger<FireInsuranceController> _logger { get; }
        private BaseLog _baseLog { get; }

        public FireInsuranceController(IFireInsuranceService fireInsuranceService, IConfiguration configuration,
            ILogger<FireInsuranceController> logger, BaseLog baseLog)
        {
            _fireInsuranceService = fireInsuranceService;
            _configuration = configuration;
            _logger = logger;
            _baseLog = baseLog;
        }

        /// <summary>
        /// گرفتن توکن برای صدازدن سرویسهای بیمه
        /// </summary>
        /// <param name="publicLogData"></param>
        /// <returns></returns>
        /// <exception cref="AppException"></exception>
        [AllowAnonymous]
        [HttpPost("token")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(BimehTokenRes))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(BimehTokenRes))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(BimehTokenRes))]
        public async Task<ActionResult<BimehTokenRes>> BimehFireInsuranceGetToken(PublicLogData publicLogData)
        {
            var result = await _fireInsuranceService.GetTokenAsync(publicLogData);
            try
            {
                dynamic objectResponse = JsonConvert.DeserializeObject<dynamic>(result?.Content);
                if (result.StatusCode != "OK")
                {
                    _logger.LogError($"{nameof(BimehFireInsuranceGetToken)} not-success request - input \r\n response:{result.StatusCode}-{objectResponse}");
                    return BadRequest(_baseLog.ApiResponeFailByCodeProvider<PublicLogData>(result.Content, result.StatusCode, result.RequestId, publicLogData?.PublicReqId));
                }
                return Ok(_baseLog.ApiResponseSuccessByCodeProvider<BimehTokenRes>(result?.Content, result.StatusCode, result?.RequestId, publicLogData?.PublicReqId));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Exception occurred while {nameof(BimehFireInsuranceGetToken)}");
                throw new RamzNegarException(ErrorCode.InternalError, $"Exception occurred while: {nameof(BimehFireInsuranceGetToken)} => {ex.Message}");
            }
        }


        /// <summary>
        /// گرفتن اطلاعات پایه برای صدا زدن متد استعلام و متد های بعدی
        /// </summary>
        /// <param name="sportInsuranceBasicReq"></param>
        /// <returns></returns>
        /// <exception cref="AppException"></exception>
        [AllowAnonymous]
        [HttpPost("basic-data")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(BasicDataRes))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(BasicDataRes))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(BasicDataRes))]
        public async Task<ActionResult<BasicDataRes>> BimehFireInsuranceBasicData(BasicDataReq basicDataReq)
        {
            var result = await _fireInsuranceService.GetBasicDataAsync(basicDataReq);
            try
            {
                dynamic objectResponse = JsonConvert.DeserializeObject<dynamic>(result?.Content);
                if (result.StatusCode != "OK")
                {
                    _logger.LogError($"{nameof(BimehFireInsuranceBasicData)} not-success request - input \r\n response:{result.StatusCode}-{objectResponse}");
                    return BadRequest(_baseLog.ApiResponeFailByCodeProvider<BasicDataReq>(result.Content, result.StatusCode, result.RequestId, basicDataReq?.PublicReqId));
                }
                return Ok(_baseLog.ApiResponseSuccessByCodeProvider<BasicDataRes>(result?.Content, result.StatusCode, result?.RequestId, basicDataReq?.PublicReqId));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Exception occurred while {nameof(BimehFireInsuranceGetToken)}");
                throw new RamzNegarException(ErrorCode.InternalError, $"Exception occurred while: {nameof(BimehFireInsuranceGetToken)} => {ex.Message}");
            }
        }

        /// <summary>
        /// برای استعلام قیمت بیمه نامه از این سرویس استفاده نمایید.
        /// </summary>
        /// <param name="inquiryReq"></param>
        /// <returns></returns>
        /// <exception cref="AppException"></exception>
        [AllowAnonymous]
        [HttpPost("inquiry")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(InquiryRes))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(InquiryRes))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(InquiryRes))]
        public async Task<ActionResult<InquiryRes>> BimehFireInsuranceInquiry(InquiryReqDTO inquiryReqDTO)
        {
            var result = await _fireInsuranceService.InquiryAsync(inquiryReqDTO);
            try
            {
                if (result.StatusCode != "OK")
                {
                    _logger.LogError($"{nameof(BimehFireInsuranceInquiry)} not-success request - input \r\n response:{result.StatusCode}-{result.Content}");
                    return BadRequest(_baseLog.ApiResponeFailByCodeProvider<InquiryReq>(result.Content, result.StatusCode, result.RequestId, inquiryReqDTO?.PublicReqId));
                }
                return Ok(_baseLog.ApiResponseSuccessByCodeProvider<InquiryRes>(result.Content, result.StatusCode, result.RequestId, inquiryReqDTO?.PublicReqId));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Exception occurred while {nameof(BimehFireInsuranceInquiry)}");
                throw new RamzNegarException(ErrorCode.InternalError, $"Exception occurred while: {nameof(BimehFireInsuranceInquiry)} => {ex.Message}");
            }
        }

        /// <summary>
        /// برای ثبت اولیه درخواست خرید بیمه نامه از این سرویس استفاده نمایید.
        /// </summary>
        /// <param name="createReq"></param>
        /// <returns></returns>
        /// <exception cref="AppException"></exception>
        [AllowAnonymous]
        [HttpPost("create")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(CreateRes))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(CreateRes))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(CreateRes))]
        public async Task<ActionResult<CreateRes>> BimehFireInsuranceCreate(CreateReqDTO createReq)
        {
            var result = await _fireInsuranceService.CreateAsync(createReq);
            try
            {
                dynamic objectResponse = JsonConvert.DeserializeObject<dynamic>(result?.Content);
                if (result.StatusCode != "OK")
                {
                    _logger.LogError($"{nameof(BimehFireInsuranceCreate)} not-success request - input \r\n response:{result.StatusCode}-{objectResponse}");
                    return BadRequest(_baseLog.ApiResponeFailByCodeProvider<CreateReqDTO>(result.Content, result.StatusCode, result.RequestId, createReq?.PublicReqId));
                }
                return Ok(_baseLog.ApiResponseSuccessByCodeProvider<CreateRes>(result.Content, result.StatusCode, result.RequestId, createReq?.PublicReqId));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Exception occurred while {nameof(BimehFireInsuranceInquiry)}");
                throw new RamzNegarException(ErrorCode.InternalError, $"Exception occurred while: {nameof(BimehFireInsuranceInquiry)} => {ex.Message}");
            }
        }

        /// <summary>
        /// برای دریافت فایل بیمه نامه به ازای یک شماره درخواست از این سرویس استفاده میشود
        /// </summary>
        /// <param name="userFileReq"></param>
        /// <returns></returns>
        /// <exception cref="AppException"></exception>
        [AllowAnonymous]
        [HttpPost("file")]
        [ProducesResponseType(typeof(FileStreamResult), StatusCodes.Status200OK)]
        public async Task<ActionResult> BimehFireInsuranceGetFile(FileReq userFileReq)
        {
            var result = await _fireInsuranceService.GetFileAsync(userFileReq).ConfigureAwait(false);
            try
            {
                if (result.StatusCode != "OK")
                {
                    _logger.LogError($"{nameof(BimehFireInsuranceGetFile)} not-success request - input \r\n response:{result.StatusCode}-{result.Content}");
                    return BadRequest(_baseLog.ApiResponeFailByCodeProvider<FileReq>(result.Content.ToString(), result.StatusCode, result.RequestId, userFileReq?.PublicReqId));
                }
                return File(result.Content, "application/pdf", $" Insurance{DateTime.Now}");

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Exception occurred while {nameof(BimehFireInsuranceGetFile)}");
                throw new RamzNegarException(ErrorCode.InternalError, $"Exception occurred while: {nameof(BimehFireInsuranceGetFile)} => {ex.Message}");
            }
        }


    }
}
