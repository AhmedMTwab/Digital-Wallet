using DigitalWallet.CORE.DTOs;
using DigitalWallet.CORE.ServiceInterfaces;

namespace DigitalWallet.CORE.Services;

public class SendMoneyService:ISendMoneyService
{
    public PaymentRequestMessage Handle(SendMoneyDTO sendMoneyDto)
    {
        PaymentRequestMessage paymentResponse = new PaymentRequestMessage()
        {
            TransferInfo = new()
            {
                Reference = Guid.NewGuid().ToString(),
                Date = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ssz"),
                Amount = sendMoneyDto.Amount,
                Currency = sendMoneyDto.currency
            },
            SenderInfo = new SenderInfo()
            {
                AccountNumber = sendMoneyDto.senderAccountNumber
            },
            ReceiverInfo = new ReceiverInfo()
            {
                BankCode = sendMoneyDto.receiverBankCode,
                AccountNumber = sendMoneyDto.receiverAccountNumber,
                BeneficiaryName = sendMoneyDto.receiverBeneficiaryName
            }
        };
        if (sendMoneyDto.Notes != null)
        {
            paymentResponse.Notes = sendMoneyDto.Notes;
        }

        if (sendMoneyDto.paymentType != "99")
        {
            paymentResponse.PaymentType = sendMoneyDto.paymentType;
        }

        if (sendMoneyDto.chargeDetails != "SHA")
        {
            paymentResponse.ChargeDetails = sendMoneyDto.chargeDetails;
        }
        return paymentResponse;
    }
}