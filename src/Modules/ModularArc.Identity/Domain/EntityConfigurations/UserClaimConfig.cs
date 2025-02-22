﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ModularArc.Identity.Domain;

namespace ModularArc.Identity.Domain.EntityConfigurations;

internal class UserClaimConfig : IEntityTypeConfiguration<UserClaim>
{
    public void Configure(EntityTypeBuilder<UserClaim> builder)
    {

        builder.HasOne(u => u.User).WithMany(u => u.Claims).HasForeignKey(u => u.UserId);
        builder.ToTable("UserClaims", "usr");
    }
}