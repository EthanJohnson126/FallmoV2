using UnityEngine;
using System.Collections;

public class FallScript : MonoBehaviour {

	//Checks if the block is currently calling.
	public bool isFalling = false;

	//Looks at the current Y position to compare against.
	public float Yposition;

	//References the hover script which sets the material and the height it can fall.
	public ClickScript cS;

	//Calls upon the end level function.
	public ScoreandTimer saT;

	void Start () {
		//Original y position is set in case of falling.
		Yposition = transform.position.y;
	}

	void Update () {
		//When the object is falling, set isfalling to true;
		if(this.rigidbody.velocity.y > .01){
			isFalling = true;
		}

		else{
			if(isFalling == true){
				//When the block lands, check how far it's fallen.
				float fallHeight = Yposition - transform.position.y;

				//If block has fallen more than its number height, reset the level.
				if(fallHeight > cS.fallNumber - .25){

                    //Turns the mouse back on in case of reset.
                    Screen.lockCursor = false;
                    Screen.showCursor = true;

					saT.switchEnd = true;
				}

				//Reset the original y position for falling later.
				Yposition = transform.position.y;

                //We've stopped falling!
				isFalling = false;

			}
		}
	
	}
}
