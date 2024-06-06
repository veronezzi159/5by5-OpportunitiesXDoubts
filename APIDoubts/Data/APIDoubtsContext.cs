using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Models;

namespace APIDoubts.Data
{
    public class APIDoubtsContext : DbContext
    {
        public APIDoubtsContext (DbContextOptions<APIDoubtsContext> options)
            : base(options)
        {
        }

        public DbSet<Models.Doubt> Doubt { get; set; } = default!;
    }
}
