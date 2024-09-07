using ECommerce_NetCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce_NetCore.DataAccess.repositories
{
    public interface IProductRepository
    {
        Task<Product> GetItemAsync(string id);

        Task<string> CreateAsync(Product entity);

        Task<(ICollection<Product> productoLista, int total)> ListAsync();

        Task UpdateAsync(Product entity);

        Task DeleteAsync(string id);
    }
}
