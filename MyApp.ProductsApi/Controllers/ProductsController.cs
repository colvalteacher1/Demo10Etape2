
using Microsoft.AspNetCore.Mvc;

namespace MyApp.ProductsApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        // Liste des produits en mémoire
        private static readonly List<Product> products = new()
        {
            new Product { Id = 1, Name = "Laptop", Price = 1200 },
            new Product { Id = 2, Name = "Smartphone", Price = 800 },
            new Product { Id = 3, Name = "Tablet", Price = 500 },
            new Product { Id = 4, Name = "Headphones", Price = 150 }
        };

        // GET: api/products
        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(products);
        }

        // GET: api/products/1
        [HttpGet("{id}")]
        public IActionResult GetOne(int id)
        {
            var product = products.FirstOrDefault(p => p.Id == id);

            if (product == null)
                return NotFound(new { message = "Product not found" });

            return Ok(product);
        }

        // Classe Product définie directement dans le contrôleur
        public class Product
        {
            public int Id { get; set; }
            public string Name { get; set; } = "";
            public decimal Price { get; set; }
        }
    }
}
