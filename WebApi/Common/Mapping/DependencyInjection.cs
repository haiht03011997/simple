using System.Reflection;

using AutoMapper;

namespace WebApi.Common.Mapping;

public static class DependencyInjection
{
    public static IServiceCollection AddMappings(this IServiceCollection services)
    {
        // Initialize AutoMapper configuration
        var mapperConfig = new MapperConfiguration(mc =>
        {
            mc.AddMaps(Assembly.GetExecutingAssembly()); // Scan the current executing assembly for mappings
        });

        // Register IMapper as a service with the configured IMapper instance
        IMapper mapper = mapperConfig.CreateMapper();
        services.AddSingleton(mapper);

        // Return the modified service collection
        return services;
    }
}