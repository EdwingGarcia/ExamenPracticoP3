using ApiTareas.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiTareas.Data
{
    public class ApplicationDBContext:DbContext
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options) { }
        public DbSet<Tarea> Tarea { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Tarea>().HasData(

                new Tarea()
                {
                    IdTarea = 1,
                    Nombre = "Caminar",
                    Estado = "Pendiente",
                    Descripcion="Corriendo"
                 }
            );

        }




        }
}
