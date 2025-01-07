using CRUDify_API.Models;
using Microsoft.EntityFrameworkCore;

namespace CRUDify_API.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options): base(options) 
        {    
        }
        public DbSet<User> Users  => Set<User>();
         
    }
}
