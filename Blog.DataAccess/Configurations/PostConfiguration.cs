﻿using Blog.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.DataAccess.Configurations
{ 
    public class PostConfiguration : EntityConfiguration<Post>
    { 
        protected override void ConfigureTableSpecifics(EntityTypeBuilder<Post> builder)
        {
            builder.Property(x => x.Title).IsRequired().HasMaxLength(80);
            builder.Property(x => x.Description).IsRequired();

            builder.HasIndex(x => x.Title).IsUnique();
            builder.HasIndex(x => x.Description);

            //sa strane Posta

            //builder.HasOne(x=>x.User).WithMany(x=>x.Posts).HasForeignKey(x=>x.UserId).OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(x => x.Categories).WithOne(x => x.Post).HasForeignKey(x => x.PostId).OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(x => x.Tags).WithOne(x => x.Post).HasForeignKey(x => x.PostId).OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(x => x.Images).WithOne(x => x.Post).HasForeignKey(x => x.PostId).OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(x => x.Comments).WithOne(x => x.Post).HasForeignKey(x => x.PostId).OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(x => x.Likes).WithOne(x => x.Post).HasForeignKey(x => x.PostId).OnDelete(DeleteBehavior.Cascade);
        }
    }
}
