using System;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Windows;

namespace UI
{
    public class CreateGameUI : MonoBehaviour
    {
        [SerializeField] private TMP_InputField sizeInput, playerCountInput;
        [SerializeField] private string boardSceneName;
        [SerializeField] private BoardContainer boardContainer;

        public void CreateGame()
        {
            //Validate board size
            int size;
            string sizeText = sizeInput.text;
            try
            {
                size = int.Parse(sizeText);
            }
            catch (Exception)
            {
                Debug.Log("Size must be a number!");
                return;
            }

            if (size <= 0)
            {
                Debug.Log("Size: Only positive numbers greater 0 allowed!");
                return;
            }

            //Validate player count
            int playerCount;
            string pcText = playerCountInput.text;
            try
            {
                playerCount = int.Parse(pcText);
            }
            catch (Exception)
            {
                Debug.Log("Player count must be a number!");
                return;
            }

            if (playerCount <= 0)
            {
                Debug.Log("Player count: Only positive numbers between");
                return;
            }

            boardContainer.size = size;
            boardContainer.playerCount = playerCount;
            DontDestroyOnLoad(boardContainer);
            SceneManager.LoadScene(boardSceneName, LoadSceneMode.Single);
        }
    }
}