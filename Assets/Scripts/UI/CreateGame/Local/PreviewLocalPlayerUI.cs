using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class PreviewLocalPlayerUI : MonoBehaviour
    {
        [SerializeField] private TMP_Text id, playerName;
        [SerializeField] private Button removeButton;

        public string PlayerName { get => playerName.text; set => playerName.text = value; }
        public int ID { get => int.Parse(id.text); set => id.text = value.ToString(); }
        public Button RemoveButton { get => removeButton; }
    }
}