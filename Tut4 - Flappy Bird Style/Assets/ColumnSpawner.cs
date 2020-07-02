using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColumnSpawner : MonoBehaviour
{
    public GameObject ColumnPrefab;
    public float SpawnPosition_x = 50f;
    public float SpawnPosition_y;
    public float SpawnPosition_y_Range = 2f;
    public float spawnRate = 3f;
    public Vector2 defaultSpawnPos;

    private float TimeSinceLastSpawned;
    private int currentCol;

    private GameObject[] Col;
    private int ColSize = 5;
    // Start is called before the first frame update
    void Start()
    {
        currentCol = 0;
        Col = new GameObject[ColSize];
        defaultSpawnPos = new Vector2(-20f, -20f);
        TimeSinceLastSpawned = 0f;

        for (int i = 0; i < ColSize; i++)
        {
            Col[i] = Instantiate(ColumnPrefab, defaultSpawnPos, Quaternion.identity);
        }
    }

    // Update is called once per frame
    void Update()
    {
        TimeSinceLastSpawned += Time.deltaTime;

        if(TimeSinceLastSpawned > spawnRate && PersistentManager.instance.isGameOver == false)
        {
            SpawnPosition_y = Random.Range(-SpawnPosition_y_Range, SpawnPosition_y_Range);
            Col[currentCol].transform.position = new Vector2(SpawnPosition_x, SpawnPosition_y);

            currentCol++;
            Debug.Log(currentCol.ToString() + ", " + ColSize.ToString());
            if (currentCol >= ColSize)
                currentCol = 0;
            TimeSinceLastSpawned = 0f;
        }
    }
}
