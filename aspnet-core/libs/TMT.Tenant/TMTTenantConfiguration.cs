using System;
using JetBrains.Annotations;
using Volo.Abp;
using Volo.Abp.Data;

namespace TMT.TenantManagement
{
    [Serializable]
    public class TMTTenantConfiguration
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public ConnectionStrings ConnectionStrings { get; set; }

        public TMTTenantConfiguration()
        {

        }

        public TMTTenantConfiguration(string id, [NotNull] string name)
        {
            Check.NotNull(name, nameof(name));

            Id = id;
            Name = name;

            ConnectionStrings = new ConnectionStrings();
        }
    }
}
