using Application.Abstractions.Repositories;
using Infrastructure.SqlServer.Contexts;
using Infrastructure.SqlServer.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.SqlServer;

public static class DependencyInjection
{
    public static IServiceCollection AddSqlServer(this IServiceCollection services, IConfiguration configuration)
        => services.AddDbContext<QuickDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")))
            .AddRepositories();

    private static IServiceCollection AddRepositories(this IServiceCollection services)
        => services.AddScoped(typeof(IRepository<>), typeof(Repository<>))
            .AddScoped<ITradeRepository, TradeRepository>();
}