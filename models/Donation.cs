using System;

namespace RaffleDrawing.Models
{
    public class Donation
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Datetime { get; set; }
        public string Message { get; set; } 
        public float Amount { get; set; }
        public int Event { get; set; }
    }
}