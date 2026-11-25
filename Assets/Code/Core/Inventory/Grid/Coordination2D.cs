public class Coordination2D
{
    private readonly int _x;
    private readonly int _y;

    public int X => _x;
    public int Y => _y;

    public Coordination2D(int x, int y)
    {
        _x = x;
        _y = y;
    }

    public override string ToString()
    {
        return $"x : {_x}, y : {_y}";
    }
}
