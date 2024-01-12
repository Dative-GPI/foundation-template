using System;
using System.Linq;
using Foundation.Template.Context.DTOs;
using Foundation.Template.Fixtures.Abstractions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using XXXXX.Context.Kernel;

namespace XXXXX.Context.Migrations
{
    public class CustomApplicationContext : ApplicationContext
    {
        private ILogger<CustomApplicationContext> _logger;
        private IFixtureHelper _fixtureHelper;

        public CustomApplicationContext(
            ILogger<CustomApplicationContext> logger,
            DbContextOptions<CustomApplicationContext> options,
            IFixtureHelper fixtureHelper) : base(new DbContextOptions<ApplicationContext>(
                options.Extensions.ToDictionary(e => e.GetType()))
            )
        {
            _logger = logger;
            _fixtureHelper = fixtureHelper;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            _fixtureHelper.Feed<PermissionOrganisationDTO>(modelBuilder);
            _fixtureHelper.Feed<PermissionOrganisationCategoryDTO>(modelBuilder);
            _fixtureHelper.Feed<PermissionAdminDTO>(modelBuilder);
            _fixtureHelper.Feed<PermissionAdminCategoryDTO>(modelBuilder);
            _fixtureHelper.Feed<TranslationDTO>(modelBuilder);
        }
    }
}