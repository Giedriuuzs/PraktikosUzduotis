using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Backend
{
    public partial class praktikaContext : DbContext
    {
        public praktikaContext()
        {
        }

        public praktikaContext(DbContextOptions<praktikaContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Comments> Comments { get; set; }
        public virtual DbSet<Records> Records { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlite("Data Source=praktika.db");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Comments>(entity =>
            {
                entity.ToTable("comments");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("INT")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasColumnName("email");

                entity.Property(e => e.FkRecord)
                    .HasColumnName("fk_record")
                    .HasColumnType("INT");

                entity.Property(e => e.Text)
                    .IsRequired()
                    .HasColumnName("text");

                entity.Property(e => e.Time)
                    .IsRequired()
                    .HasColumnName("time")
                    .HasColumnType("DATETIME");

                entity.HasOne(d => d.FkRecordNavigation)
                    .WithMany(p => p.Comments)
                    .HasForeignKey(d => d.FkRecord);
            });

            modelBuilder.Entity<Records>(entity =>
            {
                entity.ToTable("records");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("INT")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.CommentsNr)
                    .HasColumnName("commentsNr")
                    .HasColumnType("INT");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasColumnName("email");

                entity.Property(e => e.Text)
                    .IsRequired()
                    .HasColumnName("text");

                entity.Property(e => e.Time)
                    .IsRequired()
                    .HasColumnName("time")
                    .HasColumnType("DATETIME");

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasColumnName("title");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
