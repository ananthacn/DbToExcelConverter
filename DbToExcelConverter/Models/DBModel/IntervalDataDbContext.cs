using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace DbToExcelConverter.Models.DBModel
{
    public class IntervalDataDbContext : DbContext
    {
        public virtual DbSet<IntervalData> IntervalData { get; set; }

        public IntervalDataDbContext(DbContextOptions<IntervalDataDbContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<IntervalData>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.Property(e => e.Id).HasColumnName("Id");

                entity.Property(e => e.DeliveryPoint)                   
                    .IsUnicode(false);

                entity.Property(e => e.Date)                   
                    .IsUnicode(false);

                entity.Property(e => e.TimeSlot)                    
                    .IsUnicode(false);

                entity.Property(e => e.SlotVal)
                    .IsUnicode(false);
            });
        }
    }
}
