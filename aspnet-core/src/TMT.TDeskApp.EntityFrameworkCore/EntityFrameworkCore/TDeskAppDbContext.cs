using Microsoft.EntityFrameworkCore;
using TMT.TDeskApp.Users;
using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.Modeling;
using Volo.Abp.Identity;
using Volo.Abp.Users.EntityFrameworkCore;
using TMT.TDeskApp.Attachments;
using TMT.TDeskApp.CannedResponses;
using TMT.TDeskApp.Conversations;
using TMT.TDeskApp.LabelConversations;
using TMT.TDeskApp.Labels;
using TMT.TDeskApp.Logs;
using TMT.TDeskApp.Messages;
using TMT.TDeskApp.UserConversations;
using TMT.TDeskApp.UserGroups;
using TMT.TDeskApp.Widgets;
using TMT.TDeskApp.WidgetUsers;
using TMT.TDeskApp.Friends;

namespace TMT.TDeskApp.EntityFrameworkCore
{
    /* This is your actual DbContext used on runtime.
     * It includes only your entities.
     * It does not include entities of the used modules, because each module has already
     * its own DbContext class. If you want to share some database tables with the used modules,
     * just create a structure like done for AppUser.
     *
     * Don't use this DbContext for database migrations since it does not contain tables of the
     * used modules (as explained above). See TDeskAppMigrationsDbContext for migrations.
     */
    [ConnectionStringName("Default")]
    public class TDeskAppDbContext : AbpDbContext<TDeskAppDbContext>
    {
        public DbSet<AppUser> Users { get; set; }
        public DbSet<CannedResponse> CannedResponses { get; set; }
        public DbSet<Attachment> Attachments { get; set; }
        public DbSet<Conversation> Conversations { get; set; }
        public DbSet<LabelConversation> LabelConversation { get; set; }
        public DbSet<Label> Labels { get; set; }
        public DbSet<Log> Logs { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<UserConversation> UserConversations { get; set; }
        public DbSet<UserGroup> UserGroups { get; set; }
        public DbSet<Widget> Widgets { get; set; }
        public DbSet<WidgetUser> WidgetUser { get; set; }
        public DbSet<Friend> Friends { get; set; }

        /* Add DbSet properties for your Aggregate Roots / Entities here.
         * Also map them inside TDeskAppDbContextModelCreatingExtensions.ConfigureTDeskApp
         */

        public TDeskAppDbContext(DbContextOptions<TDeskAppDbContext> options)
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            /* Configure your own tables/entities inside the ConfigureTDeskApp method */

            builder.ConfigureTDeskApp();
        }
    }
}
