using System;
using System.Linq.Expressions;
using StoreDDD.Domain.Entities;

namespace StoreDDD.Domain.Queries
{
    public static class ProductQueries
    {
        public static Expression<Func<Product, bool>> GetActiveProducts()
        {
            return x => x.Active;
        }

        public static Expression<Func<Product, bool>> GetInactiveProducts()
        {
            return x => x.Active == false;
        }
    }
}