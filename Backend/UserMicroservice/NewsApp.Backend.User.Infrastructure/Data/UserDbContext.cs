using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using NewsApp.Backend.User.Domain.Models;
using Microsoft.AspNetCore.Identity;

namespace NewsApp.Backend.User.Infrastructure.Data
{
    public class UserDbContext : IdentityDbContext<UserModel, IdentityRole<Guid>, Guid>
    {
        UserDbContext(DbContextOptions<UserDbContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<UserModel>(entity =>
            {
                entity.Property(user => user.FirstName)
                      .HasColumnType("varchar(100)")
                      .HasColumnName("FirstName")
                      .HasMaxLength(100)
                      .IsRequired();
                entity.Property(user => user.LastName)
                      .HasColumnType("varchar(100)")
                      .HasColumnName("LastName")
                      .HasMaxLength(100)
                      .IsRequired();
                entity.Property(user => user.Email)
                      .IsRequired();

            });
            builder.Entity<IdentityRole<Guid>>(entity => 
            {
                entity.Property(role => role.Id)
                      .HasColumnName("id");
                entity.Property(role => role.Name)
                      .HasColumnName("name")
                      .HasMaxLength(100)
                      .IsRequired();
            });
        }
    }
}
