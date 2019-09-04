using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using VidlyPractice.Controllers;

namespace VidlyPractice.Views.Movies
{
    public class NumberInStockBtw1And20 : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var movieViewModel = (MovieFormViewModel) validationContext.ObjectInstance;

            if (movieViewModel.NumberInStock > 1 && movieViewModel.NumberInStock <= 20)
                return ValidationResult.Success;
            else
            {
                return new ValidationResult("عدد باید بین 1 و 20 باشد");
            }
        }
    }
}