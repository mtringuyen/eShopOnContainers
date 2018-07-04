using Microsoft.eShopOnContainers.WebMVC.ViewModels;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System.Collections.Generic;
<<<<<<< HEAD
=======
using System.Linq;
using System.Net.Http;
>>>>>>> upstream/dev
using System.Threading.Tasks;
using WebMVC.Infrastructure;
using WebMVC.Models;

namespace Microsoft.eShopOnContainers.WebMVC.Services
{
    public class BasketService : IBasketService
    {
<<<<<<< HEAD
        private readonly IOptionsSnapshot<AppSettings> _settings;
        private IHttpClient _apiClient;
        private readonly string _remoteServiceBaseUrl;
        private IHttpContextAccessor _httpContextAccesor;

        public BasketService(IOptionsSnapshot<AppSettings> settings, IHttpContextAccessor httpContextAccesor, IHttpClient httpClient)
=======
        private readonly IOptions<AppSettings> _settings;
        private readonly HttpClient _apiClient;
        private readonly string _basketByPassUrl;
        private readonly string _purchaseUrl;

        private readonly string _bffUrl;

        public BasketService(HttpClient httpClient, IOptions<AppSettings> settings)
>>>>>>> upstream/dev
        {
            _apiClient = httpClient;
            _settings = settings;
<<<<<<< HEAD
            _remoteServiceBaseUrl = $"{_settings.Value.BasketUrl}/api/v1/basket";
            _httpContextAccesor = httpContextAccesor;
            _apiClient = httpClient;
=======

            _basketByPassUrl = $"{_settings.Value.PurchaseUrl}/api/v1/b/basket";
            _purchaseUrl = $"{_settings.Value.PurchaseUrl}/api/v1";
>>>>>>> upstream/dev
        }

        public async Task<Basket> GetBasket(ApplicationUser user)
        {
<<<<<<< HEAD
            var token = await GetUserTokenAsync();
            var getBasketUri = API.Basket.GetBasket(_remoteServiceBaseUrl, user.Id);
=======
            var uri = API.Basket.GetBasket(_basketByPassUrl, user.Id);
>>>>>>> upstream/dev

            var responseString = await _apiClient.GetStringAsync(uri);

<<<<<<< HEAD
            // Use the ?? Null conditional operator to simplify the initialization of response
            var response = JsonConvert.DeserializeObject<Basket>(dataString) ??
                new Basket()
                {
                    BuyerId = user.Id
                };

            return response;
=======
            return string.IsNullOrEmpty(responseString) ?
                new Basket() { BuyerId = user.Id } :
                JsonConvert.DeserializeObject<Basket>(responseString);
>>>>>>> upstream/dev
        }

        public async Task<Basket> UpdateBasket(Basket basket)
        {
<<<<<<< HEAD
            var token = await GetUserTokenAsync();
            var updateBasketUri = API.Basket.UpdateBasket(_remoteServiceBaseUrl);
=======
            var uri = API.Basket.UpdateBasket(_basketByPassUrl);

            var basketContent = new StringContent(JsonConvert.SerializeObject(basket), System.Text.Encoding.UTF8, "application/json");
>>>>>>> upstream/dev

            var response = await _apiClient.PostAsync(uri, basketContent);

            response.EnsureSuccessStatusCode();

            return basket;
        }

        public async Task Checkout(BasketDTO basket)
        {
<<<<<<< HEAD
            var token = await GetUserTokenAsync();
            var updateBasketUri = API.Basket.CheckoutBasket(_remoteServiceBaseUrl);
=======
            var uri = API.Basket.CheckoutBasket(_basketByPassUrl);
            var basketContent = new StringContent(JsonConvert.SerializeObject(basket), System.Text.Encoding.UTF8, "application/json");
>>>>>>> upstream/dev

            var response = await _apiClient.PostAsync(uri, basketContent);

            response.EnsureSuccessStatusCode();
        }

        public async Task<Basket> SetQuantities(ApplicationUser user, Dictionary<string, int> quantities)
        {
<<<<<<< HEAD
            var basket = await GetBasket(user);

            basket.Items.ForEach(x =>
            {
                // Simplify this logic by using the
                // new out variable initializer.
                if (quantities.TryGetValue(x.Id, out var quantity))
                {
                    x.Quantity = quantity;
                }
            });

            return basket;
=======
            var uri = API.Purchase.UpdateBasketItem(_purchaseUrl);

            var basketUpdate = new
            {
                BasketId = user.Id,
                Updates = quantities.Select(kvp => new
                {
                    BasketItemId = kvp.Key,
                    NewQty = kvp.Value
                }).ToArray()
            };

            var basketContent = new StringContent(JsonConvert.SerializeObject(basketUpdate), System.Text.Encoding.UTF8, "application/json");

            var response = await _apiClient.PutAsync(uri, basketContent);

            response.EnsureSuccessStatusCode();

            var jsonResponse = await response.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<Basket>(jsonResponse);
>>>>>>> upstream/dev
        }

        public Order MapBasketToOrder(Basket basket)
        {
<<<<<<< HEAD
            var order = new Order();
            order.Total = 0;

            basket.Items.ForEach(x =>
            {
                order.OrderItems.Add(new OrderItem()
                {
                    ProductId = int.Parse(x.ProductId),

                    PictureUrl = x.PictureUrl,
                    ProductName = x.ProductName,
                    Units = x.Quantity,
                    UnitPrice = x.UnitPrice
                });
                order.Total += (x.Quantity * x.UnitPrice);
            });

            return order;
=======
            var uri = API.Purchase.GetOrderDraft(_purchaseUrl, basketId);

            var responseString = await _apiClient.GetStringAsync(uri);

            var response =  JsonConvert.DeserializeObject<Order>(responseString);

            return response;
>>>>>>> upstream/dev
        }

        public async Task AddItemToBasket(ApplicationUser user, BasketItem product)
        {
<<<<<<< HEAD
            var basket = await GetBasket(user);

            if (basket == null)
            {
                basket = new Basket()
                {
                    BuyerId = user.Id,
                    Items = new List<BasketItem>()
                };
            }

            basket.Items.Add(product);

            await UpdateBasket(basket);
        }        
=======
            var uri = API.Purchase.AddItemToBasket(_purchaseUrl);

            var newItem = new
            {
                CatalogItemId = productId,
                BasketId = user.Id,
                Quantity = 1
            };

            var basketContent = new StringContent(JsonConvert.SerializeObject(newItem), System.Text.Encoding.UTF8, "application/json");
>>>>>>> upstream/dev

            var response = await _apiClient.PostAsync(uri, basketContent);
        }
    }
}
