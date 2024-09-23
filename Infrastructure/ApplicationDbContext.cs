using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<States> States { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<States>(entity =>
            {
                entity.HasKey(c => c.Id);
                entity.Property(c => c.Title).IsRequired().HasMaxLength(1000);
                entity.Property(c => c.Mobile).IsRequired().HasMaxLength(50);
                entity.Property(c => c.Descripion).IsRequired().HasMaxLength(2000);
                entity.Property(c => c.Image).IsRequired();
                entity.Property(c => c.ImageContentType).IsRequired().HasMaxLength(100);
            });

        }
    }
}
