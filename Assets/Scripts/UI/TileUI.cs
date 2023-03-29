using System.Collections;
using System.Collections.Generic;
using System.Xml.Linq;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class TileUI : MonoBehaviour
    {
        [SerializeField] private Image foregroundImage, backgroundImage;
        [SerializeField] private Button button;
        private Tile tile;

        public Tile Tile { get => tile; }

        public void Set(Tile tile, BoardUI boardUI, int x, int y)
        {
            this.tile = tile;
            UpdateImages();

            button.onClick.RemoveAllListeners();
            button.onClick.AddListener(() => 
            {
                if(tile.Player == null)
                {
                    ElementPickerUI epUI = boardUI.ElementPickerUI;
                    epUI.gameObject.SetActive(true);
                    epUI.Open(this, boardUI.Board);
                }
            });
        }

        public void Set(Player player, Element element)
        {
            tile.Set(player, element);
            UpdateImages();
        }

        private void UpdateImages()
        {
            UpdateBackground();
            UpdateForeground();
        }

        private void UpdateBackground()
        {
            backgroundImage.color = tile.Player == null ? GameData.DefaultColor : GameManager.Insatnce.Match.GetColor(tile.Player);
        }

        private void UpdateForeground()
        {
            if (tile.Player == null)
            {
                foregroundImage.enabled = false;
            }
            else
            {
                foregroundImage.enabled = true;
                foregroundImage.sprite = GameData.GetSprite(tile.Element);
            }
        }
    }
}
