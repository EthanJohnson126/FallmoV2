using UnityEngine;
using System.Collections;

public class ClickScript : MonoBehaviour {

	//The height which the block can fall.
	public int fallNumber;

	//The various materials which indicate the amount each block can fall.
	public Material materialOne;
	public Material materialTwo;
	public Material materialThree;

	//The transparent material when one hovers over it.
	public Material transparent;

	void Start () {

		//Set the initial material for each block.
		if(fallNumber == 1)
		{
			this.renderer.material = materialOne;
		}

		if(fallNumber == 2)
		{
			this.renderer.material = materialTwo;
		}

		if(fallNumber == 3)
		{
			this.renderer.material = materialThree;
		}
	}

	void OnMouseOver(){
		//When the mouse hovers over the object, turn the object transparent.
		this.renderer.material = transparent;
	}

	void OnMouseExit(){
		//When the mouse leaves the object, reset the material.
		if(fallNumber == 1)
		{
			this.renderer.material = materialOne;
		}
		
		if(fallNumber == 2)
		{
			this.renderer.material = materialTwo;
		}
		
		if(fallNumber == 3)
		{
			this.renderer.material = materialThree;
		}
	}
}
