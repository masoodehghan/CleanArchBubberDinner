using BubberDinner.Application.Menus.CreateMenu.Commands;
using BubberDinner.Contracts.Menus;
using BubberDinner.Domain.MenuAggregate;
using BubberDinner.Domain.MenuAggregate.Entities;

using MenuSection = BubberDinner.Domain.MenuAggregate.Entities.MenuSection;
using MenuItem = BubberDinner.Domain.MenuAggregate.Entities.MenuItem;

using Mapster;
using BubberDinner.Application.Menus.Queries;

namespace BubberDinner.Api.Common.Mapping;


public class MenuMappingConfig : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<(CreateMenuRequest Request, string HostId), CreateMenuCommand>()
                .Map(dest => dest.HostId, src => src.HostId)
                .Map(dest => dest, src => src.Request);
                


        config.NewConfig<Menu, MenuResponse>()
                .Map(dest => dest.Id, src => src.Id.Value)
                .Map(dest => dest.HostId, src => src.hostId.Value)
                .Map(dest => dest.MenuSectionResponses, src => src.Sections);
                
        config.NewConfig<MenuSection, MenuSectionResponse>()
                .Map(dest => dest.Id, src => src.Id.Value)
                .Map(dest => dest.MenuItemResponses, src => src.Items);

        config.NewConfig<MenuItem, MenuItemResponse>()
                .Map(dest => dest.Id, src => src.Id.Value)
                .PreserveReference(true);
        
        config.NewConfig<ReadMenuRequest, ReadMenuQuery>()
                .Map(dest => dest.Id, src => src.Id);
    }
}
