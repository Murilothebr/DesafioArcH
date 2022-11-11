using Microsoft.AspNetCore.Mvc;
using TransacaoAPI.Entity;
using TransacaoAPI.Repositories;

namespace TransacaoAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TransactionController : ControllerBase
    {

        private readonly ITransactRepository _repository;

        public TransactionController(ITransactRepository _repository)
        {
            _repository = _repository ??throw new ArgumentNullException(nameof(_repository));
        }

        [HttpGet(Name = "Get transaction")]
        public Transaction Get()
        {
            return new Transaction
            {
                ID = "381939801",
                Value = 8291,
            };
        }
    }
}