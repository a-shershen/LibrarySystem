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
         static CustomContext()
        {
            Database.SetInitializer<CustomContext>(new DBInitializer());
        }
        public CustomContext(string connectionString) : base(connectionString) { }


        public DbSet<Models.Book> Books { get; set; }

        public DbSet<Models.Reader> Readers { get; set; }

        public DbSet<Models.ReaderBook> ReaderBooks { get; set; }

        public DbSet<Models.User> Users { get; set; }
    }

    class DBInitializer:System.Data.Entity.DropCreateDatabaseIfModelChanges<CustomContext>
    {
        protected override void Seed(CustomContext context)
        {
            base.Seed(context);

            context.Users.Add(new Models.User
            {
                FirstName = "Ivan",
                LastName = "Petrov",
                Login = "admin",
                //Generate by SHA256 Hash
                Password = "96cae35ce8a9b0244178bf28e4966c2ce1b8385723a96a6b838858cdd6ca0a1e"
            });
            context.SaveChanges();
        }
    }
}
