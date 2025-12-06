using Microsoft.EntityFrameworkCore;
using BankCardService.Domain.Entities;
namespace BankCardService.Infrastructure.Data;

public class BankCardDbContext : DbContext
{
   

    public BankCardDbContext (DbContextOptions<BankCardDbContext> options) : base(options)
    {      
    }

    public DbSet<BankCard> BankCards { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);



    }

}
