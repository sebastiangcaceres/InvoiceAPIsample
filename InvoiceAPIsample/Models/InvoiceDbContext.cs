using Microsoft.EntityFrameworkCore;

namespace InvoiceAPIsample.Models
{
    public class InvoiceDbContext:DbContext
    {
        public InvoiceDbContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Invoices> Invoices { get; set; }
    }
}
