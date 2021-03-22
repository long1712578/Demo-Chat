using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;

namespace TMT.TDeskApp.Data
{
    /* This is used if database provider does't define
     * ITDeskAppDbSchemaMigrator implementation.
     */
    public class NullTDeskAppDbSchemaMigrator : ITDeskAppDbSchemaMigrator, ITransientDependency
    {
        public Task MigrateAsync()
        {
            return Task.CompletedTask;
        }
    }
}