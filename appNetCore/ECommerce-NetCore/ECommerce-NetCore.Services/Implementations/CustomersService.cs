using ECommerce_NetCore.Dto.Request;
using ECommerce_NetCore.Dto.Response;
using ECommerce_NetCore.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce_NetCore.Services.Implementations
{
    public class CustomersService : ICustomersService
    {
        public Task<BaseResponse<string>> CreateAsync(CustomersDto request)
        {
            throw new NotImplementedException();
        }

        public Task<BaseResponse<string>> DeleteAsync(string id)
        {
            throw new NotImplementedException();
        }

        public Task<BaseResponse<CustomersDto>> GetAsync(string id)
        {
            throw new NotImplementedException();
        }

        public Task<CustomersDtoCollectionResponse> ListAsync()
        {
            throw new NotImplementedException();
        }

        public Task<BaseResponse<string>> UpdateAsync(string id, CustomersDto request)
        {
            throw new NotImplementedException();
        }
    }
}
