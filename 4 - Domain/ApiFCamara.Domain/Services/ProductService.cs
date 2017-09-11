using ApiFCamara.Domain.Interfaces;
using ApiFCamara.Domain.Interfaces.Services;
using ApiFCamara.Domain.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApiFCamara.Domain.Services
{
    public class ProductService : BaseService<Product>, IProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository):base(productRepository)
        {
            _productRepository = productRepository;
        }
    }
}
