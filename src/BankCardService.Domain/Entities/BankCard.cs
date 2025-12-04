using BankCardService.Domain.ValueObjects;

namespace BankCardService.Domain.Entities;


public class BankCard
{
    public Guid Id { get; set; }
    public required CardNumberVO CardNumber { get; set; }
    public required string CardHolder { get; set; }
    public DateTime ExpirationDate { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    public decimal Balance { get; set; }
    public bool IsActive { get; set; }

    private BankCard() { }

    public BankCard (string cardNumber, string cardHolder)
    {
        Id = Guid.NewGuid();
        CardNumber = new CardNumberVO(cardNumber);
        ChangeCardHolder(cardHolder); 
        ExpirationDate = DateTime.UtcNow.AddYears(7);
        CreatedAt = DateTime.UtcNow;
        Balance = 0;
        IsActive = true;
    }

    public void ChangeCardNumber(CardNumberVO newCardNumber)
    {
        CardNumber = newCardNumber;
        UpdatedAt = DateTime.UtcNow;
    }

    public void ChangeCardHolder(string newCardHolder)
    {
        if (string.IsNullOrWhiteSpace(newCardHolder))
            throw new ArgumentException("CardHolder cannot be empty");
        CardHolder = newCardHolder;
        UpdatedAt = DateTime.UtcNow;
    }

    public void Deposit(decimal amount)
    {
        if (amount <= 0) throw new ArgumentException("Deposit amount must be positive");
        Balance += amount;
        UpdatedAt = DateTime.UtcNow;
    }

    public void Withdrawal(decimal amount)
    {
        if (amount <= 0) throw new ArgumentException("Withdrawal amount must be positive");
        if (amount > Balance) throw new InvalidOperationException("Not enough money");
        Balance -= amount;
        UpdatedAt = DateTime.UtcNow;
    }

    public void Activate() => IsActive = true;
    public void Deactivate() => IsActive = false;

}
