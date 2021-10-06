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
    public class FormEncomiendaModel : PageModel
    {

        private readonly RepositorioEncomienda repositorioEncomiendas;
        [BindProperty]
        public Encomienda Encomienda {get;set;}

        public FormEncomiendaModel(RepositorioEncomienda repositorioEncomiendas)
        {
            this.repositorioEncomiendas=repositorioEncomiendas;
        }

        public IActionResult OnPost()
        {
            if(!ModelState.IsValid)
            {
                return Page();
            }            
            Encomienda = repositorioEncomiendas.Create(Encomienda);            
            return RedirectToPage("./List");
        }

    }
}
