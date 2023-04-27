using System;
using System.Collections.Generic;
using Gaz.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Gaz.Data
{
    public partial class freedb_testdbgazContext : DbContext
    {
        public freedb_testdbgazContext()
        {
        }

        public freedb_testdbgazContext(DbContextOptions<freedb_testdbgazContext> options)
            : base(options)
        {
        }

        public virtual DbSet<EditTime> EditTimes { get; set; } = null!;
        public virtual DbSet<Estimation> Estimations { get; set; } = null!;
        public virtual DbSet<EstimationsMark> EstimationsMarks { get; set; } = null!;
        public virtual DbSet<Explanation> Explanations { get; set; } = null!;
        public virtual DbSet<Indicator> Indicators { get; set; } = null!;
        public virtual DbSet<Law> Laws { get; set; } = null!;
        public virtual DbSet<Mark> Marks { get; set; } = null!;
        public virtual DbSet<Onetype> Onetypes { get; set; } = null!;
        public virtual DbSet<Poll> Polls { get; set; } = null!;
        public virtual DbSet<Role> Roles { get; set; } = null!;
        public virtual DbSet<RolesLaw> RolesLaws { get; set; } = null!;
        public virtual DbSet<Score> Scores { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;
        public virtual DbSet<UsersRole> UsersRoles { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseMySql("server=pravo9k9.beget.tech;database=pravo9k9_yana_pe;user=pravo9k9_yana_pe;password=rq-A26ZIP", ServerVersion.Parse("8.0.28-mysql"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.UseCollation("utf8mb4_0900_ai_ci")
                .HasCharSet("utf8mb4");

            modelBuilder.Entity<EditTime>(entity =>
            {
                entity.ToTable("edit_times");

                entity.UseCollation("utf8mb4_general_ci");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("created_at");

                entity.Property(e => e.Date).HasColumnName("date");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("updated_at");
            });

            modelBuilder.Entity<Estimation>(entity =>
            {
                entity.ToTable("estimations");

                entity.UseCollation("utf8mb4_general_ci");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("created_at");

                entity.Property(e => e.EstimationName)
                    .HasMaxLength(255)
                    .HasColumnName("estimation_name");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("updated_at");
            });

            modelBuilder.Entity<EstimationsMark>(entity =>
            {
                entity.ToTable("estimations_marks");

                entity.UseCollation("utf8mb4_general_ci");

                entity.HasIndex(e => e.MarkId, "estimations_marks_FK");

                entity.HasIndex(e => e.EstimationId, "estimations_marks_FK_1");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("created_at");

                entity.Property(e => e.EstimationId).HasColumnName("estimation_id");

                entity.Property(e => e.MarkId).HasColumnName("mark_id");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("updated_at");

                entity.HasOne(d => d.Estimation)
                    .WithMany(p => p.EstimationsMarks)
                    .HasForeignKey(d => d.EstimationId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("estimations_marks_FK_1");

                entity.HasOne(d => d.Mark)
                    .WithMany(p => p.EstimationsMarks)
                    .HasForeignKey(d => d.MarkId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("estimations_marks_FK");
            });

            modelBuilder.Entity<Explanation>(entity =>
            {
                entity.ToTable("explanations");

                entity.HasIndex(e => e.UserId, "explanations_FK_idx");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("created_at");

                entity.Property(e => e.Explanation1)
                    .HasMaxLength(5000)
                    .HasColumnName("explanation");

                entity.Property(e => e.Month).HasColumnName("month");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("updated_at");

                entity.Property(e => e.UserId).HasColumnName("user_id");

                entity.Property(e => e.Year).HasColumnName("year");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Explanations)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("explanations_FK");
            });

            modelBuilder.Entity<Indicator>(entity =>
            {
                entity.ToTable("indicators");

                entity.UseCollation("utf8mb4_general_ci");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("created_at");

                entity.Property(e => e.IndicatorName)
                    .HasMaxLength(255)
                    .HasColumnName("indicator_name");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("updated_at");
            });

            modelBuilder.Entity<Law>(entity =>
            {
                entity.ToTable("laws");

                entity.UseCollation("utf8mb4_general_ci");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("created_at");

                entity.Property(e => e.LawName)
                    .HasMaxLength(255)
                    .HasColumnName("law_name");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("updated_at");
            });

            modelBuilder.Entity<Mark>(entity =>
            {
                entity.ToTable("marks");

                entity.UseCollation("utf8mb4_general_ci");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.BigMark).HasColumnName("big_mark");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("created_at");

                entity.Property(e => e.LowMark).HasColumnName("low_mark");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("updated_at");

                entity.Property(e => e.YesNo)
                    .HasMaxLength(50)
                    .HasColumnName("yes_no")
                    .UseCollation("utf8_general_ci")
                    .HasCharSet("utf8");
            });

            modelBuilder.Entity<Onetype>(entity =>
            {
                entity.ToTable("onetype");

                entity.UseCollation("utf8mb4_general_ci");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("created_at");

                entity.Property(e => e.TypeName)
                    .HasMaxLength(255)
                    .HasColumnName("type_name");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("updated_at");
            });

            modelBuilder.Entity<Poll>(entity =>
            {
                entity.ToTable("poll");

                entity.UseCollation("utf8mb4_general_ci");

                entity.HasIndex(e => e.UserId, "poll_FK");

                entity.HasIndex(e => e.EstimationsMarksId, "poll_FK_1");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("created_at");

                entity.Property(e => e.EstimationsMarksId).HasColumnName("estimations_marks_id");

                entity.Property(e => e.Month).HasColumnName("month");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("updated_at");

                entity.Property(e => e.UserId).HasColumnName("user_id");

                entity.Property(e => e.Year).HasColumnName("year");

                entity.HasOne(d => d.EstimationsMarks)
                    .WithMany(p => p.Polls)
                    .HasForeignKey(d => d.EstimationsMarksId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("poll_FK_1");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Polls)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("poll_FK");
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.ToTable("roles");

                entity.UseCollation("utf8mb4_general_ci");

                entity.HasIndex(e => e.IndicatorId, "indicator_id");

                entity.HasIndex(e => e.TimeId, "roles_FK");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("created_at");

                entity.Property(e => e.IndicatorId).HasColumnName("indicator_id");

                entity.Property(e => e.RoleName)
                    .HasMaxLength(255)
                    .HasColumnName("role_name");

                entity.Property(e => e.TimeId).HasColumnName("time_id");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("updated_at");

                entity.HasOne(d => d.Indicator)
                    .WithMany(p => p.Roles)
                    .HasForeignKey(d => d.IndicatorId)
                    .HasConstraintName("roles_FK_1");

                entity.HasOne(d => d.Time)
                    .WithMany(p => p.Roles)
                    .HasForeignKey(d => d.TimeId)
                    .HasConstraintName("roles_FK");
            });

            modelBuilder.Entity<RolesLaw>(entity =>
            {
                entity.ToTable("roles_laws");

                entity.UseCollation("utf8mb4_general_ci");

                entity.HasIndex(e => e.LawId, "roles_laws_FK");

                entity.HasIndex(e => e.RoleId, "roles_laws_FK_1");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("created_at");

                entity.Property(e => e.LawId).HasColumnName("law_id");

                entity.Property(e => e.RoleId).HasColumnName("role_id");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("updated_at");

                entity.HasOne(d => d.Law)
                    .WithMany(p => p.RolesLaws)
                    .HasForeignKey(d => d.LawId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("roles_laws_FK");

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.RolesLaws)
                    .HasForeignKey(d => d.RoleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("roles_laws_FK_1");
            });

            modelBuilder.Entity<Score>(entity =>
            {
                entity.ToTable("scores");

                entity.UseCollation("utf8mb4_general_ci");

                entity.HasIndex(e => e.UserId, "scores_FK");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("created_at");

                entity.Property(e => e.FinalScore).HasColumnName("final_score");

                entity.Property(e => e.MonthScore).HasColumnName("month_score");

                entity.Property(e => e.Month).HasColumnName("month");

                entity.Property(e => e.Year).HasColumnName("year");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("updated_at");

                entity.Property(e => e.UserId).HasColumnName("user_id");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Scores)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("scores_FK");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("users");

                entity.UseCollation("utf8mb4_general_ci");

                entity.HasIndex(e => e.TypeId, "users_FK");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("created_at");

                entity.Property(e => e.Division)
                    .HasMaxLength(255)
                    .HasColumnName("division")
                    .UseCollation("utf8_general_ci")
                    .HasCharSet("utf8");

                entity.Property(e => e.Email)
                    .HasMaxLength(255)
                    .HasColumnName("email")
                    .UseCollation("utf8_general_ci")
                    .HasCharSet("utf8");

                entity.Property(e => e.Fio)
                    .HasMaxLength(255)
                    .HasColumnName("fio")
                    .UseCollation("utf8_general_ci")
                    .HasCharSet("utf8");

                entity.Property(e => e.Password)
                    .HasMaxLength(100)
                    .HasColumnName("password");

                entity.Property(e => e.Position)
                    .HasMaxLength(255)
                    .HasColumnName("position")
                    .UseCollation("utf8_general_ci")
                    .HasCharSet("utf8");

                entity.Property(e => e.ServiceNumber)
                    .HasMaxLength(255)
                    .HasColumnName("service_number")
                    .UseCollation("utf8_general_ci")
                    .HasCharSet("utf8");

                entity.Property(e => e.TypeId).HasColumnName("type_id");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("updated_at");

                entity.HasOne(d => d.Type)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.TypeId)
                    .HasConstraintName("users_FK");
            });

            modelBuilder.Entity<UsersRole>(entity =>
            {
                entity.ToTable("users_roles");

                entity.UseCollation("utf8mb4_general_ci");

                entity.HasIndex(e => e.RoleId, "users_roles_FK");

                entity.HasIndex(e => e.UserId, "users_roles_FK_1");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("created_at");

                entity.Property(e => e.RoleId).HasColumnName("role_id");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("updated_at");

                entity.Property(e => e.UserId).HasColumnName("user_id");

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.UsersRoles)
                    .HasForeignKey(d => d.RoleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("users_roles_FK");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.UsersRoles)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("users_roles_FK_1");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
