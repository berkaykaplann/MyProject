﻿using Business.Abstract;
using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        IProductService _productService;
        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet("getall")]
        public IActionResult Get()
        {
            
            var result = _productService.GetAll();
            if(result.isSuccess)
            {
                return Ok(result); // 200
            }
            return BadRequest(result); // 400
        }


        [HttpGet("getbyid")]

        public IActionResult GetById(int id) 
        {
            var result = _productService.GetById(id);
            if (result.isSuccess)
            {
                return Ok(result); // 200
            }
            return BadRequest(result); // 400
        }



        [HttpPost("add")]
        public IActionResult Add(Product product)
        {
            var result = _productService.Add(product);
            if (result.isSuccess)
            {
                return Ok(result); // 200
            }
            return BadRequest(result); // 400
        }


    }
}
