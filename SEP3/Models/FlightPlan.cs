using System;
using System.DateTime;

public class FlightPlan
{
    public string Id { get; set; }

    public Route Route { get; set; }

    public DateTime DepartureTime { get; set; }

    public DateTime ArrivalTime { get; set; }

    public DateTime Delay { get; set; }
}