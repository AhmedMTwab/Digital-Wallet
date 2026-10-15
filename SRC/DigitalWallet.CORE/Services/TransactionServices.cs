using DigitalWallet.CORE.ServiceInterfaces;
using DigitalWallet.Domain.RepositoryInterfaces;

namespace DigitalWallet.CORE.Services;

public class TransactionServices(ITransactionRepository _repo):ITransactionServices
{
    public async Task<List<long>> CheckTransactionsListExist(List<long> transactionsRefrences)
    {
        var unexistedRefrences=await _repo.CheckTransactionsListExist(transactionsRefrences);
        return unexistedRefrences;
    }
}