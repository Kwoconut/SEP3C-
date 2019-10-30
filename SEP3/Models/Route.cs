using System;
using System.Collections.Generic.List;

public class Route
{
    public Position StartLocation { get; set; }

    public Position Destination { get; set; }

    public List<Checkpoint> Checkpoints { get; set; }
}