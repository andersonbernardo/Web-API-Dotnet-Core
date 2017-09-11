using ApiFCamara.Application.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApiFCamara.Application.Interfaces
{
    public interface IProductAppService
    {
        List<ProductViewModel> GetAll();
    }
}
