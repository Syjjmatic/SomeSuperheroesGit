using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SomeSuperheroes.Data;
using SomeSuperheroes.Models;

namespace SomeSuperheroes.Controllers
{
    public class SuperheroesController : Controller
    {
        public ApplicationDbContext _context;

        public SuperheroesController(ApplicationDbContext context)
        {
            _context = context;
        }

        public ActionResult Index()
        {
            var superheroes = _context.Superhero;
            return View(superheroes);
        }

        public ActionResult Details(int Id)
        {
            return View(_context.Superhero.Find(Id));
        }
        public ActionResult Create()
        {
            Superhero superhero = new Superhero();
            return View(superhero);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Superhero superhero)
        {
            if (ModelState.IsValid)
            {
                _context.Superhero.Add(superhero);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                return Create(superhero);
            }
        }

        public ActionResult Edit(int id)
        {
            return View(_context.Superhero.Find(id));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Superhero superhero)
        {
            if (ModelState.IsValid)
            {
                _context.Superhero.Update(superhero);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                return Edit(id);
            }
        }

        public ActionResult Delete(int id)
        {
            return View(_context.Superhero.Find(id));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Superhero superhero)
        {
            _context.Superhero.Remove(superhero);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}