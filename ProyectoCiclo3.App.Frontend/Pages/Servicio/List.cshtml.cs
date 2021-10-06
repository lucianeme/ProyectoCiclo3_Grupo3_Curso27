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
    public class ListServicioModel : PageModel
    {
        private readonly RepositorioServicio repositorioServicio;
        public IEnumerable<Servicio> Servicio {get;set;}
        [BindProperty]
        public Servicio Servicio1 {get;set;}

        public ListServicioModel(RepositorioServicio repositorioServicio)
        {
            this.repositorioServicio=repositorioServicio;
        }
 
        public void OnGet()
        {
            Servicio=repositorioServicio.GetAll();
        }

        public IActionResult OnPost()
        {
            if(Servicio1.id>0)
            {
                Servicio1 = repositorioServicio.Delete(Servicio1.id);
            }
            return RedirectToPage("./List");
        }
    }
}
