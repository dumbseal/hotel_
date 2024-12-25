using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Domian.Models
{
    public partial class HotelRusBookingContext : DbContext
    {
        public HotelRusBookingContext()
        {
        }

        public HotelRusBookingContext(DbContextOptions<HotelRusBookingContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Admin> Admins { get; set; } = null!;
        public virtual DbSet<Amenity> Amenities { get; set; } = null!;
        public virtual DbSet<BookedOffer> BookedOffers { get; set; } = null!;
        public virtual DbSet<Booking> Bookings { get; set; } = null!;
        public virtual DbSet<BookingStatus> BookingStatuses { get; set; } = null!;
        public virtual DbSet<BookingStatusHistory> BookingStatusHistories { get; set; } = null!;
        public virtual DbSet<City> Cities { get; set; } = null!;
        public virtual DbSet<Hotel> Hotels { get; set; } = null!;
        public virtual DbSet<HotelPhoto> HotelPhotos { get; set; } = null!;
        public virtual DbSet<Log> Logs { get; set; } = null!;
        public virtual DbSet<Payment> Payments { get; set; } = null!;
        public virtual DbSet<PaymentMethod> PaymentMethods { get; set; } = null!;
        public virtual DbSet<Region> Regions { get; set; } = null!;
        public virtual DbSet<Review> Reviews { get; set; } = null!;
        public virtual DbSet<Room> Rooms { get; set; } = null!;
        public virtual DbSet<RoomType> RoomTypes { get; set; } = null!;
        public virtual DbSet<SpecialOffer> SpecialOffers { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;

        

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Admin>(entity =>
            {
                entity.HasIndex(e => e.Username, "UQ__Admins__536C85E4B363BEDF")
                    .IsUnique();

                entity.Property(e => e.AdminId)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("AdminID");

                entity.Property(e => e.PasswordHash)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Username)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.AdminNavigation)
                    .WithOne(p => p.Admin)
                    .HasForeignKey<Admin>(d => d.AdminId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Admins__Password__72C60C4A");
            });

            modelBuilder.Entity<Amenity>(entity =>
            {
                entity.Property(e => e.AmenityId).HasColumnName("AmenityID");

                entity.Property(e => e.AmenityName)
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<BookedOffer>(entity =>
            {
                entity.Property(e => e.BookedOfferId).HasColumnName("BookedOfferID");

                entity.Property(e => e.BookingId).HasColumnName("BookingID");

                entity.Property(e => e.OfferId).HasColumnName("OfferID");

                entity.HasOne(d => d.Booking)
                    .WithMany(p => p.BookedOffers)
                    .HasForeignKey(d => d.BookingId)
                    .HasConstraintName("FK__BookedOff__Booki__6A30C649");

                entity.HasOne(d => d.Offer)
                    .WithMany(p => p.BookedOffers)
                    .HasForeignKey(d => d.OfferId)
                    .HasConstraintName("FK__BookedOff__Offer__6B24EA82");
            });

            modelBuilder.Entity<Booking>(entity =>
            {
                entity.Property(e => e.BookingId).HasColumnName("BookingID");

                entity.Property(e => e.BookingDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.CheckInDate).HasColumnType("date");

                entity.Property(e => e.CheckOutDate).HasColumnType("date");

                entity.Property(e => e.RoomId).HasColumnName("RoomID");

                entity.Property(e => e.TotalPrice).HasColumnType("decimal(8, 2)");

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.HasOne(d => d.Room)
                    .WithMany(p => p.Bookings)
                    .HasForeignKey(d => d.RoomId)
                    .HasConstraintName("FK__Bookings__RoomID__4F7CD00D");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Bookings)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK__Bookings__UserID__4E88ABD4");
            });

            modelBuilder.Entity<BookingStatus>(entity =>
            {
                entity.Property(e => e.BookingStatusId).HasColumnName("BookingStatusID");

                entity.Property(e => e.StatusName)
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<BookingStatusHistory>(entity =>
            {
                entity.ToTable("BookingStatusHistory");

                entity.Property(e => e.BookingStatusHistoryId).HasColumnName("BookingStatusHistoryID");

                entity.Property(e => e.BookingId).HasColumnName("BookingID");

                entity.Property(e => e.BookingStatusId).HasColumnName("BookingStatusID");

                entity.Property(e => e.StatusChangeDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.Booking)
                    .WithMany(p => p.BookingStatusHistories)
                    .HasForeignKey(d => d.BookingId)
                    .HasConstraintName("FK__BookingSt__Booki__5535A963");

                entity.HasOne(d => d.BookingStatus)
                    .WithMany(p => p.BookingStatusHistories)
                    .HasForeignKey(d => d.BookingStatusId)
                    .HasConstraintName("FK__BookingSt__Booki__5629CD9C");
            });

            modelBuilder.Entity<City>(entity =>
            {
                entity.Property(e => e.CityId).HasColumnName("CityID");

                entity.Property(e => e.CityName)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.RegionId).HasColumnName("RegionID");

                entity.HasOne(d => d.Region)
                    .WithMany(p => p.Cities)
                    .HasForeignKey(d => d.RegionId)
                    .HasConstraintName("FK__Cities__RegionID__398D8EEE");
            });

            modelBuilder.Entity<Hotel>(entity =>
            {
                entity.Property(e => e.HotelId).HasColumnName("HotelID");

                entity.Property(e => e.Address)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.CityId).HasColumnName("CityID");

                entity.Property(e => e.Description).HasColumnType("text");

                entity.Property(e => e.HotelName)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Latitude).HasColumnType("decimal(9, 6)");

                entity.Property(e => e.Longitude).HasColumnType("decimal(9, 6)");

                entity.HasOne(d => d.City)
                    .WithMany(p => p.Hotels)
                    .HasForeignKey(d => d.CityId)
                    .HasConstraintName("FK__Hotels__CityID__3C69FB99");

                entity.HasMany(d => d.Amenities)
                    .WithMany(p => p.Hotels)
                    .UsingEntity<Dictionary<string, object>>(
                        "HotelAmenity",
                        l => l.HasOne<Amenity>().WithMany().HasForeignKey("AmenityId").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK__HotelAmen__Ameni__47DBAE45"),
                        r => r.HasOne<Hotel>().WithMany().HasForeignKey("HotelId").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK__HotelAmen__Hotel__46E78A0C"),
                        j =>
                        {
                            j.HasKey("HotelId", "AmenityId").HasName("PK__HotelAme__EE4094EDF8EC779F");

                            j.ToTable("HotelAmenities");

                            j.IndexerProperty<int>("HotelId").HasColumnName("HotelID");

                            j.IndexerProperty<int>("AmenityId").HasColumnName("AmenityID");
                        });
            });

            modelBuilder.Entity<HotelPhoto>(entity =>
            {
                entity.HasKey(e => e.PhotoId)
                    .HasName("PK__HotelPho__21B7B5826CAD174D");

                entity.Property(e => e.PhotoId).HasColumnName("PhotoID");

                entity.Property(e => e.HotelId).HasColumnName("HotelID");

                entity.Property(e => e.PhotoUrl)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("PhotoURL");

                entity.HasOne(d => d.Hotel)
                    .WithMany(p => p.HotelPhotos)
                    .HasForeignKey(d => d.HotelId)
                    .HasConstraintName("FK__HotelPhot__Hotel__5DCAEF64");
            });

            modelBuilder.Entity<Log>(entity =>
            {
                entity.Property(e => e.LogId).HasColumnName("LogID");

                entity.Property(e => e.AdminId).HasColumnName("AdminID");

                entity.HasOne(d => d.Admin)
                    .WithMany(p => p.Logs)
                    .HasForeignKey(d => d.AdminId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Logs__AdminID__75A278F5");
            });

            modelBuilder.Entity<Payment>(entity =>
            {
                entity.Property(e => e.PaymentId).HasColumnName("PaymentID");

                entity.Property(e => e.Amount).HasColumnType("decimal(8, 2)");

                entity.Property(e => e.BookingId).HasColumnName("BookingID");

                entity.Property(e => e.PaymentDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.PaymentMethodId).HasColumnName("PaymentMethodID");

                entity.HasOne(d => d.Booking)
                    .WithMany(p => p.Payments)
                    .HasForeignKey(d => d.BookingId)
                    .HasConstraintName("FK__Payments__Bookin__6383C8BA");

                entity.HasOne(d => d.PaymentMethod)
                    .WithMany(p => p.Payments)
                    .HasForeignKey(d => d.PaymentMethodId)
                    .HasConstraintName("FK__Payments__Paymen__6477ECF3");
            });

            modelBuilder.Entity<PaymentMethod>(entity =>
            {
                entity.Property(e => e.PaymentMethodId).HasColumnName("PaymentMethodID");

                entity.Property(e => e.MethodName)
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Region>(entity =>
            {
                entity.Property(e => e.RegionId).HasColumnName("RegionID");

                entity.Property(e => e.RegionName)
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Review>(entity =>
            {
                entity.Property(e => e.ReviewId).HasColumnName("ReviewID");

                entity.Property(e => e.Comment).HasColumnType("text");

                entity.Property(e => e.HotelId).HasColumnName("HotelID");

                entity.Property(e => e.ReviewDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.HasOne(d => d.Hotel)
                    .WithMany(p => p.Reviews)
                    .HasForeignKey(d => d.HotelId)
                    .HasConstraintName("FK__Reviews__HotelID__5AEE82B9");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Reviews)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK__Reviews__UserID__59FA5E80");
            });

            modelBuilder.Entity<Room>(entity =>
            {
                entity.Property(e => e.RoomId).HasColumnName("RoomID");

                entity.Property(e => e.HotelId).HasColumnName("HotelID");

                entity.Property(e => e.PricePerNight).HasColumnType("decimal(8, 2)");

                entity.Property(e => e.RoomNumber)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.RoomTypeId).HasColumnName("RoomTypeID");

                entity.HasOne(d => d.Hotel)
                    .WithMany(p => p.Rooms)
                    .HasForeignKey(d => d.HotelId)
                    .HasConstraintName("FK__Rooms__HotelID__412EB0B6");

                entity.HasOne(d => d.RoomType)
                    .WithMany(p => p.Rooms)
                    .HasForeignKey(d => d.RoomTypeId)
                    .HasConstraintName("FK__Rooms__RoomTypeI__4222D4EF");
            });

            modelBuilder.Entity<RoomType>(entity =>
            {
                entity.Property(e => e.RoomTypeId).HasColumnName("RoomTypeID");

                entity.Property(e => e.Description).HasColumnType("text");

                entity.Property(e => e.TypeName)
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<SpecialOffer>(entity =>
            {
                entity.HasKey(e => e.OfferId)
                    .HasName("PK__SpecialO__8EBCF0B1D7AC5783");

                entity.Property(e => e.OfferId).HasColumnName("OfferID");

                entity.Property(e => e.Description).HasColumnType("text");

                entity.Property(e => e.HotelId).HasColumnName("HotelID");

                entity.Property(e => e.OfferName)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.ValidFrom).HasColumnType("date");

                entity.Property(e => e.ValidTo).HasColumnType("date");

                entity.HasOne(d => d.Hotel)
                    .WithMany(p => p.SpecialOffers)
                    .HasForeignKey(d => d.HotelId)
                    .HasConstraintName("FK__SpecialOf__Hotel__6754599E");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasIndex(e => e.Email, "UQ__Users__A9D105340FE1288F")
                    .IsUnique();

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.Property(e => e.Email)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.FirstName)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.LastName)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.PasswordHash)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.HasMany(d => d.Hotels)
                    .WithMany(p => p.Users)
                    .UsingEntity<Dictionary<string, object>>(
                        "FavoriteHotel",
                        l => l.HasOne<Hotel>().WithMany().HasForeignKey("HotelId").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK__FavoriteH__Hotel__6EF57B66"),
                        r => r.HasOne<User>().WithMany().HasForeignKey("UserId").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK__FavoriteH__UserI__6E01572D"),
                        j =>
                        {
                            j.HasKey("UserId", "HotelId").HasName("PK__Favorite__F3E8EF17E2CECAFA");

                            j.ToTable("FavoriteHotels");

                            j.IndexerProperty<int>("UserId").HasColumnName("UserID");

                            j.IndexerProperty<int>("HotelId").HasColumnName("HotelID");
                        });
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
