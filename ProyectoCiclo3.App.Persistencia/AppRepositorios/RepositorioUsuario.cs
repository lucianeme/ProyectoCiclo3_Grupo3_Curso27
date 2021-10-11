using System.Collections.Generic;
using ProyectoCiclo3.App.Dominio;
using System.Linq;
using System;
 
namespace ProyectoCiclo3.App.Persistencia.AppRepositorios
{
    public class RepositorioUsuario
    {
        List<Usuario> usuarios;
        private readonly AppContext _appContext = new AppContext(); //Objeto para conectar con Base de Datos
 
    /*public RepositorioUsuario()
        {
            usuarios= new List<Usuario>()
            {
                new Usuario{id=1,nombre="Mario",apellidos= "Sánchez",direccion= "Carrera 27",telefono= "8945412121",ciudad="Bogotá"},
                new Usuario{id=2,nombre="Camila",apellidos= "Rodriguez",direccion= "Calle 96",telefono= "895656562",ciudad="Barranquilla"},
                new Usuario{id=3,nombre="Maria Carolina",apellidos= "Perez",direccion= "Avenida Sur con 14",telefono= "12145454",ciudad="Medellín"} 
            };
        }*/
 
        public IEnumerable<Usuario> GetAll()
        {
            return _appContext.Usuarios;
        }
 
        public Usuario GetUsuarioWithId(int id){
            return _appContext.Usuarios.Find(id);
        }

        public Usuario Create(Usuario newUsuario)
        {
            var addUsuario = _appContext.Usuarios.Add(newUsuario);
            _appContext.SaveChanges();
            return addUsuario.Entity;
        }

        public Usuario Update(Usuario newUsuario){
            //var usuario= usuarios.SingleOrDefault(b => b.id == newUsuario.id);
            var usuario = _appContext.Usuarios.Find(newUsuario.id);
            if(usuario != null){
                usuario.nombre = newUsuario.nombre;
                usuario.apellidos = newUsuario.apellidos;
                usuario.direccion = newUsuario.direccion;
                usuario.telefono = newUsuario.telefono;
                usuario.ciudad = newUsuario.ciudad;
                _appContext.SaveChanges(); // Guarda en BD
            }
            return usuario;
        }

        

        public void Delete(int id)
        {
            /*var usuario= usuarios.SingleOrDefault(b => b.id == id);
            usuarios.Remove(usuario);
            return usuario;*/
            var usuario = _appContext.Usuarios.Find(id);
            if (usuario == null)
                return;
            _appContext.Usuarios.Remove(usuario);
            _appContext.SaveChanges();
        }

    }
}
