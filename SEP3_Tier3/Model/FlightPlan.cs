using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SEP3_TIER3.Model
{
    public class FlightPlan
    {
        [Key]
        [Required]
        public int Id { get; }

        public FlightDate DepartureTime { get; set; }

        public FlightDate ArrivalTime { get; set; }

        [RegularExpression(@"^[A-Z]+[a-zA-Z""'\s-]*$")]
        public string StartLocation { get; set; }

        [RegularExpression(@"^[A-Z]+[a-zA-Z""'\s-]*$")]
        public string EndLocation { get; set; }
        public override string ToString()
        {
            return $"Id: {Id} \nDepartureTime: {DepartureTime} \nArrivalTime: {ArrivalTime} \nStartLocation: {StartLocation} \nEndLocation: {EndLocation}";
        }
    }
}
