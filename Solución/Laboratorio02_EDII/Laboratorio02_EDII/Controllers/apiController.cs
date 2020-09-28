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
        /// <summary>
        /// Metodo para devolver recorrido
        /// </summary>
        /// <param name="traversal"></param>
        /// <returns></returns>
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
        /// <summary>
        /// Prueba de que funciona correctamente la API
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult dat() {
            return Ok();
        }

        /// <summary>
        /// Metodo para agregar el orden 
        /// </summary>
        /// <param name="order"></param>
        /// <returns></returns>
        [HttpPost]
        public string Post([FromBody] int order) {
            return ArbolB<Movie>.OrderArbol(order);
        }
        /// <summary>
        /// Metodo para eliminar el arbol por completo
        /// </summary>
        /// <returns></returns>
        [HttpDelete]
        public string Delete() {
            var path = Path.Combine(Environment.CurrentDirectory, "arbol.txt");
            System.IO.File.Delete(path);
            return "Archivo de Arbol Eliminado";
        }
        /// <summary>
        /// Metodo para agregar todos los valores del arbol a traves de un JSON
        /// </summary>
        /// <param name="NMovie"></param>
        /// <returns></returns>
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
