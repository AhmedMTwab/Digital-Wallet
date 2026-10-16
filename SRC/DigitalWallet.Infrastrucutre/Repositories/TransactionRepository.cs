using DigitalWallet.Domain.Models;
using DigitalWallet.Domain.RepositoryInterfaces;
using DigitalWallet.Infrastrucutre.Context;
using Microsoft.EntityFrameworkCore;

namespace DigitalWallet.Infrastrucutre.Repositories;

public class TransactionRepository(ApplicationDbContext _context):ITransactionRepository
{
    public async Task<List<long>> CheckTransactionsListExist(List<long> transactionsRefrences)
    {
       var existedTransactions=await _context.transactions.Where(t => transactionsRefrences.Contains(t.RefrenceNumber)).Select(t=>t.RefrenceNumber).ToListAsync();
       return transactionsRefrences.Except(existedTransactions).ToList();
    }

    public async Task<bool> SaveTransactionsList(List<TransferTransaction> transactionsList)
    {
        await _context.transactions.AddRangeAsync(transactionsList);
        return await _context.SaveChangesAsync() > 0;
    }
}