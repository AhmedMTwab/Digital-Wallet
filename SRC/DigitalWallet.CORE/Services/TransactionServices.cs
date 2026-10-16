using DigitalWallet.CORE.DTOs;
using DigitalWallet.CORE.ServiceInterfaces;
using DigitalWallet.Domain.Models;
using DigitalWallet.Domain.RepositoryInterfaces;

namespace DigitalWallet.CORE.Services;

public class TransactionServices(ITransactionRepository _repo,IClientRepository _clinetRepo):ITransactionServices
{
    public async Task<List<long>> CheckTransactionsListExist(List<long> transactionsRefrences)
    {
        var unexistedRefrences=await _repo.CheckTransactionsListExist(transactionsRefrences);
        return unexistedRefrences;
    }

    public async Task<bool> SaveTransactionsList(List<ParsedTransactionDTO> transactions,string accountNumber)
    {
        List<TransferTransaction> transferTransactions = new List<TransferTransaction>();
        var client=await _clinetRepo.GetClientByAccountNumber(accountNumber);
        foreach (var transaction in transactions)
        {
            List<TransactionNotes> notes = new List<TransactionNotes>();
            foreach (var note in transaction.Notes)
            {notes.Add(new TransactionNotes(){Key = note.Key, Value = note.Value});}

            TransferTransaction transferTransaction = new TransferTransaction()
            {
                Amount = transaction.Amount,
                Date = transaction.Date,
                RefrenceNumber = transaction.ReferenceNumber,
                Notes = notes,
                Reciver = client,
                CreatedAt = DateTime.Now
            };
            transferTransactions.Add(transferTransaction);
        }

       return await  _repo.SaveTransactionsList(transferTransactions);
    }
}