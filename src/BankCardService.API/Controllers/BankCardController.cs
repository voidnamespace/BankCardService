using BankCardService.Application.DTOs;
using BankCardService.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BankCardService.API.Controllers;


[ApiController]
[Route("api/[controller]")]
public class BankCardController : ControllerBase
{
    private readonly IBankCardService _bankCardService;

    public BankCardController(IBankCardService bankCardService)
    {
        _bankCardService = bankCardService;
    }



    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateBankCardDTO createBankCardDTO)
    {
        var response = await _bankCardService.CreateAsync(createBankCardDTO);
        return CreatedAtAction(nameof(GetById), new { id = response.Id }, response);
    }

    [HttpGet("user")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    public async Task<IActionResult> GetById(Guid cardId)
    {
        var response = await _bankCardService.GetByIdAsync(cardId);
        return Ok(response);
    }

    [HttpGet("users")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    public async Task<IActionResult> GetAll()
    {
        var response = await _bankCardService.GetAllAsync();
        return Ok(response);
    }

    [HttpPut("{cardId}/deposit")]

    public async Task<IActionResult> Deposit(Guid cardId, decimal amount)
    {
        await _bankCardService.DepositAsync(cardId, amount);
        return Ok(new { Message = "Deposit successful" });
    }

    [HttpPut("{cardId}/withdrawal")]
    public async Task<IActionResult> Withdrawal(Guid cardId, decimal amount)
    {
        await _bankCardService.WithdrawalAsync(cardId, amount);
        return Ok(new { Message = "Withdrawal successful" });
    }

    [HttpPut("{cardId}/activate")]
    public async Task<IActionResult> Activate(Guid cardId)
    {
        await _bankCardService.ActivateAsync(cardId);
        return Ok(new { Message = "Activate successful" });
    }

    [HttpPut("{cardId}/deactivate")]
    public async Task<IActionResult> Deactivate(Guid cardId)
    {
        await _bankCardService.DeactivateAsync(cardId);
        return Ok(new { Message = "Deactivate successful" });
    }

    [HttpPut("{cardId}/changeHolder")]
    public async Task<IActionResult> ChangeCardHolder(Guid cardId, string newHolder)
    {
        await _bankCardService.ChangeCardHolderAsync(cardId, newHolder);
        return Ok(new { Message = "Card holder change successful" });
    }

    [HttpPut("{cardId}/changeNumber")]
    public async Task<IActionResult> ChangeCardNumber( Guid cardId, string newNumber)
    {
        await _bankCardService.ChangeCardNumberAsync(cardId, newNumber);
        return Ok(new { Message = "Card number change successfull" });
    }
}