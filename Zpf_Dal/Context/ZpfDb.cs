using Microsoft.EntityFrameworkCore;
using Zpf_Dal.Entities;

namespace Zpf_Dal.Context
{
    public class ZpfDb : DbContext
    {
        public ZpfDb(DbContextOptions<ZpfDb> option) : base(option) 
        {        
        }
        public DbSet<Employee> Employees { get; set; }
    }
}
