using BubberDinner.Domain.Common.Models;
using BubberDinner.Domain.HostAggreagte;
using BubberDinner.Domain.MenuAggregate;
using BubberDinner.Infrastructure.Persistence.Configurations;
using BubberDinner.Infrastructure.Persistence.Interceptors;
using Microsoft.EntityFrameworkCore;

namespace BubberDinner.Infrastructure.Persistence;


public class BubberDinnerDbContext : DbContext
{

    private readonly PublishDomainEventsInterceptor _publishDomainEventsInterceptor;
    public BubberDinnerDbContext(
        DbContextOptions<BubberDinnerDbContext> options,
        PublishDomainEventsInterceptor publishDomainEventsInterceptor) : base(options)
    {
        _publishDomainEventsInterceptor = publishDomainEventsInterceptor;
    }


    public DbSet<Menu> Menu { get; set; } = null!;
    public DbSet<Host> Host { get; set; } = null!;


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
        .Ignore<List<IDomainEvent>>()
        .ApplyConfigurationsFromAssembly(
            typeof(BubberDinnerDbContext).Assembly
        );
        base.OnModelCreating(modelBuilder);
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.AddInterceptors(_publishDomainEventsInterceptor);
        base.OnConfiguring(optionsBuilder);
    }
}

