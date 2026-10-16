namespace DigitalWallet.CORE.ServiceInterfaces;

public interface IHandleTransactionRequest
{
    public Task HandleTransactions(string[] transactions, IRequestParser parser, string accountNumber);
}