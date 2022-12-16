using CQRS_Project.CQRS.Results.ProductResults;
using CQRS_Project.DAL.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CQRS_Project.CQRS.Handlers.ProductHandlers
{
    public class GetProductAccounterQueryHandler
    {
        private readonly ProductContext _productContext;

        public GetProductAccounterQueryHandler(ProductContext productContext)
        {
            _productContext = productContext;
        }

        public List<GetProductAccounterQueryResult> Handle ()
        {
            var values = _productContext.Products.Select(x => 
            new GetProductAccounterQueryResult
            {
                ProductID = x.ProductID,
                Name = x.Name,
                Brand = x.Brand,
                SalePrice = x.SalePrice,
                PurchasePrice = x.PurchasePrice,
                Stock=x.Stock,
                Tax=x.Tax
            }).AsNoTracking().ToList();

            return values;
        }
    }
}
