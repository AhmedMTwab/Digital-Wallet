using System;
using Microsoft.EntityFrameworkCore;
using DigitalWallet.Domain.Models;
using System.Transactions;

namespace DigitalWallet.Infrastrucutre.Context;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }
    public DbSet<Client> clients { get; set; }
    public DbSet<TransferTransaction> transactions { get; set; }
    public DbSet<TransactionNotes> transactionNotes { get; set; }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
    }
}
