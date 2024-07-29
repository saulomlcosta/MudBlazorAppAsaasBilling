using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MudBlazorAsaasBilling.Models;

namespace MudBlazorAsaasBilling.Data.Configurations
{
    public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.ToTable("Customers");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.IdAsaas)
                      .IsRequired();

            builder.Property(x => x.Name)
                      .IsRequired(true)
                      .HasColumnType("VARCHAR(50)");

            builder.Property(x => x.Document)
                    .IsRequired(true)
                    .HasColumnType("NVARCHAR(11)");

            builder.Property(x => x.Email)
                    .IsRequired(true)
                    .HasColumnType("VARCHAR(50)");

            builder.Property(x => x.Phone)
                    .IsRequired(true)
                    .HasColumnType("NVARCHAR(11)");
     
            builder.Property(x => x.CreateDate)
                   .IsRequired(true)
                   .HasColumnType("DATE");

            builder.HasMany(b => b.Billings)
                    .WithOne(c => c.Customer)
                    .HasForeignKey(c => c.CustomerId)
                    .OnDelete(DeleteBehavior.Restrict);

            builder.HasIndex(x => x.Document).HasDatabaseName("IX_Customer_Document").IsUnique();
            builder.HasIndex(x => x.Id).HasDatabaseName("IX_Customer_Id");

        }
    }
}
