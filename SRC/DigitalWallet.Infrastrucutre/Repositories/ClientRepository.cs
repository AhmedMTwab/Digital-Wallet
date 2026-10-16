using DigitalWallet.Domain.Models;
using DigitalWallet.Domain.RepositoryInterfaces;
using DigitalWallet.Infrastrucutre.Context;
using Microsoft.EntityFrameworkCore;

namespace DigitalWallet.Infrastrucutre.Repositories;

public class ClientRepository(ApplicationDbContext _context):IClientRepository
{
    public async Task<Client> GetClientByAccountNumber(string accountNumber)
    {
        return await _context.clients.FirstOrDefaultAsync(c => c.AccountNumber == accountNumber);
    }

    public async Task<bool> CheckClientExists(string accountNumber)
    {
        var result= await _context.clients.AnyAsync(c=>c.AccountNumber == accountNumber);
        return result;
    }
}