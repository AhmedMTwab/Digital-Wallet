using DigitalWallet.CORE.ServiceInterfaces;
using DigitalWallet.Domain.RepositoryInterfaces;

namespace DigitalWallet.CORE.Services;

public class ClientService(IClientRepository _repo):IClientService
{
    public async Task<bool> CheckClientExists(string accountNumber)
    {
      var result =await _repo.CheckClientExists(accountNumber);
      return result;
    }
}