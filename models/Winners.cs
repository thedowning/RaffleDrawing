using System;

namespace RaffleDrawing.Models
{
    public class Winner
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Prize { get; set; }
        public int Event { get; set; } 
    }
}