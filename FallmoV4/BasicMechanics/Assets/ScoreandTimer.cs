using UnityEngine;
using System.Collections;

public class ScoreandTimer : MonoBehaviour {

	//The actual timer.
	public float timefromBegin;

	//Upon the player losing, they reset the current level.
	public delegate void EndLevel ();
	EndLevel levelEnd;

	//Upon this being
	public bool switchEnd = false;

	//When lose, activate the GUI.
	public bool buttonAppear = false;

	//On lose, destroy music and play, failure sound.
	public AudioClip failureClip;
	public AudioSource woodSource;
	
	public AudioSource musicSource;
	
	void Start () {
		//Adding the actions to the delgate.
		levelEnd += OnLoseEnd;
		levelEnd += ResetLevel;
		Time.timeScale = 1;
	}

	void Update () {
		//Increment timer as time passes.
		timefromBegin += Time.deltaTime;

		//The fall script calls the switchEnd bool, changes it to true, so the level can reset.
		if(switchEnd == true){

			//Destroy the current music source.
			Destroy(musicSource.gameObject);
			
			//Play failure sound.
			woodSource.clip = failureClip;
			woodSource.Play ();

			levelEnd();
		}
	}

	//Reset the level.
	void ResetLevel(){
		//Pause the game's physics and make the GUI appear.
		Time.timeScale = 0;
		buttonAppear = true;
	}

	//Print the time spent in the level.
	void OnLoseEnd(){
		print (timefromBegin);
	}

	void OnGUI(){
		if(buttonAppear == true){
			//If the player loses the level, give them the option to restart.
			if(GUI.Button(new Rect (Screen.width/3, (Screen.height/3)*2, 100, 50), "Restart level"))
				Application.LoadLevel(Application.loadedLevel);
			//Display the time spent in the level.
			if(GUI.Button(new Rect ((Screen.width/3)*2, (Screen.height/3)*2, 400, 50), "Time in level was: " + timefromBegin.ToString("f1") + " seconds"));
		}
	}
}
