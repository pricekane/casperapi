using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace casper_api.Models
{
    public class CasperContext : DbContext
    {
        public CasperContext(DbContextOptions<CasperContext> options)
            : base(options)
        { }

        public DbSet<User> Users { get; set; }
    }
}