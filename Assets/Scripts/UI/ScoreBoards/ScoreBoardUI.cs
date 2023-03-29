using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using System.Text.RegularExpressions;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using static UnityEditor.Experimental.GraphView.GraphView;

public class ScoreBoardUI : MonoBehaviour
{
    [SerializeField] private GridLayoutGroup grid;
    [SerializeField] private TMP_Text playerName, score;
    [SerializeField] private ScoreBoardData dataPrefab;

    private Match match;
    private List<ScoreBoardData> scores;
    //private List<TMP_Text> scores;

    private void Update()
    {
        if (match == null)
            return;

        scores.ForEach(score => score.UpdateScore());
    }

    public void Initialize(Match match)
    {
        this.match = match;
        scores = new();

        match.Players.ForEach(player =>
        {
            var data = Instantiate(dataPrefab, grid.transform);
            scores.Add(data);
            data.Display(player);
        });
    }

    //private void Update()
    //{
    //    if (match == null)
    //        return;

    //    var players = match.Players;
    //    for (int i = 0; i < players.Count; i++)
    //    {
    //        scores[i].text = match.GetPoints(players[i]).ToString();
    //    }
    //}

    //public void Initialize(Match match)
    //{
    //    this.match = match;
    //    scores = new();

    //    match.Players.ForEach(player =>
    //    {
    //        var name = Instantiate(playerName, grid.transform);
    //        name.text = player.Name;
    //        name.color = match.GetColor(player);

    //        var scr = Instantiate(score, grid.transform);
    //        scr.text = match.GetPoints(player).ToString();
    //        scores.Add(scr);
    //    });
    //}
}
