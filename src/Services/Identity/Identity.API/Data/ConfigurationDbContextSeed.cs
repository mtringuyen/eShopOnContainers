using IdentityServer4.EntityFramework.DbContexts;
using IdentityServer4.EntityFramework.Entities;
using IdentityServer4.EntityFramework.Mappers;
using Microsoft.EntityFrameworkCore;
using Microsoft.eShopOnContainers.Services.Identity.API.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Microsoft.eShopOnContainers.Services.Identity.API.Data
{
    public class ConfigurationDbContextSeed
    {
        public async Task SeedAsync(ConfigurationDbContext context, IConfiguration configuration)
        {
            //callbacks urls from config:
            var clientUrls = new Dictionary<string, string>
            {
                {"Mvc", configuration.GetValue<string>("MvcClient")},
                {"Spa", configuration.GetValue<string>("SpaClient")},
                {"Xamarin", configuration.GetValue<string>("XamarinCallback")},
                {"LocationsApi", configuration.GetValue<string>("LocationApiClient")},
                {"MarketingApi", configuration.GetValue<string>("MarketingApiClient")},
                {"BasketApi", configuration.GetValue<string>("BasketApiClient")},
                {"OrderingApi", configuration.GetValue<string>("OrderingApiClient")}
            };

            if (!await context.Clients.AnyAsync())
            {
                context.Clients.AddRange(Config.GetClients(clientUrls).Select(client => client.ToEntity()));
            }
            // Checking always for old redirects to fix existing deployments
            // to use new swagger-ui redirect uri as of v3.0.0
            // There should be no problem for new ones
            // ref: https://github.com/dotnet-architecture/eShopOnContainers/issues/586
            else
            {
                List<ClientRedirectUri> oldRedirects = (await context.Clients.Include(c => c.RedirectUris).ToListAsync())
                    .SelectMany(c => c.RedirectUris)
                    .Where(ru => ru.RedirectUri.EndsWith("/o2c.html"))
                    .ToList();

                if (oldRedirects.Any())
                {
                    foreach (var ru in oldRedirects)
                    {
                        ru.RedirectUri = ru.RedirectUri.Replace("/o2c.html", "/oauth2-redirect.html");
                        context.Update(ru.Client);
                    }
                    await context.SaveChangesAsync();
                }
            }

            if (!await context.IdentityResources.AnyAsync())
            {
                context.IdentityResources.AddRange(Config.GetResources().Select(resource => resource.ToEntity()));
            }

            if (!await context.ApiResources.AnyAsync())
            {
                context.ApiResources.AddRange(Config.GetApis().Select(api => api.ToEntity()));
            }

            await context.SaveChangesAsync();
        }
    }
}
