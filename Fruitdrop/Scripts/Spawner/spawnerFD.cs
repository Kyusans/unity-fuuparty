using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnerFD : MonoBehaviour
{
    [SerializeField] gameManagerFD gameManagerFD;
    [SerializeField] GameObject[] spawnObject;
    public float obstacleSpeed = 10f;
    float spawnRate = 0.6f;
    float nextSpawn = 0f;
    int whatToSpawn, randomNumber;
    bool normalMode = false;
    bool easyMode = true;

    void Start()
    {
        StartCoroutine(normalModeOn());
    }

    void Update()
    {
        if(Time.time > nextSpawn && gameManagerFD.gameStart){
            whatToSpawn = Random.Range(0, 8);
            randomNumberGenerator();
            switch(randomNumber){
                case 1:
                    Instantiate(spawnObject[8], new Vector3(Random.Range(-4, 5), 11f, 0), Quaternion.identity);
                    break;
                default:     
                    Instantiate(spawnObject[whatToSpawn], new Vector3(Random.Range(-4, 5), 11f, 0), Quaternion.identity);
                    break;
            }          
            nextSpawn = Time.time + spawnRate;
        }
    }

    IEnumerator normalModeOn(){
        yield return new WaitForSeconds(30);
        spawnRate = 0.3f;
        easyMode = false;
        normalMode = true;
        obstacleSpeed = 12f;
        StartCoroutine(hardModeOn());
    }

    IEnumerator hardModeOn(){
        yield return new WaitForSeconds(30);
        obstacleSpeed = 13.5f;
        spawnRate = 0.15f;
        normalMode = false;
    }

    private void randomNumberGenerator(){
        if(easyMode){
            randomNumber = Random.Range(1, 5);
        }else if(normalMode){
            randomNumber = Random.Range(1, 4);
        }else{
            randomNumber = Random.Range(1, 3);          
        }
    }
}