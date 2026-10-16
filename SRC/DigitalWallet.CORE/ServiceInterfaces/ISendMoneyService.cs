using DigitalWallet.CORE.DTOs;

namespace DigitalWallet.CORE.ServiceInterfaces;

public interface ISendMoneyService
{
    public PaymentRequestMessage Handle(SendMoneyDTO  sendMoneyDto);
}