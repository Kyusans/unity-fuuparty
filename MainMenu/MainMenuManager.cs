using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;
using TMPro;

public class MainMenuManager : MonoBehaviour
{
    [SerializeField] GameObject start, mainMenuButtons, registerScene, loadingAnimation, startingButtons;
    [SerializeField] TextMeshProUGUI previousRoomNameText, gameVersionText, tipsText;
    [SerializeField] Animator blackSpriteAnimator, createRoomAnimator, selectGameAnimator, roomAnimator, joinRoomAnimator, popUpBox, registerAnimator, aboutAnimation;
    [SerializeField] Text roomNameText, gameText, mainRoomNameText, mainRoomGameText, passcodeText, popUpRankingText, popUpText, joinPasscodeText, registerText;

    [SerializeField] Button createRoomSubmitButton, joinRoomSubmitButton;
    [SerializeField] AdsBanner adsBanner;
    int gameNumber = 1;

    string[] gameNameArray = {"Fly high butterfly", "ColorCade", "Fruit Drop", "Swim in", "Just Jump"};
    [SerializeField] Sprite[] gameIconSprite;
    [SerializeField] Sprite[] gameNameSprite;

    void Start()
    {
        if(PlayerPrefs.GetString("playerName") == string.Empty)
        {
            mainMenuButtons.SetActive(false);
            registerScene.SetActive(true);
        }

    }
    //====================================Buttons====================================

    public void openAbout()
    {
        aboutAnimation.Play("aboutAnimationOpen");
        gameVersionText.text = "Fuu Party\n" + "version " + Application.version;
        SoundManager.playSound("click01");
    }

    public void closeAbout()
    {
        aboutAnimation.Play("aboutAnimationClose");
        SoundManager.playSound("click01");
        startingButtons.SetActive(true);
    }


    //Register Button
    public void registerPlayerClick()
    {
        if(registerText.text == ""){
            popUpBoxTrue("Field is empty", "");
        }else{
            PlayerPrefs.SetString("playerName", registerText.text);
            startingButtons.SetActive(true);
            registerAnimator.SetBool("close", true);
        }
    //         else if(registerText.text == "Fuu" || registerText.text == "Hifumine"){
    //         popUpText.text = "No";
    //         popUpBox.SetBool("popBoxOpen", true);
    //         Invoke("popUpFalse", 4f);
    }

    void playSinglePlayer(int gameNumberSelect)
    {
        gameNumber = gameNumberSelect;
        PlayerPrefs.SetString("currentRoom", "0");
        playButtonClick();
    }
    public void lobbyFlyingVoters()
    {
        playSinglePlayer(1);
    }

    public void lobbyColorCade()
    {
        playSinglePlayer(2);
    }

    public void lobbyFruitDrop()
    {
        playSinglePlayer(3);
    }

    public void lobbySwimIn()
    {
        playSinglePlayer(4);
    }

    public void lobbyJustJump(){
        playSinglePlayer(5);
    }

    //Create Room Button
    public void openCreateRoom()
    {
        start.SetActive(false);
        createRoomAnimator.SetBool("open", true);
        SoundManager.playSound("click01");
    }
    public void closeCreateRoom()
    {
        start.SetActive(true);
        gameNumber = 1;
        createRoomAnimator.SetBool("open", false);
        SoundManager.playSound("click01");
    }

    public void createRoomSubmit()
    {
        if(roomNameText.text == "")
        {
            popUpBoxTrue("Room name field is empty", "");
        }
        else if(gameText.text == "No game selected")
        {
            popUpBoxTrue("No game selected", "");
            
        }
        else
        {      
            StartCoroutine(createRoomCoroutine("addNewRoom",roomNameText.text, gameNumber.ToString()));
        }
        SoundManager.playSound("click01");      
    }
    public void startPlayButton(){
        startingButtons.SetActive(false);
        mainMenuButtons.SetActive(true);
        SoundManager.playSound("click01");
    }

