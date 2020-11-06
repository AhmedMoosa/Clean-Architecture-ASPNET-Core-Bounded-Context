using Demo.SharedKernel.Data;
using Demo.Users.Core.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Demo.Users.Infrastructure.Data
{
    public class UsersContext : IdentityDbContext<AspNetUsers, AspNetRoles, string>, IDbContextMarker
    {
        public UsersContext(DbContextOptions<UsersContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Model.SetDefaultSchema("Users");
            base.OnModelCreating(builder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }
    }
}
