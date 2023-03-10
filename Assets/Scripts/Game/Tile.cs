public class Tile
{
    private Player player;
    private Element element;
    private int x, y;

    public Player Player { get => player; set => player = value; }
    public Element Element { get => element; set => element = value; }
    public int X { get => x; }
    public int Y { get => y; }

    public Tile(int x, int y)
    {
        this.x = x;
        this.y = y;
    }

    public void Set(Player player, Element element)
    {
        this.player = player;
        this.element = element;
    }
}
