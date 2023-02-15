using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class PrintTilemapCoords : MonoBehaviour
{

    [SerializeField] private int minX;
    [SerializeField] private int maxX;
    [SerializeField] private int minY;
    [SerializeField] private int maxY;

    void OnDrawGizmos()
    {
        GridLayout gridLayout = GetComponent<GridLayout>();

        for(int x = minX; x < maxX; x++)
        {
            for(int y = minY; y < maxY; y++)
            {
                string label = x.ToString() + "," + y.ToString();
                Handles.Label(gridLayout.CellToWorld(new Vector3Int(x, y, 0)), label);
            }
        }
    }
}
