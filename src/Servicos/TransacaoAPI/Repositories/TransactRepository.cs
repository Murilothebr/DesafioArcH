using MongoDB.Driver;
using TransacaoAPI.Data;
using TransacaoAPI.Entity;

namespace TransacaoAPI.Repositories;

public class TransactRepository : ITransactRepository
{
    private readonly ICatalogContext _contexto;

    public TransactRepository(ICatalogContext context)
    {
        _contexto = context ?? throw new ArgumentException(nameof(context));    
    }

    async Task ITransactRepository.CreateTransaction(Transaction transaction)
    {
        await _contexto.Transact.InsertOneAsync(transaction);
    }

    async Task<bool> ITransactRepository.deleteTransaction(string ID)
    {
        FilterDefinition<Transaction> filterCriteria = Builders<Transaction>.Filter.Eq(x => x.ID, ID);

        DeleteResult deleteResult = await _contexto.Transact.DeleteOneAsync(filterCriteria);

        return deleteResult.IsAcknowledged && deleteResult.DeletedCount > 0;
    }

    async Task<Transaction> ITransactRepository.GetTransaction(string ID)
    {
        return await _contexto.Transact.Find(p => p.ID == ID).FirstOrDefaultAsync();
    }

    async Task<IEnumerable<Transaction>> ITransactRepository.GetTransactions()
    {
        return await _contexto.Transact.Find(x => true).ToListAsync();
    }

    async Task<bool> ITransactRepository.UpdateTransaction(Transaction transaction)
    {
        var updateResult = await _contexto.Transact.ReplaceOneAsync
            (filter: guid => guid.ID == transaction.ID, replacement: transaction);

        return updateResult.IsAcknowledged && updateResult.ModifiedCount > 0;
    }
}
