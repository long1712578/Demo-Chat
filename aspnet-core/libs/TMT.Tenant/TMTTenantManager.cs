using System;
using System.Threading.Tasks;
using TMT.UniqueKey;
using Volo.Abp;
using Volo.Abp.Domain.Services;

namespace TMT.TenantManagement
{
    public class TMTTenantManager : DomainService, ITMTTenantManager
    {
        protected ITMTTenantRepository TenantRepository { get; }

        public TMTTenantManager(ITMTTenantRepository tenantRepository)
        {
            TenantRepository = tenantRepository;

        }

        public virtual async Task<TMTTenant> CreateAsync(string name)
        {
            Check.NotNull(name, nameof(name));

            await ValidateNameAsync(name);

            var generator = new SequentialUniqueKeyGenerator();

            return new TMTTenant(generator.Create(), name);
        }

        public virtual async Task ChangeNameAsync(TMTTenant tenant, string name)
        {
            Check.NotNull(tenant, nameof(tenant));
            Check.NotNull(name, nameof(name));

            await ValidateNameAsync(name, tenant.Id);
            tenant.SetName(name);
        }

        protected virtual async Task ValidateNameAsync(string name, string expectedId = null)
        {
            var tenant = await TenantRepository.FindByNameAsync(name);
            if (tenant != null && tenant.Id != expectedId)
            {
                throw new UserFriendlyException("Duplicate tenancy name: " + name); //TODO: A domain exception would be better..?
            }
        }
    }
}