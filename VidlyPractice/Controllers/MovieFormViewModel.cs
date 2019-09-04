using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using VidlyPractice.Models;
using VidlyPractice.Views.Movies;

namespace VidlyPractice.Controllers
{
    public class MovieFormViewModel
    {
        public MovieFormViewModel()
        {
            ReleaseDate = DateTime.MinValue;
            NumberInStock = 0;
            DateAdded = DateTime.Today;
        }

        public int Id { get; set; }

        [Required(ErrorMessage = "نام فیلم الزامی")]
        [MaxLength(70, ErrorMessage = "نام حداکثر 70 کاراکتر")]
        public string Name { get; set; }

        public Genre Genre { get; set; }

        [Required(ErrorMessage = "انتخاب یک ژانر الزامی است")]
        public byte GenreId { get; set; }

        public IEnumerable<Genre> Genres { get; set; }

        [Required]
        public DateTime? ReleaseDate { get; set; }

        public DateTime DateAdded { get; set; }

        [Required(ErrorMessage = "عددی را وارد فرمائید")]
        [NumberInStockBtw1And20]
        public short? NumberInStock { get; set; }
    }
}