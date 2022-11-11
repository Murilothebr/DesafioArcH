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

    Task ITransactRepository.CreateTransaction(Transaction transaction)
    {
        throw new NotImplementedException();
    }

    Task<bool> ITransactRepository.deleteProduct(string ID)
    {
        throw new NotImplementedException();
    }

    async Task<Transaction> ITransactRepository.GetTransaction(string ID)
    {
        return await _contexto.Transaction.Find(p => true).ToListAsync();
    }

    Task<IEnumerable<Transaction>> ITransactRepository.GetTransactions()
    {
        throw new NotImplementedException();
    }

    Task<bool> ITransactRepository.UpdateProduct(Transaction transaction)
    {
        throw new NotImplementedException();
    }
}
