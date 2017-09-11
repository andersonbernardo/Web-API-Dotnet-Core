using ApiFCamara.Domain.Interfaces;
using ApiFCamara.Domain.Model;
using ApiFCamara.Infra.Data.Context;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApiFCamara.Infra.Data.Repositories
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        public ProductRepository(IDbContext context_) : base(context_) { }
    }
}
