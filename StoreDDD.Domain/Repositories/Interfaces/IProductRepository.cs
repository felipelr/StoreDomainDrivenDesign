using System;
using StoreDDD.Domain.Entities;
using System.Collections.Generic;

namespace StoreDDD.Domain.Repositories.Interfaces
{
    public interface IProductRepository
    {
        IEnumerable<Product> Get(IEnumerable<Guid> ids);
    }
}