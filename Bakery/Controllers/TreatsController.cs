using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Bakery.Models;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;
using System.Security.Claims;

namespace Bakery.Controllers
{
    public class TreatsController : Controller
    {
        private readonly BakeryContext _db;

        public TreatsController(BakeryContext db)
        {
            _db = db;
        }

        public ActionResult Index()
        {
            return View(_db.Treats.ToList());
        }

        [Authorize(Policy = "RequireAdministratorRole")]
        public ActionResult Create()
        {
            return View();
        }

        [Authorize(Policy = "RequireAdministratorRole")]
        [HttpPost]
        public ActionResult Create(Treat treat)
        {
            _db.Treats.Add(treat);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Details(int id)
        {
            Treat thisTreat = _db.Treats
                .Include(treat => treat.JoinEntities)
                .ThenInclude(join => join.Flavor)
                .FirstOrDefault(treat => treat.TreatId == id);
            return View(thisTreat);
        }

        [Authorize(Policy = "RequireAdministratorRole")]
        public ActionResult AddFlavor(int id)
        {
            Treat thisTreat = _db.Treats.FirstOrDefault(treat => treat.TreatId == id);
            ViewBag.FlavorId = new SelectList(_db.Flavors, "FlavorId", "Type");
            return View(thisTreat);
        }

        [Authorize(Policy = "RequireAdministratorRole")]
        [HttpPost]
        public ActionResult AddFlavor(Treat treat, int flavorId)
        {
#nullable enable
            FlavorTreat? joinEntity = _db.FlavorTreats.FirstOrDefault(join => (join.FlavorId == flavorId && join.TreatId == treat.TreatId));
#nullable disable
            if (joinEntity == null && flavorId != 0)
            {
                _db.FlavorTreats.Add(new FlavorTreat() { FlavorId = flavorId, TreatId = treat.TreatId });
                _db.SaveChanges();
            }
            return RedirectToAction("Details", new { id = treat.TreatId });
        }

        [Authorize(Policy = "RequireAdministratorRole")]
        public ActionResult Edit(int id)
        {
            Treat thisTreat = _db.Treats.FirstOrDefault(treat => treat.TreatId == id);
            return View(thisTreat);
        }

        [Authorize(Policy = "RequireAdministratorRole")]
        [HttpPost]
        public ActionResult Edit(Treat treat)
        {
            _db.Treats.Update(treat);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        [Authorize(Policy = "RequireAdministratorRole")]
        public ActionResult Delete(int id)
        {
            Treat thisTreat = _db.Treats.FirstOrDefault(treat => treat.TreatId == id);
            return View(thisTreat);
        }

        [Authorize(Policy = "RequireAdministratorRole")]
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Treat thisTreat = _db.Treats.FirstOrDefault(treat => treat.TreatId == id);
            _db.Treats.Remove(thisTreat);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        [Authorize(Policy = "RequireAdministratorRole")]
        [HttpPost]
        public ActionResult DeleteJoin(int joinId)
        {
            FlavorTreat joinEntry = _db.FlavorTreats.FirstOrDefault(entry => entry.FlavorTreatId == joinId);
            _db.FlavorTreats.Remove(joinEntry);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}