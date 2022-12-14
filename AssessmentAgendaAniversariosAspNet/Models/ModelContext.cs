using Microsoft.EntityFrameworkCore;

namespace AssessmentAgendaAniversariosAspNet.Models
{
    public class ModelContext: DbContext
    {
        public DbSet<Amigo> Amigos { get; set; }

        public ModelContext(DbContextOptions<ModelContext> options) : base(options)
        {

        }
    }
}
