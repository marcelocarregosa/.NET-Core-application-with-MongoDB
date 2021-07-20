using System;

namespace Api.Models
{
    public class InfectedDto
    {
         public DateTime BirthDate { get; set; }
        public string Sex { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
    }
}