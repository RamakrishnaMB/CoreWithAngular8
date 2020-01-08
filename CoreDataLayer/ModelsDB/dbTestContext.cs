using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace CoreDataLayer.ModelsDB
{
    public partial class dbTestContext : DbContext
    {
        public dbTestContext()
        {
        }

        public dbTestContext(DbContextOptions<dbTestContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Booking> Booking { get; set; }
        public virtual DbSet<Customers> Customers { get; set; }
        public virtual DbSet<RoomType> RoomType { get; set; }

        // Unable to generate entity type for table 'dbo.Sales'. Please see the warning messages.

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                //run this in PackageManagerConsole and select defult project to = CoreDataLayer
                //Scaffold-DbContext "Server=ES-SYS-764\SQL2017;Database=dbTest;Trusted_Connection=True;" Microsoft.EntityFrameworkCore.SqlServer -OutputDir ModelsDB
                optionsBuilder.UseSqlServer(ConnectionString.GetConnectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.6-servicing-10079");

            modelBuilder.Entity<Booking>(entity =>
            {
                entity.Property(e => e.BookingId)
                    .HasColumnName("BookingID")
                    .ValueGeneratedNever();

                entity.Property(e => e.CheckInDate).HasColumnType("datetime");

                entity.Property(e => e.CheckOutDate).HasColumnType("datetime");

                entity.Property(e => e.Cid).HasColumnName("CId");

                entity.HasOne(d => d.C)
                    .WithMany(p => p.Booking)
                    .HasForeignKey(d => d.Cid)
                    .HasConstraintName("FK_Booking_Booking");

                entity.HasOne(d => d.Room)
                    .WithMany(p => p.Booking)
                    .HasForeignKey(d => d.RoomId)
                    .HasConstraintName("FK_Booking_RoomType");
            });

            modelBuilder.Entity<Customers>(entity =>
            {
                entity.HasKey(e => e.Cid)
                    .HasName("PK__Customer__C1F8DC39CD09601D");

                entity.Property(e => e.Cid).HasColumnName("CId");

                entity.Property(e => e.Email).HasMaxLength(20);

                entity.Property(e => e.Name).HasMaxLength(20);

                entity.Property(e => e.ProfilePic).HasMaxLength(300);

                entity.Property(e => e.Telephone).HasMaxLength(20);
            });

            modelBuilder.Entity<RoomType>(entity =>
            {
                entity.Property(e => e.RoomType1)
                    .HasColumnName("RoomType")
                    .HasMaxLength(10)
                    .IsUnicode(false);
            });
        }
    }
}
