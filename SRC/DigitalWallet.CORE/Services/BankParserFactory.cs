using System;
using DigitalWallet.CORE.ServiceInterfaces;

namespace DigitalWallet.CORE.Services;

public class BankParserFactory : IBankParserFactory
{
    public async Task<IRequestParser> CreateParser(string bankName)
    {
        if(bankName == "PayTech")
        {
            IRequestParser parser=new PayTechRequestParser();
            return parser;
        }
        return(null);
    }
}
