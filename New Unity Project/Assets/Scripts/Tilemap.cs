using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tilemap : MonoBehaviour
{
    public GameObject player;

    public TileType[] tileType;
    int[,] tile;

    //15x15 map size
    int mapX = 7;
    int mapZ = 7;

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

        for (int x=0; x < 4; x++)
        {
            // Random Obstacle Placement
            tile[Random.Range(1, 7), Random.Range(1, 7)] = Random.Range(1, 4);
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

                GameObject t = (GameObject)Instantiate (g.Prefab, new Vector3(x, y, z), Quaternion.identity);

                Interactable i = t.GetComponent<Interactable>();
                i.tileX = x;
                i.tileZ = z;
                i.map = this;
            }
        }
    }

    public void playerMovement(int x, int z)
    {
        player.transform.position = new Vector3(x, 0.5f, z);
    }
}
