using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class CardController : MonoBehaviour
{
    public Sprite [] icons;
    public Sprite defaultIcon;
    public Sprite tickIcon;
    int [] iconStatus;
    public Image [] cards;
    public int countDownTime=5;
    public float winDelayTime=1f;
    [HideInInspector] public int countDownTimeCount;
    GameObject [] cardsChild;
    int [] cardMemory;
    InGameController igc;
     [HideInInspector] public bool startCountDown=false;
    // Start is called before the first frame update
    public void StartGameMode()
    {
        /*
         for each image index i will choose 2 random card index from available card:
         so when player tap on cards the image acociated with it gets repleced with the existing card image
        */
        cardMemory=new int[cards.Length];
        iconStatus= new int [icons.Length]; // value defines number of times it is used 
        cardsChild=new GameObject [cards.Length];
        //i have made 2 radomizing method, I dont wanna delete any of those so will use any of those randomly
        //update 2nd randomizing methods seems to randomize it better so only gonna use this now
        //AssignIcons();
        //Debug.Log("Assigning method");
        //Debug.Log("Random method method");
        igc=FindObjectOfType<InGameController>();
        if(PlayerPrefs.GetInt("GameMode",1)==1){
            RandomizeIcons();
            ShowAllCards();
            HideCardChild();
            countDownTimeCount=countDownTime;
            igc.UpdateCountDown(countDownTime);
            igc.UpdateInGameUI();
            attempt=0;
            FindObjectOfType<InGameController>().UpdateAttempt(attempt);

            igc.gameFinished=true;
            startCountDown=true;
            timer=0;
            FindObjectOfType<SFXManager>().Play("buttonClick");
        }else{
            
            RandomizeIcons();
            GamePlayStarts();
            igc.UpdateInGameUI();//works just like start
            igc.gameFinished=false;
        }
        igc.inGameAnim.SetBool("ShowCanvas",true);
        
    }
    float timer;
    
    void Update()
    {
        if(startCountDown){
            timer += Time.deltaTime;
            if (timer > 1f) 
            {
                countDownTimeCount--;
                igc.UpdateCountDown(countDownTimeCount);
                timer=0;
                if(countDownTimeCount==-1){
                    startCountDown=false;
                }
            }
        }
    }

    private void RandomizeIcons()
    {
        for (int i = 0; i < icons.Length*2; i++)
        {
            if(i>icons.Length-1)
            {
                cardMemory[i]=i-icons.Length;
            }else cardMemory[i]=i;
            
        }
        cardMemory = Shuffle<int>(cardMemory);
        //lets shuffle it 2 times
        cardMemory = Shuffle<int>(cardMemory);
    }

    private void ShowAllCards()
    {
        for (int i=0; i<cards.Length;i++)
        {
            cards[i].sprite=icons[cardMemory[i]];
            
        }
    }
    public void HideAllCards()
    {
        for (int i=0; i<cards.Length;i++)
        {
            cards[i].sprite=defaultIcon;
            
        }
    }
    int index;
    private void AssignIcons()
    {
        for (int i=0; i<cards.Length;i++)
        {
            List<int> availableIcons=new List<int>();
            availableIcons=checkAvailableIcons();//available icon index
            
            index = availableIcons[UnityEngine.Random.Range(0,availableIcons.Count)]; //random index from available icon list
            //Debug.Log("Previous "+iconStatus[index]);

            //Debug.Log("Later "+iconStatus[index]);
            //Debug.Log(index);
            cardMemory[i]= index;
            iconStatus[index]++;//changing status of randomly seclected icon
            availableIcons.Clear();
        }
    }

    private List<int> checkAvailableIcons()
    {
        List<int> availableIcons = new List<int>();
        availableIcons.Clear();
        for(int i=0;i<icons.Length;i++)
        {
            if(iconStatus[i]==0 || iconStatus[i]==1)
            {
                availableIcons.Add(i);
                //Debug.Log("status "+iconStatus[i]+" for "+i);
            }
        }
        // for (int i = 0; i < availableIcons.Count; i++)
        // {
        //     print(availableIcons[i]);
        // }
        return availableIcons;
    }

    // Update is called once per frame
    
    public T[] Shuffle<T>(T[] array)
	{
		System.Random _random = new System.Random();
        var random = _random;
		for (int i = array.Length; i > 1; i--)
		{
			// Pick random element to swap.
			int j = random.Next(i); // 0 <= j <= i-1
			// Swap.
			T tmp = array[j];
			array[j] = array[i - 1];
			array[i - 1] = tmp;
		}
		return array;
	}
    [HideInInspector] public List<int> openCards = new List<int>();
    [HideInInspector] public int attempt;
    [HideInInspector] public bool attemptRecord;
    int matchedCardsNumber;
    public void ShowCard(int index)
    {
        if(cards[index].sprite==defaultIcon)
        {
            FindObjectOfType<SFXManager>().Play("cardClick");
            cards[index].sprite=icons[cardMemory[index]];
            if(openCards.Count==1)
            {
                attempt++;
                openCards.Add(index);
                if(MatchCard(openCards)){
                    
                    ShowMatchedCards(openCards);
                    openCards.Clear();
                    matchedCardsNumber++;
                    if(matchedCardsNumber==icons.Length){
                        FindObjectOfType<InGameController>().CheckRecordAttempt();
                        FindObjectOfType<InGameController>().CheckRecordTime();
                        
                        
                        FindObjectOfType<SFXManager>().Play("win");
                        Invoke("ShowWinPanel", winDelayTime);
                    }
                }
                
                FindObjectOfType<InGameController>().UpdateAttempt(attempt);
                
            }else if(openCards.Count==2)
            {
                CloseCards(openCards);
                openCards.Clear();
                openCards.Add(index);
            }else if(openCards.Count==0)
            { 
                openCards.Add(index);
            }
        }
        
        
    }
    void ShowWinPanel(){
        FindObjectOfType<InGameController>().winPanel.SetActive(true);
        FindObjectOfType<WinPanel>().UpdatePanel();
    }
    public bool MatchCard(List<int> list){
        if(cards[list[0]].sprite==cards[list[1]].sprite){
            cardsChild[list[0]].SetActive(true);
            cardsChild[list[1]].SetActive(true);
            FindObjectOfType<SFXManager>().Play("cardMatch");
            return true;
        }else return false;
        
    }
    public void CloseCards(List<int> list){
        cards[list[0]].sprite=defaultIcon;
        cards[list[1]].sprite=defaultIcon;  
    }
    public void ShowMatchedCards(List<int> list){
        
    }
    public void GamePlayStarts()
    {
        //RandomizeIcons();
        for (int i=0; i<cards.Length;i++)
        {
            cards[i].sprite=defaultIcon;
            cardsChild[i]=cards[i].transform.GetChild(0).gameObject;
            cardsChild[i].GetComponent<Image>().sprite=tickIcon;
            cardsChild[i].SetActive(false);
            
        }
        openCards.Clear();
        attempt=0;
        FindObjectOfType<InGameController>().UpdateAttempt(attempt);
        matchedCardsNumber=0;
        igc.gameFinished=false;
        FindObjectOfType<SFXManager>().Play("startGame");
    }
    public void HideCardChild(){
        for (int i=0; i<cards.Length;i++)
        {
            cardsChild[i]=cards[i].transform.GetChild(0).gameObject;
            cardsChild[i].GetComponent<Image>().sprite=tickIcon;
            cardsChild[i].SetActive(false);
            
        }
    }
}
