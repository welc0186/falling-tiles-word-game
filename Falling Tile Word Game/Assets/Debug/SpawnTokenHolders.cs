using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnTokenHolders : MonoBehaviour
{
    
    [SerializeField] GameObject tokenHolderPrefab;

    [SerializeField] private int minX;
    [SerializeField] private int maxX;
    [SerializeField] private int minY;
    [SerializeField] private int maxY;

    void Awake()
    {
        GridLayout gridLayout = GetComponent<GridLayout>();

        for(int x = minX; x < maxX; x++)
        {
            for(int y = minY; y < maxY; y++)
            {
                Vector3 position = gridLayout.CellToWorld(new Vector3Int(x, y, 0));
                Instantiate(tokenHolderPrefab, new Vector3(position.x + 0.5f, position.y + 0.5f, 0), Quaternion.identity);
            }
        }
    }
}
