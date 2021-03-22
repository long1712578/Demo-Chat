using System;
using System.Collections.Generic;
using System.Linq;
using JetBrains.Annotations;
using TMT.Auditing;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.TenantManagement;
using Volo.Abp.Data;
using Data = Volo.Abp.Data;
using Volo.Abp;

namespace TMT.TenantManagement
{
    public class TMTTenant : TMTFullAuditedAggregateRoot<string>
    {
        public virtual string Name { get; protected set; }

        public virtual List<TMTTenantConnectionString> ConnectionStrings { get; protected set; }

        protected TMTTenant()
        {

        }

        protected internal TMTTenant(string id, [NotNull] string name)
            : base(id)
        {
            SetName(name);

            ConnectionStrings = new List<TMTTenantConnectionString>();
        }

        [CanBeNull]
        public virtual string FindDefaultConnectionString()
        {
            return FindConnectionString(Data.ConnectionStrings.DefaultConnectionStringName);
        }

        [CanBeNull]
        public virtual string FindConnectionString(string name)
        {
            return ConnectionStrings.FirstOrDefault(c => c.Name == name)?.Value;
        }

        public virtual void SetDefaultConnectionString(string connectionString)
        {
            SetConnectionString(Data.ConnectionStrings.DefaultConnectionStringName, connectionString);
        }

        public virtual void SetConnectionString(string name, string connectionString)
        {
            var tenantConnectionString = ConnectionStrings.FirstOrDefault(x => x.Name == name);

            if (tenantConnectionString != null)
            {
                tenantConnectionString.SetValue(connectionString);
            }
            else
            {
                ConnectionStrings.Add(new TMTTenantConnectionString(Id, name, connectionString));
            }
        }

        public virtual void RemoveDefaultConnectionString()
        {
            RemoveConnectionString(Data.ConnectionStrings.DefaultConnectionStringName);
        }

        public virtual void RemoveConnectionString(string name)
        {
            var tenantConnectionString = ConnectionStrings.FirstOrDefault(x => x.Name == name);

            if (tenantConnectionString != null)
            {
                ConnectionStrings.Remove(tenantConnectionString);
            }
        }

        protected internal virtual void SetName([NotNull] string name)
        {
            Name = Check.NotNullOrWhiteSpace(name, nameof(name), TenantConsts.MaxNameLength);
        }
    }
}