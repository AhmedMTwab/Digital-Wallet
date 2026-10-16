using DigitalWallet.CORE.DTOs;
using DigitalWallet.CORE.ServiceInterfaces;

namespace DigitalWallet.CORE.Services;

public class HandleTransactionRequest(ITransactionServices _service):IHandleTransactionRequest
{
    public async Task HandleTransactions(string[] transactions, IRequestParser parser, string accountNumber)
    {
        var parsedTransactions = await parser.Parse(transactions);
        var unexistedTransactions = await ExcludeExistedTransactions(parsedTransactions);
        await _service.SaveTransactionsList(unexistedTransactions.ToList(), accountNumber);
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