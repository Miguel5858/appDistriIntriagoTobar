using ECommerce_NetCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce_NetCore.DataAccess.repositories
{
    public interface ICategoryRepository
    {

        Task<Category> GetItemAsync(string id);

        Task<string> CreateAsync(Category entity);

        Task<(ICollection<Category> categoryLista, int total)> ListAsync();

        Task UpdateAsync(Category entity);

        Task DeleteAsync(string id);

    }
}
