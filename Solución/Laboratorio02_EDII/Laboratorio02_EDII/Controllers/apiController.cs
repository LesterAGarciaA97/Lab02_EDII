using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.IO;
using System.Threading.Tasks;
using Laboratorio02_EDII.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BibliotecaDeClases;
using Laboratorio02_EDII.Models;

namespace Laboratorio02_EDII.Controllers
{
    delegate string MovieToSring(Movie p);
    delegate Movie StringToMovie(string s);
    [Route("[controller]")]
    [ApiController]
    public class apiController : ControllerBase
    {
        [HttpGet("traversal")]
        public List<Movie> Get(string traversal)
        {
            var grado = 7;
            var path = Path.Combine(Environment.CurrentDirectory, "arbol.txt");
            if (!ArbolB<Movie>.ExisteArbol())
            {
                string text = $"{grado.ToString("0000;-0000")}|0000|0001|";
                System.IO.File.WriteAllText(path, text);
            }
            var StP = new StringToMovie(Movie.StringToMovie);
            return ArbolB<Movie>.Recorrido(null);
        }
        [HttpGet]
        public ActionResult dat() {
            return Ok();
        }

        [HttpPost]
        public string Post([FromBody] int order) {
            return ArbolB<Movie>.OrderArbol(order);
        }

        [HttpDelete]
        public string Delete() {
            var path = Path.Combine(Environment.CurrentDirectory, "arbol.txt");
            System.IO.File.Delete(path);
            return "Archivo de Arbol Eliminado";
        }

        [HttpPost("populate")]
        public ActionResult Add([FromBody] Movie[] NMovie) {
            try
            {
                var grado = 7;
                var path = Path.Combine(Environment.CurrentDirectory, "arbol.txt");
                if (!ArbolB<Movie>.ExisteArbol())
                {
                    string text = $"{grado.ToString("0000;-0000")}|0000|0001|";
                    System.IO.File.WriteAllText(path, text);
                }

                var PtS = new MovieToSring(Movie.MovieToString);
                var StP = new StringToMovie(Movie.StringToMovie);
                for (int i = 0; i < NMovie.Length; i++)
                {
                    ArbolB<Movie>.InsertarArbol(NMovie[i], StP, PtS);
                }
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

    }
}
