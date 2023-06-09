using UnityEngine;

public class ChangeSprite : MonoBehaviour
{
    [SerializeField] SpriteRenderer spriteRenderer;
    [SerializeField] Sprite blueObstacle, brownObstacle, greenObstacle, nightObstacle;
    int number;
    void Start()
    {
         switch(FindObjectOfType<RandomBackgroundFV>().randomNumber){
            case 1:
                spriteRenderer.sprite = brownObstacle;
                break;
            case 3:
                spriteRenderer.sprite = greenObstacle;
                break;
            case 4:
                spriteRenderer.sprite = greenObstacle;
                break;
            case 5:
                spriteRenderer.sprite = blueObstacle;
                break;
            case 6:
                spriteRenderer.sprite = greenObstacle;
                break;
            default:
                spriteRenderer.sprite = nightObstacle;
                break;
        }
    }
}   