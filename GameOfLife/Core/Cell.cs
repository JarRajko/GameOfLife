public class Cell
{
    public bool IsAlive { get; set; }
    public Color Color { get; set; }
    public string Species { get; set; }

    public Cell(bool isAlive, Color color, string species = "Default")
    {
        IsAlive = isAlive;
        Color = color;
        Species = species;
    }
}