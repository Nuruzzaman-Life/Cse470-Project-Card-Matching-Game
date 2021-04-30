using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class WinPanel : MonoBehaviour
{
    public TextMeshProUGUI timeText;
    public TextMeshProUGUI recordTimeText;
    public TextMeshProUGUI attemptText;
    public TextMeshProUGUI recordAttemtText;

    public GameObject modeName;
    
    public GameObject timeRecordHeader;
    public GameObject attemtRecordHeader;
    // Start is called before the first frame update
    public void UpdatePanel()
    {
        InGameController igc = FindObjectOfType<InGameController>();
        CardController cC = FindObjectOfType<CardController>();
        igc.inGameAnim.SetBool("ShowCanvas",false);
        if(PlayerPrefs.GetInt("GameMode",1)==1){
            timeText.text="Time Used: "+igc.currentTime.ToString()+" s.";
            recordTimeText.text="Record Time: "+PlayerPrefs.GetInt("RecordTime",0).ToString()+" s.";
            attemptText.text="Attempt Used: "+cC.attempt.ToString();
            recordAttemtText.text="Record Attempt: "+PlayerPrefs.GetInt("RecordAttempt",0).ToString();
            modeName.SetActive(false);
        }else{
            modeName.SetActive(true);
            timeText.text="Time Used: "+igc.currentTime.ToString()+" s.";
            recordTimeText.text="Record Time: "+PlayerPrefs.GetInt("BlindRecordTime",0).ToString()+" s.";
            attemptText.text="Attempt Used: "+cC.attempt.ToString();
            recordAttemtText.text="Record Attempt: "+PlayerPrefs.GetInt("BlindRecordAttempt",0).ToString();
        }
        

        if(igc.timeRecord){
            timeRecordHeader.SetActive(true);
            recordTimeText.text="Previous Record Time: "+PlayerPrefs.GetInt("PreviousRecordTime",0).ToString()+" s.";
            igc.timeRecord=false;
        }else timeRecordHeader.SetActive(false);

        if(cC.attemptRecord){
            attemtRecordHeader.SetActive(true);
            recordAttemtText.text="Previous Record Attempt: "+PlayerPrefs.GetInt("PreviousRecordAttempt",0).ToString();
            cC.attemptRecord=false;
        }else attemtRecordHeader.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
