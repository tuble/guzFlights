namespace guzFlightsUltra.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using guzFlightsUltra.Models;
    using guzFlightsUltra.Services.Contracts;
    using Microsoft.AspNetCore.Authorization; // !!
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;

    [Authorize]
    public class FlightController : Controller
    {
        private readonly IFlightService flightService;
        public FlightController(IFlightService flightService)
        {
            this.flightService = flightService;
        }

        [Authorize(Roles = "Administrator")]
        [Authorize(Roles = "Employee")]
        public IActionResult ListAll()
        {
            var viewModel = new IndexAllFlightsViewModel();
            
            // viewModel.Albums = this.albumService.GetAll();

            // var rated = this.albumService.GetAllRatings();

            // rated = rated.OrderBy(x => x.AlbumId).ToList();
            // viewModel.Albums = viewModel.Albums.OrderBy(x => x.AlbumId).ToList(); 


/*            foreach (var album in viewModel.Albums)
            {
                if (!viewModel.AlbumsWithRating.Keys.Contains<Album>(album))
                {
                    viewModel.AlbumsWithRating.Add(album, 0);
                }
            }
*/
            return this.View(viewModel);
        }

        // IMPLEMENT
/*        [Authorize(Roles = "Administrator")]
        public IActionResult Create()
        {
            //var viewModel = new CreateAlbumViewModel();
            // return this.View(viewModel);
        }

        public IActionResult Create(string title, string artist, int year, int genreId)
        {
            if (this.albumService.CreateAlbum(title, artist, year, genreId) == 0)
            {
                return this.RedirectToAction("AlbumAlreadyAdded", new { error = $"Album {title} by {artist} is already in the database" });
            }

            return this.RedirectToAction("ListAll");
        }
*/
/*        public IActionResult Delete()
        {
            var viewModel = new DeleteAlbumViewModel();
            viewModel.Albums = this.albumService.GetAll();
            return this.View(viewModel);
        }

        [HttpPost]
        public IActionResult Delete(int albumId)
        {
            var viewModel = new DeleteAlbumViewModel();
            viewModel.Albums = this.albumService.GetAll();

            this.albumService.DeleteAlbum(albumId);
            return this.RedirectToAction("ListAll");
        }
*/
        //[Route("Album/{id}")]
        // display detailed flight info
/*        public IActionResult AlbumInfo(int albumId)
        {
            var viewModel = new IndexAlbumViewModel();

            var a = albumService.GetAll().FirstOrDefault(x => x.AlbumId == albumId);

            viewModel.Artist = a.Artist;
            viewModel.GenreId = a.GenreId;
            viewModel.Genre = genreService.GetAll().FirstOrDefault(x => x.Id == a.GenreId).Name;
            viewModel.Title = a.Title;
            viewModel.Year = a.Year;
            viewModel.TimesRated = a.TimesRated;

            return this.View(viewModel);
        }

*/    }
}