using ECommerce_History.api.Models;
using Microsoft.EntityFrameworkCore;

namespace ECommerce_History.api.Persistences
{
    public class ContextDatabase : DbContext
    {

        public ContextDatabase(DbContextOptions options) : base(options)
        {

        }

        public DbSet<HistoryModel> Histories => Set<HistoryModel>();


        public DbSet<InvoiceModel> Invoices => Set<InvoiceModel>();
    }
}
