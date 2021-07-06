using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tilemap : MonoBehaviour
{
    public TileType[] tileType;
    int[,] tile;

    //15x15 map size
    int mapX = 15;
    int mapZ = 15;

    int y = 0;

    void Start()
    {
        tile = new int[mapX, mapZ];
        tile[0, 0] = 0;

        for (int x=0; x < mapX; x++)
        {
            for (int z = 0; z < mapZ; z++)
            {
                tile[x, z] = 0;
            }
        }

        for (int x=0; x < 30; x++)
        {
            // Random Obstacle Placement
            tile[Random.Range(0, 15), Random.Range(0, 15)] = Random.Range(1, 4);
        }

        SpawnMap();

    }

    void SpawnMap()
    {
        for (int x = 0; x < mapX; x++)
        {
            for (int z = 0; z < mapZ; z++)
            {
                TileType g = tileType[tile[x, z]];

                Instantiate (g.Prefab, new Vector3(x, y, z), Quaternion.identity);
            }
        }
    }
}
