using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MudBlazorAsaasBilling.Models;

namespace MudBlazorAsaasBilling.Data.Configurations
{
    public class BillingConfiguration : IEntityTypeConfiguration<Billing>
    {
        public void Configure(EntityTypeBuilder<Billing> builder)
        {
            builder.ToTable("Billing");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.IdPaymentAsaas)
                      .IsRequired();

            builder.Property(x => x.BillingType)
                    .HasColumnType("char")
                    .HasMaxLength(20)
                    .IsRequired();

            builder.Property(x => x.Value)
                     .IsRequired(true);

            builder.Property(x => x.Description)
                .HasColumnType("VARCHAR(250)")
                .IsRequired(false);

            builder.Property(x => x.DueDate)
                    .IsRequired(true)
                    .HasColumnType("DATE");

            builder.Property(x => x.IsPaid)
                     .IsRequired(true)
                     .HasDefaultValue(false);

            builder.Property(x => x.CustomerId)
                     .IsRequired();

            builder.Property(x => x.CreateDate)
                    .IsRequired(true)
                    .HasColumnType("DATE");

            builder.HasIndex(x => x.Id).HasDatabaseName("IX_Billing_Id");
            builder.HasIndex(x => x.CustomerId).HasDatabaseName("IX_Billing_CustomerId");
            builder.HasIndex(x => x.DueDate).HasDatabaseName("IX_Billing_DueDate");
        }
    }
}
