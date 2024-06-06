using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Models;

namespace APIOpportunities.Data
{
    public class APIOpportunitiesContext : DbContext
    {
        public APIOpportunitiesContext (DbContextOptions<APIOpportunitiesContext> options)
            : base(options)
        {
        }

        public DbSet<Models.Opportunity> Opportunity { get; set; } = default!;
    }
}
