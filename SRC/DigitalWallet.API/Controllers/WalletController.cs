using DigitalWallet.CORE.ServiceInterfaces;
using DigitalWallet.CORE.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DigitalWallet.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WalletController(IBankParserFactory _bankParserFactory) : ControllerBase
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

            return Ok();
        }
    }
}
