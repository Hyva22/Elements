using System.Collections;
using System.Collections.Generic;
using UI;
using UnityEngine;

public class Board
{
    private int size;
    private Tile[,] tiles;
    private List<Player> players;
    private int activePlayer;

    public int Size { get => size; }
    public Tile[,] Tiles { get => tiles; }
    public List<Player> Players { get => players; }
    public Player ActivePlayer { get => players[activePlayer]; }

    public Board(int size, int playerCount)
    {
        this.size = size;
        tiles = new Tile[size,size];

        //populate players
        players = new(playerCount);
        for(int i = 0; i < playerCount; i++)
        {
            players.Add(new Player(i, GameData.GetColor(i)));
        }

        //PopulateGrid grid
        for (int i = 0; i < tiles.GetLength(0); i++)
        {
            for (int j = 0; j < tiles.GetLength(1); j++)
            {
                tiles[i,j] = new(i, j);
            }
        }
    }

    public void CyclePlayer()
    {
        activePlayer++;
        activePlayer %= players.Count;
    }

    private bool IsWin(Tile contestor, Tile challenged)
    {
        if(challenged.Player == null || contestor == null)
            return false;
        Element winElement;
        GameData.winOrder.TryGetValue(contestor.Element, out winElement);

        if(challenged.Element == winElement)
            return true;
        else
            return false;
    }

    public void UpdateScore()
    {
        players.ForEach(player => player.Points = 0);

        for (int i = 0; i < tiles.GetLength(0); i++)
        {
            for (int j = 0; j < tiles.GetLength(1); j++)
            {
                Tile thisTile = tiles[i, j];
                if (thisTile.Player == null)
                    continue;

                //compare up
                if (j + 1 < tiles.GetLength(1))
                {
                    if(IsWin(thisTile, tiles[i, j + 1]))
                        thisTile.Player.Points++;
                }
                //compare right
                if(i + 1 < tiles.GetLength(0))
                {
                    if (IsWin(thisTile, tiles[i + 1, j]))
                        thisTile.Player.Points++;
                }
                //compare down
                if(i > 0)
                {
                    if (IsWin(thisTile, tiles[i - 1, j]))
                        thisTile.Player.Points++;
                }
                //compare left
                if(j > 0)
                {
                    if (IsWin(thisTile, tiles[i, j - 1]))
                        thisTile.Player.Points++;
                }
            }
        }
    }
}
