using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpManager : MonoBehaviour
{
    [Header("Tile Types")]
    public GameObject[] TilePrefabs;
    public GameObject[] SpecialTilePrefabs;

    [Header("Other Things")]
    [SerializeField] private Transform playerTransform;
    [SerializeField] private GameObject standardSize;

    private float spawnZ = 0;
    private float tileLength;
    private int tilesOnScreen = 30;
    private float safeZone;
    private int lastPrefabIndex = 0;
    private int i, j, coinRandomNumber, specialRandomNumber;
    private bool spawn;
    //private Vector3 xval;

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
        spawn = true;
    }

    private void Start()
    {
        EventManager.current.updateEvent += UpdateTiles;
        coinRandomNumber = RandomPrefabIndex();
        specialRandomNumber = SpecialRandomPrefabIndex();
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
        if (i > 20) //change location of coin every 20
        {
            spawn = false;
            coinRandomNumber = RandomPrefabIndex();

            i = 0;
            //spawn special
            specialRandomNumber = RandomPrefabIndex();
        }
        if (spawn) //spawn coins
        {
            if (prefabIndex == -1)
                go = Instantiate(TilePrefabs[coinRandomNumber]) as GameObject;
            else
                go = Instantiate(TilePrefabs[prefabIndex]) as GameObject;

            go.transform.SetParent(transform);
            go.transform.position = new Vector3(-1, 0, 0);
            go.transform.position = Vector3.forward * spawnZ;
            spawnZ += tileLength * 2; //spacing
            activeTiles.Add(go);
        }
        else if (!spawn) //spawn special item
        {
            if (prefabIndex == -1)
                go = Instantiate(SpecialTilePrefabs[specialRandomNumber]) as GameObject;
            else
                go = Instantiate(SpecialTilePrefabs[prefabIndex]) as GameObject;

            go.transform.SetParent(transform);
            go.transform.position = new Vector3(-1, 0, 0);
            go.transform.position = Vector3.forward * spawnZ;
            spawnZ += tileLength * 2; //spacing
            activeTiles.Add(go);
            spawn = true;
        }
        i++;
    }

    private void SpawnSpecialTile(int prefabIndex = -1)
    {
        GameObject go;

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
        randomIndex = Random.Range(0, TilePrefabs.Length);

        lastPrefabIndex = randomIndex;
        return randomIndex;
    }

    private int SpecialRandomPrefabIndex()
    {
        if (SpecialTilePrefabs.Length <= 1)
        {
            return 0;
        }

        int randomIndex = 0;
        randomIndex = Random.Range(0, SpecialTilePrefabs.Length);

        lastPrefabIndex = randomIndex;
        return randomIndex;
    }

}
