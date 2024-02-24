using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using System.Web.Mvc;
using TestStore.Models;

namespace TestStore.Controllers
{
    public class StoreController : Controller
    {
        // GET: Store
        //[Authorize]
        private TestStoreDbContext _context;
        private SqlConnection connection;

        public StoreController()
        {
            _context = new TestStoreDbContext();
            string connStr = ConfigurationManager.ConnectionStrings["TestStoreDb"].ToString();
            connection = new SqlConnection(connStr);
        }
        // GET: Store
        public ActionResult Index()
        {
            List<Album> albums = _context.Albums.Include("Artist").Include("Genre").ToList();
            return View(albums);

        }

        [HttpGet]
        public ActionResult Create()
        {
            ViewBag.ArtistID = new SelectList(_context.Artists, "ArtistID", "ArtistName");
            ViewBag.GenreID = new SelectList(_context.Genres, "GenreID", "Name");

            return View();
        }

        //[HttpPost]
        //public ActionResult Create(Album album)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        _context.Albums.Include("Artist").Include("Genre");
        //        _context.Albums.Add(album);
        //        _context.SaveChanges();
        //        return RedirectToAction("Index");
        //    }
        //    return View();
        //}


        [HttpPost]
        public ActionResult Create(Album album)
        {

            SqlCommand sqlCommand = new SqlCommand("sp_createAlbum", connection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            connection.Open();

            sqlCommand.Parameters.AddWithValue("@ArtistID", album.ArtistID);
            sqlCommand.Parameters.AddWithValue("@GenreID", album.GenreID);
            //sqlCommand.Parameters.AddWithValue("@ArtistName", album.Artist.ArtistName);
            //sqlCommand.Parameters.AddWithValue("@Name", album.Genre.Name);
            sqlCommand.Parameters.AddWithValue("@Title", album.Title);
            sqlCommand.Parameters.AddWithValue("@Price", album.Price);
            sqlCommand.Parameters.AddWithValue("@AlbumArtUrl", album.AlbumArtUrl);
            sqlCommand.ExecuteNonQuery();
            connection.Close();
            //ViewData["Message"] = "Album " + album.Title + " Is Saved Succesfully";
            return View();
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            Album album = _context.Albums.Find(id);
            SqlCommand command = new SqlCommand("sp_deleteAlbum", connection);
            command.CommandType = CommandType.StoredProcedure;

            command.Parameters.Add("@AlbumID", id);

            StringBuilder errorMsg = new StringBuilder();

            if (album != null)
            {
                try
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                }
                catch (SqlException e)
                {

                    for (int i = 0; i < e.Errors.Count; i++)
                    {

                        errorMsg.Append("Index #: " + i + "/n" + "Message: " + e.Errors[i].Message);
                    }

                    Console.WriteLine(errorMsg.ToString());
                    throw;
                }
                finally
                {
                    connection.Close();
                }
            }
            return RedirectToAction("Index");


        }
        public ActionResult Details(int id)
        {
            Album matchedAlbum = _context.Albums.FirstOrDefault(m => m.AlbumID == id);
            return View(matchedAlbum);
        }

        //[HttpGet]
        //public ActionResult Edit(int id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }

        //    Album matchedAlbum = _context.Albums.Include("Artist")
        //        .Include("Genre")
        //        .Where(a => a.AlbumID == id).FirstOrDefault<Album>();

        //    ViewBag.ArtistID = new SelectList(_context.Artists, "ArtistID", "ArtistName", matchedAlbum.ArtistID);

        //    ViewBag.GenreID = new SelectList(_context.Genres, "GenreID", "Name", matchedAlbum.GenreID);


        //    return View(matchedAlbum);
        //}

        [HttpPost]
        public ActionResult Edit(Album album)
        {
            if (ModelState.IsValid)
            {
                Album matchedAlbum = _context.Albums.FirstOrDefault(al => al.AlbumID == album.AlbumID);

                matchedAlbum.Title = album.Title;
                matchedAlbum.Price = album.Price;
                matchedAlbum.AlbumArtUrl = album.AlbumArtUrl;
                matchedAlbum.ArtistID = album.ArtistID;
                matchedAlbum.GenreID = album.GenreID;
                _context.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ArtistID = new SelectList(_context.Artists, "ArtistID", "ArtistName", album.ArtistID);

            ViewBag.GenreID = new SelectList(_context.Genres, "GenreID", "Name", album.GenreID);

            return View(album);

        }
        public ActionResult Edit(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Album album = _context.Albums.Find(id);
            if (album == null)
            {
                return HttpNotFound();
            }
            ViewBag.ArtistId = new SelectList(_context.Artists, "ArtistID", "ArtistName", album.ArtistID);
            ViewBag.GenreId = new SelectList(_context.Genres, "GenreID", "Name", album.GenreID);

            return View(album);
        }
    }

}
