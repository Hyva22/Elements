using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using static UnityEditor.Experimental.GraphView.GraphView;

public class ScoreBoardUI : MonoBehaviour
{
    [SerializeField] private GridLayoutGroup grid;
    [SerializeField] private TMP_Text playerName, score;

    private Board board;
    private List<TMP_Text> scores;

    private void Update()
    {
        if (board == null)
            return;

        var players = board.Players;
        for (int i = 0; i < players.Count; i++)
        {
            scores[i].text = players[i].Points.ToString();
        }
    }

    public void Display(Board board)
    {
        this.board = board;
        scores = new();
        var players = board.Players;
        playerName.text = players[0].ID.ToString();
        playerName.color = players[0].Color;
        score.text = players[0].Points.ToString();
        scores.Add(score);

        for(int i = 1; i < players.Count; i++)
        {
            var name = Instantiate(playerName, grid.transform);
            name.text= players[i].ID.ToString();
            name.color = players[i].Color;

            var scr = Instantiate(score, grid.transform);
            scr.text= players[i].Points.ToString();
            scores.Add(scr);
        }
    }
}
