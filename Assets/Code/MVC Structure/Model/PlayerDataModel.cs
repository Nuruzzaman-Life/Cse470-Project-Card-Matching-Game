using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDataModel : MonoBehaviour
{
    // Here I am using Unity's Database system. It is Called PlayerPrefs
    public void RecordNewBestAttempt(int value){
        PlayerPrefs.SetInt("RecordAttempt", value);
    }
    public void RecordNewBestTiming(int value){
        PlayerPrefs.SetInt("RecordTiming", value);
    }
    public int CurrentBestTiming(){
        return PlayerPrefs.GetInt("RecordTime",0);

    }
    public int CurrentBestAttempt(){
        return PlayerPrefs.GetInt("RecordAttempt",0);
    }
    public void BlindRecordNewBestAttempt(int value){
        PlayerPrefs.SetInt("BlindRecordAttempt", value);
    }
    public void BlindRecordNewBestTiming(int value){
        PlayerPrefs.SetInt("BlindRecordTiming", value);
    }
    public int BlindCurrentBestTiming(){
        return PlayerPrefs.GetInt("BlindRecordTime",0);

    }
    public int BlindCurrentBestAttempt(){
        return PlayerPrefs.GetInt("BlindRecordAttempt",0);
    }
}
