using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TestStore.Models;

namespace TestStore.Controllers
{
    public class HomeController : Controller
    {
        private TestStoreDbContext _db;

        public HomeController()
        {
            _db = new TestStoreDbContext();
        }


        public ActionResult Index()
        {
            List<Album> albums = _db.Albums.Include("Artist").Include("Genre").ToList();
            return View(albums);
        }


        public ActionResult Browse(string genre)
        {
            var genreModel = new Genre { Name = genre };
            //List<Album> albums = _db.Albums.Include("Artist").Include("Genre").ToList();
            return View(genreModel);
        }


        public ActionResult DailyDeal()
        {
            Album randomAlbum = _db.Albums
             .Include("Artist")
             .OrderBy(a => System.Guid.NewGuid())
             .FirstOrDefault();
            randomAlbum.Price *= 0.5M;

            return PartialView("_DailyDeal", randomAlbum);
        }

        public ActionResult Search(string q)
        {
            //ViewData["CurrentFilter"] = q;

            var albums = from mem in _db.Albums
                         select mem;
            if (!String.IsNullOrEmpty(q))
            {
                albums = albums.Where(m => m.Artist.ArtistName.Contains(q));
                return PartialView(albums);
            }

            var memberList = _db.Albums.ToList();
            return View(memberList);

        }

        public ActionResult SearchResult(string searchString)
        {
            ViewData["CurrentFilter"] = searchString;

            var albums = from mem in _db.Albums
                         select mem;
            if (!String.IsNullOrEmpty(searchString))
            {
                albums = albums.Where(m => m.Artist.ArtistName.Contains(searchString));
                return PartialView(albums);
            }

            var memberList = _db.Albums.ToList();
            return View(memberList);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        

       

        //public ActionResult ArtistSearch(string searchString)
        //{
        //    var artists = _db.Artists.Where(ar => ar.ArtistName.Contains(searchString))
        //        .ToList();
        //    return View(artists);
        //}

        //private List<Artist> GetArtists(string searchString)
        //{
        //    return _db.Artists.Where(ar => ar.ArtistName.Contains(searchString))
        //        .ToList();
        //}
    }
}