using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PieceGrid : GameGrid
{
    // struct CharPiecePair {
    //     char c;
    //     GridPiece piece;
    // }

    public PieceGrid(int xSize, int ySize)
        :base(xSize, ySize) {}
    
    string PiecesToString(GameObject[] pieces)
    {
        string result = "";
        foreach(GameObject piece in pieces)
        {
            if(piece.TryGetComponent(out GridPiece gridPiece))
            {
                //result += gridPiece.GetLetter();
            } else
            {
                result += ' ';
            }
        }
        return result;
    }

    public void ScanRow(int row)
    {
        string rowString = PiecesToString(GetGridObjects(new Vector2Int(0, row), gridObjects.GetLength(0)));
        //Debug.Log("Row string: " + rowString);
        List<string> possibleStrings = new List<string>();
        int minWordLength = 3;
        for(int a = 0; a < rowString.Length; a++)
        {
            for(int b = a + minWordLength - 1; b < rowString.Length; b++)
            {
                possibleStrings.Add(PiecesToString((GetGridObjects(new Vector2Int(a, row), b - a + 1))));
            }
        }
        foreach(string s in possibleStrings)
        {
            Debug.Log("String subset: " + s);
        }
    }

}
