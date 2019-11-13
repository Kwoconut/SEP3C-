using System;

public class Checkpoint
{
    public string Name { get; set; }

    public Position Position { get; set; }

    public bool IsAirType { get; }

    public Checkpoint(string Name,Position Position,bool IsAirType)
    {
        this.Name = Name;
        this.Position = Position;
        this.IsAirType = IsAirType;
    }


}