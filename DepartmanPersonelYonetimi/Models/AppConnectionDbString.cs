using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace DepartmanPersonelYonetimi.Models
{
    public class AppConnectionDbString : DbContext
    {
        public AppConnectionDbString() : base($@"Server=.\SQLEXPRESS;Database=DepartmanPersonelYonetimi;User Id = sa; Password=9090;") { }

        public DbSet<Departman> Departman { get; set; }
        public DbSet<Personel> Personel { get; set; }



    }
}