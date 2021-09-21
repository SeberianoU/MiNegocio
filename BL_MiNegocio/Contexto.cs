using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
namespace BL_MiNegocio
{
    public class Contexto : DbContext
    {
        public Contexto() : base("MiNegocio")
        {

        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            Database.SetInitializer(new DatosdeInicio());

        }

        public DbSet<Usuario> Usuarios { get; set; }

    }
}