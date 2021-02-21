using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Authentificaton.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;

namespace Authentificaton.Controllers
{
    [Authorize]
    public class StudentController : Controller
    {
        private readonly ApplicationDbContext _db;

        public StudentController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            var displaydata = _db.tablestd.ToList();
            return View(displaydata);
        }

        [HttpGet]
        public async Task<IActionResult> Index(string Stdsearch)
        {
            ViewData["getstudentdetails"] = Stdsearch;
            var stdquery = from x in _db.tablestd select x;
            if (!String.IsNullOrEmpty(Stdsearch))
            {
                stdquery = stdquery.Where(x =>  x.nom.Contains(Stdsearch) || x.prenom.Contains(Stdsearch) || x.cin.Contains(Stdsearch));
            }
            return View(await stdquery.AsNoTracking().ToListAsync());
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(NewSudentClass nec)
        {
            if (ModelState.IsValid)
            {
                _db.Add(nec);
                await _db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(nec);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Index");
            }
            var getempdetails = await _db.tablestd.FindAsync(id);
            return View(getempdetails);
        }

        [HttpPost]

        public async Task<IActionResult> Edit(NewSudentClass nc)
        {
            if (ModelState.IsValid)
            {
                _db.Update(nc);
                await _db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(nc);
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Index");
            }
            var getstddetails = await _db.tablestd.FindAsync(id);
            return View(getstddetails);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Index");
            }
            var getstddetails = await _db.tablestd.FindAsync(id);
            return View(getstddetails);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {

            var getstddetails = await _db.tablestd.FindAsync(id);
            _db.tablestd.Remove(getstddetails);
            await _db.SaveChangesAsync();

            return RedirectToAction("Index");
        }
    }
}
