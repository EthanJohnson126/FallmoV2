using UnityEngine;
using System.Collections;

public class TurnonPhysics : MonoBehaviour {

	//The objects to be checked and changed with rigidbodies.
	public GameObject[] physicsObjects;

	public float secondstoWait = 0;
	public float secondstoFall = 0;

	void Update () {
	
	}

	void OnWithPhysics(){

        //Lock mouse so the player can't rapidly click through the puzzle.
        Screen.showCursor = false;
        Screen.lockCursor = true;

		//Sets all physics objects to be checked by the script.
		physicsObjects = GameObject.FindGameObjectsWithTag("Physicsobject");

		//Changes the physics to active.
		foreach(GameObject physics in physicsObjects){
			physics.rigidbody.isKinematic = false;
			physics.rigidbody.useGravity = true;
		}

		//Returns physics to stable state.
		Invoke("TurnoffPhysics", secondstoFall);
	}

	void TurnoffPhysics(){
		//Turns off physics

		foreach(GameObject physics in physicsObjects){
			physics.rigidbody.isKinematic = true;
			physics.rigidbody.useGravity = false;
		}

        //Turn the mouse back on.
        Screen.showCursor = true;
        Screen.lockCursor = false;
	}

	public void StartPhysics(){
		//Calls physics change upon click.
		Invoke("OnWithPhysics", secondstoWait);
	}
}
