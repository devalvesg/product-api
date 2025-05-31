using Application.Contracts.Data;
using Application.Contracts.UseCases;
using Application.UseCases;
using Infrastructure.Repositories;
using Infrastructure.Settings;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using System.Security.Authentication;

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

                var clientSettings = MongoClientSettings.FromConnectionString(opts.ConnectionString);

                clientSettings.SslSettings = new SslSettings
                {
                    EnabledSslProtocols = SslProtocols.Tls12 | SslProtocols.Tls13,
                    CheckCertificateRevocation = true
                };

                return new MongoClient(clientSettings);
            });

            services.AddScoped(sp =>
            {
                var opts = sp.GetRequiredService<IOptions<MongoDbSettings>>().Value;
                var client = sp.GetRequiredService<IMongoClient>();
                return client.GetDatabase(opts.DatabaseName);
            });

            //Repository
            services.AddScoped<IProductRepository, ProductRepository>();

            //UseCases
            services.AddScoped<IProductCrudUseCase, ProductCrudUseCase>();
            return services;
        }
    }
}
