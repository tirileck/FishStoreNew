﻿using Arch.EntityFrameworkCore.UnitOfWork;
using Microsoft.AspNetCore.Mvc;
using FishStore.Entities.Products;
using FishStore.Entities.Products.ProductDicts;
using System.Collections.Generic;
using System.Linq;

namespace FishStore.Controllers
{
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
        public IActionResult Clothing()
        {
            var products = _unitOfWork.GetRepository<Clothing>().GetAll();
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
        public IActionResult Rod()
        {
            var products = _unitOfWork.GetRepository<Rod>().GetAll();
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
        public IActionResult Bait()
        {
            var products = _unitOfWork.GetRepository<Bait>().GetAll();
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

        #region TypeOfRod
        public IActionResult TypeOfRod()
        {
            var products = _unitOfWork.GetRepository<TypeOfRod>().GetAll();
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
        public IActionResult TypeOfClothing()
        {
            var products = _unitOfWork.GetRepository<TypeOfClothing>().GetAll();
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
        public IActionResult TypeOfBait()
        {
            var products = _unitOfWork.GetRepository<TypeOfBait>().GetAll();
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
    }
}