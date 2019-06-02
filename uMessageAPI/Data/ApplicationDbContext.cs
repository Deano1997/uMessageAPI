using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using uMessageAPI.Data.Mapping;
using uMessageAPI.Models;

namespace uMessageAPI.Data
{
    public class ApplicationDbContext : IdentityDbContext<User, IdentityRole<Guid>, Guid> {
        public ApplicationDbContext(DbContextOptions options) : base(options) { }

        // TODO: Provide additional data sets that are accessible through our database connection.
        public DbSet<Channel> Channels { get; set; }
        public DbSet<Member> ChannelUsers { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<Member> Members { get; set; }

        protected override void OnModelCreating(ModelBuilder builder) {
            base.OnModelCreating(builder);
            builder.ApplyConfiguration(new MemberConfiguration());
        }

    }

}