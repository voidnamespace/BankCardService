using BankCardService.Application.DTOs;
namespace BankCardService.Application.Interfaces;
public interface IBankCardService
{
    Task<BankCardDTO> CreateAsync(CreateBankCardDTO createBankCardDTO);

    Task DepositAsync (Guid cardId, decimal amount);

    Task WithdrawalAsync(Guid cardId, decimal amount);

    Task ActivateAsync(Guid cardId);

    Task DeactivateAsync(Guid cardId);

    Task ChangeCardHolderAsync(Guid cardId, string newHolder);

    Task ChangeCardNumberAsync(Guid cardId, string newNumber);

    Task<BankCardDTO> GetByIdAsync(Guid cardId);

    Task<IEnumerable<BankCardDTO>> GetAllAsync();
}