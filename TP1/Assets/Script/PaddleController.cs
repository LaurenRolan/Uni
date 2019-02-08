using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleController : MonoBehaviour {

	[SerializeField]
	private float speed = 1f;

	private Vector3 nextPosition = new Vector3(0, -9.5f, 0);
	// Use this for initialization
	void Start () {
		nextPosition = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		nextPosition.x = transform.position.x + (Input.GetAxisRaw("Horizontal") * speed  * Time.deltaTime);
		nextPosition.x = Mathf.Clamp(nextPosition.x, -8f, 8f);
		transform.position = nextPosition;
		//Debug.Log(Input.GetAxis("Horizontal").ToString());
	}
}
