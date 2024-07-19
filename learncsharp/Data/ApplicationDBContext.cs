using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using learnteddy.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace learnteddy.Data
{
    public class ApplicationDBContext : IdentityDbContext<AppUser>
    {
        public ApplicationDBContext(DbContextOptions dbContextOptions) : base(dbContextOptions)
        {

        }

        public DbSet<User> users {get;set;}
        public DbSet<Message> messages {get;set;}
        public DbSet<Group> groups {get;set;}
        public DbSet<GroupMember> groupMembers {get;set;} // many-to-many

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            // build many to many
            builder.Entity<Group>()
                .HasMany(e => e.AppUsers)
                .WithMany(e => e.Groups)
                .UsingEntity<GroupMember>(
                    l => l.HasOne<AppUser>(e => e.AppUser).WithMany(e => e.GroupMembers),
                    r => r.HasOne<Group>(e => e.Group).WithMany(e => e.GroupMembers));


            // build role service
            List<IdentityRole> roles = new List<IdentityRole>{
                new IdentityRole{
                    Name = "Admin",
                    NormalizedName = "ADMIN"
                },
                new IdentityRole{
                    Name = "User",
                    NormalizedName = "USER"
                }
            };
            builder.Entity<IdentityRole>().HasData(roles); 
        }
    }
}