using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ModularArc.Identity.Domain;

namespace ModularArc.Identity.Domain.EntityConfigurations;

internal class UserTokenConfig : IEntityTypeConfiguration<UserToken>
{
    public void Configure(EntityTypeBuilder<UserToken> builder)
    {

        builder.HasOne(u => u.User).WithMany(u => u.Tokens).HasForeignKey(u => u.UserId);
        builder.ToTable("UserTokens", "usr");
    }
}