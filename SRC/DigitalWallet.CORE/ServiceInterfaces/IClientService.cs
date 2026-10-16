namespace DigitalWallet.CORE.ServiceInterfaces;

public interface IClientService
{
    public Task<bool> CheckClientExists(string accountNumber);
}