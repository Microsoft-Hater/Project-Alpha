//B00164770
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


//Should follow a prety similar formula to HealthManager
public class EnemyTextManager : MonoBehaviour
{
	
	public int fullEnemies = 4;
	public TMP_Text enemiesText; //Should allow the text to dynamically update
	private int currentEnemies;
	public TMP_Text WinnerText;//Win and lose screens dont have their own scripts
	
    // Start is called before the first frame update
    void Start()
    {
      currentEnemies = fullEnemies;
       UpdateEnemiesText();	
	   WinnerText.gameObject.SetActive(false);
	   //Found .setActive to use the win and lose screens
	   //Apparently its fine to refer to winnertext as a gameobject
	   //Pretty much identical process for the loser screen in HealthManager
    }
	public void enemyDeath(){
	currentEnemies = currentEnemies - 1;	
	if(currentEnemies < 0){
		currentEnemies = 0;
	}
	UpdateEnemiesText();
	if (currentEnemies == 0){
		DisplayWinnerText();//Straightforward
	}
	}
	//Now have to actually have the method to update the text
	void UpdateEnemiesText(){
		
		//Seems best to still print the string for best practices, had issues otherwise
		enemiesText.text = "Enemies Left: " + currentEnemies;
	}
	
	void DisplayWinnerText(){
		WinnerText.gameObject.SetActive(true);
		//best way i found to display the screen when enemies = 0
	}

    // Update is called once per frame
    void Update()
    {
        
    }
}
