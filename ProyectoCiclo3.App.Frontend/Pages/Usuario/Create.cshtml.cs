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
    public class FormUsuarioModel : PageModel
    {

        private readonly RepositorioUsuario repositorioUsuarios;
        [BindProperty]
        public Usuario Usuario {get;set;}
        
        public FormUsuarioModel(RepositorioUsuario repositorioUsuarios)
        {
            this.repositorioUsuarios=repositorioUsuarios;
        }


        public void OnGet()
        {
            //Comentario Marisel
        }

        public IActionResult OnPost()
        {
            if(!ModelState.IsValid)
            {
                return Page();
            }            
            Usuario = repositorioUsuarios.Create(Usuario);            
            return RedirectToPage("./List");
        }

    }
}
