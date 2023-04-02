using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore; // for connect to DB help framework

namespace Que
{
    public class ApplicationContext : DbContext // for send sql requests
    {
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=que.db");
        }


        public DbSet<User> Users { get; set; }
    }
}
