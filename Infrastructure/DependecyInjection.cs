using Application.Contracts.Data;
using Infrastructure.Repositories;
using Infrastructure.Settings;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace Infrastructure
{
    public static class DependecyInjection
    {
        public static IServiceCollection AddData(this IServiceCollection services, IConfiguration configuration)
        {
            //Mongo configuration
            services.Configure<MongoDbSettings>(configuration.GetSection("MongoDbSettings"));

            services.AddSingleton<IMongoClient>(sp =>
            {
                var opts = sp.GetRequiredService<IOptions<MongoDbSettings>>().Value;
                return new MongoClient(opts.ConnectionString);
            });

            services.AddScoped(sp =>
            {
                var opts = sp.GetRequiredService<IOptions<MongoDbSettings>>().Value;
                var client = sp.GetRequiredService<IMongoClient>();
                return client.GetDatabase(opts.DatabaseName);
            });

            services.AddScoped<IProductRepository, ProductRepository>();
            return services;
        }
    }
}
