using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AFS.SAMPLE.DomainModelLayer.Users;

public class UserConfig : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.ToTable(nameof(User), "dbo");
        builder.HasKey(s => s.Id);

        builder.Property(s => s.UserName).HasMaxLength(50);        
        builder.Property(s => s.Password).HasMaxLength(20);        
        builder.Property(s => s.Email).HasMaxLength(100);
        builder.Property(s => s.PhoneNumber).HasMaxLength(20);        
        builder.Property(s => s.TokenExpiredMinute).HasDefaultValue(60);
    }
}
