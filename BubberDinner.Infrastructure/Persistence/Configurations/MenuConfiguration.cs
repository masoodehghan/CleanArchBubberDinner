using BubberDinner.Domain.MenuAggregate;
using BubberDinner.Domain.MenuAggregate.Entities;
using BubberDinner.Domain.MenuAggregate.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BubberDinner.Infrastructure.Persistence.Configurations;


public class MenuConfiguration : IEntityTypeConfiguration<Menu>
{
    public void Configure(EntityTypeBuilder<Menu> builder)
    {
        ConfigureMenusTable(builder);
        ConfigureMenuSectionsTable(builder);
        ConfigureDinnerIdsTable(builder);
        ConfigureMenuReviewIdsTable(builder);
    }

    private void ConfigureMenuReviewIdsTable(EntityTypeBuilder<Menu> builder)
    {
        builder.OwnsMany(m => m.MenuReviewIds, mid => 
        {
            mid.ToTable("MenuMenuReviewIds");
            mid.WithOwner().HasForeignKey("MenuId");

            mid.HasKey("Id");
            mid.Property(m => m.Value)
                    .ValueGeneratedNever()
                    .HasColumnName("MenuReviewId");
        });
        builder.Metadata.FindNavigation(nameof(Menu.MenuReviewIds))!
            .SetPropertyAccessMode(PropertyAccessMode.Field);
    }

    private void ConfigureDinnerIdsTable(EntityTypeBuilder<Menu> builder)
    {
        builder.OwnsMany(m => m.DinnerIds, dib => 
        {
            dib.ToTable("MenuDinnerIds");
            dib.WithOwner().HasForeignKey("MenuId");
            dib.HasKey("Id");
            dib.Property(d => d.Value)
                .ValueGeneratedNever()
                .HasColumnName("DinnerId");
        });
        builder.Metadata.FindNavigation(nameof(Menu.DinnerIds))!
            .SetPropertyAccessMode(PropertyAccessMode.Field);
    }

    private static void ConfigureMenuSectionsTable(EntityTypeBuilder<Menu> builder)
    {
        builder.OwnsMany(s => s.Sections, sb => 
        {
            sb.ToTable("MenuSections");
            sb.WithOwner().HasForeignKey("MenuId");
            sb.HasKey("Id", "MenuId");
            sb.Property(s => s.Id)
                .ValueGeneratedNever()
                .HasColumnName("MenuSectionId")
                .HasConversion(
                    id => id.Value,
                    value => MenuSectionId.Create(value)
                );
            sb.Property(m => m.Name)
                .HasMaxLength(100);
        
            sb.Property(m => m.Description)
                .HasMaxLength(255);
            
            
            sb.OwnsMany(s => s.Items, ib => 
            {
                ib.ToTable("MenuItems");
                ib.WithOwner().HasForeignKey("MenuSectionId", "MenuId");

                ib.HasKey(nameof(MenuItem.Id), "MenuSectionId", "MenuId");

                ib.Property(m => m.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("MenuItemId")
                    .HasConversion(
                        id => id.Value,
                        value => MenuItemId.Create(value)
                    );
                ib.Property(m => m.Name)
                .HasMaxLength(100);
        
                ib.Property(m => m.Description)
                        .HasMaxLength(255);
                
            });
        
            sb.Navigation(i => i.Items).Metadata.SetField("_items");
            sb.Navigation(i => i.Items).Metadata.SetPropertyAccessMode(PropertyAccessMode.Field);
        });

        builder.Metadata.FindNavigation(nameof(Menu.Sections))!
        .SetPropertyAccessMode(PropertyAccessMode.Field);     
    }

    private static void ConfigureMenusTable(EntityTypeBuilder<Menu> builder)
    {
        builder.ToTable("Menus");
        builder.HasKey(m => m.Id);

        builder.Property(m => m.Id)
                .ValueGeneratedNever()
                .HasConversion(
                    id => id.Value,
                    value => MenuId.Create(value)
                );

        builder.Property(m => m.Name)
                .HasMaxLength(100);
        
        builder.Property(m => m.Description)
                .HasMaxLength(255);

    
    }


}
