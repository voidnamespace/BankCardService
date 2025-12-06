using BankCardService.Application.DTOs;
using BankCardService.Domain.Entities;

namespace BankCardService.Application.Interfaces;

public interface IBankCardRepository
{
    Task<BankCard> CreateAsync(BankCard bankCard);
    Task<BankCard?> GetByIdAsync (Guid id);
    Task<IEnumerable<BankCard>> GetAllAsync();
    Task UpdateAsync(Guid id, BankCard newBankCard);
    Task DeleteAsync(Guid id);

}
