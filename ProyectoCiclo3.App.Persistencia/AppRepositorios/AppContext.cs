using Microsoft.EntityFrameworkCore;
using ProyectoCiclo3.App.Dominio;
//Crear conexión con base de datos
namespace ProyectoCiclo3.App.Persistencia
{
    public class AppContext: DbContext{
        public DbSet<Encomienda> Encomiendas { get; set; } //Hacer DbSets de las otras clases
        public DbSet<Servicio> Servicios { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder){
            if(!optionsBuilder.IsConfigured){
                optionsBuilder.UseSqlServer("Data Source = misiontic2021equipo3grupo27.database.windows.net; Initial Catalog = ProyectoCiclo3Amazon; User ID=admin_equipo3-DS27;Password=xxxxxxxx");
            }
        } 
    }
}
