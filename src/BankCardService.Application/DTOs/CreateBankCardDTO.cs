namespace BankCardService.Application.DTOs;

public class CreateBankCardDTO
{
    public string CardNumber { get; set; } = null!;
    public string CardHolder { get; set; } = null!;
    public decimal InitialBalance { get; set; } = 0;
}
