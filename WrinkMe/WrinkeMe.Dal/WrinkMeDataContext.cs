using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using WrinkMe.Domain.Models;

namespace WrinkeMe.Dal
{
    public class WrinkMeDataContext : DbContext
    {
        public WrinkMeDataContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<ShortUrl> ShortUrls { get; set; }
        public DbSet<UserAgent> Requests { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            base.OnConfiguring(builder);
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {

        }
    }
}
