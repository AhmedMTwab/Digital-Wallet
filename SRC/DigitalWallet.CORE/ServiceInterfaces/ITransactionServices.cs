using DigitalWallet.CORE.DTOs;

namespace DigitalWallet.CORE.ServiceInterfaces;

public interface ITransactionServices
{
    public Task<List<long>> CheckTransactionsListExist(List<long> transactionsRefrences);
    public Task<bool> SaveTransactionsList(List<ParsedTransactionDTO> transactions,string accountNumber);

}