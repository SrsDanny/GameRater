using System.Data.Entity;

namespace PagingExtensions.Tests
{
    internal class Foo
    {
        public int Id { get; set; }
        public int Index { get; set; }
    }

    internal class TestDbContext : DbContext
    {
        public DbSet<Foo> Foos { get; set; }
    }
}
