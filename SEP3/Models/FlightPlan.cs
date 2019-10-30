using System;
using System.DateTime;

public class FlightPlan
{
    public String IdOfThePlane { get; set; }

    public Route Route { get; set; }

    public DateTime DepartureTime { get; set; }

    public DateTime ArrivalTime { get; set; }

    public DateTime Delay { get; set; }
}