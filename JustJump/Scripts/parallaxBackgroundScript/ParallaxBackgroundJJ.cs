using UnityEngine;

public class ParallaxBackgroundJJ : MonoBehaviour
{ 
    [SerializeField] float moveSpeed = 1f;
    [SerializeField] float offSet;
    
    Vector2 startPosition;
    float newXposition;

    void Start()
    {
        startPosition = transform.position;
    }

    void Update(){
        newXposition = Mathf.Repeat(Time.time * -moveSpeed, offSet);
        transform.position = startPosition + Vector2.right * newXposition;        
    }

}