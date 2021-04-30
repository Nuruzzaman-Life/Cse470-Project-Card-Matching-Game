using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    public GameObject menuPanel;
    public GameObject inGameCanvas;
    public GameObject gamePanel;
    public Sprite soundOn;
    public Sprite soundOff;
    public Image soundIcon;
    
    // Start is called before the first frame update
    private void Start() {
        if(PlayerPrefs.GetInt("SoundStatus",0)==0){
            
            soundIcon.sprite=soundOn;
            FindObjectOfType<SFXManager>().UpdateVolume();
        }else if(PlayerPrefs.GetInt("SoundStatus",0)==-1){
            
            soundIcon.sprite=soundOff;
            FindObjectOfType<SFXManager>().Mute();
        }
    }
    public void StartPlaying(int mode){
        PlayerPrefs.SetInt("GameMode",mode);
        
        menuPanel.SetActive(false);
        inGameCanvas.SetActive(true);
        gamePanel.SetActive(true);
        FindObjectOfType<CardController>().StartGameMode();
    }
    public void Exit(){
        Application.Quit();
    }
    public void ChangeSoundMode(Image soundIcon){
        if(PlayerPrefs.GetInt("SoundStatus",0)==0){
            PlayerPrefs.SetInt("SoundStatus",-1);
            soundIcon.sprite=soundOff;
            FindObjectOfType<SFXManager>().Mute();
        }else if(PlayerPrefs.GetInt("SoundStatus",0)==-1){
            PlayerPrefs.SetInt("SoundStatus",0);
            soundIcon.sprite=soundOn;
            FindObjectOfType<SFXManager>().UpdateVolume();
        }
        FindObjectOfType<SFXManager>().Play("buttonClick");
    }
}
