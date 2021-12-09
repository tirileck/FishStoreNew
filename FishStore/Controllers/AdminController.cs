using Arch.EntityFrameworkCore.UnitOfWork;
using Microsoft.AspNetCore.Mvc;
using FishStore.Entities.Products;
using FishStore.Entities.Products.ProductDicts;
using System.Collections.Generic;
using System.Linq;
using FishStore.Entities.Accounting;
using Microsoft.AspNetCore.Authorization;
using FishStore.Entities.Ordering.OrderDicts;
using FishStore.Entities.Ordering;

namespace FishStore.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public AdminController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Entities()
        {
            return View();
        }

        #region Clothing
        [HttpGet]
        public IActionResult Clothing(string searchText)
        {
            var products = _unitOfWork.GetRepository<Clothing>().GetAll();
            if (searchText != null)
                products = products.Where(p => p.Name.Contains(searchText));
            var typesOfClothing = _unitOfWork.GetRepository<TypeOfClothing>().GetAll();
            foreach (var item in products)
                item.TypeOfClothing = typesOfClothing.Where(i => i.ID == item.TypeOfClothingID).FirstOrDefault();
            return View(products);
        }

        [HttpGet]
        public IActionResult AddClothing()
        {
            ViewBag.TypeOfClothing = _unitOfWork.GetRepository<TypeOfClothing>().GetAll();
            return View();
        }

        [HttpPost]
        public IActionResult AddClothing(Clothing clothing)
        {
            _unitOfWork.GetRepository<Clothing>().Insert(clothing);
            _unitOfWork.SaveChanges();
            return RedirectToAction("Clothing");
        }

        [HttpGet]
        public IActionResult EditClothing(int id)
        {
            ViewBag.TypeOfClothing = _unitOfWork.GetRepository<TypeOfClothing>().GetAll();
            var product = _unitOfWork.GetRepository<Clothing>().GetAll()
                .Where(product => product.ID == id).FirstOrDefault();
            return View(product);
        }

        [HttpPost]
        public IActionResult EditClothing(Clothing clothing)
        {
            _unitOfWork.GetRepository<Clothing>().Update(clothing);
            _unitOfWork.SaveChanges();
            return RedirectToAction("Clothing");
        }

        [HttpGet]
        public IActionResult DeleteClothing(int id)
        {
            var product = _unitOfWork.GetRepository<Clothing>().GetAll()
                .Where(product => product.ID == id).FirstOrDefault();
            _unitOfWork.GetRepository<Clothing>().Delete(product);
            _unitOfWork.SaveChanges();
            return RedirectToAction("Clothing");
        }
        #endregion

        #region Rod
        public IActionResult Rod(string searchText)
        {
            var products = _unitOfWork.GetRepository<Rod>().GetAll();
            if (searchText != null)
                products = products.Where(p => p.Name.Contains(searchText));
            var typesOfRod = _unitOfWork.GetRepository<TypeOfRod>().GetAll();
            foreach (var item in products)
                item.TypeOfRod = typesOfRod.Where(i => i.ID == item.TypeOfRodID).FirstOrDefault();
            return View(products);
        }

        [HttpGet]
        public IActionResult AddRod()
        {
            ViewBag.TypeOfRod = _unitOfWork.GetRepository<TypeOfRod>().GetAll();
            return View();
        }

        [HttpPost]
        public IActionResult AddRod(Rod rod)
        {
            _unitOfWork.GetRepository<Rod>().Insert(rod);
            _unitOfWork.SaveChanges();
            return RedirectToAction("Rod");
        }

        [HttpGet]
        public IActionResult EditRod(int id)
        {
            ViewBag.TypeOfRod = _unitOfWork.GetRepository<TypeOfRod>().GetAll();
            var product = _unitOfWork.GetRepository<Rod>().GetAll()
                .Where(product => product.ID == id).FirstOrDefault();
            return View(product);
        }

        [HttpPost]
        public IActionResult EditRod(Rod rod)
        {
            _unitOfWork.GetRepository<Rod>().Update(rod);
            _unitOfWork.SaveChanges();
            return RedirectToAction("Rod");
        }

        [HttpGet]
        public IActionResult DeleteRod(int id)
        {
            var product = _unitOfWork.GetRepository<Rod>().GetAll()
                .Where(product => product.ID == id).FirstOrDefault();
            _unitOfWork.GetRepository<Rod>().Delete(product);
            _unitOfWork.SaveChanges();
            return RedirectToAction("Rod");
        }
        #endregion

        #region Bait
        public IActionResult Bait(string searchText)
        {
            var products = _unitOfWork.GetRepository<Bait>().GetAll();
            if (searchText != null)
                products = products.Where(p => p.Name.Contains(searchText));
            var typesOfBait = _unitOfWork.GetRepository<TypeOfBait>().GetAll();
            foreach (var item in products)
                item.TypeOfBait = typesOfBait.Where(i => i.ID == item.TypeOfBaitID).FirstOrDefault();
            return View(products);
        }

        [HttpGet]
        public IActionResult AddBait()
        {
            ViewBag.TypeOfBait = _unitOfWork.GetRepository<TypeOfBait>().GetAll();
            return View();
        }

        [HttpPost]
        public IActionResult AddBait(Bait bait)
        {
            _unitOfWork.GetRepository<Bait>().Insert(bait);
            _unitOfWork.SaveChanges();
            return RedirectToAction("Bait");
        }

        [HttpGet]
        public IActionResult EditBait(int id)
        {
            ViewBag.TypeOfBait = _unitOfWork.GetRepository<TypeOfBait>().GetAll();
            var product = _unitOfWork.GetRepository<Bait>().GetAll()
                .Where(product => product.ID == id).FirstOrDefault();
            return View(product);
        }

        [HttpPost]
        public IActionResult EditBait(Bait bait)
        {
            _unitOfWork.GetRepository<Bait>().Update(bait);
            _unitOfWork.SaveChanges();
            return RedirectToAction("Bait");
        }

        [HttpGet]
        public IActionResult DeleteBait(int id)
        {
            var product = _unitOfWork.GetRepository<Bait>().GetAll()
                .Where(product => product.ID == id).FirstOrDefault();
            _unitOfWork.GetRepository<Bait>().Delete(product);
            _unitOfWork.SaveChanges();
            return RedirectToAction("Bait");
        }
        #endregion

        #region Gear
        public IActionResult Gear(string searchText)
        {
            var products = _unitOfWork.GetRepository<Gear>().GetAll();
            if (searchText != null)
                products = products.Where(p => p.Name.Contains(searchText));
            var typesOfBait = _unitOfWork.GetRepository<TypeOfGear>().GetAll();
            foreach (var item in products)
                item.TypeOfGear = typesOfBait.Where(i => i.ID == item.TypeOfGearID).FirstOrDefault();
            return View(products);
        }

        [HttpGet]
        public IActionResult AddGear()
        {
            ViewBag.TypeOfGear = _unitOfWork.GetRepository<TypeOfGear>().GetAll();
            return View();
        }

        [HttpPost]
        public IActionResult AddGear(Gear gear)
        {
            _unitOfWork.GetRepository<Gear>().Insert(gear);
            _unitOfWork.SaveChanges();
            return RedirectToAction("Gear");
        }

        [HttpGet]
        public IActionResult EditGear(int id)
        {
            ViewBag.TypeOfGear = _unitOfWork.GetRepository<TypeOfGear>().GetAll();
            var product = _unitOfWork.GetRepository<Gear>().GetAll()
                .Where(product => product.ID == id).FirstOrDefault();
            return View(product);
        }

        [HttpPost]
        public IActionResult EditGear(Gear gear)
        {
            _unitOfWork.GetRepository<Gear>().Update(gear);
            _unitOfWork.SaveChanges();
            return RedirectToAction("Gear");
        }

        [HttpGet]
        public IActionResult DeleteGear(int id)
        {
            var product = _unitOfWork.GetRepository<Gear>().GetAll()
                .Where(product => product.ID == id).FirstOrDefault();
            _unitOfWork.GetRepository<Gear>().Delete(product);
            _unitOfWork.SaveChanges();
            return RedirectToAction("Gear");
        }
        #endregion

        #region TypeOfRod
        public IActionResult TypeOfRod(string searchText)
        {
            var products = _unitOfWork.GetRepository<TypeOfRod>().GetAll();
            if (searchText != null)
                products = products.Where(p => p.Name.Contains(searchText));
            return View(products);
        }

        [HttpGet]
        public IActionResult AddTypeOfRod()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddTypeOfRod(TypeOfRod typeOfRod)
        {
            _unitOfWork.GetRepository<TypeOfRod>().Insert(typeOfRod);
            _unitOfWork.SaveChanges();
            return RedirectToAction("TypeOfRod");
        }

        [HttpGet]
        public IActionResult EditTypeOfRod(int id)
        {
            var product = _unitOfWork.GetRepository<TypeOfRod>().GetAll()
                .Where(product => product.ID == id).FirstOrDefault();
            return View(product);
        }

        [HttpPost]
        public IActionResult EditTypeOfRod(TypeOfRod typeOfRod)
        {
            _unitOfWork.GetRepository<TypeOfRod>().Update(typeOfRod);
            _unitOfWork.SaveChanges();
            return RedirectToAction("TypeOfRod");
        }

        [HttpGet]
        public IActionResult DeleteTypeOfRod(int id)
        {
            var product = _unitOfWork.GetRepository<TypeOfRod>().GetAll()
                .Where(product => product.ID == id).FirstOrDefault();
            _unitOfWork.GetRepository<TypeOfRod>().Delete(product);
            _unitOfWork.SaveChanges();
            return RedirectToAction("TypeOfRod");
        }
        #endregion

        #region TypeOfClothing
        public IActionResult TypeOfClothing(string searchText)
        {
            var products = _unitOfWork.GetRepository<TypeOfClothing>().GetAll();
            if (searchText != null)
                products = products.Where(p => p.Name.Contains(searchText));
            return View(products);
        }

        [HttpGet]
        public IActionResult AddTypeOfClothing()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddTypeOfClothing(TypeOfClothing typeOfClothing)
        {
            _unitOfWork.GetRepository<TypeOfClothing>().Insert(typeOfClothing);
            _unitOfWork.SaveChanges();
            return RedirectToAction("TypeOfClothing");
        }

        [HttpGet]
        public IActionResult EditTypeOfClothing(int id)
        {
            var product = _unitOfWork.GetRepository<TypeOfClothing>().GetAll()
                .Where(product => product.ID == id).FirstOrDefault();
            return View(product);
        }

        [HttpPost]
        public IActionResult EditTypeOfClothing(TypeOfClothing typeOfClothing)
        {
            _unitOfWork.GetRepository<TypeOfClothing>().Update(typeOfClothing);
            _unitOfWork.SaveChanges();
            return RedirectToAction("TypeOfClothing");
        }

        [HttpGet]
        public IActionResult DeleteTypeOfClothing(int id)
        {
            var product = _unitOfWork.GetRepository<TypeOfClothing>().GetAll()
                .Where(product => product.ID == id).FirstOrDefault();
            _unitOfWork.GetRepository<TypeOfClothing>().Delete(product);
            _unitOfWork.SaveChanges();
            return RedirectToAction("TypeOfClothing");
        }
        #endregion

        #region TypeOfBait
        public IActionResult TypeOfBait(string searchText)
        {
            var products = _unitOfWork.GetRepository<TypeOfBait>().GetAll();
            if (searchText != null)
                products = products.Where(p => p.Name.Contains(searchText));
            return View(products);
        }

        [HttpGet]
        public IActionResult AddTypeOfBait()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddTypeOfBait(TypeOfBait typeOfBait)
        {
            _unitOfWork.GetRepository<TypeOfBait>().Insert(typeOfBait);
            _unitOfWork.SaveChanges();
            return RedirectToAction("TypeOfBait");
        }

        [HttpGet]
        public IActionResult EditTypeOfBait(int id)
        {
            var product = _unitOfWork.GetRepository<TypeOfBait>().GetAll()
                .Where(product => product.ID == id).FirstOrDefault();
            return View(product);
        }

        [HttpPost]
        public IActionResult EditTypeOfBait(TypeOfBait typeOfBait)
        {
            _unitOfWork.GetRepository<TypeOfBait>().Update(typeOfBait);
            _unitOfWork.SaveChanges();
            return RedirectToAction("TypeOfBait");
        }

        [HttpGet]
        public IActionResult DeleteTypeOfBait(int id)
        {
            var product = _unitOfWork.GetRepository<TypeOfBait>().GetAll()
                .Where(product => product.ID == id).FirstOrDefault();
            _unitOfWork.GetRepository<TypeOfBait>().Delete(product);
            _unitOfWork.SaveChanges();
            return RedirectToAction("TypeOfBait");
        }
        #endregion

        #region TypeOfGear
        public IActionResult TypeOfGear(string searchText)
        {
            var products = _unitOfWork.GetRepository<TypeOfGear>().GetAll();
            if (searchText != null)
                products = products.Where(p => p.Name.Contains(searchText));
            return View(products);
        }

        [HttpGet]
        public IActionResult AddTypeOfGear()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddTypeOfGear(TypeOfGear typeOfGear)
        {
            _unitOfWork.GetRepository<TypeOfGear>().Insert(typeOfGear);
            _unitOfWork.SaveChanges();
            return RedirectToAction("TypeOfGear");
        }

        [HttpGet]
        public IActionResult EditTypeOfGear(int id)
        {
            var product = _unitOfWork.GetRepository<TypeOfGear>().GetAll()
                .Where(product => product.ID == id).FirstOrDefault();
            return View(product);
        }

        [HttpPost]
        public IActionResult EditTypeOfGear(TypeOfGear typeOfGear)
        {
            _unitOfWork.GetRepository<TypeOfGear>().Update(typeOfGear);
            _unitOfWork.SaveChanges();
            return RedirectToAction("TypeOfGear");
        }

        [HttpGet]
        public IActionResult DeleteTypeOfGear(int id)
        {
            var product = _unitOfWork.GetRepository<TypeOfGear>().GetAll()
                .Where(product => product.ID == id).FirstOrDefault();
            _unitOfWork.GetRepository<TypeOfGear>().Delete(product);
            _unitOfWork.SaveChanges();
            return RedirectToAction("TypeOfGear");
        }
        #endregion

        #region User
        public IActionResult User(string searchText)
        {
            var users = _unitOfWork.GetRepository<User>().GetAll();
            if (searchText != null)
                users = users.Where(p => p.Name.Contains(searchText));
            var roles = _unitOfWork.GetRepository<Role>().GetAll();
            foreach (var item in users)
                item.Role = roles.Where(i => i.ID == item.RoleId).FirstOrDefault();
            return View(users);
        }

        [HttpGet]
        public IActionResult AddUser()
        {
            ViewBag.Role = _unitOfWork.GetRepository<Role>().GetAll();
            return View();
        }

        [HttpPost]
        public IActionResult AddUser(User user)
        {
            _unitOfWork.GetRepository<User>().Insert(user);
            _unitOfWork.SaveChanges();
            return RedirectToAction("User");
        }

        [HttpGet]
        public IActionResult EditUser(int id)
        {
            ViewBag.Role = _unitOfWork.GetRepository<Role>().GetAll();
            var user = _unitOfWork.GetRepository<User>().GetAll()
                .Where(user => user.ID == id).FirstOrDefault();
            return View(user);
        }

        [HttpPost]
        public IActionResult EditUser(User user)
        {
            _unitOfWork.GetRepository<User>().Update(user);
            _unitOfWork.SaveChanges();
            return RedirectToAction("User");
        }

        [HttpGet]
        public IActionResult DeleteUser(int id)
        {
            var user = _unitOfWork.GetRepository<User>().GetAll()
                .Where(user => user.ID == id).FirstOrDefault();
            _unitOfWork.GetRepository<User>().Delete(user);
            _unitOfWork.SaveChanges();
            return RedirectToAction("User");
        }
        #endregion

        #region Role
        public IActionResult Role(string searchText)
        {
            var roles = _unitOfWork.GetRepository<Role>().GetAll();
            if (searchText != null)
                roles = roles.Where(p => p.Name.Contains(searchText));
            return View(roles);
        }

        [HttpGet]
        public IActionResult AddRole()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddRole(Role role)
        {
            _unitOfWork.GetRepository<Role>().Insert(role);
            _unitOfWork.SaveChanges();
            return RedirectToAction("Role");
        }

        [HttpGet]
        public IActionResult EditRole(int id)
        {
            var role = _unitOfWork.GetRepository<Role>().GetAll()
                .Where(role => role.ID == id).FirstOrDefault();
            return View(role);
        }

        [HttpPost]
        public IActionResult EditRole(Role role)
        {
            _unitOfWork.GetRepository<Role>().Update(role);
            _unitOfWork.SaveChanges();
            return RedirectToAction("Role");
        }

        [HttpGet]
        public IActionResult DeleteRole(int id)
        {
            var role = _unitOfWork.GetRepository<Role>().GetAll()
                .Where(role => role.ID == id).FirstOrDefault();
            _unitOfWork.GetRepository<Role>().Delete(role);
            _unitOfWork.SaveChanges();
            return RedirectToAction("Role");
        }
        #endregion

        #region OrderStatus

        public IActionResult OrderStatus(string searchText)
        {
            var roles = _unitOfWork.GetRepository<OrderStatus>().GetAll();
            if (searchText != null)
                roles = roles.Where(p => p.Name.Contains(searchText));
            return View(roles);
        }

        [HttpGet]
        public IActionResult AddOrderStatus()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddOrderStatus(OrderStatus orderStatus)
        {
            _unitOfWork.GetRepository<OrderStatus>().Insert(orderStatus);
            _unitOfWork.SaveChanges();
            return RedirectToAction("OrderStatus");
        }

        [HttpGet]
        public IActionResult EditOrderStatus(int id)
        {
            var orderStatus = _unitOfWork.GetRepository<OrderStatus>().GetAll()
                .Where(orderStatus => orderStatus.ID == id).FirstOrDefault();
            return View(orderStatus);
        }

        [HttpPost]
        public IActionResult EditOrderStatus(OrderStatus orderStatus)
        {
            _unitOfWork.GetRepository<OrderStatus>().Update(orderStatus);
            _unitOfWork.SaveChanges();
            return RedirectToAction("OrderStatus");
        }

        [HttpGet]
        public IActionResult DeleteOrderStatus(int id)
        {
            var orderStatus = _unitOfWork.GetRepository<OrderStatus>().GetAll()
                .Where(orderStatus => orderStatus.ID == id).FirstOrDefault();
            _unitOfWork.GetRepository<OrderStatus>().Delete(orderStatus);
            _unitOfWork.SaveChanges();
            return RedirectToAction("OrderStatus");
        }
        #endregion

        #region Order
        public IActionResult Order(string searchText)
        {
            var usersRepo = _unitOfWork.GetRepository<User>();
            var orders = _unitOfWork.GetRepository<Order>().GetAll();
            if (searchText != null)
                orders = orders.Where(p => p.User.Name.Contains(searchText));
            
            var orderStatuses = _unitOfWork.GetRepository<OrderStatus>().GetAll();
            foreach (var item in orders)
            {
                item.User = usersRepo.GetAll().Where(user => user.ID == item.UserId).FirstOrDefault();
                item.OrderStatus = orderStatuses.Where(i => i.ID == item.OrderStatusId).FirstOrDefault();
            }
            return View(orders);
        }


        [HttpGet]
        public IActionResult EditOrderDetails(int id)
        {
            ViewBag.OrderStatuses = _unitOfWork.GetRepository<OrderStatus>().GetAll();
            var order = _unitOfWork.GetRepository<Order>().GetAll()
                .Where(order => order.ID == id).FirstOrDefault();
            return View(order);
        }

        [HttpPost]
        public IActionResult EditOrderDetails(Order order)
        {
            _unitOfWork.GetRepository<Order>().Update(order);
            _unitOfWork.SaveChanges();
            return RedirectToAction("Order");
        }

        [HttpGet]
        public IActionResult AboutOrder(int id)
        {
            var order = _unitOfWork.GetRepository<Order>().GetAll()
                .Where(order => order.ID == id).FirstOrDefault();
            order.User = _unitOfWork.GetRepository<User>().GetAll()
                .Where(user => user.ID == order.UserId).FirstOrDefault();
            order.OrderStatus = _unitOfWork.GetRepository<OrderStatus>().GetAll()
                .Where(orderStatus => orderStatus.ID == order.OrderStatusId).FirstOrDefault();
            var orderItems = _unitOfWork.GetRepository<OrderItem>().GetAll()
                .Where(orderItem => orderItem.OrderId == id);
            foreach(var item in orderItems)
            {
                item.Product = _unitOfWork.GetRepository<ProductObject>().GetAll()
                .Where(product => product.ID == item.ProductId).FirstOrDefault();
            }
            ViewBag.OrderItems = orderItems;
            return View(order);
        }

        [HttpGet]
        public IActionResult DeleteOrder(int id)
        {
            var order = _unitOfWork.GetRepository<Order>().GetAll()
                .Where(order => order.ID == id).FirstOrDefault();
            var orderItems = _unitOfWork.GetRepository<OrderItem>().GetAll()
                .Where(order => order.OrderId == id);
            _unitOfWork.GetRepository<Order>().Delete(order);
            foreach(var item in orderItems)
                _unitOfWork.GetRepository<OrderItem>().Delete(item);
            _unitOfWork.SaveChanges();
            return RedirectToAction("Order");
        }
        #endregion
    }
}
