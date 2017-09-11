using ApiFCamara.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Text;
using ApiFCamara.Domain.Model;
using System.Linq;
using ApiFCamara.Application.Interfaces;
using ApiFCamara.Application.Model;
using AutoMapper;

namespace ApiFCamara.Application
{
    public class ProductAppService : IProductAppService
    {
        private readonly IProductService _productService;
        private readonly IMapper _mapper;

        public ProductAppService(IProductService productService, IMapper mapper)
        {
            _productService = productService;
            _mapper = mapper;
        }

        public List<ProductViewModel> GetAll()
        {
            var products = _productService.GetAll().ToList();

            return products.Select(x => new ProductViewModel() { Name = x.Name, Description = x.Description, SKU = x.SKU }).ToList();
            //return _mapper.Map<List<ProductViewModel>>(products);            
        }
    }
}
