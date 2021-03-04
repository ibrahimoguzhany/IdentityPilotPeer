using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Arfitect.Training.PilotPeer.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace Arfitect.Training.PilotPeer.Models.Context
{
    public class RequestContext : DbContext
    {
        public DbSet<SupportRequest> SupportRequests { get; set; }

        public RequestContext(DbContextOptions<RequestContext> options) : base(options)
        {
            
        }
        public RequestContext()
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

        }

    }
}
