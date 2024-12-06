namespace AOC2024.Day06;

public class Coordinate
{
    public int X { get; set; }
    public int Y { get; set; }

    public override bool Equals(object obj)
    {
        if (obj is not Coordinate other)
            return false;

        return X == other.X && Y == other.Y;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(X, Y);
    }
}

public enum State
{
    Path,
    Blocked
}