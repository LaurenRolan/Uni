using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateMe : MonoBehaviour {

	//Access from editor, but not from other classes
	[SerializeField]
	private float xDegresPerFrame;
	// Use this for initialization
	void Start () {
		//Initialized in the Editor
	}
	
	// Update is called once per frame
	void Update () {
		transform.Rotate(Vector3.up, xDegresPerFrame * Time.deltaTime); //Un frame n'est pas constant -> rotation par seconde
	}
}
