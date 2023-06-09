using UnityEngine;
using UnityEngine.UI;

public class PlayerJumps : MonoBehaviour
{
    [SerializeField] GameObject playerHitSound;
    [SerializeField] GameManagerFV gameManagerFV;
    [SerializeField] Animator addScoreAnimator;
    [SerializeField] Text addScoreAnimationText;
    [SerializeField] MainScore mainScore;
    float jumpForce = 14.8f;
    public bool isAlive = true;
    public Collider2D playerCollider;
    public Rigidbody2D rb;

    void Start()
    {
        playerCollider = GetComponent<Collider2D>();
        playerCollider.enabled = false;
        rb.bodyType = RigidbodyType2D.Kinematic;
    }

    void Update()
    {

        // if(Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began && isAlive){
        //     SoundManager.playSound("jetPack");
        //     rb.velocity = Vector2.up * jumpForce;
        // }

        if(Input.GetMouseButtonDown(0) && isAlive && gameManagerFV.gameStart == true){
            SoundManager.playSound("jetPack");
            rb.velocity = Vector2.up * jumpForce;
        }
    }
    void OnCollisionEnter2D(Collision2D other)
    {
        if(other.transform.tag == "Obstacle" && isAlive){
            gameObject.tag = "DeadPlayer";
            isAlive = false;
            rb.freezeRotation = false;
            gameManagerFV.gameOver();
            playerHitSound.SetActive(true);
            rb.gravityScale += 1f;
            Invoke("freezePlayer", 3.5f);
        }  
    }
    void freezePlayer()
    {
        rb.bodyType = RigidbodyType2D.Static;
    }

    //addScore

    void OnTriggerEnter2D(Collider2D other)
    {
        if(transform.tag == "Player"){
           SoundManager.playSound("coinCollected");                
           if(other.transform.tag == "oneObstacle")
           {
               mainScore.secondsCount += 1f;
               addScoreTrue();
               addScoreAnimationText.text = "+1";
           }
           else if(other.transform.tag == "twoObstacle")
           {
               mainScore.secondsCount += 2f;
               addScoreTrue();
               addScoreAnimationText.text = "+2";
           }
       }
    }

    void addScoreFalse()
    {
        addScoreAnimationText.text = "";
        addScoreAnimator.SetBool("addScore", false);
    }

    void addScoreTrue()
    {
        addScoreAnimator.SetBool("addScore", true);
        Invoke("addScoreFalse", 0.8f);
    }
}