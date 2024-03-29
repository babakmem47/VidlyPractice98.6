﻿
namespace VidlyPractice.Models
{
    public class MembershipType
    {
        public byte Id { get; set; }
        public string Name { get; set; }
        public short SigUpFee { get; set; }
        public byte DurationInMonth { get; set; }
        public byte DiscountRate { get; set; }
        public static readonly byte Unknown = 0;
        public static readonly byte PayAsYouGo = 1;
    }
}