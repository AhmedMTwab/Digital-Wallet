using System;
using System.Collections.Generic;
using System.Xml.Serialization;
namespace DigitalWallet.CORE.DTOs;

[XmlRoot("PaymentRequestMessage")]
public class PaymentRequestMessage
{
    [XmlElement("TransferInfo")]
    public TransferInfo TransferInfo { get; set; }

    [XmlElement("SenderInfo")]
    public SenderInfo SenderInfo { get; set; }

    [XmlElement("ReceiverInfo")]
    public ReceiverInfo ReceiverInfo { get; set; }

    [XmlArray("Notes")]
    [XmlArrayItem("Note")]
    public List<string>? Notes { get; set; }

    [XmlElement("PaymentType")]
    public string? PaymentType { get; set; }

    [XmlElement("ChargeDetails")]
    public string? ChargeDetails { get; set; }
}

public class TransferInfo
{
    [XmlElement("Reference")]
    public string Reference { get; set; }

    [XmlElement("Date")]
    public string Date { get; set; } 

    [XmlElement("Amount")]
    public decimal Amount { get; set; }

    [XmlElement("Currency")]
    public string Currency { get; set; }
}

public class SenderInfo
{
    [XmlElement("AccountNumber")]
    public string AccountNumber { get; set; }
}

public class ReceiverInfo
{
    [XmlElement("BankCode")]
    public string BankCode { get; set; }

    [XmlElement("AccountNumber")]
    public string AccountNumber { get; set; }

    [XmlElement("BeneficiaryName")]
    public string BeneficiaryName { get; set; }
}
