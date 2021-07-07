using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tilemap : MonoBehaviour
{
    public GameObject player;

    public TileType[] tileType;
    int[,] tile;

    Node[,] graph;

    //7x7 map size
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

        graphMap();

        SpawnMap();

    }

    class Node
    {
        public List<Node> points;
    }

    void graphMap()
    {
        graph = new Node[mapX, mapZ];

        for (int x = 0; x < mapX; x++)
        {
            for (int z = 0; z < mapZ; z++)
            {
                graph[x, z].points.Add(graph[x - 1, z]);
                graph[x, z].points.Add(graph[x + 1, z]);
                graph[x, z].points.Add(graph[x, z - 1]);
                graph[x, z].points.Add(graph[x, z + 1]);
            }
        }
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

    public Vector3 coord(int x, int z)
    {
        return new Vector3(x, 0.5f, z);
    }

    public void playerMovement(int x, int z)
    {
        //set player coord info
        player.GetComponent<player>().tileX = x;
        player.GetComponent<player>().tileZ = z;
        //set player visual info
        player.transform.position = coord(x, z);

        //Dijkstra pathfinding algorithm
        Dictionary<Node, float> distance = new Dictionary<Node, float>();

        Node source = graph[player.GetComponent<player>().tileX];
        Node source = graph[player.GetComponent<player>().tileZ];

        distance[source] = 0;
    }
}
