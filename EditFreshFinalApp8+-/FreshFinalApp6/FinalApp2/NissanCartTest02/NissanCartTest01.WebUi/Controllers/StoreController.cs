
using NissanCartTest01.WebUi.Models;
using System.Linq;
using System.Web.Mvc;

namespace NissanCartTest01.WebUi.Controllers
{
    public class StoreController : Controller
    {
        ApplicationDbContext storeDB = new ApplicationDbContext();
        //
        // GET: /Store/

        public ActionResult Index()
        {
            var genres = storeDB.Genres.ToList();

            return View(genres);
        }

        //
        // GET: /Store/Browse?genre=Disco

        public ActionResult Browse(string genre)
        {
            // Retrieve Genre and its Associated Albums from database
            var genreModel = storeDB.Genres.Include("VehCats")
                .Single(g => g.Name == genre);

            return View(genreModel);
        }

        //
        // GET: /Store/Details/5

        public ActionResult Details(int id)
        {
            var vehcat = storeDB.VehCats.Find(id);

            return View(vehcat);
        }

        //
        // GET: /Store/GenreMenu

        [ChildActionOnly]
        public ActionResult GenreMenu()
        {
            var genres = storeDB.Genres.ToList();

            return PartialView(genres);
        }

        public ActionResult test()
        {
            return View();
        }

    }
}