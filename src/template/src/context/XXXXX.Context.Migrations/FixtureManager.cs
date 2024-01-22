using System;

using Foundation.Template.Context.DTOs;
using Foundation.Template.Fixtures;
using Foundation.Template.Fixtures.Abstractions;

using Microsoft.Extensions.Logging;

namespace XXXXX.Context.Migrations
{
    public class FixtureManager : BaseFixtureManager
    {
        public FixtureManager(ILogger<FixtureManager> logger, IFixtureHelper helper) : base(logger, helper)
        {
            Add<TranslationDTO, Fixture>(
                TranslationProvider.GetAllTranslations,
                fixture => new TranslationDTO()
                {
                    Id = Guid.NewGuid(),
                    Code = fixture.Code,
                    ValueDefault = fixture.Value
                },
                (fixture, dto) =>
                {
                    dto.ValueDefault = fixture.Value;
                    return dto;
                });

            Add<PermissionOrganisationDTO, Fixture>(
                PermissionHelper.GetPermissions(typeof(XXXXX.Core.Kernel.Authorizations)),
                fixture => new PermissionOrganisationDTO()
                {
                    Id = Guid.NewGuid(),
                    Code = fixture.Code,
                    LabelDefault = fixture.Value
                },
                (fixture, dto) =>
                {
                    dto.LabelDefault = fixture.Value;
                    return dto;
                });

            Add<PermissionOrganisationCategoryDTO, Fixture>(
                PermissionHelper.GetCategories(typeof(XXXXX.Core.Kernel.Authorizations)),
                fixture => new PermissionOrganisationCategoryDTO()
                {
                    Id = Guid.NewGuid(),
                    Code = fixture.Code,
                    LabelDefault = fixture.Value
                },
                (fixture, dto) =>
                {
                    dto.LabelDefault = fixture.Value;
                    return dto;
                });

            Add<PermissionAdminDTO, Fixture>(
                PermissionHelper.GetPermissions(typeof(XXXXX.Admin.Kernel.Authorizations)),
                fixture => new PermissionAdminDTO()
                {
                    Id = Guid.NewGuid(),
                    Code = fixture.Code,
                    LabelDefault = fixture.Value
                },
                (fixture, dto) =>
                {
                    dto.LabelDefault = fixture.Value;
                    return dto;
                });

            Add<PermissionAdminCategoryDTO, Fixture>(
                PermissionHelper.GetCategories(typeof(XXXXX.Admin.Kernel.Authorizations)),
                fixture => new PermissionAdminCategoryDTO()
                {
                    Id = Guid.NewGuid(),
                    Code = fixture.Code,
                    LabelDefault = fixture.Value
                },
                (fixture, dto) =>
                {
                    dto.LabelDefault = fixture.Value;
                    return dto;
                });
        }
    }
}