using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using Arfitect.Training.PilotPeer.Models.Entities;
using Arfitect.Training.PilotPeer.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Arfitect.Training.PilotPeer.Models.Context
{
    public class AppIdentityDbContext : IdentityDbContext<AppUser, AppRole, string>
    {
        public AppIdentityDbContext(DbContextOptions<AppIdentityDbContext> options) : base(options)
        {

        }

        public AppIdentityDbContext()
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<SupportRequest>().HasOne(x => x.User).WithMany(x => x.SupportRequests)
                .HasForeignKey(x => x.UserId);
        }


        public DbSet<SupportRequest> SupportRequests { get; set; }


    }
}
