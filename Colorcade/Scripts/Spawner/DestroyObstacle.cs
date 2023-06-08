using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyObstacle : MonoBehaviour
{
    [SerializeField] GameObject mainObstacle;
    void OnCollisionEnter2D(Collision2D other)
    {
        Destroy(mainObstacle);
    }
}
