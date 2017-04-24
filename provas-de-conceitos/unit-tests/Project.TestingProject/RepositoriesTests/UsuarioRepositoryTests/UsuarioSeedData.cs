using Project.TestingProject.Base;
using Project.UnitOfWorkProject.Entities;
using System.Collections.Generic;

namespace Project.TestingProject.RepositoriesTests.UsuarioRepositoryTests.UsuarioRepositorySeed
{
    public class UsuarioSeedData : GenericSeedData<Usuario>, ISeedData
    {
        public UsuarioSeedData()
        {
            DataList = new List<Usuario>
            {
                new Usuario { Nome = "us1", Email = "us1@email.com", Status = UsuarioStatus.Ativo },
                new Usuario { Nome = "us2", Email = "us2@email.com", Status = UsuarioStatus.Inativo },
                new Usuario { Nome = "us3", Email = "us3@email.com", Status = UsuarioStatus.Ativo }
            };
        }
    }
}