    public void openSelectGame()
    {
        selectGameAnimator.SetBool("open", true);
        SoundManager.playSound("click01");
    }

    public void playButtonClick()
    {
        //tips
        switch(gameNumber)
        {
            case 1:
                tipsText.text = "Don't get hit";
                break;
            case 2:
                tipsText.text = "Collide with the same color\nof your character";
                break;
            case 3:
                tipsText.text = "Collect many fruits and\nevade the bombs";
                break;
            case 4:
                tipsText.text = "Collect bubbles to regenerate\nyour oxygen bar";
                break;
            case 5:
                tipsText.text = "Don't fall down just\njump";
                break;
            
            
        }
        SoundManager.playSound("click");
        loadingAnimation.SetActive(true);
        blackSpriteAnimator.SetBool("close", true);
        Invoke("loadScene", 3f);
        adsBanner.destroyBanner();
    }
    void selectedGame(int gameNumberSelected)
    {
        gameNumber = gameNumberSelected;
        gameText.text = gameNameArray[gameNumber-1];
        selectGameAnimator.SetBool("open", false);  
        SoundManager.playSound("click01");
    }
    public void flyingVotersClick(){
        selectedGame(1);
    }

    public void colorCadeClick(){
        selectedGame(2);
    }

    public void fruitDropClick(){
        selectedGame(3);
    }

    public void swimInClick(){
        selectedGame(4);
    }

    public void justJumpClick(){
        selectedGame(5);
    }

    //Join Room Button

    public void openJoinRoom()
    {
        if(PlayerPrefs.GetString("previousRoomName") == ""){
            previousRoomNameText.text = "No room found";
        }else{
            previousRoomNameText.text = PlayerPrefs.GetString("previousRoomName");
        }
        
        start.SetActive(false);
        joinRoomAnimator.SetBool("open", true);
        SoundManager.playSound("click01");
    }
    public void closeJoinRoom()
    {
        start.SetActive(true);
        gameNumber = 1;
        joinRoomAnimator.SetBool("open", false);
        SoundManager.playSound("click01");
    }

    public void joinRoomSubmit(){
        if(joinPasscodeText.text == ""){
            popUpBoxTrue("Field is empty", "");
        }else{
            StartCoroutine(joinRoomCoroutine("joinRoom",joinPasscodeText.text));
        }
            SoundManager.playSound("click01");      
    }

    public void previousRoomButton(){
        SoundManager.playSound("click01");
        StartCoroutine(joinRoomCoroutine("joinRoom", PlayerPrefs.GetString("previousPassCode")));
    }
    //Room Button
    public void leaveRoom(){
        start.SetActive(true);
        gameNumber = 1;
        roomAnimator.SetBool("open", false);
        createRoomAnimator.SetBool("submit", false);
        joinRoomAnimator.SetBool("submit", false);
        createRoomSubmitButton.enabled = true;
        joinRoomSubmitButton.enabled = true;
        SoundManager.playSound("click01");
    }
     //-----------------------------------Database-----------------------------------//
    IEnumerator createRoomCoroutine(string operation, string name, string gameId)
    {
        string url = "http://www.shareatext.com/games/fuuparty/room.php";
        WWWForm form = new WWWForm();
        form.AddField("operation", operation);
        form.AddField("name", name);
        form.AddField("gameId", gameId);
        using (var request = UnityWebRequest.Post(url, form))
        {
            yield return request.SendWebRequest();
            if (request.result ==  UnityWebRequest.Result.ConnectionError){
                 popUpBoxTrue(request.error, "");     
            }else{
                string responseText = request.downloadHandler.text;
                if (!responseText.Equals("0")){
                    string json1 = request.downloadHandler.text;

                    json1 = fixJson(json1);
                    Room[] rooms = JsonHelper.FromJson<Room>(json1);
                    
                    foreach(Room room in rooms)
                    {
                        PlayerPrefs.SetString("currentRoom", room.roomId);
                        PlayerPrefs.SetString("previousRoomName", room.roomName);
                        PlayerPrefs.SetString("previousPassCode", room.passCode);
                        mainRoomGameText.text = gameNameArray[room.gameId - 1];
                        mainRoomNameText.text = room.roomName;
                        passcodeText.text = room.passCode;

                        roomAnimator.SetBool("open", true);
                        createRoomAnimator.SetBool("submit", true);
                        Invoke("allRoomFalse", 1f);
                        createRoomSubmitButton.enabled = false;                  
                    }
                }
                else{
                     popUpBoxTrue("Server Error Occured", "");
                }

            }
        }
    }

