using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class ElementPickerUI : MonoBehaviour
    {
        [SerializeField] private Button fire, water, earth, wind;

        private Board board;
        private TileUI tileUI;

        private void Awake()
        {
            fire.onClick.AddListener(() => Set(Element.Fire));
            water.onClick.AddListener(() => Set(Element.Water));
            earth.onClick.AddListener(() => Set(Element.Earth));
            wind.onClick.AddListener(() => Set(Element.Wind));
        }

        public void Open(TileUI tileUI, Board board)
        {
            this.tileUI = tileUI;
            this.board = board;

            transform.position = tileUI.transform.position;
        }

        private void Set(Element element)
        {
            Match match = GameManager.Insatnce.Match;
            tileUI.Set(match.ActivePlayer, element);
            match.UpdateScore();
            match.CyclePlayer();
            gameObject.SetActive(false);
        }
    }
}
