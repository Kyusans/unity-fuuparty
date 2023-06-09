using System.Collections;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{

    [SerializeField] GameObject prefab1, prefab2, prefab3;
    float spawnRate = 2.1f;
    float randomX = 15f;
    float height = 2f;
    float heightMain = 3f;
    float nextSpawn = 0f;
    int whatToSpawn;
    bool easyModeOn = true;
    bool normalModeOn,hardModeOn = false;

    void Start(){
        StartCoroutine(normalMode());
    }

    void Update()
    {
        if(Time.time > nextSpawn){
            randomNumber();
            switch(whatToSpawn){
                case 1:
                    Instantiate(prefab1, new Vector3(randomX,Random.Range(-height, height),0),Quaternion.identity);
                    break;
                case 2:
                    Instantiate(prefab2, new Vector3(randomX,Random.Range(-height, height),0), Quaternion.identity);
                    break;
                default:
                    Instantiate(prefab3, new Vector3(randomX,Random.Range(-heightMain, heightMain),0), Quaternion.identity);
                    break;     
            }   
            nextSpawn = Time.time + spawnRate;

        }
    }

    IEnumerator normalMode(){
        yield return new WaitForSeconds(30f);
        spawnRate = 1.9f;
        easyModeOn = false;
        normalModeOn = true;
        yield return StartCoroutine(hardMode());   
    }

    IEnumerator hardMode(){
        yield return new WaitForSeconds(20f);
        normalModeOn = false;
        hardModeOn = true;
    }

    void randomNumber(){
        if(easyModeOn){
            whatToSpawn = Random.Range(1, 5);
        }else if(normalModeOn){
            whatToSpawn = Random.Range(1, 7);
        }else if (hardModeOn){
            whatToSpawn = 3;
        }
    }
}