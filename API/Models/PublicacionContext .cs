using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
// conexion a la BD
    
namespace API.Models
{
    public class PublicacionContext : DbContext
    {
        public PublicacionContext() : base("apiConnection")
        {

        }
        public DbSet<Publicaciones> Publicacion { get; set; }
    }   
}