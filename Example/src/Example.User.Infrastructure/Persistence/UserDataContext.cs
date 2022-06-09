using Example.User.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Example.User.Infrastructure.Persistence
{
    public class UserDataContext : DbContext
    {
        public DbSet<UserEntity>  Users { get; set; }
        public UserDataContext(DbContextOptions<UserDataContext> options) : base(options)   
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
           modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
