using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InGameController : MonoBehaviour
{
    public GameObject menuPanel;
    public GameObject gamePanel;
    public GameObject winPanel;
    
    public TextMeshProUGUI attemptsText;
    public TextMeshProUGUI recordAttempt;
    public TextMeshProUGUI timeText;
    public TextMeshProUGUI recordTime;
    public TextMeshProUGUI countDownText;
    public TextMeshProUGUI blindmode;
    public Animator inGameAnim;
    
    [HideInInspector] public bool gameFinished=true;
    
    // Start is called before the first frame update
    void Start()
    {
        //PlayerPrefs.DeleteAll();
        UpdateInGameUI();
        
        //gameFinished=true;
        currentTime=0;
        UpdateTime();
        
    }

    // Update is called once per frame
    float timer;
    [HideInInspector] public int currentTime;
    
    void Update()
    {
        if (!gameFinished)
        {
            timer += Time.deltaTime;
            if (timer > 1f) 
            {
                currentTime++;
                UpdateTime();
            }
        }
        
    }
    public void UpdateCountDown(int count)
    {
        //Debug.Log("came for count "+count);
        
        if(count==0){
            countDownText.text="Start!";
            //FindObjectOfType<CardController>().HideAllCards();
            
            StartPlay();
        }else if(count<0){
            countDownText.text=" ";
            gameFinished=false;
        }
        else{
            countDownText.text=count.ToString();
            //FindObjectOfType<SFXManager>().Play("tick");
        }
         
    }
    public void UpdateTime(){
        timeText.text="Time "+currentTime.ToString()+" s.";
        timer = 0f;
    }
    public void GoToMainMenu(){
        currentTime=0;
        UpdateTime();
        gameFinished=false;

        CardController cardController= FindObjectOfType<CardController>();
        cardController.countDownTimeCount=cardController.countDownTime;
        cardController.startCountDown=false;
        FindObjectOfType<CardController>().openCards.Clear();

        countDownText.text=" ";

        menuPanel.SetActive(true);
        gameObject.SetActive(false);
        gamePanel.SetActive(false);
        winPanel.SetActive(false);
        FindObjectOfType<SFXManager>().Play("buttonClick");
    }
    public void RestartGame(){
        currentTime=0;
        UpdateTime();
        gameFinished=false;
        FindObjectOfType<CardController>().StartGameMode();
        UpdateInGameUI();
        winPanel.SetActive(false);
        
    }

    public void UpdateInGameUI(){
        if(PlayerPrefs.GetInt("GameMode",1)==1){
            if(PlayerPrefs.GetInt("RecordAttempt",0)==0){
                recordAttempt.text="Record: "+"null";
                recordTime.text="Record: "+"null";
        }else{
                recordAttempt.text="Record: "+PlayerPrefs.GetInt("RecordAttempt",0).ToString();
                recordTime.text="Record: "+PlayerPrefs.GetInt("RecordTime",0).ToString()+" s.";
                //Debug.Log("from start");
            }
            blindmode.text=" ";
        }else{
            if(PlayerPrefs.GetInt("BlindRecordAttempt",0)==0){
                recordAttempt.text="Record: "+"null";
                recordTime.text="Record: "+"null";
            }else{
                recordAttempt.text="Record: "+PlayerPrefs.GetInt("BlindRecordAttempt",0).ToString();
                recordTime.text="Record: "+PlayerPrefs.GetInt("BlindRecordTime",0).ToString()+" s.";
                //Debug.Log("from start");
            }
            countDownText.text=" ";
            blindmode.text="Blind Mode";
        }
    }
    public void StartPlay(){
        currentTime=0;
        UpdateTime();
        gameFinished=false;
        FindObjectOfType<CardController>().GamePlayStarts();
        UpdateInGameUI();
        winPanel.SetActive(false);
        
    }
    [HideInInspector]public bool timeRecord;
    public void CheckRecordTime(){
        gameFinished=true;
        if(PlayerPrefs.GetInt("GameMode",1)==1){
            if(PlayerPrefs.GetInt("RecordTime",0)>currentTime || 
            PlayerPrefs.GetInt("RecordTime",0)==0 ){
                PlayerPrefs.SetInt("PreviousRecordTime",PlayerPrefs.GetInt("RecordTime",0));
                PlayerPrefs.SetInt("RecordTime",currentTime);
                timeRecord=true;
            }
        }else{
            if(PlayerPrefs.GetInt("BlindRecordTime",0)>currentTime || 
            PlayerPrefs.GetInt("BlindRecordTime",0)==0 ){
                PlayerPrefs.SetInt("PreviousRecordTime",PlayerPrefs.GetInt("BlindRecordTime",0));
                PlayerPrefs.SetInt("BlindRecordTime",currentTime);
                timeRecord=true;
            }
        }
        
    }
    public void CheckRecordAttempt(){
        CardController cardController=FindObjectOfType<CardController>();
        gameFinished=true;
        if(PlayerPrefs.GetInt("GameMode",1)==1){
            if(PlayerPrefs.GetInt("RecordAttempt",0)>cardController.attempt || 
                        PlayerPrefs.GetInt("RecordAttempt",0)==0 ){
                            //record attept
                            PlayerPrefs.SetInt("PreviousRecordAttempt",PlayerPrefs.GetInt("RecordAttempt",0));
                            PlayerPrefs.SetInt("RecordAttempt",cardController.attempt);
                            cardController.attemptRecord=true;
                            //Debug.Log("from method");
                        }
        }else{
            if(PlayerPrefs.GetInt("BlindRecordAttempt",0)>cardController.attempt || 
                        PlayerPrefs.GetInt("BlindRecordAttempt",0)==0 ){
                            //record attept
                            PlayerPrefs.SetInt("PreviousRecordAttempt",PlayerPrefs.GetInt("BlindRecordAttempt",0));
                            PlayerPrefs.SetInt("BlindRecordAttempt",cardController.attempt);
                            cardController.attemptRecord=true;
                            //Debug.Log("from method");
                        }
        }
        
    }
    public void UpdateAttempt(int attempt){
        //attempt++;
        attemptsText.text="Attemts: "+attempt.ToString();
    }
}
