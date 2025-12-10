using BankCardService.Application.DTOs;
using BankCardService.Application.Interfaces;
using BankCardService.Domain.Entities;
using BankCardService.Domain.ValueObjects;


namespace BankCardService.Application.Service;

public class BankCardService : IBankCardService
{
    private readonly IBankCardRepository _bankCardRepository;

    public BankCardService(IBankCardRepository bankCardRepository)
    {
        _bankCardRepository = bankCardRepository;
    }


    public async Task DepositAsync (Guid id, decimal amount)
    {
        var card = await _bankCardRepository.GetByIdAsync(id);
        if (card == null)
            throw new KeyNotFoundException("Bank card not found");
        if (amount == 0 || amount < 0)
            throw new ArgumentException("Amount can not be less than/equal to zero");
        card.Deposit(amount);
        await _bankCardRepository.SaveAsync();
    }

}

    
  

