﻿using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IProductService
    {
        
        IDataResult<List<Product>> GetAll();
        IDataResult<List<Product>> GetAllByCategoryId(int categoryId);
        IDataResult<List<Product>> GetAllByUnitPrice(decimal min, decimal max); // iki fiyat arası ürünleri getir
        IDataResult<List<ProductDetailDto>> GetProductDetails(); // ürün detaylarını getir
        IDataResult<Product> GetById(int productId); 
        IResult Add(Product product); 
        IResult Update(Product product);
    }
}
