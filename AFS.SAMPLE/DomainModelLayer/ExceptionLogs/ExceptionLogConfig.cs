using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AFS.SAMPLE.DomainModelLayer.ExceptionLogs;

public class ExceptionLogConfig : IEntityTypeConfiguration<ExceptionLog>
{
    public void Configure(EntityTypeBuilder<ExceptionLog> builder)
    {
        builder.ToTable(nameof(ExceptionLog), "dbo");
        builder.HasKey(s => s.Id);
          
        builder.HasOne(s => s.User).WithMany(s => s.ExceptionLogs).HasForeignKey(s => s.UserId).IsRequired();

    }
}
