using System.Collections.Generic;
using ProyectoCiclo3.App.Dominio;
using System.Linq;
using System;
 
namespace ProyectoCiclo3.App.Persistencia.AppRepositorios
{
    public class RepositorioEncomienda
    {
        List<Encomienda> encomiendas;
 
    public RepositorioEncomienda()
        {
            encomiendas= new List<Encomienda>()
            {
                new Encomienda{id=1,descripcion="Articulos",peso=10,tipo= "Tipo A",presentacion= "Caja"},
                new Encomienda{id=2,descripcion="Documentos",peso=1,tipo= "Tipo B",presentacion= "Sobre"},
                new Encomienda{id=3,descripcion="Diplomas",peso=1,tipo= "Tipo C",presentacion= "Sobre"} 
            };
        }
 
        public IEnumerable<Encomienda> GetAll()
        {
            return encomiendas;
        }
 
        public Encomienda GetEncomiendaWithId(int id){
            return encomiendas.SingleOrDefault(b => b.id == id);
        }

        public Encomienda Create(Encomienda newEncomienda)
        {
            if(encomiendas.Count > 0){
                newEncomienda.id=encomiendas.Max(r => r.id) +1; 
            }
            else{
                newEncomienda.id = 1; 
            }
           encomiendas.Add(newEncomienda);
           return newEncomienda;
        }

        public Encomienda Update(Encomienda newEncomienda){
            var encomienda= encomiendas.SingleOrDefault(b => b.id == newEncomienda.id);
            if(encomienda != null){
                encomienda.descripcion = newEncomienda.descripcion;
                encomienda.peso = newEncomienda.peso;
                encomienda.tipo = newEncomienda.tipo;
                encomienda.presentacion = newEncomienda.presentacion;
            }
            return encomienda;
        }

        public Encomienda Delete(int id)
        {
            var encomienda= encomiendas.SingleOrDefault(b => b.id == id);
            encomiendas.Remove(encomienda);
            return encomienda;
        }

    }
}