using System.Linq;
using Microsoft.AspNetCore.Mvc;
using P2FixAnAppDotNetCode.Models;
using P2FixAnAppDotNetCode.Models.Services;

namespace P2FixAnAppDotNetCode.Controllers
{
    public class CartController : Controller
    {
        private readonly ICart _cart;
        private readonly IProductService _productService;

        public CartController(ICart pCart, IProductService productService)
        {
            _cart = pCart;
            _productService = productService;
        }

        public ViewResult Index()
        {
            return View(_cart as Cart);
        }

        [HttpPost]
        public RedirectToActionResult AddToCart(int id)
        {
            Product product = _productService.GetProductById(id);

            if (product != null)
            {
                // BUG corrigé : on ne peut plus mettre au panier plus d'articles qu'il n'y en a en stock
                int quantityInCart = (_cart as Cart).Lines
                    .Where(l => l.Product.Id == id)
                    .Sum(l => l.Quantity);
                if (quantityInCart < product.Stock)
                {
                    _cart.AddItem(product, 1);
                }
                return RedirectToAction("Index");
            }
            else
            {
                return RedirectToAction("Index", "Product");
            }
        }

        public RedirectToActionResult RemoveFromCart(int id)
        {
            Product product = _productService.GetAllProducts()
                .FirstOrDefault(p => p.Id == id);

            if (product != null)
            {
                _cart.RemoveLine(product);
            }
            return RedirectToAction("Index");
        }
    }
}
