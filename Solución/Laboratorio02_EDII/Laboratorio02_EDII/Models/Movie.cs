using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Laboratorio02_EDII.Models
{
    public class Movie : IComparable
    {
        //Constructor de modelo Movie
        //public Movie(string _director, double _imdbRating, string _genre, double _rottenTomatoesRating, string _title, string _releaseDate)
        //{
        //    director = _director;
        //    imdbRating = _imdbRating;
        //    genre = _genre;
        //    rottenTomatoesRating = _rottenTomatoesRating;
        //    title = _title;
        //    releaseDate = _releaseDate;
        //}

        //Getters y Setters
        public string director { get; set; }
        public double imdbRating { get; set; }
        public string genre { get; set; }
        public string releaseDate { get; set; }
        public double rottenTomatoesRating { get; set; }
        public string title { get; set; }

        public int CompareTo(object obj) {
            return this.title.CompareTo(((Movie)obj).title);
        }

        public static string MovieToString(Movie NMovie) {

            NMovie.title = NMovie.title == null ? "" : NMovie.title;
            NMovie.director = NMovie.director == null ? "" : NMovie.director;
            NMovie.genre = NMovie.genre == null ? "" : NMovie.genre;
            NMovie.releaseDate = NMovie.releaseDate == null ? "" : NMovie.releaseDate;

            return $"{string.Format("{0, -100}", NMovie.title)}=={string.Format("{0,-100}", NMovie.director)}=={string.Format("{0,-100}", NMovie.imdbRating)}=={string.Format("{0, -100}", NMovie.genre)}=={string.Format("{0, -100}", NMovie.releaseDate)}=={string.Format("{0, -100}", NMovie.rottenTomatoesRating)}";

        }
        public static Movie StringToMovie(string data) {
            var DataSeparada = data.Split(new string[] { "==" }, StringSplitOptions.RemoveEmptyEntries);
            return new Movie() { title = DataSeparada[0].Trim(), director = DataSeparada[1].Trim(), imdbRating = Convert.ToDouble(DataSeparada[2].Trim()), genre = DataSeparada[3].Trim(), releaseDate = DataSeparada[4].Trim(), rottenTomatoesRating = Convert.ToDouble(DataSeparada[5].Trim())};
        }
    }
}
