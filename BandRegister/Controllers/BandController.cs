using BandRegister.Data;
using BandRegister.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace BandRegister.Controllers
{
    public class BandController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            using (var db = new BandRegisterDbContext())
            {
                var allBands = db.Bands.ToList();
                return View(allBands);
            }
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Band band)
        {
            Band newBand = new Band
            {
                Name = band.Name,
                Members = band.Members,
                Honorarium = band.Honorarium,
                Genre = band.Genre
            };
            using (var db = new BandRegisterDbContext())
            {
                db.Bands.Add(newBand);
                db.SaveChanges();
            }
                return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            using (var db = new BandRegisterDbContext())
            {
                var bandToEdit = db.Bands.FirstOrDefault(t => t.Id == id);
                return View(bandToEdit);
            }
        }

        [HttpPost]
        public IActionResult Edit(Band band)
        {
            using (var db = new BandRegisterDbContext())
            {
                var bandToEdit = db.Bands.FirstOrDefault(t => t.Id == band.Id);
                bandToEdit.Name = band.Name;
                bandToEdit.Members = band.Members;
                bandToEdit.Honorarium = band.Honorarium;
                bandToEdit.Genre = band.Genre;
                db.SaveChanges();
            }
                return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            using (var db = new BandRegisterDbContext())
            {
                var bandToDelete = db.Bands.FirstOrDefault(t => t.Id == id);
                return View(bandToDelete);
            }
        }

        [HttpPost]
        public IActionResult Delete(Band band)
        {
            using (var db = new BandRegisterDbContext())
            {
                db.Bands.Remove(band);
                db.SaveChanges();
            }
                return RedirectToAction("Index");
        }
    }
}