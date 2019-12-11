using System;
using System.ComponentModel.DataAnnotations;

namespace SEP3_TIER3.Model
{
    public class Position
    {
        [Required]
        [Range(0, double.MaxValue)]
        public double XCoordinate { get; set; }

        [Required]
        [Range(0, double.MaxValue)]
        public double YCoordinate { get; set; }

        public override string ToString()
        {
            return $"XCoordinate: {XCoordinate} \n YCoordinate: {YCoordinate}";
        }
    }
}
