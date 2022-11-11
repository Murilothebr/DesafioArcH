using TransacaoAPI.Entity;

namespace TransacaoAPI.Repositories
{
    public interface ITransactRepository
    {
        Task<IEnumerable<Transaction>> GetTransactions();
        Task<Transaction> GetTransaction(String ID);

        Task CreateTransaction(Transaction transaction);
        Task<bool> UpdateProduct(Transaction transaction);
        Task<bool> deleteProduct(String ID);
    }
}
