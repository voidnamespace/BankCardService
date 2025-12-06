using BankCardService.Domain.Entities;
using BankCardService.Application.Interfaces;
using BankCardService.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace BankCardService.Infrastructure.Repositories;

public class BankCardRepository : IBankCardRepository
{
    private readonly BankCardDbContext _context;

    public BankCardRepository (BankCardDbContext context)
    {
        _context = context;
    }

    public async Task<BankCard> CreateAsync(BankCard bankCard)
    {
        await _context.BankCards.AddAsync(bankCard);
        await _context.SaveChangesAsync();
        return bankCard;
    }

    public async Task<BankCard?> GetByIdAsync (Guid id)
    {
        var allBankCard = await _context.BankCards.ToListAsync();
        
        var bankCard = allBankCard.FirstOrDefault(x => x.Id == id);

        return bankCard;

    }

    public async Task<IEnumerable<BankCard>> GetAllAsync()
    {
        var all = await _context.BankCards.ToListAsync();
        return all;
    }

    public async Task UpdateAsync(Guid id, BankCard newBankCard)
    {
        var oldCard = await _context.BankCards.FindAsync(id);
        if (oldCard == null)
        {
            throw new ArgumentNullException("Old bank card not found");
        }
        oldCard = newBankCard;
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(Guid id)
    {
        var delBankCard = await _context.BankCards.FindAsync(id);
        if (delBankCard == null)
        {
            throw new ArgumentNullException("Bank card does not exist");
        }
        _context.BankCards.Remove(delBankCard);
        await _context.SaveChangesAsync();
    }
}
