using System.Collections;
using System.Collections.Generic;
using UI;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager instance;

    [SerializeField] private Match match;
    [SerializeField] private BoardUI boardUI;


    public static GameManager Insatnce { get => instance; }

    public Match Match { get => match; set => match = value; }
    public BoardUI BoardUI { get => boardUI; }

    private void Awake()
    {
        instance = this;
    }
}
