using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApiFCamara.Infra.Data.Context
{
    public abstract class BaseContext : DbContext, IDbContext
    {

    }
}
