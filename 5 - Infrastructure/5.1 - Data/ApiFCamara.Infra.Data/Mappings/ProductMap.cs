using ApiFCamara.Domain.Model;
using ApiFCamara.Infra.Data.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ApiFCamara.Infra.Data.Mappings
{
    public class ProductMap : EntityTypeConfiguration<Product>
    {
        public override void Map(EntityTypeBuilder<Product> builder)
        {
            builder.Property(c => c.Id).ValueGeneratedOnAdd()                
                .HasColumnName("Id");

            builder.Property(c => c.Name)
                .HasColumnType("varchar(100)")
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(c => c.SKU)
                  .HasColumnType("varchar(100)")
                  .HasMaxLength(100)
                  .IsRequired();

            builder.Property(c => c.Description)
                .HasColumnType("varchar(1000)")
                .HasMaxLength(1000)
                .IsRequired();
        }
    }
}
