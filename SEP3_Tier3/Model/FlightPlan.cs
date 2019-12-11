using System.ComponentModel.DataAnnotations;

namespace SEP3_TIER3.Model
{
    public class FlightPlan
    {
        public int FlightNumber { get; set; }
        public FlightDate DepartureTime { get; set; }
        public FlightDate ArrivalTime { get; set; }

        [RegularExpression(@"^[A-Z]+[a-zA-Z""'\s-]*$")]
        public string StartLocation { get; set; }

        [RegularExpression(@"^[A-Z]+[a-zA-Z""'\s-]*$")]
        public string EndLocation { get; set; }
        public override string ToString()
        {
            return $"FlightNumber: {FlightNumber}\nDepartureTime: {DepartureTime} \nArrivalTime: {ArrivalTime} \nStartLocation: {StartLocation} \nEndLocation: {EndLocation}";
        }
    }
}
