
namespace VidlyPractice.Models
{
    public class MembershipType
    {
        public byte Id { get; set; }
        public short SigUpFee { get; set; }
        public byte DurationInMonth { get; set; }
        public byte DiscountRate { get; set; }
    }
}