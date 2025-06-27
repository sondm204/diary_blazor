using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace diary_blazor_web.Models;

public partial class DiaryContext : DbContext
{
    public DiaryContext()
    {
    }

    public DiaryContext(DbContextOptions<DiaryContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Comment> Comments { get; set; }

    public virtual DbSet<Diary> Diaries { get; set; }

    public virtual DbSet<Like> Likes { get; set; }

    public virtual DbSet<Tag> Tags { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        var config = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
        optionsBuilder.UseSqlServer(config.GetConnectionString("DefaultConnection"));
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Comment>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__comments__3213E83F93CCFBD9");

            entity.ToTable("comments");

            entity.Property(e => e.Id)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("id");
            entity.Property(e => e.Content)
                .HasColumnType("text")
                .HasColumnName("content");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.DiaryId)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("diary_id");
            entity.Property(e => e.UserId)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("user_id");

            entity.HasOne(d => d.Diary).WithMany(p => p.Comments)
                .HasForeignKey(d => d.DiaryId)
                .HasConstraintName("FK__comments__diary___66603565");

            entity.HasOne(d => d.User).WithMany(p => p.Comments)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK__comments__user_i__656C112C");
        });

        modelBuilder.Entity<Diary>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__diary_en__3213E83F1ED16D0F");

            entity.ToTable("diaries");

            entity.Property(e => e.Id)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("id");
            entity.Property(e => e.AllowComments)
                .HasDefaultValue((byte)1)
                .HasColumnName("allow_comments");
            entity.Property(e => e.Content)
                .HasColumnType("text")
                .HasColumnName("content");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.IsActive)
                .HasDefaultValue((byte)1)
                .HasColumnName("is_active");
            entity.Property(e => e.IsPublic)
                .HasDefaultValue((byte)0)
                .HasColumnName("is_public");
            entity.Property(e => e.PublicedAt)
                .HasColumnType("datetime")
                .HasColumnName("publiced_at");
            entity.Property(e => e.Title)
                .HasMaxLength(255)
                .HasColumnName("title");
            entity.Property(e => e.UpdatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("updated_at");
            entity.Property(e => e.UserId)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("user_id");

            entity.HasOne(d => d.User).WithMany(p => p.Diaries)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK__diary_ent__user___619B8048");

            entity.HasMany(d => d.Tags).WithMany(p => p.Diaries)
                .UsingEntity<Dictionary<string, object>>(
                    "DiaryTag",
                    r => r.HasOne<Tag>().WithMany()
                        .HasForeignKey("TagId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__diary_tag__tag_i__7D439ABD"),
                    l => l.HasOne<Diary>().WithMany()
                        .HasForeignKey("DiaryId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__diary_tag__diary__7E37BEF6"),
                    j =>
                    {
                        j.HasKey("DiaryId", "TagId").HasName("PK__diary_ta__47BB58E31CDEBF93");
                        j.ToTable("diary_tags");
                        j.IndexerProperty<string>("DiaryId")
                            .HasMaxLength(20)
                            .IsUnicode(false)
                            .HasColumnName("diary_id");
                        j.IndexerProperty<string>("TagId")
                            .HasMaxLength(20)
                            .IsUnicode(false)
                            .HasColumnName("tag_id");
                    });
        });

        modelBuilder.Entity<Like>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__likes__3213E83FBCC369F9");

            entity.ToTable("likes");

            entity.Property(e => e.Id)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.DiaryId)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("diary_id");
            entity.Property(e => e.UserId)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("user_id");

            entity.HasOne(d => d.Diary).WithMany(p => p.Likes)
                .HasForeignKey(d => d.DiaryId)
                .HasConstraintName("FK__likes__diary_id__6B24EA82");

            entity.HasOne(d => d.User).WithMany(p => p.Likes)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK__likes__user_id__6A30C649");
        });

        modelBuilder.Entity<Tag>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__tags__3213E83FE9C780FF");

            entity.ToTable("tags");

            entity.Property(e => e.Id)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("id");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .HasColumnName("name");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__users__3213E83F25FE2B56");

            entity.ToTable("users");

            entity.HasIndex(e => e.Username, "UQ__users__F3DBC5726FEB3C28").IsUnique();

            entity.Property(e => e.Id)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("id");
            entity.Property(e => e.CreateAt)
                .HasColumnType("datetime")
                .HasColumnName("create_at");
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("email");
            entity.Property(e => e.Password)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("password");
            entity.Property(e => e.Username)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("username");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
