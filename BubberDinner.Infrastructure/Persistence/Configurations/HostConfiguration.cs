using BubberDinner.Domain.HostAggreagte;
using BubberDinner.Domain.HostAggreagte.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BubberDinner.Infrastructure.Persistence.Configurations;


public class HostConfiguration : IEntityTypeConfiguration<Host>
{
    public void Configure(EntityTypeBuilder<Host> builder)
    {
        builder.HasKey("Id");
        builder.Property(h => h.Id)
            .HasColumnName("HostId")
            .ValueGeneratedNever()
            .HasConversion(
                id => id.Value,
                value => HostId.Create(value)
            );
        
        builder.OwnsOne(s => s.UserId, ub =>
        {
            ub.WithOwner().HasForeignKey("HostId");

            ub.Property(u => u.Value)
                .ValueGeneratedNever()
                .HasColumnName("UserId");
        });

        builder.OwnsMany(s => s.MenuIds, mb => {
            mb.ToTable("MenuIds");
            mb.WithOwner().HasForeignKey("HostId");

            mb.HasKey("Id");

            mb.Property(m => m.Value)
                    .HasColumnName("MenuId")
                    .ValueGeneratedNever();


        });

    }
}
