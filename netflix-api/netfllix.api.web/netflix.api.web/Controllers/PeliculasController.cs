using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using netflix.api.application.Model.ApiPeliculas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace netflix.api.web.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class PeliculasController : Controller
    {
        List<PeliculasModel> peliculas = new List<PeliculasModel>();
        public PeliculasController()
        {
            peliculas = new List<PeliculasModel>();
            for (int i = 1; i < 9; i++)
            {
                peliculas.Add(new PeliculasModel()
                {
                    Id = i,
                    Titulo = $"Pelicula {i}"
                });
            }
        }

        // GET: PeliculasController
        [HttpGet]
        public IEnumerable<PeliculasModel> Index()
        {
            return peliculas;
        }

    }
}
