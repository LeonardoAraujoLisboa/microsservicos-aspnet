﻿using GeekShopping.ProductAPI.Data.ValueObject;
using GeekShopping.ProductAPI.Repository;
using GeekShopping.ProductAPI.Utils;
using Microsoft.AspNetCore.Authorization;
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
        [Authorize]
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
        [Authorize]
        public async Task<ActionResult> Create([FromBody] ProductVO productVO)
        {
            if (productVO == null)
            {
                return BadRequest();
            }
            var product = await _repository.Create(productVO);
            return Ok(product);
        }

        [HttpPut]
        [Authorize]
        public async Task<ActionResult> Update([FromBody] ProductVO productVO)
        {
            if (productVO == null)
            {
                return BadRequest();
            }
            var product = await _repository.Update(productVO);
            return Ok(product);
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = Role.Admin)]//delete so é permitido pra admin
        public async Task<ActionResult> DeleteById(long id)
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
