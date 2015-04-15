using UnityEngine;
using System.Collections;

public class NextLevelScript : MonoBehaviour {

	//The amount of pieces in each individual puzzle.
    public int amountinPuzzle;
	
	//Calls the next level after the current one.
    public int nextLevel;

	//On win, activate GUI.
	public bool buttonAppear = false;

	//On win, destroy music and play, victory sound.
	public AudioClip victoryClip;
	public AudioSource woodSource;

	public AudioSource musicSource;

	void Update () {

		//When all pieces are destroyed, load the next level.
        if (amountinPuzzle <= 0 && Time.timeScale != 0)
        {
			//Destroy the current music source.
			Destroy(musicSource.gameObject);

			//Play victory sound.
			woodSource.clip = victoryClip;
			woodSource.Play ();

			//Make the GUI for the next level appear.
			buttonAppear = true;
        }
	
	}

	void OnGUI(){
		if(buttonAppear == true){
			//Upon completion of the level, a button appears which allows the player to move to the next level.
			if(GUI.Button(new Rect (Screen.width/3, (Screen.height/3)*2, 100, 50), "Next Level"))
				Application.LoadLevel(nextLevel);
		}
	}
}
