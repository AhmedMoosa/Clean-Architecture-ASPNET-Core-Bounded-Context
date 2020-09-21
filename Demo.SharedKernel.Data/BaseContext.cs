using Microsoft.EntityFrameworkCore;
using System;

namespace Demo.SharedKernel.Data
{
    public class BaseContext<TDbContext> : DbContext where TDbContext : DbContext
    {
        public BaseContext(DbContextOptions<TDbContext> options) : base(options)
        {

        }
    }
}
