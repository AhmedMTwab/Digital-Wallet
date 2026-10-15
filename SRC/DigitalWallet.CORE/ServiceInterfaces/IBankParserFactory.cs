using System;

namespace DigitalWallet.CORE.ServiceInterfaces;

public interface IBankParserFactory
{
    public Task<IRequestParser> CreateParser(string bankName);
}
