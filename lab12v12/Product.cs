namespace lab12v12;

public class Product
{
    public string Name { get; set; } = string.Empty;
    public double Price { get; set; }

    public override string ToString() => $"{Name} ({Price} грн)";
}