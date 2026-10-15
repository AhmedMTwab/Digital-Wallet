using System;
using DigitalWallet.CORE.DTOs;

namespace DigitalWallet.CORE.ServiceInterfaces;

public interface IRequestParser
{
    public Task<List<ParsedTransactionDTO>> Parse(string[] transacitons);
}
