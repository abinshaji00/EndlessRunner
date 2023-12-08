using System.Collections.Generic;
using UnityEngine;

public class Tilemanager : MonoBehaviour
{
    public GameObject[] TilePrefabs;
    private Transform playerTrensform;
    private float spawnZ = -5f;
    private float SpawnLength = 10;
    private int amuntOfTiles = 10;
    private List<GameObject> activeTiles;
    private float SafeZone = 20f;
    private int lastPrefabIndex = 0;
    public GameObject pauseUi;


    private void Start()
    {
        activeTiles = new List<GameObject>();
        playerTrensform = GameObject.FindGameObjectWithTag("Player").transform;
        for (int i = 0; i < amuntOfTiles; i++)
        {
            if (i < 2)
                SpawnTile(0);
            else
                SpawnTile();
        }
    }
    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            if (GameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
        if (playerTrensform.position.z-SafeZone>(spawnZ-amuntOfTiles*SpawnLength))
        {
            SpawnTile();
            deleteTiles();
        }
    }
    private void SpawnTile(int prefabIdx= -1)
    {
        GameObject go;
        if(prefabIdx==-1)
            go= Instantiate(TilePrefabs[RandomPrefabIndex()] as GameObject);
        else
            go = Instantiate(TilePrefabs[prefabIdx] as GameObject);
        go.transform.SetParent(transform);
        go.transform.position= Vector3.forward*spawnZ;
        spawnZ += SpawnLength;
        activeTiles.Add(go);
    }
    private void deleteTiles()
    {
        Destroy(activeTiles[0]);
        activeTiles.RemoveAt(0);
    }
    private int RandomPrefabIndex()
    {
        if (TilePrefabs.Length <= 1) return 0;
        int randomIndex = lastPrefabIndex;
        while(randomIndex==lastPrefabIndex)
        {
            randomIndex=Random.Range(0, TilePrefabs.Length);
        }
        lastPrefabIndex = randomIndex;
        return randomIndex;
    }
    public static bool GameIsPaused=false;
    public void Resume()
    {
        pauseUi.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }
    public void Pause()
    {
        pauseUi.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }

}
