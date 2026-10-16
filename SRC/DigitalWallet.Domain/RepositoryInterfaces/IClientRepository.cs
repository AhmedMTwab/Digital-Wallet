using DigitalWallet.Domain.Models;

namespace DigitalWallet.Domain.RepositoryInterfaces;

public interface IClientRepository
{
    public Task<Client> GetClientByAccountNumber(string accountNumber);
    public Task<bool>  CheckClientExists(string accountNumber);
}