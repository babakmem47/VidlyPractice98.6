using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace VidlyPractice.Dtos
{
    [DataContract]
    public class CustomerDto
    {
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        [Required(ErrorMessage = "الزامی")]
        public string Name { get; set; }

        [DataMember]
        [Required(ErrorMessage = "الزامی")]
        public bool IsSubscribedToNewsLetter { get; set; }

        public MembershipTypeDto MembershipTypeDto { get; set; }

        [DataMember]
        [Range(1,4, ErrorMessage = "بین 1 و چهار باشد")]
        public byte MembershipTypeDtoId { get; set; }

        [DataMember]
        public string Membership { get; set; }

        [DataMember]
        public DateTime? BirthDate { get; set; }

    }
}