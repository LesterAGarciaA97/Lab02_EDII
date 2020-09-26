using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Laboratorio02_EDII.Models
{
    public class Movie
    {
        //Constructor de modelo Movie
        public Movie(string director, string imdbRating, string genre, string rottenTomatoesRating, string title_date)
        {
            Director = director;
            ImbdRating = imdbRating;
            Genre = genre;
            RottenTomatoesRating = rottenTomatoesRating;
            Title_Date = title_date;
        }
        public Movie()
        {
            //Vacío
        }
        //Getters y Setters
        public string Director { get; set; }
        public string ImbdRating { get; set; }
        public string Genre { get; set; }
        public string RottenTomatoesRating { get; set; }
        public string Title_Date { get; set; }
    }
}
