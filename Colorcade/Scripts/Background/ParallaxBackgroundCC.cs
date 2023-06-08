using UnityEngine;

public class ParallaxBackgroundCC : MonoBehaviour
{
    [SerializeField] float offSet;
    [SerializeField] PlayerScript playerScript;
    float moveSpeed = 8f;
    
    Vector2 startPosition;
    float newXposition;

    void Start()
    {
        startPosition = transform.position;
    }

    void Update()
    {
        if(playerScript.isAlive)
        newXposition = Mathf.Repeat(Time.time * -moveSpeed, offSet);
        transform.position = startPosition + Vector2.right * newXposition;
    }


}
