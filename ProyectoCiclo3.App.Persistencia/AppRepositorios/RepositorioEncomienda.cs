using System.Collections.Generic;
using ProyectoCiclo3.App.Dominio;
using System.Linq;
using System;
 
namespace ProyectoCiclo3.App.Persistencia.AppRepositorios
{
    public class RepositorioEncomienda
    {
        List<Encomienda> encomiendas;
        private readonly AppContext _appContext = new AppContext(); //Objeto para conectar con Base de Datos
 
    /*public RepositorioEncomienda()
        {
            encomiendas= new List<Encomienda>()
            {
                new Encomienda{id=1,descripcion="Articulos",peso=10,tipo= "Tipo A",presentacion= "Caja"},
                new Encomienda{id=2,descripcion="Documentos",peso=1,tipo= "Tipo B",presentacion= "Sobre"},
                new Encomienda{id=3,descripcion="Diplomas",peso=1,tipo= "Tipo C",presentacion= "Sobre"} 
            };
        }*/
 
        public IEnumerable<Encomienda> GetAll()
        {
            //return encomiendas;
            return _appContext.Encomiendas; // servicios
        }
 
        public Encomienda GetEncomiendaWithId(int id){
            //return encomiendas.SingleOrDefault(b => b.id == id);
            return _appContext.Encomiendas.Find(id); // BD Servicios

        }

        public Encomienda Create(Encomienda newEncomienda)
        {
            /*if(encomiendas.Count > 0){
                newEncomienda.id=encomiendas.Max(r => r.id) +1; 
            }
            else{
                newEncomienda.id = 1; 
            }
           encomiendas.Add(newEncomienda);
           return newEncomienda;*/
           var addEncomienda = _appContext.Encomiendas.Add(newEncomienda);
            _appContext.SaveChanges();
            return addEncomienda.Entity;
        }

        public Encomienda Update(Encomienda newEncomienda){
            //var encomienda= encomiendas.SingleOrDefault(b => b.id == newEncomienda.id);
            var encomienda = _appContext.Encomiendas.Find(newEncomienda.id);
            if(encomienda != null){
                encomienda.descripcion = newEncomienda.descripcion;
                encomienda.peso = newEncomienda.peso;
                encomienda.tipo = newEncomienda.tipo;
                encomienda.presentacion = newEncomienda.presentacion;
                _appContext.SaveChanges(); // Guarda en BD
            }
            return encomienda;
        }

        public void Delete(int id)
        {
            /*var encomienda= encomiendas.SingleOrDefault(b => b.id == id);
            encomiendas.Remove(encomienda);
            return encomienda;*/
            var encomienda = _appContext.Encomiendas.Find(id);
            if (encomienda == null)
                return;
            _appContext.Encomiendas.Remove(encomienda);
            _appContext.SaveChanges();
        }

    }
}