using ECommerce_NetCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce_NetCore.DataAccess.repositories
{
    public interface ICustomersRepository
    {

        Task<Customer> GetItemAsync(string id);

        Task<string> CreateAsync(Customer entity);

        Task<(ICollection<Customer> clienteLista, int total)> ListAsync();

        Task UpdateAsync(Customer entity);

        Task DeleteAsync(string id);

    }
}
