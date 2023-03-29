using System;
using System.Drawing;
using UnityEngine;

[Serializable]
public class Player
{
    [SerializeField] private int id;
    [SerializeField] private string name;
    //private int points;
    //private UnityEngine.Color color;

    public int ID { get => id; }
    public string Name { get => name; }
    //public int Points { get => points; set => points = value; }
    //public UnityEngine.Color Color { get => color; }

    //public Player(int id, UnityEngine.Color color)
    //{
    //    this.id = id;
    //    this.color = color;
    //}

    public Player(int id, string name)
    {
        this.id = id;
        this.name = name;
    }
}
