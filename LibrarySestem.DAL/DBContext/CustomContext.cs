using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace LibrarySestem.DAL.DBContext
{
    class CustomContext:DbContext
    {
        public CustomContext(string connectionString) : base(connectionString) { }

        public DbSet<Models.Book> Books { get; set; }

        public DbSet<Models.Reader> Readers { get; set; }

        public DbSet<Models.ReaderBook> ReaderBooks { get; set; }

        public DbSet<Models.User> Users { get; set; }
    }
}
