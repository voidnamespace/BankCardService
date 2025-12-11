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

    public async Task<BankCardDTO> CreateAsync(CreateBankCardDTO createBankCardDTO)
    {
        if (createBankCardDTO == null)
            throw new ArgumentNullException(nameof(createBankCardDTO));

        var card = new BankCard(
            cardNumber: createBankCardDTO.CardNumber,
            cardHolder: createBankCardDTO.CardHolder
        );

        await _bankCardRepository.AddAsync(card);
        await _bankCardRepository.SaveAsync();

        return new BankCardDTO
        {
            Id = card.Id,
            CardNumber = card.CardNumber.Value,
            CardHolder = card.CardHolder,
            ExpirationDate = card.ExpirationDate,
            Balance = card.Balance,
            IsActive = card.IsActive
        };
    }

    public async Task DepositAsync(Guid cardId, decimal amount)
    {
        var card = await _bankCardRepository.GetByIdAsync(cardId);
        if (card == null)
            throw new KeyNotFoundException("Bank card not found");
        if (amount <= 0)
            throw new ArgumentException("Amount can not be less than/equal to zero");
        card.Deposit(amount);
        await _bankCardRepository.SaveAsync();
    }

    public async Task WithdrawalAsync(Guid cardId, decimal amount)
    {
        if (amount <= 0)
            throw new ArgumentException("Amount can not be less than/equal to zero");
        var card = await _bankCardRepository.GetByIdAsync(cardId);
        if (card == null)
            throw new KeyNotFoundException("Bank card not found");
        card.Withdrawal(amount);
        await _bankCardRepository.SaveAsync();
    }

    public async Task ActivateAsync(Guid cardId)
    {
        var card = await _bankCardRepository.GetByIdAsync(cardId);
        if (card == null)
            throw new KeyNotFoundException("Bank card not found");
        card.Activate();
        await _bankCardRepository.SaveAsync();
    }

    public async Task DeactivateAsync(Guid cardId)
    {
        var card = await _bankCardRepository.GetByIdAsync(cardId);
        if (card == null)
            throw new KeyNotFoundException("Bank card not found");
        card.Deactivate();
        await _bankCardRepository.SaveAsync();
    }

    public async Task ChangeCardHolderAsync(Guid cardId, string newHolder)
    {
        var card = await _bankCardRepository.GetByIdAsync(cardId);
        if (card == null)
            throw new KeyNotFoundException("Bank card not found");
        card.ChangeCardHolder(newHolder);
        await _bankCardRepository.SaveAsync();
    }

    public async Task ChangeCardNumberAsync(Guid cardId, string newNumber)
    {
        var card = await _bankCardRepository.GetByIdAsync(cardId);
        if (card == null)
            throw new KeyNotFoundException("Bank card not found");
        var cardNumberVO = new CardNumberVO(newNumber);
        card.ChangeCardNumber(cardNumberVO);
        await _bankCardRepository.SaveAsync();
    }
    
    public async Task<BankCardDTO> GetByIdAsync(Guid cardId)
    {
        var card = await _bankCardRepository.GetByIdAsync(cardId);
        if (card == null)
            throw new KeyNotFoundException("Bank card not found");

        return new BankCardDTO
        {
            Id = card.Id,
            CardNumber = card.CardNumber.Value,
            CardHolder = card.CardHolder,
            ExpirationDate = card.ExpirationDate,
            Balance = card.Balance,
            IsActive = card.IsActive
        };
            
    }
}

    
  

