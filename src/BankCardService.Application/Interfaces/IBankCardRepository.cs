using BankCardService.Application.DTOs;
using BankCardService.Domain.Entities;

namespace BankCardService.Application.Interfaces;

public interface IBankCardRepository
{
    Task<BankCard> CreateAsync(BankCardDTO bankCardDTO);
    Task<BankCard?> GetByIdAsync (Guid id);
    Task<IEnumerable<BankCard>> GetAllAsync();
    Task UpdateAsync(Guid id, BankCardDTO newBankCard);
    Task DeleteAsync(Guid id);

}
