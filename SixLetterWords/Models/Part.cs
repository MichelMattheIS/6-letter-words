namespace SixLetterWords.Models;

internal class Part: IComparable<Part>
{
    public int Position { get; set; }
    public string Name { get; set; }

    public Part(int position, string name)
    {
        Position = position;
        Name = name;
    }

    public int CompareTo(Part? other)
    {
        if (Position < other?.Position)
            return -1;  
        else if (Position > other?.Position)
            return 1;
        else
            return 0;
    }

    public override string ToString()
    {
        return Name;
    }
}