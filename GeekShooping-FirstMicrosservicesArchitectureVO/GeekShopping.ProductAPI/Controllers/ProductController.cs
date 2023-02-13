﻿using GeekShopping.ProductAPI.Data.ValueObject;
using GeekShopping.ProductAPI.Repository;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GeekShopping.ProductAPI.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class ProductController : ControllerBase
    {
        private IProductRepository _repository;
        public ProductController(IProductRepository repository)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetById(long id)
        {
            var product = await _repository.GetById(id);
            if (product == null)
            {
                return NotFound();
            }
            return Ok(product);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductVO>>> GetProducts()
        {
            var products = await _repository.GetProducts();
            return Ok(products);
        }

        [HttpPost]
        public async Task<ActionResult> Create(ProductVO productVO)
        {
            if (productVO == null)
            {
                return BadRequest();
            }
            var product = await _repository.Create(productVO);
            return Ok(product);
        }

        [HttpPut]
        public async Task<ActionResult> Update(ProductVO productVO)
        {
            if (productVO == null)
            {
                return BadRequest();
            }
            var product = await _repository.Update(productVO);
            return Ok(product);
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(long id)
        {
            var status = await _repository.DeleteById(id);
            if (!status)
            {
                return BadRequest();
            }
            return Ok(status);
        }
    }
}
