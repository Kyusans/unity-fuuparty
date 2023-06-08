using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    float obstacleSpeedMain;

    void Start()
    {  
        Invoke("destroyObstacle", 6f);
        obstacleSpeedMain = FindObjectOfType<Spawner>().obstacleSpeed;
    }

    void FixedUpdate()
    {
        transform.position += Vector3.left * obstacleSpeedMain * Time.fixedDeltaTime;
    }

    void destroyObstacle(){
        Destroy(gameObject);
    }
}
