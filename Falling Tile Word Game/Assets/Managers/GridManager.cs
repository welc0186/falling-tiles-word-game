using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class GridManager : MonoBehaviour
{
    [SerializeField] GameObject tokenHolderPrefab;

    [SerializeField] private float tokenHolderSpawnChance;

    [SerializeField] private int minX;
    [SerializeField] private int maxX;
    [SerializeField] private int minY;
    [SerializeField] private int maxY;

    private GridLetterScanner gridLetterScanner;
    private bool initialized;
    public PieceGrid GridPieces { get; private set; }
    
    void Awake()
    {
        gridLetterScanner = new GridLetterScanner(GetComponent<GridLayout>());
        GameManager.OnGameStateChanged += GameStateChanged;
        GridPieces = new PieceGrid(maxX, maxY);
    }

    void InitializeGrid()
    {
        for(int x = minX; x < maxX; x++)
        {
            for(int y = minY; y < maxY; y++)
            {
                SpawnGridPiece(new Vector2Int(x, y));
            }
        }
        initialized = true;
    }

    private void GameStateChanged(GameState newState)
    {
        if(newState == GameState.Play)
        {
            InitializeGrid();
        }
    }

    void SpawnGridPiece(Vector2Int gridCoordinate)
    {
        GameObject spawnPrefab = tokenHolderPrefab;
        // if(UnityEngine.Random.Range(0,1f) < tokenHolderSpawnChance)
        // {
        //     spawnPrefab = tokenHolderPrefab;
        // }
        Vector3 position = GetComponent<GridLayout>().CellToWorld(new Vector3Int(gridCoordinate.x, gridCoordinate.y, 0));
        GameObject gridPieceGO = Instantiate(spawnPrefab, new Vector3(position.x + 0.5f, position.y + 0.5f, 0), Quaternion.identity);
        gridPieceGO.GetComponent<GridPiece>().OnGridChanged += OnGridChanged;
        if(initialized)
        {
            gridPieceGO.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
            gridPieceGO.transform.DOScale(Vector3.one, 0.5f);
        }
        GridPieces.AddGridObject(gridPieceGO, gridCoordinate.x, gridCoordinate.y);
    }

    void OnGridChanged(object sender, GridPiece.OnGridChangedEventArgs e)
    {
        Vector2Int piecePosition = GridPieces.WhereGridObject(e.GridPiece.gameObject);
        int xPos = piecePosition.x;
        int yPos = piecePosition.y;
        GridPieces.ScanRow(yPos);
        // List<GridPiece> horizontalGridPieces = ScanLineFromPiece(xPos, yPos, false);
        // List<GridPiece> verticalGridPieces = ScanLineFromPiece(xPos, yPos, true);
        // bool isHorizontalWord = Dictionary.Instance.IsValidWord(PiecesToString(horizontalGridPieces));
        // bool isVerticalWord = Dictionary.Instance.IsValidWord(PiecesToString(verticalGridPieces));
        // if(isHorizontalWord)
        // {
        //     ClearGridPieces(horizontalGridPieces);
        // }
        // if(isVerticalWord)
        // {
        //     ClearGridPieces(verticalGridPieces);
        // }
    }

    string PiecesToString(List<GridPiece> gridPieces)
    {
        string word = "";
        foreach(GridPiece gridPiece in gridPieces)
        {
            //word += gridPiece.GetLetter();
        }
        return word;
    }

    void ClearGridPieces(List<GridPiece> gridPieces)
    {
        PointManager.Instance.AddPoints(gridPieces.Count);
        foreach(GridPiece gridPiece in gridPieces)
        {
            ClearGridPiece(gridPiece);
        }
    }

    void ClearGridPiece(GridPiece gridPiece)
    {
        GridPieces.ClearGridObject(gridPiece.gameObject);
        //gridPiece.Clear();
    }

    // void ShiftColumnDown(int x)
    // {
    //     for(int y = 1; y < maxY; y++)
    //     {
    //         if(GridPieces[x,y-1] == null)
    //         {
    //             Vector3 newPosition = GetComponent<GridLayout>().CellToWorld(new Vector3Int(x, y-1, 0));
    //             GridPieces[x, y].GetComponent<GridPiece>()?.FallTo(new Vector3(newPosition.x + 0.5f, newPosition.y + 0.5f, 0));
    //             GridPieces[x, y-1] = GridPieces[x, y];
    //             GridPieces[x, y] = null;
    //         }
    //     }
    // }

    List<GridPiece> ScanLineFromPiece(int startX, int startY, bool checkVertical = false)
    {
        List<GridPiece> gridPieces = new List<GridPiece>();
        if(!checkVertical)
        {
            int yPos = startY;
            for(int x = startX; GetGridPieceLetter(x, yPos) != ' '; x++)
            {
                gridPieces.Add(GridPieces.GridObject(x, yPos).GetComponent<GridPiece>());
            }
            for(int x = startX - 1; GetGridPieceLetter(x, yPos) != ' '; x--)
            {
                gridPieces.Insert(0, GridPieces.GridObject(x, yPos).GetComponent<GridPiece>());
            }
            return gridPieces;
        }
        int xPos = startX;
        for(int y = startY; GetGridPieceLetter(xPos, y) != ' '; y--)
        {
            gridPieces.Add(GridPieces.GridObject(xPos, y).GetComponent<GridPiece>());
        }
        for(int y = startY + 1; GetGridPieceLetter(xPos, y) != ' '; y++)
        {
            gridPieces.Insert(0, GridPieces.GridObject(xPos, y).GetComponent<GridPiece>());
        }
        return gridPieces;
    }

    char GetGridPieceLetter(int x, int y)
    {
        GameObject gridPiece = GridPieces.GridObject(x, y);
        if(gridPiece != null && gridPiece.TryGetComponent(out IHaveLetter Letter))
        {
            return Letter.GetLetter();
        }
        return ' ';
    }

    void OnDestroy()
    {
        GameManager.OnGameStateChanged -= GameStateChanged;
    }

    // Vector2Int FindGamePiece(GameObject gamePiece)
    // {
    //     for(int x = 0; x < maxX; x++)
    //     {
    //         for(int y = 0; y < maxY; y++)
    //         {
    //             if(GridPieces[x, y] == gamePiece)
    //             {
    //                 return new Vector2Int(x, y);
    //             }
    //         }
    //     }
    //     return new Vector2Int(-1, -1);
    // }

}
