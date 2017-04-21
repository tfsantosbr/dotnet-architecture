using System.Collections.Generic;

namespace Project.UnitOfWorkProjectProject.Entities
{
    public class Pais : Entity<int>
    {
        public string Nome { get; set; }

        public virtual ICollection<Usuario> Usuarios { get; set; }
    }
}
