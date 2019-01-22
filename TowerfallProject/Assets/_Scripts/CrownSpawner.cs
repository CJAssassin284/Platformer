using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrownSpawner : MonoBehaviour {

    [Header("Item Spawn Tools")]
    public float spawnTimer;
    public float spawnNumber;
    public float spawnMin = 5;
    public float spawnMax = 10;

    [Space]
    public List<GameObject> _spawnPoints;

    //Used to access items for different stages
    [System.Serializable]
    public class Items
    {
        public List<GameObject> itemsToSpawn;

    }
    [Space]
    public Items items = new Items();


    private void Start()
    {
        spawnNumber = Random.Range(spawnMin, spawnMax);
        //Finds all the spawn points on the stage
        for (int i = 0; i < transform.childCount; i++)
        {
            _spawnPoints.Add(transform.GetChild(i).gameObject);
            Debug.Log(i);
        }
    }

    private void Update()
    {
        spawnTimer += Time.deltaTime;

        if(spawnTimer >= spawnNumber)
        {
            Spawn(_spawnPoints[Random.Range(0, _spawnPoints.Count)].transform.position, items.itemsToSpawn[Random.Range(0,items.itemsToSpawn.Count)].gameObject);
            spawnTimer = 0;
        }
    }

    void Spawn(Vector3 pos, GameObject itemToSpawn)
    {
        Instantiate(itemToSpawn, pos, Quaternion.identity);
        spawnNumber = Random.Range(spawnMin, spawnMax);
    }
}
