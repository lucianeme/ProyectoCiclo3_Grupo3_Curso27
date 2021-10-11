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
    public class ListEncomiendaModel : PageModel
    {

        private readonly RepositorioEncomienda repositorioEncomienda;
        public IEnumerable<Encomienda> Encomienda {get;set;}
        [BindProperty]
        public Encomienda Encomienda1 {get;set;}
 
        public ListEncomiendaModel(RepositorioEncomienda repositorioEncomienda)
        {
            this.repositorioEncomienda=repositorioEncomienda;
        }


        public void OnGet()
        {
            Encomienda = repositorioEncomienda.GetAll();
        }

        public IActionResult OnPost()
        {
            if(Encomienda1.id>0)
            {
                //Encomienda1 = repositorioEncomienda.Delete(Encomienda1.id);
                repositorioEncomienda.Delete(Encomienda1.id);
            }
            return RedirectToPage("./List");
        }
    }
}
