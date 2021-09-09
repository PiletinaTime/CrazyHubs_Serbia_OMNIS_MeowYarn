using TMPro;
using UnityEngine;

public class GenerateMap : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI Level;
    [SerializeField]
    private GameObject[] MapPrefabs;
    private float spawnPoint = 50f;
    public static int level = 1;
    private int levelLength;
    private bool skirts;
    private bool finish;
    private void Awake()
    {
        levelLength = level * 50 + 150;
        Random.InitState(level);
        Level.text = "Level " + level;
    }
    void Update()
    {
        if(!finish)
           SpawnPrefab();
    }
    private void SpawnPrefab()
    {
        if (spawnPoint > levelLength)
            SpawnFinish();
        else
        {
            int random = Random.Range(0, MapPrefabs.Length - 1);
            if (skirts)
            {
                while (MapPrefabs[random].name.Contains("Skirts"))
                    random = Random.Range(0, MapPrefabs.Length - 1);
                SpawnNormal(random);
            }
            else
            {
                if(MapPrefabs[random].name.Contains("Skirts"))
                    SpawnSkirts(random);
                else 
                    SpawnNormal(random);
            }
        }
    }
    private void SpawnSkirts(int random)
    {
        Instantiate(MapPrefabs[random], new Vector3(0, 0, spawnPoint), Quaternion.identity);
        spawnPoint += 25f;
        skirts = true;
    }
    private void SpawnNormal(int random)
    {
        Instantiate(MapPrefabs[random], new Vector3(0, 0, spawnPoint), Quaternion.Euler(0, -90, 0));
        spawnPoint += 50f;
        skirts = false;
    }
    private void SpawnFinish()
    {
        Instantiate(MapPrefabs[MapPrefabs.Length - 1], new Vector3(0, 0, spawnPoint), Quaternion.identity);
        finish = true;
    }
}