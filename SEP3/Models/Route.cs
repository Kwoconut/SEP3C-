using System;
using System.Collections.Generic.List;

public class Route
{
    public string StartLocation { get; set; }

    public string Destination { get; set; }

    public List<Checkpoint> Checkpoints { get; set; }
}