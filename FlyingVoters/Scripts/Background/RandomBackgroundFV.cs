using UnityEngine;

public class RandomBackgroundFV : MonoBehaviour
{
    [SerializeField] GameObject backGround1, backGround2, backGround3, backGround4, backGround5, backGround6, backGround7, backGround8, backGround9, backGround10, backGround11;
    public int randomNumber;
    void Awake()
    {       
        randomNumber = Random.Range(1,12);
        switch(randomNumber){
            case 1:
                Instantiate(backGround1);
                break;
            case 2:
                Instantiate(backGround2);
                break;
            case 3:
                Instantiate(backGround3);
                break;
            case 4:
                Instantiate(backGround4);
                break;
            case 5:
                Instantiate(backGround5);
                break;
            case 6:
                Instantiate(backGround6);
                break;
            case 7:
                Instantiate(backGround7);
                break;
            case 8:
                Instantiate(backGround8);
                break;
            case 9:
                Instantiate(backGround9);
                break;
            case 10:
                Instantiate(backGround10);
                break;
            case 11:
                Instantiate(backGround11);
                break;
        } 
        
    }
}
