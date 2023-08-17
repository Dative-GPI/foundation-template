using Microsoft.EntityFrameworkCore;

using Foundation.Template.Context.DTOs;

namespace Foundation.Template.Context
{
    public class BaseApplicationContext : DbContext
    {

        #region Common
        public DbSet<ImageDTO> Images { get; set; }
        public DbSet<FileDTO> Files { get; set; }
        public DbSet<ApplicationDTO> Applications { get; set; }
        #endregion

        #region Permissions
        public DbSet<PermissionOrganisationDTO> Permissions { get; set; }
        public DbSet<PermissionAdminDTO> PermissionAdmins { get; set; }
        public DbSet<PermissionOrganisationCategoryDTO> PermissionCategories { get; set; }
        public DbSet<PermissionAdminCategoryDTO> PermissionAdminCategories { get; set; }
        public DbSet<OrganisationTypePermissionDTO> OrganisationTypePermissions { get; set; }
        public DbSet<RoleOrganisationPermissionDTO> RoleOrganisationPermissions { get; set; }
        public DbSet<RoleAdminPermissionDTO> RoleAdminPermissions { get; set; }
        #endregion


        #region Translations
        public DbSet<TranslationDTO> Translations { get; set; }
        public DbSet<ApplicationTranslationDTO> ApplicationTranslations { get; set; }
        #endregion


        public BaseApplicationContext(DbContextOptions options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            #region Common
            modelBuilder.Entity<ImageDTO>(m =>
            {
                m.HasKey(i => i.Id);
            });

            modelBuilder.Entity<FileDTO>(m =>
            {
                m.HasKey(i => i.Id);
                m.HasOne(i => i.Application)
                    .WithMany()
                    .HasForeignKey(i => i.ApplicationId);
            });

            modelBuilder.Entity<ApplicationDTO>(m =>
            {
                m.HasKey(a => a.Id);
            });
            #endregion

            #region Permissions
            modelBuilder.Entity<PermissionOrganisationDTO>(m =>
            {
                m.HasKey(p => p.Id);
                m.Property(p => p.Translations)
                    .HasColumnType("jsonb");
            });

            modelBuilder.Entity<PermissionAdminDTO>(m =>
            {
                m.HasKey(p => p.Id);
                m.Property(p => p.Translations)
                    .HasColumnType("jsonb");
            });

            modelBuilder.Entity<PermissionOrganisationCategoryDTO>(m =>
            {
                m.HasKey(p => p.Id);
                m.Property(p => p.Translations)
                    .HasColumnType("jsonb");
            });

            modelBuilder.Entity<PermissionAdminCategoryDTO>(m =>
            {
                m.HasKey(p => p.Id);
                m.Property(p => p.Translations)
                    .HasColumnType("jsonb");
            });

            modelBuilder.Entity<OrganisationTypePermissionDTO>(m =>
            {
                m.HasKey(otp => otp.Id);
                m.HasOne(otp => otp.Permission)
                    .WithMany(p => p.OrganisationTypePermissions)
                    .HasForeignKey(otp => otp.PermissionId);
            });

            modelBuilder.Entity<RoleOrganisationPermissionDTO>(m =>
            {
                m.HasKey(rp => rp.Id);
                m.HasOne(rp => rp.PermissionOrganisation)
                    .WithMany(p => p.RoleOrganisationPermissions)
                    .HasForeignKey(rp => rp.PermissionOrganisationId);
            });

            modelBuilder.Entity<RoleAdminPermissionDTO>(m =>
            {
                m.HasKey(rp => rp.Id);
                m.HasOne(rp => rp.PermissionAdmin)
                    .WithMany(p => p.RoleAdminPermissions)
                    .HasForeignKey(rp => rp.PermissionAdminId);
            });
            #endregion

            #region Translations
            modelBuilder.Entity<TranslationDTO>(m =>
            {
                m.HasKey(t => t.Id);
                m.HasIndex(t => t.Code).IsUnique();
            });

            modelBuilder.Entity<ApplicationTranslationDTO>(m =>
            {
                m.HasKey(t => t.Id);
                m.HasOne(t => t.Translation)
                    .WithMany()
                    .HasForeignKey(t => t.TranslationId);
                m.HasOne(t => t.Application)
                    .WithMany()
                    .HasForeignKey(t => t.ApplicationId);
            });
            #endregion
        }
    }
}