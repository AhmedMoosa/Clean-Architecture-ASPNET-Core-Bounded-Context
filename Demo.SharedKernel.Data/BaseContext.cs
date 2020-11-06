using Microsoft.EntityFrameworkCore;
using System;

namespace Demo.SharedKernel.Data
{
    public class BaseContext<TDbContext> : DbContext where TDbContext : DbContext
    {
        public BaseContext(DbContextOptions<TDbContext> options) : base(options)
        {
            // You can write code to specify Tenant ID and connection string here
        }



        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLazyLoadingProxies();

            // optionsBuilder.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);

            base.OnConfiguring(optionsBuilder);
        }
    }
}
