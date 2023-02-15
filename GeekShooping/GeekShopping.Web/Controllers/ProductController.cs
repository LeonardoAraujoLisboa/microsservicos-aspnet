using GeekShopping.Web.Models;
using GeekShopping.Web.Services.IServices;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace GeekShopping.Web.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService ?? throw new ArgumentNullException(nameof(productService));
        }

        public async Task<IActionResult> ProductIndex()
        {
            var products = await _productService.GetAllProducts(); //voce tem q startar os dois serviços
            return View(products);
        }

        public async Task<IActionResult> ProductCreate()//essa é a parte do front vai no service nao faz nada e ai so retorna o front que é a tela mesmo
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> ProductCreate(ProductModel model)
        {
            if (ModelState.IsValid)
            {
                var response = await _productService.CreateProduct(model);
                if (response != null)
                {
                    return RedirectToAction(nameof(ProductIndex));
                }
            }
            return View(model);
        }

        public async Task<IActionResult> ProductUpdate(int id)
        {
            var model = await _productService.GetProductById(id);
            if (model == null)
            {
                return NotFound();
            }
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> ProductUpdate(ProductModel model)
        {
            if (ModelState.IsValid)
            {
                var response = await _productService.UpdateProduct(model);
                if (response != null)
                {
                    return RedirectToAction(nameof(ProductIndex));//se deu certo ele vai retornar para a tela de productIndex 
                }
            }
            return View(model);
        }

        public async Task<IActionResult> ProductDelete(int id)
        {
            var model = await _productService.GetProductById(id);
            if (model == null)
            {
                return NotFound();
            }
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> ProductDelete(ProductModel model)
        {
            if (ModelState.IsValid)
            {
                var response = await _productService.DeleteById(model.Id);
                if (!response)
                {
                    return View(model);
                }
            }
            return RedirectToAction(nameof(ProductIndex));
        }
    }
}
