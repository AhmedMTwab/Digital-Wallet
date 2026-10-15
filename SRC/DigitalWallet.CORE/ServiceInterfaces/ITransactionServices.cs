namespace DigitalWallet.CORE.ServiceInterfaces;

public interface ITransactionServices
{
    public Task<List<long>> CheckTransactionsListExist(List<long> transactionsRefrences);
}