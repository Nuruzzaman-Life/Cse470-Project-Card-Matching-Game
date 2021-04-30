using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    // Start is called before the first frame update
    public void CardTap(Button button){
        char[] name = button.name.ToCharArray();
        string retrivedName = null;

        for (int i = 2; i <= name.Length - 2; i++)
        {
            retrivedName += name[i];
        }
        int number =int.Parse(retrivedName);

        FindObjectOfType<CardController>().ShowCard(number-1);
        
    }
    
}
