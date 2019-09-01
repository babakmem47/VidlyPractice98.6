using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using VidlyPractice.Models;

namespace VidlyPractice.ViewModels
{
    public class CustomerFormViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "ضروری")]
        [MaxLength(50, ErrorMessage = "طول حداکثر 50 کاراکتر")]
        public string Name { get; set; }

        public bool IsSubscribedToNewsLetter { get; set; }

        public DateTime? BirthDate { get; set; }

        public MembershipType MembershipType { get; set; }

        [Display(Name = "The Membership Type")]
        public byte MembershipTypeId { get; set; }
        
        public IEnumerable<MembershipType> MembershipTypes { get; set; }
    }
}