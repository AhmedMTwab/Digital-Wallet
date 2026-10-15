using DigitalWallet.CORE.DTOs;
using DigitalWallet.CORE.ServiceInterfaces;
using DigitalWallet.CORE.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DigitalWallet.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WalletController(IBankParserFactory _bankParserFactory,ITransactionServices _service) : ControllerBase
    {
        [HttpPost]
        [Route("{bankName}")]
        public async Task<IActionResult> ReciveMoney(string bankName, [FromHeader] string accountNumber)
        {
            var payload = await new StreamReader(Request.Body).ReadToEndAsync();
            string[] transactions = payload.Split("\n");
            var parser = await _bankParserFactory.CreateParser(bankName);
            if (parser == null)
            {
                return BadRequest();
            }
            var parsedTransactions = await parser.Parse(transactions);
            var unexistedTransactions = await ExcludeExistedTransactions(parsedTransactions);
           return Ok();
        }

        private async  Task<IEnumerable<ParsedTransactionDTO>> ExcludeExistedTransactions(
            List<ParsedTransactionDTO> parsedTransactions)
        {
            var parsedTransactionsRefrences = parsedTransactions.Select(t => t.ReferenceNumber).ToList();
            var unexistedTransactionsRefrenceNumbers=await _service.CheckTransactionsListExist(parsedTransactionsRefrences);
            var unexistedTransactions =parsedTransactions.Where(t=>unexistedTransactionsRefrenceNumbers.Contains(t.ReferenceNumber));
            return unexistedTransactions;
        }
    }
}
