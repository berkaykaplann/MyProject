﻿using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        ICustomerService _customerService;

        public CustomersController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _customerService.GetAll();
            if (result.isSuccess)
            {
                return Ok(result); // 200
            }
            return BadRequest(result); // 400
        }


        [HttpGet("getbyid")]
        public IActionResult GetById(string id)
        {
            var result = _customerService.GetById(id);
            if (result.isSuccess)
            {
                return Ok(result); // 200
            }
            return BadRequest(result); // 400
        }

        [HttpGet("getcustomerdetail")]
        public IActionResult GetCustomerDetail()
        {
            var result = _customerService.GetCustomerDetail();
            if (result.isSuccess)
            {
                return Ok(result); // 200
            }
            return BadRequest(result);
        }


            [HttpPost("add")]
        public IActionResult Add(Customer customer)
        {
            var result = _customerService.Add(customer);
            if (result.isSuccess)
            {
                return Ok(result); // 200
            }
            return BadRequest(result); // 400
        }
    }
}
