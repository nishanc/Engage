using Engage.API.Models;
using Microsoft.EntityFrameworkCore;

namespace Engage.API.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options){} //DataContext a type and passs to base constructor

        public DbSet<Value> Values { get; set; }
    }
}