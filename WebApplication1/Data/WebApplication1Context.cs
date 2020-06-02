using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebApplication1;
using WebApplication1.Models;

namespace WebApplication1.Data
{
    public class WebApplication1Context : DbContext
    {
        public WebApplication1Context (DbContextOptions<WebApplication1Context> options)
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TagsInter>()
                .HasKey(t => new { t.DealID, t.TagID });

            modelBuilder.Entity<TagsInter>()
                .HasOne(pt => pt.Deal)
                .WithMany(p => p.TagsInter)
                .HasForeignKey(pt => pt.DealID);

            modelBuilder.Entity<TagsInter>()
                .HasOne(pt => pt.Tag)
                .WithMany(t => t.TagsInter)
                .HasForeignKey(pt => pt.TagID);
        }

        public DbSet<User> User { get; set; }
        public DbSet<Company> Company { get; set; }
        public DbSet<Location> Location { get; set; }
        public DbSet<Resturaunt> Resturaunt { get; set; }
        public DbSet<Day> Day { get; set; }
        public DbSet<Address> Address { get; set; }
        public DbSet<Tags> Tags { get; set; }
        public DbSet<TagsInter> TagsInter { get; set; }
        public DbSet<WebApplication1.Models.ResturauntPage> ResturauntPage { get; set; }
        public DbSet<WebApplication1.Models.Deal> Deal { get; set; }
    }
}
