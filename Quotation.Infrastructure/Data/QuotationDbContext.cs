using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Quotation.Domain.Entities;

namespace Quotation.Infrastructure.Data
{
    public class QuotationDbContext : IdentityDbContext<IdentityUser>
    {
        public DbSet<Unit> Units { get; set; }
        public DbSet<State> States { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Company> Companys { get; set; }
        public QuotationDbContext(DbContextOptions<QuotationDbContext> option) : base (option)
        {

        }
    }
}
