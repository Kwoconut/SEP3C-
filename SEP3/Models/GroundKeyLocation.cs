using System;

public class GroundKeyLocation
{
    public string Name { get; set; }

    public Checkpoint Checkpoint { get; set; }

    public string Type { get; set; }

    public GroundKeyLocation(string  Name, Checkpoint Checkpoint, string Type)
    {
        this.Name = Name;
        this.Checkpoint = Checkpoint;
        this.Type = Type;
    }

}