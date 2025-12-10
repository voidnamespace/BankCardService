using BankCardService.Application.Interfaces;
using BankCardService.Domain.ValueObjects;
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
            throw new KeyNotFoundException("Bank card not found");
        card.Deposit(amount);
        await _context.SaveChangesAsync();
    }

    public async Task WithdrawalAsync(Guid cardId, decimal amount)
    {
        var card = await _context.BankCards.FindAsync(cardId);
        if (card == null)
            throw new KeyNotFoundException("Bank card not found");
        card.Withdrawal(amount);
        await _context.SaveChangesAsync();
    }

    public async Task ActivateAsync(Guid cardId)
    {
        var card = await _context.BankCards.FindAsync(cardId);
        if (card == null)
            throw new KeyNotFoundException("Bank card not found");
        card.Activate();
        await _context.SaveChangesAsync();
    }

    public async Task DeactivateAsync(Guid cardId)
    {
        var card = await _context.BankCards.FindAsync(cardId);
        if (card == null)
            throw new KeyNotFoundException("Bank card not found");
        card.Deactivate();
        await _context.SaveChangesAsync();
    }
    public async Task ChangeCardHolderAsync(Guid cardId, string newHolder)
    {
        var card = await _context.BankCards.FindAsync(cardId);
        if (card == null)
            throw new KeyNotFoundException("Bank card not found");
        card.ChangeCardHolder(newHolder);
        await _context.SaveChangesAsync();
    }
    public async Task ChangeCardNumberAsync(Guid cardId, string newNumber)
    {
        var card = await _context.BankCards.FindAsync(cardId);
        if (card == null)
            throw new KeyNotFoundException("Bank card not found");
        var cardNumberVo = new CardNumberVO(newNumber);
        card.ChangeCardNumber(cardNumberVo);
        await _context.SaveChangesAsync();
    }

}
