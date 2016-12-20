using MongoDB.Driver;
using Project.Models.Core.Entities;
using Project.Persistence.Core.Contexts.Base;

namespace Project.Persistence.Core.Contexts
{
    public class CoreMongoContext : MongoContextBase
    {
        #region - CONSTRUCTORS -

        public CoreMongoContext()
            : base()
        {
        }

        public CoreMongoContext(string connectionString)
            : base(connectionString)
        {
        }

        #endregion

        #region - COLLECTIONS -

        public IMongoCollection<Client> Clients { get; set; }
        public IMongoCollection<RefreshToken> RefreshTokens { get; set; }
        public IMongoCollection<Role> Roles { get; set; }
        public IMongoCollection<Usuario> Usuarios { get; set; }
        public IMongoCollection<UsuarioClaim> UsuarioClaims { get; set; }
        public IMongoCollection<UsuarioRole> UsuarioRoles { get; set; }

        #endregion

        #region - MAIN METHODS -

        public override void OnModelCreating()
        {
            Clients = GetCollection<Client>();
            RefreshTokens = GetCollection<RefreshToken>();
            Roles = GetCollection<Role>();
            Usuarios = GetCollection<Usuario>();
            UsuarioClaims = GetCollection<UsuarioClaim>();
            UsuarioRoles = GetCollection<UsuarioRole>();
        }

        #endregion
    }
}
