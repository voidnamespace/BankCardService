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

        modelBuilder.Entity<BankCard>(b =>
        {
            b.OwnsOne(x => x.CardNumber, cn =>
            {
                cn.Property(p => p.Value)
                    .HasColumnName("CardNumber")
                    .IsRequired();
            });
        });
    }


}
