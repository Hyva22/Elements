using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class StartScreen : MonoBehaviour
    {
        [SerializeField] private Button onlineGameButton, localGameButton, settingsButton, quitGameButon;
        [SerializeField] private CreateLocalGameUI createLocalGameUIPrefab;

        private void Awake()
        {
            quitGameButon.onClick.AddListener(QuitGame);
            localGameButton.onClick.AddListener(OpenCreateLocalGameUI);
        }

        private void OpenCreateLocalGameUI()
        {
            Instantiate(createLocalGameUIPrefab, transform.parent);
            Destroy(gameObject);
        }

        private void QuitGame()
        {
            Application.Quit();
        }
    }
}
