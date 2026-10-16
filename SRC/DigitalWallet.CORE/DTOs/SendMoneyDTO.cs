namespace DigitalWallet.CORE.DTOs;

public class SendMoneyDTO
{
    public decimal Amount { get; set; }
    public string currency {get; set;}
    public string senderAccountNumber { get; set; }
    public string receiverAccountNumber { get; set; }
    public string receiverBankCode { get; set; }
    public string receiverBeneficiaryName { get; set; }
    public List<string>? Notes {get; set;}
    public string paymentType {get; set;}
    public string chargeDetails {get; set;}
}