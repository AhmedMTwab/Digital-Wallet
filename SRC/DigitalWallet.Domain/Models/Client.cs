using System;

namespace DigitalWallet.Domain.Models;

public class Client
{
    public Guid Id { get; set; }
    public string AccountNumber { get; set; }
    public string BeneficiaryName { get; set; }
    public virtual List<TransferTransaction> TransferTransactions { get; set; } = new();
}
