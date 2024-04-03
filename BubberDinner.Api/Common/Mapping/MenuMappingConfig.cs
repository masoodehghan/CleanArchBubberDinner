using BubberDinner.Application.Menus.CreateMenu.Commands;
using BubberDinner.Contracts.Menus;
using BubberDinner.Domain.MenuAggregate;
using BubberDinner.Domain.MenuAggregate.Entities;

using MenuSection = BubberDinner.Domain.MenuAggregate.Entities.MenuSection;
using MenuItem = BubberDinner.Domain.MenuAggregate.Entities.MenuItem;

using Mapster;

namespace BubberDinner.Api.Common.Mapping;


public class MenuMappingConfig : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<(CreateMenuRequest Request, string HostId), CreateMenuCommand>()
                .Map(dest => dest.HostId, src => src.HostId)
                .Map(dest => dest, src => src.Request);


        config.NewConfig<Menu, MenuResponse>()
                .Map(dest => dest.id, src => src.Id.Value)
                .Map(dest => dest.HostId, src => src.hostId.Value);

        config.NewConfig<MenuSection, MenuSectionResponse>()
                .Map(dest => dest.id, src => src.Id.Value);

        config.NewConfig<MenuItem, MenuItemResponse>()
                .Map(dest => dest.id, src => src.Id.Value);

        
    }
}
