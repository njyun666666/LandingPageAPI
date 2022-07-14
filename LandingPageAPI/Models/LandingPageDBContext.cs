using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace LandingPageAPI.Models
{
    public partial class LandingPageDBContext : DbContext
    {
        public LandingPageDBContext()
        {
        }

        public LandingPageDBContext(DbContextOptions<LandingPageDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<TbFooterSetting> TbFooterSettings { get; set; } = null!;
        public virtual DbSet<TbHeaderSetting> TbHeaderSettings { get; set; } = null!;
        public virtual DbSet<TbItem> TbItems { get; set; } = null!;
        public virtual DbSet<TbMenu> TbMenus { get; set; } = null!;
        public virtual DbSet<TbMenuType> TbMenuTypes { get; set; } = null!;
        public virtual DbSet<TbPage> TbPages { get; set; } = null!;
        public virtual DbSet<TbPageSection> TbPageSections { get; set; } = null!;
        public virtual DbSet<TbSectionSetting> TbSectionSettings { get; set; } = null!;
        public virtual DbSet<TbSectionType> TbSectionTypes { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseMySql("name=ConnectionStrings:LandingPageDBConnection", Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.29-mysql"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.UseCollation("utf8mb4_0900_ai_ci")
                .HasCharSet("utf8mb4");

            modelBuilder.Entity<TbFooterSetting>(entity =>
            {
                entity.HasKey(e => e.FooterId)
                    .HasName("PRIMARY");

                entity.ToTable("TbFooterSetting");

                entity.HasIndex(e => e.SectionTypeId, "fk_TbFooterSetting_SectionTypeID_idx");

                entity.Property(e => e.FooterId).HasColumnName("FooterID");

                entity.Property(e => e.Content).HasMaxLength(500);

                entity.Property(e => e.CopyRight).HasMaxLength(100);

                entity.Property(e => e.Item1).HasMaxLength(50);

                entity.Property(e => e.Logo).HasMaxLength(100);

                entity.Property(e => e.SectionTypeId)
                    .HasMaxLength(50)
                    .HasColumnName("SectionTypeID");

                entity.Property(e => e.Title).HasMaxLength(100);

                entity.HasOne(d => d.SectionType)
                    .WithMany(p => p.TbFooterSettings)
                    .HasForeignKey(d => d.SectionTypeId)
                    .HasConstraintName("fk_TbFooterSetting_SectionTypeID");
            });

            modelBuilder.Entity<TbHeaderSetting>(entity =>
            {
                entity.HasKey(e => e.HeaderId)
                    .HasName("PRIMARY");

                entity.ToTable("TbHeaderSetting");

                entity.HasIndex(e => e.MenuId, "fk_TbHeaderSetting_MenuID_idx");

                entity.Property(e => e.HeaderId).HasColumnName("HeaderID");

                entity.Property(e => e.Logo).HasMaxLength(100);

                entity.Property(e => e.MenuId).HasColumnName("MenuID");

                entity.HasOne(d => d.Menu)
                    .WithMany(p => p.TbHeaderSettings)
                    .HasForeignKey(d => d.MenuId)
                    .HasConstraintName("fk_TbHeaderSetting_MenuID");
            });

            modelBuilder.Entity<TbItem>(entity =>
            {
                entity.HasKey(e => e.ItemId)
                    .HasName("PRIMARY");

                entity.ToTable("TbItem");

                entity.HasIndex(e => e.ItemGroupId, "idx_TbSectionSetting_ItemGroupID");

                entity.Property(e => e.ItemId).HasColumnName("ItemID");

                entity.Property(e => e.Content).HasMaxLength(500);

                entity.Property(e => e.Enable).HasDefaultValueSql("'0'");

                entity.Property(e => e.Icon).HasMaxLength(50);

                entity.Property(e => e.ImageUrl)
                    .HasMaxLength(100)
                    .HasColumnName("ImageURL");

                entity.Property(e => e.ItemGroupId)
                    .HasMaxLength(50)
                    .HasColumnName("ItemGroupID");

                entity.Property(e => e.Sort).HasDefaultValueSql("'0'");

                entity.Property(e => e.SubTitle).HasMaxLength(100);

                entity.Property(e => e.Target).HasMaxLength(10);

                entity.Property(e => e.Title).HasMaxLength(100);

                entity.Property(e => e.Url)
                    .HasMaxLength(100)
                    .HasColumnName("URL");
            });

            modelBuilder.Entity<TbMenu>(entity =>
            {
                entity.HasKey(e => e.MenuId)
                    .HasName("PRIMARY");

                entity.ToTable("TbMenu");

                entity.HasIndex(e => e.MenuTypeId, "fk_TbMenu_MenuType_idx");

                entity.HasIndex(e => e.MenuParentId, "idx_TbMenu_MenuParentID");

                entity.Property(e => e.MenuId).HasColumnName("MenuID");

                entity.Property(e => e.Enable).HasDefaultValueSql("'0'");

                entity.Property(e => e.Icon).HasMaxLength(50);

                entity.Property(e => e.ImageUrl)
                    .HasMaxLength(100)
                    .HasColumnName("ImageURL");

                entity.Property(e => e.MenuParentId).HasColumnName("MenuParentID");

                entity.Property(e => e.MenuTypeId)
                    .HasMaxLength(50)
                    .HasColumnName("MenuTypeID");

                entity.Property(e => e.SubTitle).HasMaxLength(50);

                entity.Property(e => e.Target).HasMaxLength(10);

                entity.Property(e => e.Title).HasMaxLength(50);

                entity.Property(e => e.Url)
                    .HasMaxLength(100)
                    .HasColumnName("URL");

                entity.HasOne(d => d.MenuType)
                    .WithMany(p => p.TbMenus)
                    .HasForeignKey(d => d.MenuTypeId)
                    .HasConstraintName("fk_TbMenu_MenuType");
            });

            modelBuilder.Entity<TbMenuType>(entity =>
            {
                entity.HasKey(e => e.MenuTypeId)
                    .HasName("PRIMARY");

                entity.ToTable("TbMenuType");

                entity.Property(e => e.MenuTypeId)
                    .HasMaxLength(50)
                    .HasColumnName("MenuTypeID");
            });

            modelBuilder.Entity<TbPage>(entity =>
            {
                entity.HasKey(e => e.PageId)
                    .HasName("PRIMARY");

                entity.ToTable("TbPage");

                entity.Property(e => e.PageId).HasColumnName("PageID");

                entity.Property(e => e.Description)
                    .HasMaxLength(200)
                    .HasComment("網頁描述");

                entity.Property(e => e.Enable).HasDefaultValueSql("'0'");

                entity.Property(e => e.HeaderColorMode).HasMaxLength(10);

                entity.Property(e => e.IsIndex).HasComment("首頁");

                entity.Property(e => e.Path)
                    .HasMaxLength(50)
                    .HasComment("路徑");

                entity.Property(e => e.Title)
                    .HasMaxLength(50)
                    .HasComment("網頁標題");
            });

            modelBuilder.Entity<TbPageSection>(entity =>
            {
                entity.ToTable("TbPageSection");

                entity.HasIndex(e => e.PageId, "PageID");

                entity.HasIndex(e => e.SectionId, "SectionID");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.PageId).HasColumnName("PageID");

                entity.Property(e => e.SectionId).HasColumnName("SectionID");

                entity.Property(e => e.Sort).HasDefaultValueSql("'0'");

                entity.HasOne(d => d.Page)
                    .WithMany(p => p.TbPageSections)
                    .HasForeignKey(d => d.PageId)
                    .HasConstraintName("TbPageSection_ibfk_1");

                entity.HasOne(d => d.Section)
                    .WithMany(p => p.TbPageSections)
                    .HasForeignKey(d => d.SectionId)
                    .HasConstraintName("TbPageSection_ibfk_2");
            });

            modelBuilder.Entity<TbSectionSetting>(entity =>
            {
                entity.HasKey(e => e.SectionId)
                    .HasName("PRIMARY");

                entity.ToTable("TbSectionSetting");

                entity.Property(e => e.SectionId).HasColumnName("SectionID");

                entity.Property(e => e.BackgroundColor).HasMaxLength(10);

                entity.Property(e => e.BackgroundImage).HasMaxLength(100);

                entity.Property(e => e.Container).HasMaxLength(10);

                entity.Property(e => e.Content).HasMaxLength(500);

                entity.Property(e => e.Item1).HasMaxLength(50);

                entity.Property(e => e.SectionTypeId)
                    .HasMaxLength(50)
                    .HasColumnName("SectionTypeID");

                entity.Property(e => e.SubTitle).HasMaxLength(100);

                entity.Property(e => e.Title).HasMaxLength(100);
            });

            modelBuilder.Entity<TbSectionType>(entity =>
            {
                entity.HasKey(e => e.SectionTypeId)
                    .HasName("PRIMARY");

                entity.ToTable("TbSectionType");

                entity.Property(e => e.SectionTypeId)
                    .HasMaxLength(50)
                    .HasColumnName("SectionTypeID");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
