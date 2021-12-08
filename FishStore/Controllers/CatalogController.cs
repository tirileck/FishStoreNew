using Arch.EntityFrameworkCore.UnitOfWork;
using FishStore.Entities.Products;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace FishStore.Controllers
{
    public class CatalogController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public CatalogController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Bait()
        {
            var products = _unitOfWork.GetRepository<Bait>().GetAll();
            return View(products);
        }
        public IActionResult Clothing(string SearchString)
        {
            var products = _unitOfWork.GetRepository<Clothing>().GetAll();
            return View(products);
        }
        public IActionResult Gear()
        {
            var products = _unitOfWork.GetRepository<Gear>().GetAll();
            return View(products);
        }
        public IActionResult Rod()
        {
            var products = _unitOfWork.GetRepository<Rod>().GetAll();
            return View(products);
        }
    }
}
