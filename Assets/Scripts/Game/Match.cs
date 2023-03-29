using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class PlayerData
{
    public Color color;
    public int points;
}

[Serializable]
public class Match
{
    [SerializeField] private List<Player> players;
    [SerializeField] private Player activePlayer;
    [SerializeField] private SDictionary<Player, PlayerData> playerData;
    [SerializeField] private int turn;
    [SerializeField] private Board board;

    public Board Board { get => board; }
    public Player ActivePlayer { get => activePlayer; set => activePlayer = value; }
    public List<Player> Players { get => players; }

    public Match(List<Player> players, int boardSize)
    {
        if (players == null || players.Count < 2)
            throw new System.Exception("Need at least 2 palyers to create a match!");

        this.players = players;

        InitializePlayerdata();

        activePlayer = players[0];

        board = new(boardSize);
    }

    private void InitializePlayerdata()
    {
        playerData = new();
        for (int i = 0; i < players.Count; i++)
        {
            PlayerData pd = new() { color = GameData.GetColor(i) };
            playerData.Add(players[i], pd);
        }
    }

    private PlayerData GetPlayerData(Player player)
    {
        for (int i = 0; i < playerData.Count; i++)
        {
            if (playerData[i].key == player)
                return playerData[i].value;
        }

        throw new Exception("Player data not found");
    }

    public Color GetColor(Player player)
    {
        return GetPlayerData(player).color;
    }

    public int GetPoints(Player player)
    {
        return GetPlayerData(player).points;
    }

    public void CyclePlayer()
    {
        if(activePlayer == null)
        {
            activePlayer = players[0];
            return;
        }
        else
        {
            int index = players.IndexOf(activePlayer);
            index = (index + 1 ) % players.Count;
            activePlayer = players[index];
        }
    }

    private bool IsWin(Tile contestor, Tile challenged)
    {
        if (challenged.Player == null || contestor == null)
            return false;
        Element winElement;
        GameData.winOrder.TryGetValue(contestor.Element, out winElement);

        if (challenged.Element == winElement)
            return true;
        else
            return false;
    }

    public void UpdateScore()
    {
        playerData.ForEach(player => player.value.points = 0);

        var tiles = Board.Tiles;

        for (int i = 0; i < tiles.GetLength(0); i++)
        {
            for (int j = 0; j < tiles.GetLength(1); j++)
            {
                Tile thisTile = tiles[i, j];
                if (thisTile.Player == null)
                    continue;

                var playerData = GetPlayerData(thisTile.Player);

                //compare up
                if (j + 1 < tiles.GetLength(1))
                {
                    if (IsWin(thisTile, tiles[i, j + 1]))
                        playerData.points++;
                }
                //compare right
                if (i + 1 < tiles.GetLength(0))
                {
                    if (IsWin(thisTile, tiles[i + 1, j]))
                        playerData.points++;
                }
                //compare down
                if (i > 0)
                {
                    if (IsWin(thisTile, tiles[i - 1, j]))
                        playerData.points++;
                }
                //compare left
                if (j > 0)
                {
                    if (IsWin(thisTile, tiles[i, j - 1]))
                        playerData.points++;
                }
            }
        }
    }
}
