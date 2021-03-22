


using Microsoft.EntityFrameworkCore;
using TMT.TDeskApp.Attachments;
using TMT.TDeskApp.Conversations;
using TMT.TDeskApp.Friends;
using TMT.TDeskApp.LabelConversations;
using TMT.TDeskApp.Labels;
using TMT.TDeskApp.Messages;
using TMT.TDeskApp.UserConversations;
using TMT.TDeskApp.UserGroups;
using TMT.TDeskApp.Users;
using TMT.TDeskApp.Widgets;
using TMT.TDeskApp.WidgetUsers;
using Volo.Abp;
using Volo.Abp.EntityFrameworkCore.Modeling;

namespace TMT.TDeskApp.EntityFrameworkCore
{
    public static class TDeskAppDbContextModelCreatingExtensions
    {
        public static void ConfigureTDeskApp(this ModelBuilder builder)
        {
            Check.NotNull(builder, nameof(builder));

            /* Configure your own tables/entities inside here */

            builder.Entity<AppUser>(b =>
            {
                b.ToTable(TDeskAppConsts.DbTablePrefix + "Users"); //Sharing the same table "AbpUsers" with the IdentityUser
                b.ConfigureByConvention();
                b.Property(x => x.Id).HasMaxLength(16);
                b.HasOne<Friend>().WithMany().HasForeignKey(x => new { x.UserSend, x.UserRecive }).IsRequired();

            });

            builder.Entity<Attachment>(b =>
            {
                b.ToTable(TDeskAppConsts.DbTablePrefix + "Attachments");
                b.ConfigureByConvention();
                b.Property(x => x.Id).HasMaxLength(16).IsRequired();
                b.Property(x => x.ConversationId).HasMaxLength(16);
                b.Property(x => x.MessageId).HasMaxLength(16);

                b.HasOne<Conversation>().WithMany().HasForeignKey(x => x.ConversationId).IsRequired();
                b.HasOne<Message>().WithMany().HasForeignKey(x => x.MessageId).IsRequired()
                    .OnDelete(DeleteBehavior.NoAction);

            });

            builder.Entity<Message>(b =>
            {
                b.ToTable(TDeskAppConsts.DbTablePrefix + "Messages");
                b.ConfigureByConvention();
                b.Property(x => x.Id).HasMaxLength(16);
                b.HasOne<Conversation>().WithMany().HasForeignKey(x => x.ConversationId).IsRequired();

            });

            builder.Entity<Conversation>(b =>
            {
                b.ToTable(TDeskAppConsts.DbTablePrefix + "Conversations");
                b.ConfigureByConvention();
                b.Property(x => x.Id).HasMaxLength(16);
                b.HasOne<UserGroup>().WithMany().HasForeignKey(x => x.UserGroupId).IsRequired();
                b.HasOne<Widget>().WithMany().HasForeignKey(x => x.WidgetId).IsRequired();

            });

            builder.Entity<UserConversation>(b =>
            {
                b.ToTable(TDeskAppConsts.DbTablePrefix + "UserConversations");
                b.ConfigureByConvention();
                b.Property(x => x.Id).HasMaxLength(16);
                b.HasOne<Conversation>().WithMany().HasForeignKey(x => x.ConversationId).IsRequired();
            });

            builder.Entity<UserGroup>(b =>
            {
                b.ToTable(TDeskAppConsts.DbTablePrefix + "UserGroups");
                b.ConfigureByConvention();
                b.Property(x => x.Id).HasMaxLength(16);
            });

            builder.Entity<Label>(b =>
            {
                b.ToTable(TDeskAppConsts.DbTablePrefix + "Labels");
                b.ConfigureByConvention();
                b.Property(x => x.Id).HasMaxLength(16);
            });

            builder.Entity<LabelConversation>(b =>
            {
                b.ToTable(TDeskAppConsts.DbTablePrefix + "LabelConversations");
                b.ConfigureByConvention();
                b.Property(x => x.Id).HasMaxLength(16);

                b.HasOne<Label>().WithMany().HasForeignKey(x => x.LabelId).IsRequired();
                b.HasOne<Conversation>().WithMany().HasForeignKey(x => x.ConversationId).IsRequired();

            });

            builder.Entity<Widget>(b =>
            {
                b.ToTable(TDeskAppConsts.DbTablePrefix + "Widgets");
                b.ConfigureByConvention();
                b.Property(x => x.Id).HasMaxLength(16);

            });

            builder.Entity<WidgetUser>(b =>
            {
                b.ToTable(TDeskAppConsts.DbTablePrefix + "WidgetUsers");
                b.ConfigureByConvention();
                b.Property(x => x.Id).HasMaxLength(16);
                b.HasOne<Widget>().WithMany().HasForeignKey(x => x.WidgetId).IsRequired();
            });

            builder.Entity<Friend>(b =>
            {
                b.ToTable(TDeskAppConsts.DbTablePrefix + "Friends");
                b.ConfigureByConvention();
                b.Property(x => x.Id).HasMaxLength(16);
                b.HasKey(x => new { x.UserSend, x.UserRecive });

            });
        }
    }
}