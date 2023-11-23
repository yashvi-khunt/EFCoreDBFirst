using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace EFCoreDBFirst.Models
{
    public partial class MOVIES_W3Context : DbContext
    {
        public MOVIES_W3Context()
        {
        }

        public MOVIES_W3Context(DbContextOptions<MOVIES_W3Context> options)
            : base(options)
        {
        }

        public virtual DbSet<Actor> Actors { get; set; } = null!;
        public virtual DbSet<Director> Directors { get; set; } = null!;
        public virtual DbSet<Genre> Genres { get; set; } = null!;
        public virtual DbSet<Movie> Movies { get; set; } = null!;
        public virtual DbSet<MovieCast> MovieCasts { get; set; } = null!;
        public virtual DbSet<MovieDirection> MovieDirections { get; set; } = null!;
        public virtual DbSet<MovieGenre> MovieGenres { get; set; } = null!;
        public virtual DbSet<Rating> Ratings { get; set; } = null!;
        public virtual DbSet<Reviewer> Reviewers { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=.; Database=MOVIES_W3;Trusted_Connection=true;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Actor>(entity =>
            {
                entity.HasKey(e => e.ActId);

                entity.ToTable("actor");

                entity.Property(e => e.ActId)
                    .ValueGeneratedNever()
                    .HasColumnName("act_id");

                entity.Property(e => e.ActFname)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("act_fname");

                entity.Property(e => e.ActGender)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("act_gender");

                entity.Property(e => e.ActLname)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("act_lname");
            });

            modelBuilder.Entity<Director>(entity =>
            {
                entity.HasKey(e => e.DirId);

                entity.ToTable("director");

                entity.Property(e => e.DirId)
                    .ValueGeneratedNever()
                    .HasColumnName("dir_id");

                entity.Property(e => e.DirFname)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("dir_fname");

                entity.Property(e => e.DirLname)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("dir_lname");
            });

            modelBuilder.Entity<Genre>(entity =>
            {
                entity.HasKey(e => e.GenId);

                entity.ToTable("genres");

                entity.Property(e => e.GenId)
                    .ValueGeneratedNever()
                    .HasColumnName("gen_id");

                entity.Property(e => e.GenTitle)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("gen_title");
            });

            modelBuilder.Entity<Movie>(entity =>
            {
                entity.HasKey(e => e.MovId);

                entity.ToTable("movie");

                entity.Property(e => e.MovId)
                    .ValueGeneratedNever()
                    .HasColumnName("mov_id");

                entity.Property(e => e.MovDtRel)
                    .HasColumnType("datetime")
                    .HasColumnName("mov_dt_rel");

                entity.Property(e => e.MovLang)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("mov_lang");

                entity.Property(e => e.MovRelCountry)
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .HasColumnName("mov_rel_country");

                entity.Property(e => e.MovTime).HasColumnName("mov_time");

                entity.Property(e => e.MovTitle)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("mov_title");

                entity.Property(e => e.MovYear).HasColumnName("mov_year");
            });

            modelBuilder.Entity<MovieCast>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("movie_cast");

                entity.Property(e => e.ActId).HasColumnName("act_id");

                entity.Property(e => e.MovId).HasColumnName("mov_id");

                entity.Property(e => e.Role)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("role");

                entity.HasOne(d => d.Act)
                    .WithMany()
                    .HasForeignKey(d => d.ActId)
                    .HasConstraintName("FK__movie_cas__act_i__3C69FB99");

                entity.HasOne(d => d.Mov)
                    .WithMany()
                    .HasForeignKey(d => d.MovId)
                    .HasConstraintName("FK__movie_cas__mov_i__3D5E1FD2");
            });

            modelBuilder.Entity<MovieDirection>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("movie_direction");

                entity.Property(e => e.DirId).HasColumnName("dir_id");

                entity.Property(e => e.MovId).HasColumnName("mov_id");

                entity.HasOne(d => d.Dir)
                    .WithMany()
                    .HasForeignKey(d => d.DirId)
                    .HasConstraintName("FK__movie_dir__dir_i__2F10007B");

                entity.HasOne(d => d.Mov)
                    .WithMany()
                    .HasForeignKey(d => d.MovId)
                    .HasConstraintName("FK__movie_dir__mov_i__300424B4");
            });

            modelBuilder.Entity<MovieGenre>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("movie_genres");

                entity.Property(e => e.GenId).HasColumnName("gen_id");

                entity.Property(e => e.MovId).HasColumnName("mov_id");

                entity.HasOne(d => d.Gen)
                    .WithMany()
                    .HasForeignKey(d => d.GenId)
                    .HasConstraintName("FK__movie_gen__gen_i__2C3393D0");

                entity.HasOne(d => d.Mov)
                    .WithMany()
                    .HasForeignKey(d => d.MovId)
                    .HasConstraintName("FK__movie_gen__mov_i__2D27B809");
            });

            modelBuilder.Entity<Rating>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("rating");

                entity.Property(e => e.MovId).HasColumnName("mov_id");

                entity.Property(e => e.NumORatings).HasColumnName("num_o_ratings");

                entity.Property(e => e.RevId).HasColumnName("rev_id");

                entity.Property(e => e.RevStars).HasColumnName("rev_stars");

                entity.HasOne(d => d.Mov)
                    .WithMany()
                    .HasForeignKey(d => d.MovId)
                    .HasConstraintName("FK_rating_movie");

                entity.HasOne(d => d.Rev)
                    .WithMany()
                    .HasForeignKey(d => d.RevId)
                    .HasConstraintName("FK_rating_reviewer");
            });

            modelBuilder.Entity<Reviewer>(entity =>
            {
                entity.HasKey(e => e.RevId)
                    .HasName("PK_reviwer");

                entity.ToTable("reviewer");

                entity.Property(e => e.RevId)
                    .ValueGeneratedNever()
                    .HasColumnName("rev_id");

                entity.Property(e => e.RevName)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("rev_name");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
