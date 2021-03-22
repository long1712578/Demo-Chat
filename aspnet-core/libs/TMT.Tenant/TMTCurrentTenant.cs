using System;
using Volo.Abp;
using Volo.Abp.DependencyInjection;

namespace TMT.TenantManagement
{
    public class TMTCurrentTenant : ITMTCurrentTenant, ITransientDependency
    {
        public virtual bool IsAvailable => !string.IsNullOrEmpty(Id);

        public virtual string Id => _currentTenantAccessor.Current?.TenantId;

        public string Name => _currentTenantAccessor.Current?.Name;

        private readonly ITMTCurrentTenantAccessor _currentTenantAccessor;

        public TMTCurrentTenant(ITMTCurrentTenantAccessor currentTenantAccessor)
        {
            _currentTenantAccessor = currentTenantAccessor;
        }

        public IDisposable Change(string id, string name = null)
        {
            return SetCurrent(id, name);
        }

        private IDisposable SetCurrent(string tenantId, string name = null)
        {
            var parentScope = _currentTenantAccessor.Current;
            _currentTenantAccessor.Current = new TMTBasicTenantInfo(tenantId, name);
            return new DisposeAction(() =>
            {
                _currentTenantAccessor.Current = parentScope;
            });
        }
    }
}
