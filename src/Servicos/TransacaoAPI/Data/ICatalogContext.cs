using MongoDB.Driver;
using TransacaoAPI.Entity;

namespace TransacaoAPI.Data;

public interface ICatalogContext
{
    IMongoCollection<Transaction> transactions { get; }
}