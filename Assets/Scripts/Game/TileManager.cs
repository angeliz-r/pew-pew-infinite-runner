using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileManager : MonoBehaviour
{
    [Header("Tile Types")]
    public GameObject[] TilePrefabs;

    [Header("Other Things")]
    [SerializeField] private Transform playerTransform;
    [SerializeField] private GameObject standardSize;


    [Header("ScoreManager")]
    public Score scoreManager;

    private float spawnZ;
    private float tileLength;
    private int tilesOnScreen = 16;
    private float safeZone;
    private int lastPrefabIndex = 0;

    [Header("Spawned Tiles")]
    public List<GameObject> activeTiles;
    void Awake()
    {
        activeTiles = new List<GameObject>();

        //grab size from renderer para sure & so its not hardcoded
        tileLength = standardSize.GetComponent<Renderer>().bounds.size.z;
        Debug.Log("tile length bridge" + tileLength);
        spawnZ = -tileLength * 6;
        safeZone = tileLength * 2 ;

    }

    private void Start()
    {
        EventManager.current.updateEvent += UpdateTiles;
        //initialize first so player won't fall without anyone catching them
        for (int i = 0; i < tilesOnScreen; i++)
        {
            if (i < 10)
                SpawnTile(0);
            else
                SpawnTile();
        }
    }

    private void OnDestroy()
    {
        EventManager.current.updateEvent -= UpdateTiles;
    }

    void UpdateTiles()
    {
        if (playerTransform.position.z - safeZone> (spawnZ - tilesOnScreen * tileLength))
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
        go.transform.position = Vector3.forward * spawnZ;
        spawnZ += tileLength;
        activeTiles.Add(go);
    }

    private void DeleteTile()
    {
        Destroy(activeTiles[0]);
        activeTiles.RemoveAt(0);
    }

    private int RandomPrefabIndex()
    {
        if (TilePrefabs.Length <= 1)
        {
            return 0;
        }

        int randomIndex = 0;
        while(randomIndex == lastPrefabIndex) //randomize w/o repeating
        {
            //randomize depending on higher score
            if (scoreManager.GetScore() <=  300)
            {
                randomIndex = Random.Range(0, 5);
            }
            if (scoreManager.GetScore() > 300)
            {
                randomIndex = Random.Range(0, 10);
            }
            if (scoreManager.GetScore() > 600)
            {
                randomIndex = Random.Range(0, 14);
            }
            if (scoreManager.GetScore() > 900)
            {
                randomIndex = Random.Range(0, TilePrefabs.Length);
            }
        }
        lastPrefabIndex = randomIndex;
        return randomIndex;
    }

}