    IEnumerator joinRoomCoroutine(string operation, string passCode)
    {
        string url = "http://www.shareatext.com/games/fuuparty/room.php";
        WWWForm form = new WWWForm();
        form.AddField("operation", operation);
        form.AddField("passCode", passCode);
        using (var request = UnityWebRequest.Post(url, form))
        {
            yield return request.SendWebRequest();
            if (request.result ==  UnityWebRequest.Result.ConnectionError){
                popUpBoxTrue(request.error, "");              
            }else{
                string responseText = request.downloadHandler.text;
                if (!responseText.Equals("0")){
                    string json1 = request.downloadHandler.text;

                    json1 = fixJson(json1);
                    Room[] rooms = JsonHelper.FromJson<Room>(json1);
                    foreach(Room room in rooms)
                    {
                        PlayerPrefs.SetString("currentRoom", room.roomId);
                        mainRoomNameText.text = room.roomName;
                        passcodeText.text = room.passCode;
                        mainRoomGameText.text = gameNameArray[room.gameId - 1];
                        gameNumber = room.gameId;

                        roomAnimator.SetBool("open", true);
                        joinRoomAnimator.SetBool("submit", true);
                        Invoke("allRoomFalse", 1f);               
                    }

                }else{
                    popUpBoxTrue("Invalid passcode", "");
                }

            }
        }
    }



// ====================================Something====================================
    void loadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + gameNumber);
    }

    void allRoomFalse()
    {
        createRoomAnimator.SetBool("open", false);
        joinRoomAnimator.SetBool("open", false);
        joinPasscodeText.text = "";
        roomNameText.text = "";
        gameText.text = "No game selected";
    }
    void popUpFalse(){
        popUpBox.SetBool("popBoxOpen", false);
        popUpText.text = "";
        popUpRankingText.text = "";
        

    }

    void popUpBoxTrue(string popText, string popUpRanking)
    {
        popUpText.text = popText;
        popUpRankingText.text = popUpRanking;
        popUpBox.SetBool("popBoxOpen", true);
        Invoke("popUpFalse", 4f);
    }

    [System.Serializable]
    private class Room
    {
        public string roomName;
        public string roomId;
        public string passCode;
        public int gameId;
        public Room(string rName, string rId, string pCode, int gID ){
            this.roomName = rName;
            this.roomId = rId;
            this.gameId = gID;
            this.passCode = pCode;
        }

    }
    public static class JsonHelper
    {
        public static T[] FromJson<T>(string json)
        {
            Wrapper<T> wrapper = JsonUtility.FromJson<Wrapper<T>>(json);
            return wrapper.Items;
        }

        public static string ToJson<T>(T[] array)
        {
            Wrapper<T> wrapper = new Wrapper<T>();
            wrapper.Items = array;
            return JsonUtility.ToJson(wrapper);
        }

        public static string ToJson<T>(T[] array, bool prettyPrint)
        {
            Wrapper<T> wrapper = new Wrapper<T>();
            wrapper.Items = array;
            return JsonUtility.ToJson(wrapper, prettyPrint);
        }

        [System.Serializable]
        private class Wrapper<T>
        {
            public T[] Items;
        }
    }
    public string fixJson(string value)
    {
        value = "{\"Items\":" + value + "}";
        return value;
    }

}