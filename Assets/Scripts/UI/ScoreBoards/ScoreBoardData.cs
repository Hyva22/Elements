using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ScoreBoardData : MonoBehaviour
{
    [SerializeField] private TMP_Text playerName, score;

    private Player player;


    public void Display(Player player)
    {
        this.player = player;
        playerName.text = player.Name;
        playerName.color = GameManager.Insatnce.Match.GetColor(player);
        UpdateScore();
    }

    public void UpdateScore()
    {
        score.text = GameManager.Insatnce.Match.GetPoints(player).ToString();
    }
}
