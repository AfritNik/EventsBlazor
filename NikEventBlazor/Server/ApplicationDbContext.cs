using Microsoft.EntityFrameworkCore;
using NikEventBlazor.Shared.Entries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NikEventBlazor.Server
{
    public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options): base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<EventMember>().HasKey(x=>new {x.EventId, x.MemberId});
        }

        public DbSet<NikEvent> Events {get;set;}
        public DbSet<User> Users {get;set;}
        public DbSet<EventMember> EventMebers {get;set;}
    }
}
