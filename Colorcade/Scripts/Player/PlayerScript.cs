using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerScript : MonoBehaviour
{
    [SerializeField] SpriteRenderer playerSpriteRenderer;
    [SerializeField] Image nextColorSpriteRenderer;
    [SerializeField] Sprite redPlayer, greenPlayer, bluePlayer;
    [SerializeField] int touchPixelDistance = 10;
    [SerializeField] Spawner spawner;
    [SerializeField] GameObject explosionGameObject;
    [SerializeField] GameManager gameManager;
    [SerializeField] Animator cameraShakeAnimator;
    [SerializeField] Transform explosionTransform, playerParent;
    Rigidbody2D rb;
    Vector2 startPos;

    float playerMoveDistance = 6f;
    int randomNumber, nextColorNumber, nextColor;
    bool fingerDown;
    bool inMaxPositionTop, inMaxPositionBottom = false;
    public bool isAlive = true;
    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        nextColorChange();
        playerChangeColor();
    }
    

    void Update()
    {
        if(isAlive)
        {
            playerMove();
        }
    }

    void playerMove(){
        if (Input.touchCount>0 && Input.touches[0].phase == TouchPhase.Ended)
            fingerDown = false;
    
        if(!fingerDown && Input.touchCount > 0 && Input.touches[0].phase == TouchPhase.Began)
        {
            startPos = Input.touches[0].position;
            fingerDown = true;
        }
        if(fingerDown && isAlive)
        {
            if(Input.touches[0].position.y >= startPos.y + touchPixelDistance && !inMaxPositionTop)
            {
                fingerDown = false;
                transform.position += new Vector3(0, playerMoveDistance, 0);
                SoundManager.playSound("jump");
            }
            else if(Input.touches[0].position.y <= startPos.y - touchPixelDistance && !inMaxPositionBottom)
            {
                fingerDown = false;
                transform.position += new Vector3(0, -playerMoveDistance, 0);  
                SoundManager.playSound("jump");
            }
            
        }

        if(transform.position.y >= playerMoveDistance)
        {
            inMaxPositionTop = true;
        }
        else if (transform.position.y <= -playerMoveDistance)
        {
            inMaxPositionBottom = true;
        }
        else
        {
            inMaxPositionTop = false;
            inMaxPositionBottom = false;
        }
    }


    void playerChangeColor()
    {
        nextColor = nextColorNumber; 
        switch(nextColor)
        {   
            case 1:
                playerSpriteRenderer.sprite = redPlayer;
                transform.tag = "redPlayer";
                break;
            case 2:
                playerSpriteRenderer.sprite = greenPlayer;
                transform.tag = "greenPlayer";
                break;
            case 3:
                playerSpriteRenderer.sprite = bluePlayer;
                transform.tag = "bluePlayer";
                break;
        }
        nextColorChange();
    }
    void nextColorChange()
    {
        randomNumber = Random.Range(1, 4);

        switch(randomNumber)
        {   
            case 1:
                nextColorSpriteRenderer.sprite = redPlayer;
                break;
            case 2:
                nextColorSpriteRenderer.sprite = greenPlayer;
                break;
            case 3:
                nextColorSpriteRenderer.sprite = bluePlayer;
                break;
        }
        nextColorNumber = randomNumber;
    }
    void OnCollisionEnter2D(Collision2D other)
    {
        if(isAlive)
        {

            if(other.transform.tag == "redEnemy")
        {
                if(transform.tag == "redPlayer")
                {
                    playerSafe();
                }
                else
                {
                    playerExploded();
                }
            }
        else if(other.transform.tag == "greenEnemy")
        {
                if(transform.tag == "greenPlayer")
                {
                    playerSafe();
                }
                else
                {
                    playerExploded();
                }
        }
        else if(other.transform.tag == "blueEnemy")
        {
                if(transform.tag == "bluePlayer")
                {
                    playerSafe();
                }
                else
                {
                    playerExploded();
                }
            }
        }
    }

    void playerExploded()
    {
        explosionTransform.SetParent(playerParent.transform, true);
        rb.gravityScale += 0.1f;
        rb.constraints = RigidbodyConstraints2D.None;
        explosionGameObject.SetActive(true);
        cameraShakeAnimator.enabled = true;
        SoundManager.playSound("explosion");
        isAlive = false;
        gameManager.gameOver();
    }

    void playerSafe()
    {
        SoundManager.playSound("collect");
        gameManager.addScore();
        playerChangeColor();
    }
}