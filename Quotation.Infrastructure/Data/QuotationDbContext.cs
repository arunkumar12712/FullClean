
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Quotation.Domain.Entities;

namespace Quotation.Infrastructure.Data
{
    public class QuotationDbContext : DbContext
    {
        public DbSet<Unit> Units { get; set; }
        public DbSet<State> States { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Company> Company { get; set; }
        public QuotationDbContext(DbContextOptions<QuotationDbContext> option) : base (option)
        {

        }
    }
}
