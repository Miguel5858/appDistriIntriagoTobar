using ECommerce_NetCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce_NetCore.DataAccess.repositories
{
    public class ProductRepository : ECommerceRepositoryGeneric<Product>, IProductRepository
    {
        public ProductRepository(ECommerceNetCoreDbContext context) : base(context)
        {

        }

        public async Task<string> CreateAsync(Product entity)
        {
            return await Insert(entity);
        }

        public async Task DeleteAsync(string id)
        {
            await DeleteEntity(id);
        }

        public async Task<Product> GetItemAsync(string id)
        {
            return await Select(id);
        }

        public async Task<(ICollection<Product> productoLista, int total)> ListAsync()
        {
            var productLista = await SelectAll();
            int total = 0;
            if (productLista != null)
            {
                total = productLista.Count;
            }
            return (productLista, total);
        }

        public async Task UpdateAsync(Product entity)
        {
            await UpdateEntity(entity);
        }
    }
}
