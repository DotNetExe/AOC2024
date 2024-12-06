namespace AOC2024.Day06;

public static class GuardGallivant
{
    public static State[,] GetRoom(string path, out Coordinate guard)
    {
        guard = new Coordinate() { X = 0, Y = 0 };
        var roomDataValue = File.ReadAllLines(path);
        var room = new State[roomDataValue.Length,roomDataValue[0].Length];
        for (var i = 0; i < roomDataValue.Length; i++)
        {
            var line = roomDataValue[i];
            for (var character = 0; character < line.Length; character++)
            {
                var current = line[character];
                switch (current)
                {
                    case '.':
                        room[i, character] = State.Path;
                        break;
                    case '#':
                        room[i, character] = State.Blocked;
                        break;
                    case '^':
                        guard.X = character;
                        guard.Y = i;
                        room[i, character] = State.Path;
                        break;
                }
            }
        }
        
        return room;
    }

    public static void WalkRoom(State[,] room, Coordinate coord)
    {
        var guard = new Guard()
        {
            Coordinate = coord,
            Facing = Facing.Up
        };
        
        var walk = true;
        var visitedCoords = new List<Coordinate>();
        while (walk)
        {
            if (guard.Facing == Facing.Up)
            {
                if (room[guard.Coordinate.Y - 1, guard.Coordinate.X] == State.Path)
                {
                    guard.Coordinate.Y = --guard.Coordinate.Y;
                    visitedCoords.Add(new Coordinate() { X = guard.Coordinate.X, Y = guard.Coordinate.Y });
                }
                else
                    guard.Facing = Facing.Right;
            } 
            else if (guard.Facing == Facing.Right)
            {
                if (room[guard.Coordinate.Y, guard.Coordinate.X + 1] == State.Path)
                {
                    guard.Coordinate.X = ++guard.Coordinate.X;
                    visitedCoords.Add(new Coordinate() { X = guard.Coordinate.X, Y = guard.Coordinate.Y });
                } else
                    guard.Facing = Facing.Down;
            } 
            else if (guard.Facing == Facing.Down)
            {
                if (room[guard.Coordinate.Y + 1, guard.Coordinate.X] == State.Path)
                {
                    guard.Coordinate.Y = ++guard.Coordinate.Y;
                    visitedCoords.Add(new Coordinate() { X = guard.Coordinate.X, Y = guard.Coordinate.Y });
                } else
                    guard.Facing = Facing.Left;
            }
            else
            {
                if (room[guard.Coordinate.Y, guard.Coordinate.X - 1] == State.Path)
                {
                    guard.Coordinate.X = --guard.Coordinate.X;
                    visitedCoords.Add(new Coordinate() { X = guard.Coordinate.X, Y = guard.Coordinate.Y });
                } else
                    guard.Facing = Facing.Up;
            }
            
            switch (guard.Facing)
            {
                case Facing.Up:
                    if (guard.Coordinate.Y - 1 < 0)
                        walk = false;
                    break;
                case Facing.Right:
                    if (guard.Coordinate.X + 1 > room.GetLength(1)-1)
                        walk = false;
                    break;
                case Facing.Down:
                    if (guard.Coordinate.Y + 1 > room.GetLength(0)-1)
                        walk = false;
                    break;
                case Facing.Left:
                    if (guard.Coordinate.X - 1 < 0)
                        walk = false;
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
        
        var distinctPositions = visitedCoords.Distinct().ToList();
        Console.WriteLine(distinctPositions.Count);
    }
    
    private class Guard
    {
        public Coordinate Coordinate { get; set; }
        public Facing Facing { get; set; }
    }
    
    private enum Facing
    {
        Up,
        Right,
        Down,
        Left
    }
}