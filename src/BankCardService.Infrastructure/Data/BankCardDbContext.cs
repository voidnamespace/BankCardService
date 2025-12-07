using BankCardService.Domain.Entities;
using Microsoft.EntityFrameworkCore;
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


        modelBuilder.Entity<BankCard>(entity =>
        {
            entity.HasKey(x => x.Id);

            entity.Property(x => x.CardNumber)
            .IsRequired();

            entity.Property(x => x.CardHolder)
            .IsRequired();

            entity.Property(x => x.Balance)
            .HasDefaultValue(0)
            .IsRequired();
            
            entity.Property(x => x.IsActive)
            .HasDefaultValue(true)
            .IsRequired();
            

        });



    }


}
