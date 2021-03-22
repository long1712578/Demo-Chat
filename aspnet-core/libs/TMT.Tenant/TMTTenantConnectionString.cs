using JetBrains.Annotations;
using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp;
using Volo.Abp.Domain.Entities;
using Volo.Abp.TenantManagement;

namespace TMT.TenantManagement
{
    public class TMTTenantConnectionString : Entity
    {
        public virtual string TenantId { get; protected set; }

        public virtual string Name { get; protected set; }

        public virtual string Value { get; protected set; }

        protected TMTTenantConnectionString()
        {

        }

        public TMTTenantConnectionString(string tenantId, [NotNull] string name, [NotNull] string value)
        {
            TenantId = tenantId;
            Name = Check.NotNullOrWhiteSpace(name, nameof(name), TenantConnectionStringConsts.MaxNameLength);
            SetValue(value);
        }

        public virtual void SetValue([NotNull] string value)
        {
            Value = Check.NotNullOrWhiteSpace(value, nameof(value), TenantConnectionStringConsts.MaxValueLength);
        }

        public override object[] GetKeys()
        {
            return new object[] { TenantId, Name };
        }
    }
}
