using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TransacaoAPI.Entity;
using TransacaoAPI.Repositories;

namespace TransacaoAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CatalogController : ControllerBase{
    private readonly ITransactRepository _repo;

    public CatalogController(ITransactRepository _repository) {
        _repo = _repository ?? throw new ArgumentNullException(nameof(_repository));
    }

    public async Task<ActionResult<IEnumerable<Transaction>>> getTransactions() {
        var transactions = await _repo.GetTransactions();
        return Ok(transactions);
    }

    public async Task<ActionResult<Transaction>> GetbyID(string ID)
    {
        var transaction = await _repo.GetTransaction(ID);
        if (transaction is null) //Is keyword é igual a  "=="
        {
            return NotFound();
        }
        return Ok(transaction);
    }

    public async Task<ActionResult<Transaction>> Update(Transaction transaction)
    {
        if (transaction is null) //Is keyword é igual a  "=="
        {
            return BadRequest("Transação não foi achada");
        }
        return Ok(await _repo.UpdateTransaction(transaction));
    }

    public async Task<ActionResult<Transaction>> DeletebyID(String ID)
    {
        return Ok(await _repo.deleteTransaction(ID));
    }
}
