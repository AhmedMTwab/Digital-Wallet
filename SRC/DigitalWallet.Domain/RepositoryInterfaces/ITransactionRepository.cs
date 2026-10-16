using DigitalWallet.Domain.Models;

namespace DigitalWallet.Domain.RepositoryInterfaces;

public interface ITransactionRepository
{
    public Task<List<long>> CheckTransactionsListExist(List<long> transactionsRefrences);
    public Task<bool> SaveTransactionsList(List<TransferTransaction> transactionsList);
}