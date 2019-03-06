using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brick : MonoBehaviour {

	[SerializeField] private GameObject deathParticules;
	void OnCollisionEnter (Collision col)
    {
        
		Instantiate<GameObject> 
		(
			deathParticules,
			col.gameObject.transform.position,
			Quaternion.identity	
		);
		GameManager.Instance.DestroyBrick();
		Destroy(col.gameObject);
    }

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
