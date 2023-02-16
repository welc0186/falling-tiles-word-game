using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameGrid
{
    protected GameObject[,] gridObjects;

    public GameGrid(int xSize, int ySize)
    {
        gridObjects = new GameObject[xSize, ySize];
    }

    public GameObject GridObject(int x, int y)
    {
        if(WithinBounds(x,y))
        {
            return gridObjects[x,y];
        }
        return null;
    }

    public GameObject[] GetGridObjects(Vector2Int start, int length = 1, bool horizontal = true)
    {
        if(!WithinBounds(start) || length < 1)
        {
            return new GameObject[0];
        }
        GameObject[] result = new GameObject[length];
        if(horizontal)
        {
            for(int x = start.x; x < start.x + length; x++)
            {
                result[x - start.x] = gridObjects[x, start.y];
            }
            return result;
        }
        for(int y = start.y; y > start.y - length; y--)
        {
            result[start.y - y] = gridObjects[start.x, y];
        }
        return result;
    }

    public void AddGridObject(GameObject gridObject, int x, int y)
    {
        gridObjects[x,y] = gridObject;
    }

    public bool ClearGridObjects(List<GameObject> clearObjects)
    {
        bool foundAll = true;
        foreach(GameObject clearObject in clearObjects)
        {
            foundAll = foundAll && ClearGridObject(clearObject);
        }
        return foundAll;
    }

    public bool ClearGridObject(GameObject clearObject)
    {
        int x = WhereGridObject(clearObject).x;
        int y = WhereGridObject(clearObject).y;
        if(x > -1 && y > -1)
        {
            gridObjects[x,y] = null;
            return true;
        }
        return false;
    }

    public Vector2Int WhereGridObject(GameObject findObject)
    {
        for(int x = 0; x < gridObjects.GetLength(0); x++)
        {
            for(int y = 0; y < gridObjects.GetLength(1); y++)
            {
                if(gridObjects[x, y] == findObject)
                {
                    return new Vector2Int(x, y);
                }
            }
        }
        return new Vector2Int(-1, -1);
    }

    protected bool WithinBounds(int x, int y)
    {
        if(0 <= x && x < gridObjects.GetLength(0) &&
            0 <= y && y < gridObjects.GetLength(1))
        {
            return true;
        }
        return false;
    }
    
    protected bool WithinBounds(Vector2Int coord)
    {
        int x = coord.x;
        int y = coord.y;
        return WithinBounds(x, y);
    }

}
