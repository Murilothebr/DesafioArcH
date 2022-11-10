using MongoDB.Driver;
using TransacaoAPI.Entity;

namespace TransacaoAPI.Data;

public class CatalogContextoSeed
{
    public static void SetData(IMongoCollection<Transaction> Transactcollection)
    {
        bool existProduct = Transactcollection.Find(s => true).Any();
        if (!existProduct)
        {
            Transactcollection.InsertManyAsync(GetMany());
        }
    }

    private static IEnumerable<Transaction> GetMany()
    {
        return new List<Transaction>()
        {
            new Transaction()
            {
                ID = "19829813",
                Value = 11000,
            }
        };
    }
}
