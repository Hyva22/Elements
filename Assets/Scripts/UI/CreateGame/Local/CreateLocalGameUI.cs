using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Windows;

using preview = UI.PreviewLocalPlayerUI;

namespace UI
{
    public class CreateLocalGameUI : MonoBehaviour
    {
        [SerializeField] private TMP_InputField playerNameInput;
        [SerializeField] private Button playerColorButton;
        [SerializeField] private ColorPicker colorPicker;

        private void Awake()
        {
            playerColorButton.onClick.AddListener(OpenColorPicker);
            colorPicker.Initialize();
            colorPicker.OnSelect.Add(OnColorSelected);
            playerColorButton.GetComponent<Image>().color = colorPicker.SelectedColor;
        }

        private void OpenColorPicker()
        {
            colorPicker.gameObject.SetActive(true);
        }

        private void OnColorSelected()
        {
            playerColorButton.GetComponent<Image>().color = colorPicker.SelectedColor;
        }
    }
}