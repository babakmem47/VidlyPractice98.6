using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using VidlyPractice.Models;

namespace VidlyPractice.Controllers
{
    public class MovieFormViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "نام فیلم الزامی")]
        [MaxLength(70, ErrorMessage = "نام حداکثر 70 کاراکتر")]
        public string Name { get; set; }

        public Genre Genre { get; set; }

        public byte GenreId { get; set; }

        public IEnumerable<Genre> Genres { get; set; }

        public DateTime? ReleaseDate { get; set; }

        public DateTime? DateAdded { get; set; }

        public short? NumberInStock { get; set; }
    }
}