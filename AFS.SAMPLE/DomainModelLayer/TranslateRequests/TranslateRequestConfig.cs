using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AFS.SAMPLE.DomainModelLayer.Requests;

public class TranslateRequestConfig : IEntityTypeConfiguration<TranslateRequest>
{
    public void Configure(EntityTypeBuilder<TranslateRequest> builder)
    {
        builder.ToTable(nameof(TranslateRequest), "dbo");
        builder.HasKey(s => s.Id);

        builder.Property(s => s.InputText).HasMaxLength(3000);                
        builder.Property(s => s.ResponseText).HasMaxLength(3000);                
        builder.Property(s => s.ResponseTranslated).HasMaxLength(3000);                
        builder.Property(s => s.ResponseTranslation).HasMaxLength(3000);

        builder.HasOne(s => s.User).WithMany(s => s.Requests).HasForeignKey(s => s.UserId).IsRequired();
    }
}
