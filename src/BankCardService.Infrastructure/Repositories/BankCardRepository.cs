
using BankCardService.Application.Interfaces;
using BankCardService.Infrastructure.Data;

namespace BankCardService.Infrastructure.Repositories;

public class BankCardRepository : IBankCardRepository
{
    private readonly  BankCardDbContext _context;

    public BankCardRepository (BankCardDbContext context)
    {
        _context = context;
    }




}
