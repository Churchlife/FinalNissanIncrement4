using System.Linq;
using System.Web.Mvc;
using System.Data.Entity;
using NissanCartTest01.WebUi.Models;

namespace NissanCartTest01.WebUi.Controllers
{
    public class StoreManagerController : Controller
    {
        public ApplicationDbContext db = new ApplicationDbContext();
        // GET: StoreManager
        public ViewResult Index()
        {
            var vehcats = db.VehCats.Include(a => a.Genre);
            //var albums = db.VehCats.Include(a => a.Genre).Include(a => a.Artist);
            return View(vehcats.ToList());
        }

        // GET: StoreManager/Details/5
        public ViewResult Details(int id)
        {
            VehCat vehcat = db.VehCats.Find(id);
            return View(vehcat);
        }

        // GET: StoreManager/Create
        public ActionResult Create()
        {
            ViewBag.GenreId = new SelectList(db.Genres, "GenreId", "Name");
            
            return View();

        }

        // POST: StoreManager/Create
        [HttpPost]
        public ActionResult Create(VehCat vehcat)
        {
            if (ModelState.IsValid)
            {
                db.VehCats.Add(vehcat);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.GenreId = new SelectList(db.Genres, "GenreId", "Name", vehcat.GenreId);
           // ViewBag.ArtistId = new SelectList(db.Artists, "ArtistId", "Name", album.ArtistId);
            return View(vehcat);
        }

        // GET: StoreManager/Edit/5
        public ActionResult Edit(int id)
        {
            VehCat vehcat = db.VehCats.Find(id);
            ViewBag.GenreId = new SelectList(db.Genres, "GenreId", "Name", vehcat.GenreId);
            //ViewBag.ArtistId = new SelectList(db.Artists, "ArtistId", "Name", album.ArtistId);
            return View(vehcat);
        }

        // POST: StoreManager/Edit/5
        [HttpPost]
        public ActionResult Edit(VehCat vehcat)
        {
            if (ModelState.IsValid)
            {
                db.Entry(vehcat).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.GenreId = new SelectList(db.Genres, "GenreId", "Name", vehcat.GenreId);
            //ViewBag.ArtistId = new SelectList(db.Artists, "ArtistId", "Name", album.ArtistId);
            return View(vehcat);
        }

        // GET: StoreManager/Delete/5
        public ActionResult Delete(int id)
        {
            VehCat vehcat = db.VehCats.Find(id);
            return View(vehcat);
        }

        // POST: StoreManager/Delete/5
        
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            VehCat vehcat = db.VehCats.Find(id);
            db.VehCats.Remove(vehcat);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
