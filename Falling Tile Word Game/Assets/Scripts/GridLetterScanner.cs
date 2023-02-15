using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridLetterScanner
{
    
    private GridLayout gridLayout;

    public GridLetterScanner(GridLayout gridLayout)
    {
        this.gridLayout = gridLayout;
    }

    public List<GridPiece> ScanLineFromPiece(Vector2 pieceLocation, bool checkVertical = false)
    {
        List<GridPiece> gridPieces = new List<GridPiece>();
        if(!checkVertical)
        {
            float yPos = pieceLocation.y;
            for(float x = pieceLocation.x; GetGridPieceLetter(new Vector2(x, yPos)) != ' '; x++)
            {
                gridPieces.Add(GetGridPiece(new Vector2(x, yPos)));
            }
            for(float x = pieceLocation.x - 1; GetGridPieceLetter(new Vector2(x, yPos)) != ' '; x--)
            {
                gridPieces.Insert(0, GetGridPiece(new Vector2(x, yPos)));
            }
            return gridPieces;
        }
        float xPos = pieceLocation.x;
        for(float y = pieceLocation.y; GetGridPieceLetter(new Vector2(xPos, y)) != ' '; y--)
        {
            gridPieces.Add(GetGridPiece(new Vector2(xPos, y)));
        }
        for(float y = pieceLocation.y + 1; GetGridPieceLetter(new Vector2(xPos, y)) != ' '; y++)
        {
            gridPieces.Insert(0, GetGridPiece(new Vector2(xPos, y)));
        }
        return gridPieces;
    }

    public GridPiece GetGridPiece(Vector2 position)
    {
        RaycastHit2D[] hits = Physics2D.RaycastAll(position, Vector2.left, 0.0001f);
        foreach(RaycastHit2D hit in hits)
        {
            if(hit.transform.gameObject.GetComponent<GridPiece>() != null)
            {
                return hit.transform.gameObject.GetComponent<GridPiece>();
            }
        }
        return null;
    }

    char GetGridPieceLetter(Vector2 position)
    {
        GridPiece gridPiece = GetGridPiece(position);
        if(gridPiece != null && gridPiece.TryGetComponent(out IHaveLetter Letter))
        {
            return Letter.GetLetter();
        }
        return ' ';
    }

    bool DoPiecesContainWord(List<GridPiece> gridPieces)
    {
        return true;
    }
    
}
