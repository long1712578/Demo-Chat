using AutoMapper;
using Volo.Abp.Data;
using Volo.Abp.MultiTenancy;

namespace TMT.TenantManagement
{
    public class TMTTenantManagementMappingProfile : Profile
    {
        public TMTTenantManagementMappingProfile()
        {
            CreateMap<TMTTenant, TMTTenantConfiguration>()
                .ForMember(ti => ti.ConnectionStrings, opts =>
                {
                    opts.MapFrom((tenant, ti) =>
                    {
                        var connStrings = new ConnectionStrings();

                        foreach (var connectionString in tenant.ConnectionStrings)
                        {
                            connStrings[connectionString.Name] = connectionString.Value;
                        }

                        return connStrings;
                    });
                });

            CreateMap<TMTTenant, TMTTenantEto>();
        }
    }
}
