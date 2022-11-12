using MongoDB.Driver;
using System.Transactions;
using TransacaoAPI.Entity;
using Transaction = TransacaoAPI.Entity.Transaction;

namespace TransacaoAPI.Data;

public class CatalogContext : ICatalogContext
{
    

    public IMongoCollection<Transaction> Transact { get; }

    public CatalogContext(IConfiguration configuration)
    {
        var client = new MongoClient(configuration.GetValue<string>("DatabaseSettings:ConnectionString"));
        var database = client.GetDatabase(configuration.GetValue<string>("DatabaseSettings:Database"));
        Transact = database.GetCollection<Transaction>(configuration.GetValue<string>("DatabaseSettings:Collection"));

        CatalogContextoSeed.SetData(Transact);
    }
}
