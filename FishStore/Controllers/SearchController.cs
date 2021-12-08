using Arch.EntityFrameworkCore.UnitOfWork;
using FishStore.Entities.Products;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace FishStore.Controllers
{
    public class SearchController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private int pageSize = 50;
        public SearchController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public IActionResult Index(string SearchString, int page = 1)
        {
            ViewBag.SearchText = SearchString;
            var products = _unitOfWork.GetRepository<ProductObject>().GetAll()
                .Where(t => t.Name.Contains(SearchString))
                .Skip((page - 1) * pageSize).Take(pageSize);

            return View(products);
        }
    }
}
