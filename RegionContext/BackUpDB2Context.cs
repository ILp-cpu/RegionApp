using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace RegionContext
{
    public partial class BackUpDB2Context : DbContext
    {
        public BackUpDB2Context()
        {
        }

        public BackUpDB2Context(DbContextOptions<BackUpDB2Context> options)
            : base(options)
        {
        }

        public virtual DbSet<City> City { get; set; }
        public virtual DbSet<Region> Region { get; set; }
        public virtual DbSet<Route> Route { get; set; }
        public virtual DbSet<Users> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Data Source=MSSQL_SERVER_NAME;Initial Catalog=BackUpDB2;Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.0-rtm-35687");

            modelBuilder.Entity<City>(entity =>
            {
                entity.Property(e => e.CityName)
                    .IsRequired()
                    .HasColumnName("City_Name")
                    .HasMaxLength(50);

                entity.Property(e => e.RegionId).HasColumnName("Region_Id");

                entity.HasOne(d => d.Region)
                    .WithMany(p => p.City)
                    .HasForeignKey(d => d.RegionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_City_Region");
            });

            modelBuilder.Entity<Region>(entity =>
            {
                entity.Property(e => e.RegionId)
                    .HasColumnName("region_id")
                    .ValueGeneratedNever();

                entity.Property(e => e.EntityTypeId).HasColumnName("entity_type_id");

                entity.Property(e => e.FeatureBindingId).HasColumnName("feature_binding_id");

                entity.Property(e => e.ParentRegionId).HasColumnName("parent_region_id");

                entity.Property(e => e.RegionLevel).HasColumnName("region_level");

                entity.Property(e => e.RegionName)
                    .IsRequired()
                    .HasColumnName("region_name")
                    .HasMaxLength(500);
            });

            modelBuilder.Entity<Route>(entity =>
            {
                entity.Property(e => e.EventDate)
                    .HasColumnType("date")
                    .HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.FromCity)
                    .WithMany(p => p.RouteFromCity)
                    .HasForeignKey(d => d.FromCityId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Route_City");

                entity.HasOne(d => d.ToCity)
                    .WithMany(p => p.RouteToCity)
                    .HasForeignKey(d => d.ToCityId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Route_City1");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Route)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Route_Users");
            });

            modelBuilder.Entity<Users>(entity =>
            {
                entity.Property(e => e.Gender)
                    .IsRequired()
                    .HasMaxLength(1);
            });
        }
    }
}
