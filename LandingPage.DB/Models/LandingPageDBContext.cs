using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace LandingPageDB.Models
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
        public virtual DbSet<TbItemGroup> TbItemGroups { get; set; } = null!;
        public virtual DbSet<TbMenu> TbMenus { get; set; } = null!;
        public virtual DbSet<TbMenuType> TbMenuTypes { get; set; } = null!;
        public virtual DbSet<TbOrgRole> TbOrgRoles { get; set; } = null!;
        public virtual DbSet<TbOrgUser> TbOrgUsers { get; set; } = null!;
        public virtual DbSet<TbPage> TbPages { get; set; } = null!;
        public virtual DbSet<TbPageSection> TbPageSections { get; set; } = null!;
        public virtual DbSet<TbRefreshToken> TbRefreshTokens { get; set; } = null!;
        public virtual DbSet<TbSectionSetting> TbSectionSettings { get; set; } = null!;
        public virtual DbSet<TbSectionType> TbSectionTypes { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.UseCollation("utf8mb4_0900_ai_ci")
                .HasCharSet("utf8mb4");

            modelBuilder.Entity<TbFooterSetting>(entity =>
            {
                entity.HasKey(e => e.FooterId)
                    .HasName("PRIMARY");

                entity.ToTable("TbFooterSetting");

                entity.HasIndex(e => e.SectionId, "fk_TbFooterSetting_SectionTypeID_idx");

                entity.Property(e => e.FooterId).HasColumnName("FooterID");

                entity.Property(e => e.SectionId).HasColumnName("SectionID");

                entity.HasOne(d => d.Section)
                    .WithMany(p => p.TbFooterSettings)
                    .HasForeignKey(d => d.SectionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_TbFooterSetting_SectionID");
            });

            modelBuilder.Entity<TbHeaderSetting>(entity =>
            {
                entity.HasKey(e => e.HeaderId)
                    .HasName("PRIMARY");

                entity.ToTable("TbHeaderSetting");

                entity.Property(e => e.HeaderId).HasColumnName("HeaderID");

                entity.Property(e => e.LogoDark).HasMaxLength(100);

                entity.Property(e => e.LogoLight).HasMaxLength(100);

                entity.Property(e => e.MenuGroupId).HasColumnName("MenuGroupID");
            });

            modelBuilder.Entity<TbItem>(entity =>
            {
                entity.HasKey(e => e.ItemId)
                    .HasName("PRIMARY");

                entity.ToTable("TbItem");

                entity.HasIndex(e => e.ItemGroupId, "idx_TbSectionSetting_ItemGroupID");

                entity.Property(e => e.ItemId).HasColumnName("ItemID");

                entity.Property(e => e.Content).HasMaxLength(500);

                entity.Property(e => e.Icon).HasMaxLength(50);

                entity.Property(e => e.ImageUrl)
                    .HasMaxLength(100)
                    .HasColumnName("ImageURL");

                entity.Property(e => e.ItemGroupId).HasColumnName("ItemGroupID");

                entity.Property(e => e.SubTitle).HasMaxLength(200);

                entity.Property(e => e.Target).HasMaxLength(10);

                entity.Property(e => e.Title).HasMaxLength(100);

                entity.Property(e => e.Url)
                    .HasMaxLength(100)
                    .HasColumnName("URL");

                entity.HasOne(d => d.ItemGroup)
                    .WithMany(p => p.TbItems)
                    .HasForeignKey(d => d.ItemGroupId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_TbItem_ItemGroupID");
            });

            modelBuilder.Entity<TbItemGroup>(entity =>
            {
                entity.HasKey(e => e.ItemGroupId)
                    .HasName("PRIMARY");

                entity.ToTable("TbItemGroup");

                entity.Property(e => e.ItemGroupId).HasColumnName("ItemGroupID");

                entity.Property(e => e.Description).HasMaxLength(200);
            });

            modelBuilder.Entity<TbMenu>(entity =>
            {
                entity.HasKey(e => e.MenuId)
                    .HasName("PRIMARY");

                entity.ToTable("TbMenu");

                entity.HasIndex(e => e.MenuTypeId, "fk_TbMenu_MenuType_idx");

                entity.HasIndex(e => new { e.MenuGroupId, e.Enable }, "idx_TbMenu_MenuGroupID_Enable");

                entity.Property(e => e.MenuId).HasColumnName("MenuID");

                entity.Property(e => e.Icon).HasMaxLength(50);

                entity.Property(e => e.ImageUrl)
                    .HasMaxLength(100)
                    .HasColumnName("ImageURL");

                entity.Property(e => e.MenuGroupId).HasColumnName("MenuGroupID");

                entity.Property(e => e.MenuParentId).HasColumnName("MenuParentID");

                entity.Property(e => e.MenuTypeId)
                    .HasMaxLength(50)
                    .HasColumnName("MenuTypeID");

                entity.Property(e => e.Sort).HasDefaultValueSql("'1'");

                entity.Property(e => e.SubTitle)
                    .HasMaxLength(200)
                    .UseCollation("utf8mb3_general_ci")
                    .HasCharSet("utf8mb3");

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

                entity.Property(e => e.Description).HasMaxLength(200);
            });

            modelBuilder.Entity<TbOrgRole>(entity =>
            {
                entity.HasKey(e => e.Rid)
                    .HasName("PRIMARY");

                entity.ToTable("TbOrgRole");

                entity.Property(e => e.Rid)
                    .HasMaxLength(50)
                    .HasColumnName("RID");

                entity.Property(e => e.RoleName).HasMaxLength(50);
            });

            modelBuilder.Entity<TbOrgUser>(entity =>
            {
                entity.HasKey(e => e.Uid)
                    .HasName("PRIMARY");

                entity.ToTable("TbOrgUser");

                entity.Property(e => e.Uid)
                    .HasMaxLength(50)
                    .HasColumnName("UID");

                entity.Property(e => e.CreateDate).HasColumnType("datetime");

                entity.Property(e => e.CreateUid)
                    .HasMaxLength(50)
                    .HasColumnName("CreateUID");

                entity.Property(e => e.Email)
                    .HasMaxLength(50)
                    .HasColumnName("EMail");

                entity.Property(e => e.Name).HasMaxLength(50);

                entity.Property(e => e.Passwrod).HasMaxLength(255);

                entity.Property(e => e.UpdateDate).HasColumnType("datetime");

                entity.Property(e => e.UpdateUid)
                    .HasMaxLength(50)
                    .HasColumnName("UpdateUID");

                entity.HasMany(d => d.Rids)
                    .WithMany(p => p.Uids)
                    .UsingEntity<Dictionary<string, object>>(
                        "TbOrgRoleUser",
                        l => l.HasOne<TbOrgRole>().WithMany().HasForeignKey("Rid").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("TbOrgRoleUsers_ibfk_2"),
                        r => r.HasOne<TbOrgUser>().WithMany().HasForeignKey("Uid").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("TbOrgRoleUsers_ibfk_1"),
                        j =>
                        {
                            j.HasKey("Uid", "Rid").HasName("PRIMARY").HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0 });

                            j.ToTable("TbOrgRoleUsers");

                            j.HasIndex(new[] { "Rid" }, "RID");

                            j.IndexerProperty<string>("Uid").HasMaxLength(50).HasColumnName("UID");

                            j.IndexerProperty<string>("Rid").HasMaxLength(50).HasColumnName("RID");
                        });
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

                entity.Property(e => e.HeaderColorMode).HasMaxLength(50);

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

                entity.HasIndex(e => e.PageId, "TbPageSection_ibfk_1");

                entity.HasIndex(e => e.SectionId, "TbPageSection_ibfk_2");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.PageId).HasColumnName("PageID");

                entity.Property(e => e.SectionId).HasColumnName("SectionID");

                entity.HasOne(d => d.Page)
                    .WithMany(p => p.TbPageSections)
                    .HasForeignKey(d => d.PageId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("TbPageSection_ibfk_1");

                entity.HasOne(d => d.Section)
                    .WithMany(p => p.TbPageSections)
                    .HasForeignKey(d => d.SectionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("TbPageSection_ibfk_2");
            });

            modelBuilder.Entity<TbRefreshToken>(entity =>
            {
                entity.HasKey(e => e.RefreshToken)
                    .HasName("PRIMARY");

                entity.ToTable("TbRefreshToken");

                entity.Property(e => e.ExpireTime).HasColumnType("datetime");

                entity.Property(e => e.Uid)
                    .HasMaxLength(255)
                    .HasColumnName("UID");
            });

            modelBuilder.Entity<TbSectionSetting>(entity =>
            {
                entity.HasKey(e => e.SectionId)
                    .HasName("PRIMARY");

                entity.ToTable("TbSectionSetting");

                entity.HasIndex(e => e.Item2, "TbSectionSetting_Item2_idx");

                entity.HasIndex(e => new { e.Item1, e.Item2 }, "fk_TbSectionSetting_Item1_idx");

                entity.Property(e => e.SectionId).HasColumnName("SectionID");

                entity.Property(e => e.BackgroundColor).HasMaxLength(10);

                entity.Property(e => e.BackgroundImage).HasMaxLength(100);

                entity.Property(e => e.Content).HasMaxLength(500);

                entity.Property(e => e.ParticleIcon).HasMaxLength(50);

                entity.Property(e => e.SectionTypeId)
                    .HasMaxLength(50)
                    .HasColumnName("SectionTypeID");

                entity.Property(e => e.SubTitle).HasMaxLength(200);

                entity.Property(e => e.Title).HasMaxLength(100);

                entity.HasOne(d => d.Item1Navigation)
                    .WithMany(p => p.TbSectionSettingItem1Navigations)
                    .HasForeignKey(d => d.Item1)
                    .HasConstraintName("fk_TbSectionSetting_Item1");

                entity.HasOne(d => d.Item2Navigation)
                    .WithMany(p => p.TbSectionSettingItem2Navigations)
                    .HasForeignKey(d => d.Item2)
                    .HasConstraintName("fk_TbSectionSetting_Item2");
            });

            modelBuilder.Entity<TbSectionType>(entity =>
            {
                entity.HasKey(e => e.SectionTypeId)
                    .HasName("PRIMARY");

                entity.ToTable("TbSectionType");

                entity.Property(e => e.SectionTypeId)
                    .HasMaxLength(50)
                    .HasColumnName("SectionTypeID");

                entity.Property(e => e.Description).HasMaxLength(20);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
