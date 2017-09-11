using ApiFCamara.Domain.Model;
using ApiFCamara.Infra.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ApiFCamara.Infra.Data
{
    public class DbInitializer
    {
        public static void Initialize()
        {
            var context = new ApiFCamaraContext();

            context.Database.EnsureCreated();

            if (context.Products.Any())
            {
                return;
            }

            var products = new List<Product>
            {
                new Product { Id =  Guid.NewGuid(), Description = "Mussum Ipsum, cacilds vidis litro abertis. Praesent vel viverra nisi. Mauris aliquet nunc non turpis scelerisque, eget.", Name = "Cerveja do mussum", SKU = "CER-515151515" },
                new Product { Id =  Guid.NewGuid(), Description = "Mussum Ipsum, cacilds vidis litro abertis. Praesent vel viverra nisi. Mauris aliquet nunc non turpis scelerisque, eget.", Name = "Cachaça do mussum", SKU = "CAC-515151515" },
                new Product { Id =  Guid.NewGuid(), Description = "Mussum Ipsum, cacilds vidis litro abertis. Praesent vel viverra nisi. Mauris aliquet nunc non turpis scelerisque, eget.", Name = "Caninha do mussum", SKU = "CAN-515151515" }
            };

            context.Products.AddRange(products);

            context.SaveChanges();
        }     
    }
}
