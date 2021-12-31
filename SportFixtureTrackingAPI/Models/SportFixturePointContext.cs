using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace SportFixtureTrackingAPI.Models
{
    public partial class SportFixturePointContext : DbContext
    {
        public SportFixturePointContext()
        {
        }

        public SportFixturePointContext(DbContextOptions<SportFixturePointContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Club> Clubs { get; set; }
        public virtual DbSet<Fixture> Fixtures { get; set; }
        public virtual DbSet<FixtureResult> FixtureResults { get; set; }
        public virtual DbSet<Sport> Sports { get; set; }
        public virtual DbSet<Team> Teams { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=SportFixturePoint;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Club>(entity =>
            {
                entity.ToTable("Club");

                entity.Property(e => e.ClubDescription).HasMaxLength(50);

                entity.Property(e => e.ClubName)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Fixture>(entity =>
            {
                entity.ToTable("Fixture");

                entity.Property(e => e.FixtureDate).HasColumnType("date");

                entity.Property(e => e.FixtureHome).HasMaxLength(50);

                entity.Property(e => e.IsFinished)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.HasOne(d => d.AwayTeam)
                    .WithMany(p => p.FixtureAwayTeams)
                    .HasForeignKey(d => d.AwayTeamId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Fixture_ToTeam2");

                entity.HasOne(d => d.HomeTeam)
                    .WithMany(p => p.FixtureHomeTeams)
                    .HasForeignKey(d => d.HomeTeamId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Fixture_ToTeam");
            });

            modelBuilder.Entity<FixtureResult>(entity =>
            {
                entity.HasKey(e => e.ResultId)
                    .HasName("PK__tmp_ms_x__976902086C360F2F");

                entity.ToTable("FixtureResult");

                entity.Property(e => e.FixtureId).HasColumnName("Fixture_Id");

                entity.HasOne(d => d.Fixture)
                    .WithMany(p => p.FixtureResults)
                    .HasForeignKey(d => d.FixtureId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_FixtureResult_ToFixture");

                entity.HasOne(d => d.WinnerTeam)
                    .WithMany(p => p.FixtureResults)
                    .HasForeignKey(d => d.WinnerTeamId)
                    .HasConstraintName("FK_FixtureResult_ToTeam");
            });

            modelBuilder.Entity<Sport>(entity =>
            {
                entity.ToTable("Sport");

                entity.Property(e => e.SportDescription).HasMaxLength(50);

                entity.Property(e => e.SportName)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Team>(entity =>
            {
                entity.ToTable("Team");

                entity.Property(e => e.TeamName)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.HasOne(d => d.Club)
                    .WithMany(p => p.Teams)
                    .HasForeignKey(d => d.ClubId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Team_ToClub");

                entity.HasOne(d => d.Sport)
                    .WithMany(p => p.Teams)
                    .HasForeignKey(d => d.SportId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Team_ToSport");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
