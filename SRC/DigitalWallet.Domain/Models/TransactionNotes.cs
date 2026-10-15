using System.ComponentModel.DataAnnotations.Schema;

namespace DigitalWallet.Domain.Models;

public class TransactionNotes
{
    public int Id { get; set; }
    public string Key { get; set; }
    public string Value { get; set; }
    [ForeignKey("TransferTransaction")]
    public long TransactionReference { get; set; }

    public TransferTransaction TransferTransaction { get; set; } = new();
    public DateTime CreatedAt { get; set; }
    public DateTime ModifiedAt { get; set; }
}