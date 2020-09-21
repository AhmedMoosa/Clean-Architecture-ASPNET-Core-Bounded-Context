using Demo.Users.Core.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Demo.Users.Infrasturcture.Data
{
    public class UsersContext : IdentityDbContext<AspNetUsers, AspNetRoles, string>
    {
        public UsersContext(DbContextOptions<UsersContext> options) : base(options)
        {

        }
    }
}
