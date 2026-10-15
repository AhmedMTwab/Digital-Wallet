using System;
using System.ComponentModel;
using Microsoft.EntityFrameworkCore;


namespace DigitalWallet.Domain.Models;
[Index("AccountNumber",IsUnique =true)]
public class Client
{
    public Guid Id { get; set; }
    public string AccountNumber { get; set; }
    public string BeneficiaryName { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    public virtual List<TransferTransaction> TransferTransactions { get; set; } = new();
}
