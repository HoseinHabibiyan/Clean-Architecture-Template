﻿using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using ModularArc.Identity.Domain;

namespace ModularArc.Identity.Infrastructure.Identity.Manager;

public class AppRoleManager : RoleManager<Role>
{
    public AppRoleManager(IRoleStore<Role> store, IEnumerable<IRoleValidator<Role>> roleValidators, ILookupNormalizer keyNormalizer, IdentityErrorDescriber errors, ILogger<RoleManager<Role>> logger) : base(store, roleValidators, keyNormalizer, errors, logger)
    {
    }
}