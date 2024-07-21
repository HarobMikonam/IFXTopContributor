using System;
using System.Collections.Generic;
using IFXTopContributor.Models;
using Microsoft.EntityFrameworkCore;

namespace IFXTopContributor.Data;

public partial class DefaultdbContext : DbContext
{
    public DefaultdbContext()
    {
    }

    public DefaultdbContext(DbContextOptions<DefaultdbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Comment> Comments { get; set; }

    public virtual DbSet<Log> Logs { get; set; }

    //public virtual DbSet<Logincode> Logincodes { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<Vote> Votes { get; set; }

    public virtual DbSet<Winner> Winners { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Comment>(entity =>
        {
            entity.HasKey(e => e.Commentid).HasName("comments_pkey");

            entity.ToTable("comments");

            entity.Property(e => e.Commentid).HasColumnName("commentid");
            entity.Property(e => e.Commenttext).HasColumnName("commenttext");
            entity.Property(e => e.Createdat)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("createdat");
            entity.Property(e => e.Encryptedcomment).HasColumnName("encryptedcomment");
            entity.Property(e => e.Updatedat)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("updatedat");
            entity.Property(e => e.Userid).HasColumnName("userid");
            entity.Property(e => e.Votedforid).HasColumnName("votedforid");
        });

        modelBuilder.Entity<Log>(entity =>
        {
            entity.HasKey(e => e.Logid).HasName("logs_pkey");

            entity.ToTable("logs");

            entity.Property(e => e.Logid).HasColumnName("logid");
            entity.Property(e => e.Actiontype)
                .HasMaxLength(100)
                .HasColumnName("actiontype");
            entity.Property(e => e.Createdat)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("createdat");
            entity.Property(e => e.Targetid).HasColumnName("targetid");
            entity.Property(e => e.Userid).HasColumnName("userid");
        });

        modelBuilder.Entity<Logincode>(entity =>
        {
            entity.HasKey(e => e.Codeid).HasName("logincodes_pkey");

            entity.ToTable("logincodes");

            entity.Property(e => e.Codeid).HasColumnName("codeid");
            entity.Property(e => e.Createdat)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("createdat");
            entity.Property(e => e.Encryptedpasswordhash).HasColumnName("encryptedpasswordhash");
            entity.Property(e => e.Used)
                .HasDefaultValue(false)
                .HasColumnName("used");
            entity.Property(e => e.Userid).HasColumnName("userid");
            entity.Property(e => e.Username)
                .HasMaxLength(100)
                .HasColumnName("username");

            //entity.HasOne(d => d.User).WithMany(p => p.Logincodes)
            //    .HasForeignKey(d => d.Userid)
            //    .OnDelete(DeleteBehavior.ClientSetNull)
            //    .HasConstraintName("fk_loginuser");
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.Roleid).HasName("roles_pkey");

            entity.ToTable("roles");

            entity.HasIndex(e => e.Rolename, "roles_rolename_key").IsUnique();

            entity.Property(e => e.Roleid).HasColumnName("roleid");
            entity.Property(e => e.Rolename)
                .HasMaxLength(50)
                .HasColumnName("rolename");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Userid).HasName("users_pkey");

            entity.ToTable("users");

            entity.HasIndex(e => e.Email, "users_email_key").IsUnique();

            entity.Property(e => e.Userid).HasColumnName("userid");
            entity.Property(e => e.Createdat)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("createdat");
            entity.Property(e => e.Email)
                .HasMaxLength(255)
                .HasColumnName("email");
            entity.Property(e => e.Firstname)
                .HasMaxLength(100)
                .HasColumnName("firstname");
            entity.Property(e => e.Lastname)
                .HasMaxLength(100)
                .HasColumnName("lastname");
            entity.Property(e => e.Logincodeid).HasColumnName("logincodeid");
            entity.Property(e => e.Microsoftaccount)
                .HasDefaultValue(false)
                .HasColumnName("microsoftaccount");
            entity.Property(e => e.Roleid).HasColumnName("roleid");
            entity.Property(e => e.Updatedat)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("updatedat");

            //entity.HasOne(d => d.Logincode).WithMany(p => p.Users)
            //    .HasForeignKey(d => d.Logincodeid)
            //    .HasConstraintName("fk_logincode");
        });

        modelBuilder.Entity<Vote>(entity =>
        {
            entity.HasKey(e => e.Voteid).HasName("votes_pkey");

            entity.ToTable("votes");

            entity.HasIndex(e => new { e.Voterid, e.Votedforid, e.Month, e.Year }, "uc_vote").IsUnique();

            entity.Property(e => e.Voteid).HasColumnName("voteid");
            entity.Property(e => e.Createdat)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("createdat");
            entity.Property(e => e.Encryptedcomment).HasColumnName("encryptedcomment");
            entity.Property(e => e.Month).HasColumnName("month");
            entity.Property(e => e.Updatedat)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("updatedat");
            entity.Property(e => e.Votedforid).HasColumnName("votedforid");
            entity.Property(e => e.Voterid).HasColumnName("voterid");
            entity.Property(e => e.Year).HasColumnName("year");
        });

        modelBuilder.Entity<Winner>(entity =>
        {
            entity.HasKey(e => e.Winnerid).HasName("winners_pkey");

            entity.ToTable("winners");

            entity.HasIndex(e => new { e.Userid, e.Month, e.Year }, "uc_winner").IsUnique();

            entity.Property(e => e.Winnerid).HasColumnName("winnerid");
            entity.Property(e => e.Createdat)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("createdat");
            entity.Property(e => e.Month).HasColumnName("month");
            entity.Property(e => e.Userid).HasColumnName("userid");
            entity.Property(e => e.Year).HasColumnName("year");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
