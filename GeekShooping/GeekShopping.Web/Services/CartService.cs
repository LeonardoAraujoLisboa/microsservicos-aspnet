﻿using GeekShopping.Web.Models;
using GeekShopping.Web.Services.IServices;
using GeekShopping.Web.Utils;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Reflection;
using System.Threading.Tasks;

namespace GeekShopping.Web.Services
{
    public class CartService : ICartService
    {
        private readonly HttpClient _client;
        public const string BasePath = "api/v1/cart";

        public CartService(HttpClient client)
        {
            _client = client ?? throw new ArgumentNullException(nameof(client));
        }

        public async Task<CartViewModel> FindCartByUserId(string userId, string token)
        {
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var response = await _client.GetAsync($"{BasePath}/find-cart/{userId}");
            return await response.ReadContentAs<CartViewModel>();
        }

        public async Task<CartViewModel> AddItemToCart(CartViewModel model, string token)
        {
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var response = await _client.PostAsJson($"{BasePath}/add-cart", model);
            if (response.IsSuccessStatusCode)
            {
                return await response.ReadContentAs<CartViewModel>();
            }
            else
            {
                throw new Exception("Something went wrong calling API");
            }
        }

        public async Task<CartViewModel> UpdateCart(CartViewModel model, string token)
        {
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var response = await _client.PutAsJson($"{BasePath}/update-cart", model);
            if (response.IsSuccessStatusCode)
            {
                return await response.ReadContentAs<CartViewModel>();
            }
            else
            {
                throw new Exception("Something went wrong calling API");
            }
        }

        public async Task<bool> RemoveFromCart(long cartId, string token)
        {
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var response = await _client.DeleteAsync($"{BasePath}/remove-cart/{cartId}");
            if (response.IsSuccessStatusCode)
            {
                return await response.ReadContentAs<bool>();
            }
            else
            {
                throw new Exception("Something went wrong calling API");
            }
        }

        public async Task<bool> ApplyCoupom(CartViewModel cart, string couponCode, string token)
        {
            throw new System.NotImplementedException();
        }

        public async Task<CartViewModel> Checkout(CartHeaderViewModel cartHeader, string token)
        {
            throw new System.NotImplementedException();
        }

        public async Task<bool> ClearCart(string userId, string token)
        {
            throw new System.NotImplementedException();
        }

        public async Task<bool> RemoveCoupom(string userId, string token)
        {
            throw new System.NotImplementedException();
        }
    }
}
