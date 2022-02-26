using Microsoft.AspNetCore.Mvc;
using NorthWindWebApp.Models;
using System.Text.Json;

namespace NorthWindWebApp.Controllers
{
    public class ProductController : Controller
    {
        IConfiguration _configuration;
        HttpClient _httpClient;
        public ProductController(IConfiguration configuration)
        {
            _configuration = configuration;
            Uri baseAddress = new Uri(_configuration["ApiAddress"]);
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = baseAddress;
        }
        public IActionResult Index()
        {
            IEnumerable<ProductModel> model = new List<ProductModel>();
            var response = _httpClient.GetAsync(_httpClient.BaseAddress + "/product").Result;
            if(response.IsSuccessStatusCode)
            {
                var data = response.Content.ReadAsStringAsync().Result;
                model = JsonSerializer.Deserialize<IEnumerable<ProductModel>>(data); 
            }
            return View(model);
        }
    }
}
