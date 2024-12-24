using Microsoft.EntityFrameworkCore;
using Ordaring.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Ordaring.Infrastructure.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        public DbSet<Customer> customers => Set<Customer>();
        public DbSet<Order> orders => Set<Order>();
        public DbSet<Product> products => Set<Product>();
        public DbSet<OrderItem> ordersItems => Set<OrderItem>();
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            base.OnModelCreating(builder);
        }


    }
}
