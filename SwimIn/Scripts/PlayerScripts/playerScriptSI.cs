using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerScriptSI : MonoBehaviour
{
    [SerializeField] gameManagerSI gameManagerSI;
    [SerializeField] Rigidbody2D rb;
    [SerializeField] Animator oxygenAnimator;
    [SerializeField] CircleCollider2D circleCollider2D;
    private Animator playerAnimator;  
    float jumpForce = 1.25f;
    public bool isAliveSI = true;

    private void Start() {
        playerAnimator = GetComponent<Animator>();
    }

    void Update(){
        if(Input.GetMouseButtonDown(0) && isAliveSI && gameManagerSI.startGameSI){
            playerAnimator.SetBool("swim", true);
            rb.velocity = Vector2.down * jumpForce;
            SoundManager.playSound("waterJump");
            Invoke("swimFalse", 0.3f);
        }
    }

    void OnTriggerEnter2D(Collider2D other){
        if(other.transform.tag == "bubble"){
            SoundManager.playSound("regen");
            oxygenAnimator.Play("Oxygen_Animation", 0, 0f);
        }
    }

    void OnCollisionEnter2D(Collision2D other){
        if(other.transform.tag == "obstacle"){
            playerAnimator.Play("player_dead");
            rb.constraints = RigidbodyConstraints2D.None;
            SoundManager.playSound("waterBonk");
            circleCollider2D.enabled = false;
            gameManagerSI.gameOver();
            
            Invoke("playerRBKinematic", 4f);
        }
    }

    public void playerDynamicRB(){
        rb.bodyType = RigidbodyType2D.Dynamic;
    }

    void playerRBKinematic(){
        rb.bodyType = RigidbodyType2D.Static;
    }

    void swimFalse(){
        playerAnimator.SetBool("swim", false);
    }
}
