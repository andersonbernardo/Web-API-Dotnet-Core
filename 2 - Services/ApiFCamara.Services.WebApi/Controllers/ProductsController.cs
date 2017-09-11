using ApiFCamara.Application.Interfaces;
using ApiFCamara.Application.Model;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiFCamara.Services.WebApi.Controllers
{
    [Route("api/[controller]")]
    [Authorize()]
    [EnableCors("AllowAll")]
    public class ProductsController : Controller
    {
        private readonly IProductAppService _productAppService;

        public ProductsController(IProductAppService productAppService)
        {
            _productAppService = productAppService;
        }

        public IEnumerable<ProductViewModel> Get()
        {
            return _productAppService.GetAll();
        }
    }
}
