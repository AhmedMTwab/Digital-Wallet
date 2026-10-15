using System;
using System.Collections.Generic;
using System.Globalization;
using DigitalWallet.CORE.DTOs;
using DigitalWallet.CORE.ServiceInterfaces;

namespace DigitalWallet.CORE.Services;

public class PayTechRequestParser : IRequestParser
{
    public async Task<List<ParsedTransactionDTO>> Parse(string[] transactions)
    {
        var parsedTransactions = new List<ParsedTransactionDTO>();

        foreach (var transaction in transactions)
        {
            var dateSpan = transaction.Substring(0, 8);
            var rest = transaction.Substring(8);

            var date = DateOnly.ParseExact(dateSpan, "yyyyMMdd", null);
            var components = rest.Split("#");
            var amount = decimal.Parse(
                components[0].Replace(',', '.'),
                NumberStyles.AllowDecimalPoint,
                CultureInfo.InvariantCulture.NumberFormat);

            var referenceNumber = long.Parse(components[1]);
            if (parsedTransactions.Any(t => t.ReferenceNumber == referenceNumber))
            {
                continue;
            }
            var keyValuePairs = new Dictionary<string, string>();
            var notes = components[2].Split("/");

            for (int i = 0; i < notes.Length; i += 2)
            {
                keyValuePairs.Add(notes[i], notes[i + 1]);
            }

            var parsedTransaction = new ParsedTransactionDTO
            {
                Date = date,
                Amount = amount,
                ReferenceNumber = referenceNumber,
                Notes = keyValuePairs
            };

            parsedTransactions.Add(parsedTransaction);
        }

        return parsedTransactions;
    }
}