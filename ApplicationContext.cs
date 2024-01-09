using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace yulia5
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Month> Months { get; set; } = null!;
        //public ApplicationContext()
        //{
        //    this.Configuration.LazyLoadingEnabled = false;
        //}
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                .UseLazyLoadingProxies()        // подключение lazy loading
                .UseSqlite("Data Source=calendar.db");
        }
    }
}
