using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    public GameObject[] enemyPrefab;
    //public GameObject[] enemySpawnCoords;
    private List<GameObject> trackedSPs;

    public GameObject radiusCheck;

    private float timer = 0f;
    public float spawnRate = 3f;


    // Start is called before the first frame update
    void Start()
    {
        trackedSPs = new List<GameObject>();
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= spawnRate)
        {
            SpawnEnemy();
            timer = 0f;
        }
    }

    private void SpawnEnemy()
    {
        int spawnLoc = Random.Range(0, trackedSPs.Count);
        int enemyType = Random.Range(0, enemyPrefab.Length);
        Instantiate(enemyPrefab[enemyType], trackedSPs[spawnLoc].GetComponent<Transform>().position, Quaternion.identity);
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("Spawner"))
        {
            //Debug.Log("Added");
            trackedSPs.Add(collider.gameObject);
        }
    }

    private void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.CompareTag("Spawner"))
        {
            //Debug.Log("Removed");
            trackedSPs.Remove(collider.gameObject);
        }
    }
}
