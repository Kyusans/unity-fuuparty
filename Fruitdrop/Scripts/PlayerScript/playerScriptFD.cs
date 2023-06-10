using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerScriptFD : MonoBehaviour
{
    [SerializeField] scoreScriptFD scoreScript;
    [SerializeField] GameObject explosionGameObject;
    [SerializeField] Animator cameraShake;
    [SerializeField] gameManagerFD gameManagerFD;
    [SerializeField] Transform explosionTransform, playerParent;
    Rigidbody2D rb;
    float playerSpeed = 7f;
    bool goingRight = true;

    void Start(){
        rb = GetComponent<Rigidbody2D>();
    }
    void Update(){
        characterMoveInput();
    }
    void FixedUpdate() {
        if(gameManagerFD.gameStart)
            transform.Translate(playerSpeed * Time.fixedDeltaTime, 0, 0);
    }
    void characterMoveInput(){
        if(Input.GetMouseButtonDown(0) && goingRight){
            playerSpeed = -playerSpeed;
            goingRight = false;
        }else if(Input.GetMouseButtonDown(0) && !goingRight){
            playerSpeed = playerSpeed * -1;
            goingRight = true;
        }   
    }

    void OnTriggerEnter2D(Collider2D other){
        if(other.transform.tag == "obstacle" && gameManagerFD.gameStart){
            explosionTransform.SetParent(playerParent.transform, true);
            explosionGameObject.SetActive(true);
            rb.gravityScale += 0.1f;
            rb.constraints = RigidbodyConstraints2D.None;
            cameraShake.enabled = true;
            gameManagerFD.gameOver();
            SoundManager.playSound("explosion");
            Invoke("constraintsOn", 0.7f);
        }else if(other.transform.tag == "fruit" && gameManagerFD.gameStart){
            scoreScript.addScore();
            SoundManager.playSound("coinCollected");
        }
    }

    void constraintsOn(){
        rb.constraints = RigidbodyConstraints2D.FreezeAll;
    }
}
