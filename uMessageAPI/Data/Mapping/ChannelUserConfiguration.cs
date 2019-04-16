using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using uMessageAPI.Models;

namespace uMessageAPI.Data.Mapping {
    internal class ChannelUserConfiguration : IEntityTypeConfiguration<ChannelUser> 
        { 

        public void Configure(EntityTypeBuilder<ChannelUser> builder) {
            builder.ToTable("ChannelUser");
            builder.HasKey(b => new { b.ChannelId, b.UserId });
            builder.HasOne(b => b.Channel).WithMany(b => b.ChannelUsers).HasForeignKey(gs => gs.ChannelId);
            builder.HasOne(b => b.User).WithMany(b => b.ChannelUsers).HasForeignKey(gs => gs.UserId);
        }

    }
}
