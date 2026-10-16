using DigitalWallet.CORE.DTOs;
using DigitalWallet.CORE.ServiceInterfaces;
using DigitalWallet.CORE.Services;
using Hangfire;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DigitalWallet.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WalletController(IBankParserFactory _bankParserFactory,IHandleTransactionRequest _service,IClientService _clientService,ISendMoneyService _sendMoneyService) : ControllerBase
    {
        [HttpPost]
        [Route("receive/{bankName}")]
        public async Task<IActionResult> ReciveMoney(string bankName, [FromHeader] string accountNumber)
        {
            if (!await _clientService.CheckClientExists(accountNumber))
            {
                return BadRequest();
            }
            var parser = await _bankParserFactory.CreateParser(bankName);
            if (parser == null)
            {
                return BadRequest();
            }
            var payload = await new StreamReader(Request.Body).ReadToEndAsync();
            string[] transactions = payload.Split("\n");
            BackgroundJob.Enqueue( () => _service.HandleTransactions(transactions, parser, accountNumber));
           return Ok();
        }

        [HttpPost]
        [Route("transfer")]
        [Produces("application/xml")]
        public async Task<IActionResult> SendMoney(SendMoneyDTO  sendMoneyDto)
        {
           var paymentMessage= _sendMoneyService.Handle(sendMoneyDto);
           return Ok(paymentMessage); 
        }


    }
}
