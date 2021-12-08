using Arch.EntityFrameworkCore.UnitOfWork;
using FishStore.Entities.Products;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace FishStore.Controllers
{
    public class ProductController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public ProductController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Clothing(int id)
        {
            var product = _unitOfWork.GetRepository<Clothing>().GetAll()
                .Where(product => product.ID == id).FirstOrDefault();
            return View(product);
        }

        [HttpGet]
        public IActionResult Bait(int id)
        {
            var product = _unitOfWork.GetRepository<Bait>().GetAll()
                .Where(product => product.ID == id).FirstOrDefault();
            return View(product);
        }

        [HttpGet]
        public IActionResult Gear(int id)
        {
            var product = _unitOfWork.GetRepository<Gear>().GetAll()
                .Where(product => product.ID == id).FirstOrDefault();
            return View(product);
        }

        [HttpGet]
        public IActionResult Rod(int id)
        {
            var product = _unitOfWork.GetRepository<Rod>().GetAll()
                .Where(product => product.ID == id).FirstOrDefault();
            return View(product);
        }
    }
}
