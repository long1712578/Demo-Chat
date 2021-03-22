using System.Threading.Tasks;

namespace TMT.TDeskApp.Data
{
    public interface ITDeskAppDbSchemaMigrator
    {
        Task MigrateAsync();
    }
}
