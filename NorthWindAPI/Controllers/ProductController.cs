using DAL;
using DAL.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace NorthWindAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        NorthwindContext _db;
        public ProductController(NorthwindContext db)
        {
            _db = db;
        }

        [HttpGet]
        public IEnumerable<Product> GetAll()
        {
            return _db.Products.ToList();
        }
    }
}
