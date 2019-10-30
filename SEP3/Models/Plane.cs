using System;

public class Plane
{
    public string CallSign { get; set; }

    public string Model { get; set; }

    public string Company { get; set; }

    public FlightPlan FlightPlan { get; set; }

    public Position Position { get; set; }

    public string Status { get; set; } = "AIR";
}