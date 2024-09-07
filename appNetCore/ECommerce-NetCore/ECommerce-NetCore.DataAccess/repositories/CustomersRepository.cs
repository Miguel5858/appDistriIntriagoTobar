using Azure;
using ECommerce_NetCore.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce_NetCore.DataAccess.repositories
{
    public class CustomersRepository : ECommerceRepositoryGeneric<Customer>, ICustomersRepository
    {
        public CustomersRepository(ECommerceNetCoreDbContext context) : base(context)
        {

        }

        public async Task<string> CreateAsync(Customer entity)
        {
            return await Insert(entity);
        }

        public async Task DeleteAsync(string id)
        {
            await DeleteEntity(id);
        }

        public async Task<Customer> GetItemAsync(string id)
        {
            return await Select(id);
        }

        public async Task<(ICollection<Customer> clienteLista, int total)> ListAsync()
        {
            var clienteLista = await SelectAll();
            int total = 0;
            if (clienteLista != null)
            {

                total = clienteLista.Count;
            }

            return (clienteLista, total);
        }

        public async Task UpdateAsync(Customer entity)
        {
            await UpdateEntity(entity);
        }

    }
}
