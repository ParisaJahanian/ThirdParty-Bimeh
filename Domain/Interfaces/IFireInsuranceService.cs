using Domain.Common;
using Domain.Models.Fire;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IFireInsuranceService
    {
        Task<OutputModel> GetTokenAsync(PublicLogData basePublicLog);
        Task<OutputModel> GetBasicDataAsync(BasicDataReq basicDataReq);
        Task<OutputModel> InquiryAsync(InquiryReqDTO inquiryReqDTO);
        Task<OutputModel> CreateAsync(CreateReqDTO createReq);
        Task<FileRes> GetFileAsync(FileReq userFileReq);
    }
}
