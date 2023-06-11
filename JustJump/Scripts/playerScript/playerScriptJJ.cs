using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerScriptJJ : MonoBehaviour
{
    [SerializeField] gameManagerJJ gameManagerJJ;
    [SerializeField] Animator playerAnimator;
    Rigidbody2D rb;
    float jumpMax = 7f;
    bool isGrounded = false;
    public float jumpValue = 0f;
    public bool playerJumped, gameOver, jumpMaxed= false;

    private void Start() {
        rb = GetComponent<Rigidbody2D>();    
    }

    void Update() {
        if(Input.GetMouseButton(0) && isGrounded && !playerJumped){
            playerAnimator.Play("player_crouch");         
            jumpValue += 10f * Time.deltaTime;  
        }

        if(Input.GetMouseButtonUp(0) && isGrounded && !jumpMaxed){        
            if(jumpValue >= 1f){
                SoundManager.playSound("jump03");
                playerAnimator.Play("player_jump");
                rb.velocity = new Vector2(0, jumpValue);
                playerJumped = true;
                jumpValue = 0;             
            }else{  
                SoundManager.playSound("footSteps");
                playerAnimator.Play("player_walk");
                playerJumped = true;
                Invoke("resetJumpValue", 0.2f);
                jumpValue = 0; 
            }
            
        }

        if(jumpValue >= jumpMax && isGrounded){
            SoundManager.playSound("jump03");
            jumpMaxed = true;
            playerAnimator.Play("player_jump");
            rb.velocity = new Vector2(0, jumpMax);
            playerJumped = true;
            jumpValue = 0;           
        }    
    }

    private void resetJumpValue(){ 
        playerJumped = false;
        playerAnimator.Play("player_idle");    
    }

    private void OnCollisionEnter2D(Collision2D other) {
        if(other.transform.tag == "obstacle"){
            playerJumped = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D other) {      
        if(other.transform.tag == "obstacle"){
            playerAnimator.Play("player_idle");
            isGrounded = true;
            playerJumped = false;
            jumpMaxed = false;
            
        }
        else if(other.transform.tag == "Obstacle"){
            //-------"O"bstacle tag kay ang boundaries------
            SoundManager.playSound("deathSound");
            gameOver = true;
            gameManagerJJ.gameOver();
            rb.constraints = RigidbodyConstraints2D.FreezeAll;
        }
    }

    private void OnTriggerExit2D(Collider2D other) {
        if(other.transform.tag == "obstacle"){
            isGrounded = false;
        }
        
        if(other.transform.tag == "obstacle" && !playerJumped){
            playerAnimator.Play("player_fell");
        }
    }
}