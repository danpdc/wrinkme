using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using WrinkMe.Domain.Models;

namespace WrinkeMe.Dal
{
    public class WrinkMeDataContext : DbContext
    {
        public WrinkMeDataContext(DbContextOptions<WrinkMeDataContext> options) : base(options)
        {
        }

        public DbSet<ShortUrl> ShortUrls { get; set; }
        public DbSet<UserAgent> Requests { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserProfile> UserProfiles { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            base.OnConfiguring(builder);
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<UserAgent>().OwnsOne(ua => ua.Browser).ToTable("Browsers");
            builder.Entity<UserAgent>().OwnsOne(ua => ua.Device).ToTable("Devices");
            builder.Entity<UserAgent>().OwnsOne(ua => ua.OS).ToTable("OS");
        }
    }
}
