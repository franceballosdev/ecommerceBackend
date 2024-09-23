﻿using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Specifications
{
    public class ProductsWithTypesAndBrandsSpecification:BaseSpecification<Product>
    {
        public ProductsWithTypesAndBrandsSpecification(string sort, int? brandId, int? typeId)
            : base(x=> (!brandId.HasValue || x.ProductTypeId == brandId) && (!typeId.HasValue || x.ProductTypeId == typeId))    
        {
            AddIncludes(x=> x.ProductType);
            AddIncludes(x=> x.ProductBrand);
            AddOrderBy(x=> x.Name);

            if(!string.IsNullOrEmpty(sort))
            {
                switch(sort)
                {
                    case "priceAsc" : 
                        AddOrderBy(p=> p.Price); 
                        break;

                    case "priceDesc" : 
                        AddOrderByDescending(p => p.Price); 
                        break;

                    default: 
                        AddOrderBy(p => p.Name); 
                        break;
                }
            }
        }

        public ProductsWithTypesAndBrandsSpecification(int id) : base(x=>x.Id==id)
        {
            AddIncludes(x => x.ProductType);
            AddIncludes(x => x.ProductBrand);
        }
    }
}
