using System.Drawing;
using UnityEngine;

public class Player
{
    private int id, points;
    private UnityEngine.Color color;

    public int ID { get => id; }
    public int Points { get => points; set => points = value; }
    public UnityEngine.Color Color { get => color; }

    public Player(int id, UnityEngine.Color color)
    {
        this.id = id;
        this.color = color;
    }
}
