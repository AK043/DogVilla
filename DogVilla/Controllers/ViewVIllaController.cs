using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DogVilla.Models;

namespace DogVilla.Controllers
{
    public class ViewVIllaController : Controller
    {
        // GET: ViewVIlla
        private DogVillaEntities dbVilla = new DogVillaEntities();

        public ActionResult ViewVilla()
        {
            return View(dbVilla.VillaRecords.ToList());
        }

        // GET: ViewVIlla/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ViewVIlla/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ViewVIlla/Create
        [HttpPost]
        public ActionResult Create([Bind(Exclude = "Id")] VillaRecord VillaToCreate)
        {
            if (!ModelState.IsValid)
                return View();
            dbVilla.VillaRecords.Add(VillaToCreate);
            dbVilla.SaveChanges();
            return RedirectToAction("ViewVilla");
        }

        // GET: ViewVIlla/Edit/5
        public ActionResult Edit(int id)
        {
            var VillaToPay = (from m in  dbVilla.VillaRecords where m.id == id select m).First();
            return View(VillaToPay);
        }

        // POST: ViewVIlla/Edit/5
        [HttpPost]
        public ActionResult Edit(VillaRecord VillaToPay)
        {
            var orignalRecord = (from m in dbVilla.VillaRecords where m.id == VillaToPay.id select m).First();

            if (!ModelState.IsValid)
                return View(orignalRecord);
            dbVilla.Entry(orignalRecord).CurrentValues.SetValues(VillaToPay);

            dbVilla.SaveChanges();
            return RedirectToAction("ViewVilla");

        }
        // GET: ViewVIlla/Delete/5
        public ActionResult Delete(VillaRecord VillaID)
        {
            var d = dbVilla.VillaRecords.Where(x => x.id == VillaID.id).FirstOrDefault();
            dbVilla.VillaRecords.Remove(d);
            dbVilla.SaveChanges();
            return View();
        }

        // POST: ViewVIlla/Delete/5
        [HttpPost]
        public ActionResult Delete()
        {
            
                return View();
            }
        
    }
}
