using Dominio;
using Dominio.Comentarios;
using Dominio.CV;
using Dominio.Usuarios;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistencia
{
    public class BaseDeDatosSB : IdentityDbContext<User>
    {
        public BaseDeDatosSB(DbContextOptions<BaseDeDatosSB> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            // Declaraciones Primary Key
            builder.Entity<User>().HasKey(x => x.Id);
            builder.Entity<Comentario>().HasKey(x => x.IdComentario);
            builder.Entity<ExpLaboral>().HasKey(x => x.IdExpLaboral);
            builder.Entity<Cabecera>().HasKey(x => x.IdCvUsuario);
            builder.Entity<Idiomas>().HasKey(x => x.IdIdioma);
            builder.Entity<Skills>().HasKey(x => x.IdSkill);
            builder.Entity<Estudios>().HasKey(x => x.IdEstudio);


            // Relaciones
            builder.Entity<ExpLaboral>().HasOne<Cabecera>().WithMany(x => x.ExpLaborales).HasForeignKey(x => x.IdCvUsuario);

        }

        public DbSet<User> Users { get; set; }
        public DbSet<Comentario> Comentario { get; set; } 
        public DbSet<Cabecera> Cabeceras { get; set; }
        public DbSet<ExpLaboral> Exps { get; set; }
        public DbSet<Idiomas> Idioma { get; set; }
        public DbSet<Skills> Habilidades {get; set;}
        public DbSet<Estudios> Estudio { get; set; }



    }
}
