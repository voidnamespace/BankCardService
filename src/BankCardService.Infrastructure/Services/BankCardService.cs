
using BankCardService.Application.Interfaces;
using BankCardService.Infrastructure.Data;
using Microsoft.Extensions.Logging;

namespace BankCardService.Infrastructure.Service;

public class BankCardService : IBankCardService
{
    private readonly ILogger<BankCardService> _logger;
    private readonly BankCardDbContext _context;

    public BankCardService (ILogger<BankCardService> logger, BankCardDbContext context)
    {
        _logger = logger;
        _context = context;
    }
    
    public async Task DepositAsync(Guid cardId, decimal amount)
    {
        var card = await _context.BankCards.FindAsync(cardId);
        if (card == null)
            throw new KeyNotFoundException("No such bank card");
        card.Deposit(amount);
        await _context.SaveChangesAsync();
    }

    public async Task WithdrawalAsync(Guid cardId, decimal amount)
    {
        var card = await _context.BankCards.FindAsync(cardId);
        if (card == null)
            throw new KeyNotFoundException("No such bank card");
        card.Withdrawal(amount);
        await _context.SaveChangesAsync();
    }



}
