using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ModularArc.Identity.Domain;

namespace ModularArc.Identity.Domain.EntityConfigurations;

internal class UserRoleConfig : IEntityTypeConfiguration<UserRole>
{
    public void Configure(EntityTypeBuilder<UserRole> builder)
    {

        builder.HasOne(u => u.User).WithMany(u => u.UserRoles).HasForeignKey(u => u.UserId);
        builder.HasOne(u => u.Role).WithMany(u => u.Users).HasForeignKey(u => u.RoleId);
        builder.ToTable("UserRoles", "usr");
    }
}