using System;
using System.Collections.Generic;
using System.Text;

namespace WrinkMe.Domain.Models
{
    public class Device
    { 
        public int Id { get; set; }
        public bool IsBot { get; set; }
        public string Brand { get; set; }
        public string Family { get; set; }
        public string Model { get; set; }

        public override string ToString()
        {
            if (IsBot)
                return "Bot";

            return $"{Brand} {Family} {Model}";
        }
    }
}
