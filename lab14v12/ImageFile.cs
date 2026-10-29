namespace lab14v12;

public class ImageFile
{
    public string Name { get; set; }
    public string Format { get; set; }

    public ImageFile(string name, string format)
    {
        Name = name;
        Format = format;
    }

    public override string ToString() => $"{Name}.{Format}";
}