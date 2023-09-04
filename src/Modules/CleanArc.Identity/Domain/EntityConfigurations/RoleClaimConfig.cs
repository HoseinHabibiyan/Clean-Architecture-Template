﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CleanArc.Identity.Domain.EntityConfigurations;

internal class RoleClaimConfig : IEntityTypeConfiguration<RoleClaim>
{
	public void Configure(EntityTypeBuilder<RoleClaim> builder)
	{
		builder.ToTable("RoleClaims", "usr");

		builder.HasOne(u => u.Role).WithMany(u => u.Claims).HasForeignKey(u => u.RoleId).OnDelete(DeleteBehavior.Cascade);


	}
}