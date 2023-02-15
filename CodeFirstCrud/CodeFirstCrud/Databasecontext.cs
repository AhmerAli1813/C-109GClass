using CodeFirstCrud.EFentityDbfirst;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirstCrud
{
    class Databasecontext : DbContext
    {
        public DbSet<Student> StudentDetail { get; set; }

        public virtual DbSet<book> books { get; set; }
        public virtual DbSet<employee> employees { get; set; }
        public virtual DbSet<program> programs { get; set; }
        public virtual DbSet<semester> semesters { get; set; }
        public virtual DbSet<test> tests { get; set; }

    }
}
