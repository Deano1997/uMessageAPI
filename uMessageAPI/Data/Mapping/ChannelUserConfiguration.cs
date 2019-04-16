using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using uMessageAPI.Models;

namespace uMessageAPI.Data.Mapping {
    internal class ChannelUserConfiguration : IEntityTypeConfiguration<ChannelUser> { 

        public void Configure(EntityTypeBuilder<ChannelUser> builder) {
            builder.HasKey(b => new { b.ChannelId, b.UserId });
            builder.HasOne(b => b.Channel).WithMany(b => b.ChannelUsers).HasForeignKey(gs => gs.ChannelId);
            builder.HasOne(b => b.User).WithMany(b => b.ChannelUsers).HasForeignKey(gs => gs.UserId);
        }

    }
}
