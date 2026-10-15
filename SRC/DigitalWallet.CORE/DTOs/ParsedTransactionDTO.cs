using System;

namespace DigitalWallet.CORE.DTOs
{
    public class ParsedTransactionDTO
    {
        public DateOnly Date { get; set; }
        public decimal Amount { get; set; }
        public string ReferenceNumber { get; set; } = string.Empty;
        public Dictionary<string, string> Notes { get; set; } = new();
    }
}
