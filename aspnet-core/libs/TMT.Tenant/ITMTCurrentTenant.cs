using System;
using JetBrains.Annotations;

namespace TMT.TenantManagement
{
    public interface ITMTCurrentTenant
    {
        bool IsAvailable { get; }

        [CanBeNull]
        string Id { get; }

        [CanBeNull]
        string Name { get; }

        IDisposable Change(string id, string name = null);
    }
}
