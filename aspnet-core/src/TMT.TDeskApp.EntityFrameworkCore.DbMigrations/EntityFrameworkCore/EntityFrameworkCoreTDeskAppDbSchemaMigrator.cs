using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using TMT.TDeskApp.Data;
using Volo.Abp.DependencyInjection;

namespace TMT.TDeskApp.EntityFrameworkCore
{
    public class EntityFrameworkCoreTDeskAppDbSchemaMigrator
        : ITDeskAppDbSchemaMigrator, ITransientDependency
    {
        private readonly IServiceProvider _serviceProvider;

        public EntityFrameworkCoreTDeskAppDbSchemaMigrator(
            IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public async Task MigrateAsync()
        {
            /* We intentionally resolving the TDeskAppMigrationsDbContext
             * from IServiceProvider (instead of directly injecting it)
             * to properly get the connection string of the current tenant in the
             * current scope.
             */

            await _serviceProvider
                .GetRequiredService<TDeskAppMigrationsDbContext>()
                .Database
                .MigrateAsync();
        }
    }
}