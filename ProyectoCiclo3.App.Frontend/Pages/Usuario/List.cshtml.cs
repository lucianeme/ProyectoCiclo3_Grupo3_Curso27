using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ProyectoCiclo3.App.Persistencia.AppRepositorios;
using ProyectoCiclo3.App.Dominio;
 
namespace ProyectoCiclo3.App.Frontend.Pages
{
    public class ListUsuarioModel : PageModel
    {
       
        private readonly RepositorioUsuario repositorioUsuario;
        public IEnumerable<Usuario> Usuario {get;set;}
        [BindProperty]
        public Usuario Usuario1 {get;set;}

        public ListUsuarioModel(RepositorioUsuario repositorioUsuario)
        {
            this.repositorioUsuario=repositorioUsuario;
        }
 
        public void OnGet()
        {
            Usuario=repositorioUsuario.GetAll();
        }

        public IActionResult OnPost()
        {
            if(Usuario1.id>0)
            {
                Usuario1 = repositorioUsuario.Delete(Usuario1.id);
            }
            return RedirectToPage("./List");
        }
    }
}
