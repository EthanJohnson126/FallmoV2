using UnityEngine;
using System.Collections;

public class DestroyonClick : MonoBehaviour {

	//References the script which gives the physics a jolt.
	public TurnonPhysics toP;

	//References the script to move on.
    public NextLevelScript nlS;

	//The ways to play the sounds with a list of audisources for the different wood blocks.
	public AudioClip[] woodSounds;
	public AudioSource woodSource;

	void OnMouseDown(){

		//On click, play a random sound from the list.
		woodSource.clip = woodSounds[Random.Range(0, woodSounds.Length)];
		woodSource.Play ();

		//When the object is clicked, destroy it.
		Destroy(this.gameObject);
		//Turn on the physics loop.
		toP.StartPhysics();

        //Tells the script which switches levels how many blocks are left in the puzzle.
        nlS.amountinPuzzle--;
		
	}
}
