using Microsoft.EntityFrameworkCore;
using Zpf_Dal.Entities;

namespace Zpf_Dal.Context
{
    internal class ZpfDb : DbContext
    {
        public ZpfDb(DbContextOptions<ZpfDb> option) : base(option) 
        {        
        }
        public DbSet<Employee> Employees { get; set; }
    }
}
