using Arch.EntityFrameworkCore.UnitOfWork;
using FishStore.Entities.Accounting;
using FishStore.Entities.Ordering;
using FishStore.Entities.Products;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using FishStore.Models.Ordering;

namespace FishStore.Controllers
{
    [Authorize]
    public class OrderingController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public OrderingController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        #region Orders
        [HttpGet]
        public ActionResult AddOrder()
        {
            var currentUser = _unitOfWork.GetRepository<User>().GetAll()
                .Where(user => user.Email == User.Identity.Name).FirstOrDefault();
            var orderRepo = _unitOfWork.GetRepository<Order>();
            var orderItemsRepo = _unitOfWork.GetRepository<OrderItem>();
            var productRepo = _unitOfWork.GetRepository<ProductObject>();
            var cart = _unitOfWork.GetRepository<Cart>().GetAll()
                .Where(c => c.User.Email == User.Identity.Name);
            var order = new Order() { User = currentUser, UserId = currentUser.ID, Adress = currentUser.DeliveryAdress};
            
            double cost = 0;
            foreach (var cartItem in cart)
            {
                var product = productRepo.GetAll().Where(p => p.ID == cartItem.ProductId).FirstOrDefault();
                var orderItem = new OrderItem() { Order = order, Product = product, Count = cartItem.Count };
                orderItemsRepo.Insert(orderItem);
                cost += product.Cost * orderItem.Count;
            }
            order.Cost = cost;
            orderRepo.Insert(order);
            _unitOfWork.SaveChanges();
            ClearCart();
            return View("Thanks");
        }
        #endregion

        #region Cart
        [HttpGet]
        public ActionResult Cart()
        {
            int count = 0;
            double price = 0;
            var products = _unitOfWork.GetRepository<ProductObject>().GetAll();
            var cartItems = _unitOfWork.GetRepository<Cart>().GetAll()
                .Where(cart => cart.User.Email == User.Identity.Name);
            foreach (var item in cartItems)
            {
                item.Product = products.Where(product => product.ID == item.ProductId).FirstOrDefault();
                count++;
                price += item.Count * item.Product.Cost;
            }

            var cartModel = new CartModel() { 
                Count = count,
                Price = price,
                Carts = cartItems
            };
            return View(cartModel);
        }

        [HttpGet]
        public ActionResult AddToCart(int id)
        {
            var currentUser = _unitOfWork.GetRepository<User>().GetAll()
                .Where(user => user.Email == User.Identity.Name).FirstOrDefault();
            var product = _unitOfWork.GetRepository<ProductObject>().GetAll()
                .Where(product => product.ID == id).FirstOrDefault();
            var cart = _unitOfWork.GetRepository<Cart>();
            if (cart.GetAll().Where(cart => cart.User.Email == User.Identity.Name && cart.ProductId == id).Any())
            {
                var cartItem = cart.GetAll().Where(cart => cart.User.Email == User.Identity.Name && cart.ProductId == id).FirstOrDefault();
                cartItem.Count++;
                cart.Update(cartItem);
            }
            else
                cart.Insert(new Cart()
                {
                    User = currentUser,
                    UserId = currentUser.ID,
                    Product = product,
                    ProductId = product.ID
                });
            _unitOfWork.SaveChanges();
            return RedirectToAction("Cart");
        }

        [HttpGet]
        public ActionResult IncCountToCartProduct(int cartId)
        {
            var cart = _unitOfWork.GetRepository<Cart>().GetAll()
                .Where(c => c.ID == cartId).FirstOrDefault();
            cart.Count++;
            _unitOfWork.GetRepository<Cart>().Update(cart);
            _unitOfWork.SaveChanges();
            return RedirectToAction("Cart");
        }

        [HttpGet]
        public ActionResult DecCountToCartProduct(int cartId)
        {
            var cart = _unitOfWork.GetRepository<Cart>().GetAll()
                .Where(c => c.ID == cartId).FirstOrDefault();
            cart.Count--;
            if (cart.Count == 0)
                return RedirectToAction("RemoveCartProduct", new { cartId = cartId });
            else
            {
                _unitOfWork.GetRepository<Cart>().Update(cart);
                _unitOfWork.SaveChanges();
                return RedirectToAction("Cart");
            }
        }

        [HttpGet]
        public ActionResult RemoveCartProduct(int cartId)
        {
            var cart = _unitOfWork.GetRepository<Cart>().GetAll()
                .Where(c => c.ID == cartId).FirstOrDefault();
            _unitOfWork.GetRepository<Cart>().Delete(cart);
            _unitOfWork.SaveChanges();
            return RedirectToAction("Cart");
        }

        [HttpGet]
        public ActionResult ClearCart()
        {
            var cartRepo = _unitOfWork.GetRepository<Cart>();
            var currentCart = cartRepo.GetAll()
                .Where(c => c.User.Email == User.Identity.Name);
            foreach(var item in currentCart)
                cartRepo.Delete(item);
            _unitOfWork.SaveChanges();
            return RedirectToAction("Cart");
        }
        #endregion

    }
}
