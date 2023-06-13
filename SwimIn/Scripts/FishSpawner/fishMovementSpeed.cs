using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fishMovementSpeed : MonoBehaviour
{
    float randomSpeedNumber;
    void Start(){
        randomSpeedNumber  = Random.Range(0.3f, 0.8f);
        Destroy(gameObject, 10);
    }

    void FixedUpdate(){
        transform.Translate(Vector3.left * randomSpeedNumber * Time.deltaTime);
    }
}
