using System.Collections.Generic;
using ProyectoCiclo3.App.Dominio;
using System.Linq;
using System;
 
namespace ProyectoCiclo3.App.Persistencia.AppRepositorios
{
    public class RepositorioServicio
    {
        List<Servicio> servicios;
 
    public RepositorioServicio()
        {
            servicios= new List<Servicio>()
            {
                new Servicio{id=1,origen=1,destino=2,fecha="2021-10-01",hora= "08:00:00",encomienda=1},
                new Servicio{id=2,origen=1,destino=3,fecha="2021-10-02",hora= "09:00:00",encomienda=2},
                new Servicio{id=3,origen=2,destino=3,fecha="2021-10-03",hora= "15:00:00",encomienda=3} 
            };
        }
 
        public IEnumerable<Servicio> GetAll()
        {
            return servicios;
        }
 
        public Servicio GetServicioWithId(int id){
            return servicios.SingleOrDefault(b => b.id == id);
        }

        public Servicio Update(Servicio newServicio){
            var servicio= servicios.SingleOrDefault(b => b.id == newServicio.id);
            if(servicio != null){
                servicio.origen = newServicio.origen;
                servicio.destino = newServicio.destino;
                servicio.fecha = newServicio.fecha;
                servicio.hora = newServicio.hora;
                servicio.encomienda = newServicio.encomienda;
            }
            return servicio;
        }

        /*public Usuario Create(Usuario newUsuario)
        {
            if(usuarios.Count > 0){
                newUsuario.id=usuarios.Max(r => r.id) +1; 
            }
            else{
                newUsuario.id = 1; 
            }
           usuarios.Add(newUsuario);
           return newUsuario;
        }*/

        public Servicio Delete(int id)
        {
            var servicio= servicios.SingleOrDefault(b => b.id == id);
            servicios.Remove(servicio);
            return servicio;
        }

    }
}