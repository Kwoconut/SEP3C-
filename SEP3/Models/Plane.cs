using System;

class Plane
{
    public String CallSign { get; set; }

    public String Model { get; set; }

    public String Company { get; set; }

    public FlightPlan FlightPlan { get; set; }

    public Position Position { get; set; }

    public static String Status { get; set; }
}