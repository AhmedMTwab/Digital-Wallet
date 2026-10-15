namespace DigitalWallet.Domain.RepositoryInterfaces;

public interface ITransactionRepository
{
    public Task<List<long>> CheckTransactionsListExist(List<long> transactionsRefrences);
}