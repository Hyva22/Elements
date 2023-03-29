using System.Collections;
using System.Collections.Generic;
using Unity.Collections.LowLevel.Unsafe;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class BoardUI : MonoBehaviour
    {
        #region UI
        [SerializeField] private GridLayoutGroup tilesGrid;
        [SerializeField] private ElementPickerUI elementPickerUI;
        [SerializeField] private ScoreBoardUI scoreBoardUI;
        [SerializeField] private GameData gameData;
        [SerializeField] private TileUI tilePrefab;
        #endregion UI

        private Board board;

        public Board Board { get => board; }
        public ElementPickerUI ElementPickerUI { get => elementPickerUI; }


        //private void Awake()
        //{
        //    GameData.Initialize();
        //    LoadBoard();
        //    PopulateBoard();
        //    scoreBoardUI.Display(board);
        //}

        public void Load(Board board)
        {
            this.board = board;
            //Caching variables
            Transform tilesContainer = tilesGrid.transform;
            Tile[,] tiles = board.Tiles;

            //resize Grid
            tilesGrid.constraintCount = board.Size;

            //PopulateGrid grid
            for (int i = 0; i < tiles.GetLength(0); i++)
            {
                for (int j = 0; j < tiles.GetLength(1); j++)
                {
                    TileUI tile = Instantiate(tilePrefab, tilesContainer);
                    tile.Set(tiles[i, j], this, i, j);
                }
            }

            scoreBoardUI.Initialize(GameManager.Insatnce.Match);
        }

        //private void LoadBoard()
        //{
        //    BoardContainer boardContainer = FindObjectOfType<BoardContainer>();
        //    if(boardContainer == null)
        //    {
        //        board = new(5, 2);
        //    }
        //    else
        //    {
        //        board = new(boardContainer.size, boardContainer.playerCount);
        //        Destroy(boardContainer.gameObject);
        //    }
        //}

        //private void PopulateBoard()
        //{
        //    //Caching variables
        //    Transform tilesContainer = tilesGrid.transform;
        //    Tile[,] tiles = board.Tiles;

        //    //resize Grid
        //    tilesGrid.constraintCount = board.Size;

        //    //PopulateGrid grid
        //    for(int i = 0; i < tiles.GetLength(0); i++)
        //    {
        //        for (int j = 0; j < tiles.GetLength(1); j++)
        //        {
        //            TileUI tile = Instantiate(tilePrefab, tilesContainer);
        //            tile.Set(tiles[i, j], this);
        //        }
        //    }
        //}
    }
}
