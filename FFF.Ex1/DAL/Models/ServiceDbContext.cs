using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace FFF.Ex1.DAL.Models
{
    /// <summary>
    /// 
    /// </summary>
    public partial class ServiceDbContext : DbContext
    {
        public ServiceDbContext()
        {
        }

        public ServiceDbContext(DbContextOptions<ServiceDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Datum> Data { get; set; }
        public virtual DbSet<QueryLogAction> QueryLogActions { get; set; }
        public virtual DbSet<ServiceLogAction> ServiceLogActions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Datum>(entity =>
            {
                entity.ToTable("data");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Code).HasColumnName("code");

                entity.Property(e => e.Value)
                    .HasMaxLength(300)
                    .IsUnicode(false)
                    .HasColumnName("value");
            });

            modelBuilder.Entity<QueryLogAction>(entity =>
            {
                entity.ToTable("query_log_action");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Action)
                    .IsUnicode(false)
                    .HasColumnName("action");

                entity.Property(e => e.ActionDate)
                    .HasColumnType("datetime")
                    .HasColumnName("action_date");

                entity.Property(e => e.UserIp)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("user_ip");
            });

            modelBuilder.Entity<ServiceLogAction>(entity =>
            {
                entity.ToTable("service_log_action");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Action)
                    .IsUnicode(false)
                    .HasColumnName("action");

                entity.Property(e => e.ActionDate)
                    .HasColumnType("datetime")
                    .HasColumnName("action_date");

                entity.Property(e => e.UserIp)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("user_ip");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
