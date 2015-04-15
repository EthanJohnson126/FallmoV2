using UnityEngine;
using System.Collections;

public class CameraRotate : MonoBehaviour {

	public GameObject target = null;
	public bool orbitY = false;

	public float distance = 15;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		if(target != null)
		{
			transform.LookAt(target.transform);

			if(orbitY)
			{
				transform.RotateAround(target.transform.position, Vector3.right, Time.deltaTime * distance);
			}
		}

		distance += Input.GetAxis("Mouse ScrollWheel");
	
	}
}
