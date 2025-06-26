using HadaManagerAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace HadaManagerAPI.DB
{
    public sealed class DBContext : DbContext
    {
        public DbSet<Table> Tables { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<Person> People { get; set; }

        public string DbPath;

        public DBContext(DbContextOptions<DBContext> options)
        : base(options)
        {
        }
    }
}
