using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ModularArc.Identity.Domain.EntityConfigurations;

internal class RefreshTokenConfig : IEntityTypeConfiguration<UserRefreshToken>
{
    public void Configure(EntityTypeBuilder<UserRefreshToken> builder)
    {
        builder.HasOne(c => c.User).WithMany(c => c.UserRefreshTokens).HasForeignKey(c => c.UserId);

        builder.ToTable("UserRefreshTokens", "usr");
    }
}