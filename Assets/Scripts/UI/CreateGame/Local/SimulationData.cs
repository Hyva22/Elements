using System.Collections;
using System.Collections.Generic;
using UI;
using UnityEngine;

public class SimulationData : MonoBehaviour
{
    [SerializeField] private int playerCount = 2;
    [SerializeField] private int boardSize = 5;

    [SerializeField] private BoardUI boardUI;

    private void Awake()
    {
        StartCoroutine(Load());
    }

    private IEnumerator Load()
    {
        Debug.Log("loading Game...");
        yield return null;
        GameManager.Insatnce.Match = new(GeneratePlayers(), boardSize);
        boardUI.Load(GameManager.Insatnce.Match.Board);
        Debug.Log("loading finished");
    }

    private List<Player> GeneratePlayers()
    {
        List<Player> players = new();

        for(int i = 0; i < playerCount; i++)
        {
            players.Add(new Player(-1, "Player " + i));
        }

        return players;
    }
}
