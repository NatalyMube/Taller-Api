using API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace API.Controllers
{
    public class PublicacionesController : ApiController
    {
        [HttpGet]
        public IEnumerable<Publicaciones> Get()
        {
            using (var context = new PublicacionContext())
            {
                return context.Publicacion.ToList();
            }
        }

        [HttpGet]
        public Publicaciones Get(int id)
        {
            using (var context = new PublicacionContext())
            {
                return context.Publicacion.FirstOrDefault(x => x.Id == id);
            }
        }

        [HttpPost]
        public IHttpActionResult Post(Publicaciones productos)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            using (var context = new PublicacionContext())
            {
                context.Publicacion.Add(productos);
                context.SaveChanges();
                return Ok(productos);
            }
        }

        [HttpPut]
        public Publicaciones Put(Publicaciones publicaciones)
        {
            using (var context = new PublicacionContext())
            {
                var publicacionAct = context.Publicacion.FirstOrDefault(x => x.Id == publicaciones.Id);
                publicacionAct.Usuario = publicaciones.Usuario;
                publicacionAct.Descripcion = publicaciones.Descripcion;
                publicacionAct.FechaPublicacion = publicaciones.FechaPublicacion;
                publicacionAct.MeGusta = publicaciones.MeGusta;
                publicacionAct.MeDisgusta = publicaciones.MeDisgusta;
                publicacionAct.VecesCompartido = publicaciones.VecesCompartido;
                publicacionAct.EsPrivada = publicaciones.EsPrivada;
                context.SaveChanges();
                return publicaciones;
            }
        }


        [HttpPut]
        public bool Delete(int Id)
        {
            using (var context = new PublicacionContext())
            {
                var publicacionesDel = context.Publicacion.FirstOrDefault(x => x.Id == Id);
                context.Publicacion.Remove(publicacionesDel);
                context.SaveChanges();
                return true;
            }
        }
    }
}
