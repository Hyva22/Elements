using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class ColorPicker : MonoBehaviour, IInitializable
    {
        [Tooltip("If true the window will be deactivated after selecting a color")]
        [SerializeField] private bool disableOnSelect;
        [Tooltip("The colors that can be selected in the grid.")]
        [SerializeField] private Color[] colors;
        [SerializeField] private Button colorButtonPrefab;
        [SerializeField] private GridLayoutGroup grid;

        private Dictionary<Color, Button> buttons = new();
        private Color selectedColor; //Last clicked color
        private List<Action> onSelect = new();

        public Color SelectedColor { get => selectedColor; }
        public List<Action> OnSelect { get => onSelect; }


        #region IIinitializable
        public bool IsInitialized { get; set; } = false;

        public void Initialize()
        {
            if (IsInitialized)
                return;
            ResizeGrid();
            PopulateGrid();
            IsInitialized = true;
        }
        #endregion IIinitializable

        private void Awake()
        {
            Initialize();
        }

        /// <summary>
        /// Resizes grid to be a square
        /// </summary>
        private void ResizeGrid()
        {
            grid.constraint = GridLayoutGroup.Constraint.FixedColumnCount;
            grid.constraintCount = colors.Length / 2;
        }

        /// <summary>
        /// Clears grid and populates it with all the colors.
        /// </summary>
        private void PopulateGrid()
        {
            buttons.Clear();

            foreach (Color color in colors)
            {
                Button colorButton = Instantiate(colorButtonPrefab, transform);
                colorButton.GetComponent<Image>().color = color;
                colorButton.onClick.AddListener(() =>
                {
                    selectedColor = color;
                    if(disableOnSelect)
                        gameObject.SetActive(false);
                    onSelect.ForEach(action => action());
                });

                buttons.Add(color, colorButton);
            }

            selectedColor = colors[0];
        }

        /// <summary>
        /// Returns selected color and disables it from being selected again
        /// </summary>
        /// <returns>Selected color</returns>
        public Color FetchColor()
        {
            buttons.TryGetValue(selectedColor, out Button button);
            button.interactable = false;
            return selectedColor;
        }

        /// <summary>
        /// Makes the button with the given color interactable.
        /// </summary>
        /// <param name="color">Color to activate</param>
        public void Activate(Color color)
        {
            buttons.TryGetValue(color, out Button button);
            button.interactable = true;
        }
    }
}
