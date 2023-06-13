using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawnerSI : MonoBehaviour
{
    [SerializeField] GameObject smallRock, bubble;
    [SerializeField] GameObject[] backgroundFish;
    [SerializeField] gameManagerSI gameManagerSI;
    public float obstacleSpeed = 0.7f;
    float smallRockSpawnRate = 1f;
    float bubbleSpawnRate = 2.9f;
    float smallNextSpawn , fishNextSpawn, bubbleNextSpawn = 0f;
    int fishSpawnRandomNum;
    
    void Start(){
        StartCoroutine(normalMode());
    }

    void Update(){
        if(gameManagerSI.startGameSI){
            spawners();
        }

        //fishSpawner (Background)
        if(Time.time > fishNextSpawn){
            fishSpawnRandomNum = Random.Range(0, backgroundFish.Length);
            Instantiate(backgroundFish[fishSpawnRandomNum], new Vector3(1.4f, Random.Range(-0.734f, 1.174f), 0),Quaternion.identity);
            fishNextSpawn = Time.time + 1f;
        }
    }

    void spawners(){
        //small rock Spawner
        if(Time.time > smallNextSpawn){
            Instantiate(smallRock, new Vector3(2f,Random.Range(-1.612f, 1.85f),0),Quaternion.identity);            
            smallNextSpawn = Time.time + smallRockSpawnRate; 
        } 
        //bubbleSpawner
        if(Time.time > bubbleNextSpawn){
            Instantiate(bubble, new Vector3(1.5f,Random.Range(-1.5f, 1.5f), 0), Quaternion.identity);
            bubbleNextSpawn = Time.time + bubbleSpawnRate;
        }
        
    }

    IEnumerator normalMode(){
        yield return new WaitForSeconds(20f);
        smallRockSpawnRate = 0.7f;
        StartCoroutine(hardMode());
    }

    IEnumerator hardMode(){
        yield return new WaitForSeconds(20f);
        smallRockSpawnRate = 0.5f;
    }
}