using System.Collections.Generic;
using ProyectoCiclo3.App.Dominio;
using System.Linq;
using System;
 
namespace ProyectoCiclo3.App.Persistencia.AppRepositorios
{
    public class RepositorioServicio
    {
        List<Servicio> servicio;
 
    public RepositorioServicio()
        {
            servicio= new List<Servicio>()
            {
                new Servicio{id=1,origen=1,destino=2,fecha="2021-10-01",hora= "08:00:00",encomienda=1},
                new Servicio{id=2,origen=1,destino=3,fecha="2021-10-02",hora= "09:00:00",encomienda=2},
                new Servicio{id=3,origen=2,destino=3,fecha="2021-10-03",hora= "15:00:00",encomienda=3} 
            };
        }
 
        public IEnumerable<Servicio> GetAll()
        {
            return servicio;
        }
 
        public Servicio GetServicioWithId(int id){
            return servicio.SingleOrDefault(b => b.id == id);
        }

        /*public Encomienda Update(Encomienda newEncomienda){
            var encomienda= encomienda.SingleOrDefault(b => b.id == newEncomienda.id);
            if(encomienda != null){
                encomienda.descripcion = newUsuario.descripcion;
                encomienda.peso = newUsuario.peso;
                encomienda.tipo = newUsuario.tipo;
                encomienda.presentacion = newUsuario.presentacion;
            }
            return encomienda;
        }

        public Usuario Create(Usuario newUsuario)
        {
            if(usuarios.Count > 0){
                newUsuario.id=usuarios.Max(r => r.id) +1; 
            }
            else{
                newUsuario.id = 1; 
            }
           usuarios.Add(newUsuario);
           return newUsuario;
        }

        public Usuario Delete(int id)
        {
            var usuario= usuarios.SingleOrDefault(b => b.id == id);
            usuarios.Remove(usuario);
            return usuario;
        }*/

    }
}