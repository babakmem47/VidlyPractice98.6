using System;
using System.ComponentModel.DataAnnotations;
using VidlyPractice.Models;

namespace VidlyPractice.ViewModels
{
    public class Min18YearsIfAMember : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var customervViewModel = (CustomerFormViewModel)validationContext.ObjectInstance;

            if (customervViewModel.MembershipTypeId == MembershipType.PayAsYouGo 
                || customervViewModel.MembershipTypeId == MembershipType.Unknown)
                return ValidationResult.Success;

            if (customervViewModel.BirthDate == null)
                return new ValidationResult("تاریخ تولد را وارد کنید");

            var age = DateTime.Today.Year - customervViewModel.BirthDate.Value.Year;
            return (age >= 18)
                ? ValidationResult.Success
                : new ValidationResult("سن باید بیشتر از 18 سال باشد");
        }
    }
}