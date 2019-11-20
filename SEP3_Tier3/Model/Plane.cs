using SEP3_TIER3.Model;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SEP3_TIER3.Model
{
    public class Plane
    {
        [Key]
        [Required]
        [StringLength(10, MinimumLength = 3)]
        [RegularExpression(@"^[A-Z]+[a-zA-Z""'\s-]*$")]
        public string CallSign { get; set; }

        [RegularExpression(@"^[A-Z]+[a-zA-Z""'\s-]*$")]
        public string Model { get; set; }

        [RegularExpression(@"^[A-Z]+[a-zA-Z""'\s-]*$")]
        public string Company { get; set; }

        [Required]
        public FlightPlan FlightPlan { get; set; }

        [Required]
        public Position Position { get; set; }

        [Required]
        public Target Target { get; set; }

        public string Status { get; set; } = "In air";

        public override string ToString()
        {
            return $"CallSign: {CallSign} \nModel:{Model} \nCompany: {Company} \nFlightPlan: {FlightPlan} \nPosition: {Position} \nStatus: {Status}";
        }
    }
}