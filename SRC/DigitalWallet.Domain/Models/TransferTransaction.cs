using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DigitalWallet.Domain.Models;


public class TransferTransaction
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.None)]
    public long RefrenceNumber { get; set; }
    public DateOnly Date { get; set; }
    public decimal Amount { get; set; }
    public DateTime CreatedAt { get; set; }
    [ForeignKey("Reciver")]
    public Guid ReciverId {get;set;}


    public virtual Client Reciver { get; set; } = new();
    public virtual List<TransactionNotes> Notes { get; set; } = new();
}
