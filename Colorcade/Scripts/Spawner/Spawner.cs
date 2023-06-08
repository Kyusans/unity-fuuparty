using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] PlayerScript playerScript;
    [SerializeField] GameObject[] obstaclePatterns;
    float spawnRate = 1.25f;
    float nextSpawn = 2f;
    public float obstacleSpeed = 25f;
    int randomSpawnNumber;

    private void Start() 
    {
        StartCoroutine(normalMode());
    }
    
    void Update()
    {
        if(Time.time > nextSpawn && playerScript.isAlive)
        {
            randomSpawnNumber = Random.Range(0, 6);
            Instantiate(obstaclePatterns[randomSpawnNumber], new Vector3(30f, 0, 0), Quaternion.identity);
            nextSpawn = spawnRate + Time.time;
        }
    }

    IEnumerator normalMode()
    {
        yield return new WaitForSeconds(30f);
        spawnRate = 0.8f;
        StartCoroutine(hardMode());
    }

    IEnumerator hardMode()
    {
        yield return new WaitForSeconds(30f);
        spawnRate = 0.7f;
    }
}
