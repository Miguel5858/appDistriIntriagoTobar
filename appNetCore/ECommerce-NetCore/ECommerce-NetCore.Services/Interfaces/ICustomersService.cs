using ECommerce_NetCore.Dto.Request;
using ECommerce_NetCore.Dto.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce_NetCore.Services.Interfaces
{
    public interface ICustomersService
    {
        Task<BaseResponse<CustomersDto>> GetAsync(string id);

        Task<CustomersDtoCollectionResponse> ListAsync();

        Task<BaseResponse<string>> CreateAsync(CustomersDto request);

        Task<BaseResponse<string>> UpdateAsync(string id, CustomersDto request);

        Task<BaseResponse<string>> DeleteAsync(string id);
    }
}
