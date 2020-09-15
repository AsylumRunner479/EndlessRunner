using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileManager : MonoBehaviour
{
    //sets a collection of tilesprefabs
    public GameObject[] tilePrefabs;
    //spawnpoint on the z access for the tiles
    public float zSpawn = 0;
    //how long each tile is
    public float tileLength = 30;
    //how many tiles can be on the screen at once
    public int numberOfTiles = 25;
    private List<GameObject> activeTiles = new List<GameObject>();
    public Transform player;
    // Start is called before the first frame update
    void Start()
    {
        //activates spawn tile function a number of times dependent
        for (int i = 0; i < numberOfTiles; i++)
        {
            if (i == 0)
            {
                SpawnTile(0);
            }
            else
            {
                SpawnTile(Random.Range(0, tilePrefabs.Length));
            }
            
        }
    }

    // Update is called once per frame
    void Update()
    {
        //spawns tiles when the player progresses further and deletes behind
        if (player.position.z - 70 > zSpawn -(numberOfTiles*tileLength))
        {
            SpawnTile(Random.Range(0, tilePrefabs.Length));
            DeleteTile();
        }
    }
    //delete the earliest tile spawned
    private void DeleteTile()
    {
        Destroy(activeTiles[0]);
        activeTiles.RemoveAt(0);
    }
    //spawns tile at the spawnpoint.
    public void SpawnTile(int tileIndex)
    {
        GameObject go =
        Instantiate(tilePrefabs[tileIndex], transform.forward * zSpawn + transform.right * 9, transform.rotation);
        activeTiles.Add(go);
        zSpawn += tileLength;

    }
}
