using UnityEngine;

public class ObstacleMovement : MonoBehaviour
{
    float speed = 4.1f;
   

    void Start()
    {
        Destroy(gameObject, 10f);
    }
    void Update()
    {
        transform.position += Vector3.left * Time.deltaTime * speed;
    }
}