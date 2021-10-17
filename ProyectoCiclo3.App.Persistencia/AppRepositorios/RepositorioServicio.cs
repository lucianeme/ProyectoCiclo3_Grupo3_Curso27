using System.Collections.Generic;
using ProyectoCiclo3.App.Dominio;
using System.Linq;
using System;
using Microsoft.EntityFrameworkCore;
 
namespace ProyectoCiclo3.App.Persistencia.AppRepositorios
{
    public class RepositorioServicio
    {
        List<Servicio> servicios;
        private readonly AppContext _appContext = new AppContext(); //Objeto para conectar con Base de Datos

 
    /*public RepositorioServicio()
        {
            servicios= new List<Servicio>()
            {
                new Servicio{id=1,origen=1,destino=2,fecha="2021-10-01",hora= "08:00:00",encomienda=1},
                new Servicio{id=2,origen=1,destino=3,fecha="2021-10-02",hora= "09:00:00",encomienda=2},
                new Servicio{id=3,origen=2,destino=3,fecha="2021-10-03",hora= "15:00:00",encomienda=3} 
            };
        }*/
 
        public IEnumerable<Servicio> GetAll()
        {
            return _appContext.Servicios.Include(u => u.origen)
                       .Include(u => u.destino).
                       Include(e => e.encomienda);
        }
 
        public Servicio GetServicioWithId(int id){
            // return servicios.SingleOrDefault(b => b.id == id);
            return _appContext.Servicios.Find(id); // BD Servicios

        }

        public Servicio Create(int origen, int destino, string fecha, string hora, int encomienda)
        {
            /*if(servicios.Count > 0){
                newServicio.id=servicios.Max(r => r.id) +1; 
            }
            else{
                newServicio.id = 1; 
            }
           servicios.Add(newServicio);
           return newServicio;*/
           var newServicio = new Servicio();
            newServicio.destino = _appContext.Usuarios.Find(destino);
            newServicio.origen = _appContext.Usuarios.Find(origen);
            newServicio.encomienda = _appContext.Encomiendas.Find(encomienda);
            newServicio.fecha = DateTime.Parse(fecha);
            newServicio.hora = hora;
            var addServicio = _appContext.Servicios.Add(newServicio);
            _appContext.SaveChanges();
            return addServicio.Entity;
        }

        public Servicio Update(int id, int origen, int destino, string fecha, string hora, int encomienda){
            //var servicio= servicios.SingleOrDefault(b => b.id == newServicio.id);
            var servicio = _appContext.Servicios.Find(id);
            if(servicio != null){
                servicio.destino = _appContext.Usuarios.Find(destino);
                servicio.origen = _appContext.Usuarios.Find(origen);
                servicio.encomienda = _appContext.Encomiendas.Find(encomienda);
                // servicio.origen = newServicio.origen;
                // servicio.destino = newServicio.destino;
                servicio.fecha = DateTime.Parse(fecha);
                servicio.hora = hora;
                // servicio.encomienda = newServicio.encomienda;
                _appContext.SaveChanges(); // Guarda en BD

            }
            return servicio;
        }

        

        public void Delete(int id)
        {
            /*var servicio= servicios.SingleOrDefault(b => b.id == id);
            servicios.Remove(servicio);
            return servicio;*/
            var servicio = _appContext.Servicios.Find(id);
            if (servicio == null)
                return;
            _appContext.Servicios.Remove(servicio);
            _appContext.SaveChanges();
        }

    }
}