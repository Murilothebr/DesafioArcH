using MongoDB.Driver;
using TransacaoAPI.Entity;

namespace TransacaoAPI.Data;

public class CatalogContext : ICatalogContext
{
    public IMongoCollection<Transaction> transactions { get; }

    public CatalogContext(IConfiguration configuration)
    {
        var client = new MongoClient(configuration.GetValue<string>("DatabaseSettings:ConnectionString"));
        var database = client.GetDatabase(configuration.GetValue<string>("DatabaseSettings:Database"));
        transactions = database.GetCollection<Transaction>(configuration.GetValue<string>("DatabaseSettings:Collection"));

        CatalogContextoSeed.SetData(transactions);
    }
}
