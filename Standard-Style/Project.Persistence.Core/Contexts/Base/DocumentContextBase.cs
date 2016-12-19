using MongoDB.Driver;
using Project.Configurations;

namespace Project.Persistence.Core.Contexts.Base
{
    public abstract class DocumentContextBase
    {
        #region - PROPERTIES -

        public readonly MongoClient _client;
        public readonly IMongoDatabase _dataBase;

        #endregion

        #region - CONSTRUCTORS -

        public DocumentContextBase()
            : this(ConnectionStrings.MongoConnection)
        {
        }

        public DocumentContextBase(string connectionString)
        {
            var url = MongoUrl.Create(connectionString);

            _client = new MongoClient(url);
            _dataBase = _client.GetDatabase(url.DatabaseName);

            OnModelCreating();
        }

        #endregion

        #region - MAIN METHODS -

        public abstract void OnModelCreating();

        public IMongoCollection<T> GetCollection<T>()
        {
            return _dataBase.GetCollection<T>(nameof(T).ToLower());
        }

        #endregion
    }
}
