using MongoDB.Driver;
using TransacaoAPI.Entity;

namespace TransacaoAPI.Data;

public interface ICatalogContext
{
     public IMongoCollection<Transaction> Transact { get; }
}