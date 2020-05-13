using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpManager : MonoBehaviour
{
    [Header("Tile Types")]
    public GameObject[] TilePrefabs;

    [Header("Other Things")]
    [SerializeField] private Transform playerTransform;
    [SerializeField] private GameObject standardSize;

    private float spawnZ = 0;
    private float tileLength;
    private int tilesOnScreen = 10;
    private float safeZone;
    private int lastPrefabIndex = 0;
    private int i;
    private Vector3 xval;

    [Header("Spawned Tiles")]
    public List<GameObject> activeTiles;
    void Awake()
    {
        activeTiles = new List<GameObject>();

        //grab size from renderer para sure & so its not hardcoded
        tileLength = standardSize.GetComponent<Renderer>().bounds.size.z;
        Debug.Log("tile length " + tileLength);
        spawnZ = 40;
        safeZone = tileLength * 2;
    }

    private void Start()
    {
        for (int i = 0; i < tilesOnScreen; i++)
        {
            if (i < 10)
                SpawnTile(1);
            else
                SpawnTile();
        }
    }

    void Update()
    {
        if (playerTransform.position.z - safeZone > (spawnZ - tilesOnScreen * tileLength))
        {
            SpawnTile();
            //destroy the things catching the player when not needed anymore
            DeleteTile();
        }
    }

    private void SpawnTile(int prefabIndex = -1)
    {
        GameObject go;
        if (prefabIndex == -1)
            go = Instantiate(TilePrefabs[RandomPrefabIndex()]) as GameObject;
        else
            go = Instantiate(TilePrefabs[prefabIndex]) as GameObject;
        go.transform.SetParent(transform);

        if (i < 10) //change lane every 10
        {
            RandomLaneSpawn();
            i = 0;
        }
        go.transform.position = new Vector3(-1, 0, 0);
        go.transform.position = Vector3.forward * spawnZ;
        go.transform.position += xval * spawnZ;
        spawnZ += tileLength * 2; //spacing
        activeTiles.Add(go);
        i++;


    }

    private void DeleteTile()
    {
        Destroy(activeTiles[0]);
        activeTiles.RemoveAt(0);
    }

    private void RandomLaneSpawn()
    {
        int randomInd = 0;
        randomInd = Random.Range(-1, 1);

        if (randomInd == -1)
        {
            xval = Vector3.left;
        }
        else if (randomInd == 1)
        {
            xval = Vector3.right;
        }
    }
    private int RandomPrefabIndex()
    {
        if (TilePrefabs.Length <= 1)
        {
            return 0;
        }

        int randomIndex = 0;
        randomIndex = Random.Range(0, TilePrefabs.Length);
        lastPrefabIndex = randomIndex;
        return randomIndex;
    }

}
