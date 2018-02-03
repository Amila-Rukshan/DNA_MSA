using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionTester : MonoBehaviour {
    
	void Awake(){
		//Debug.Log ("Here "+ this.gameObject.name);
	}

	void OnCollisionEnter2D(Collision2D col){
		this.GetComponent<Rigidbody2D> ().velocity = new Vector3 (0, 0, 0);
		//Debug.Log (this.gameObject.name+" has collided with "+ col.gameObject.name);
	}

	void OnTriggerEnter2D(Collider2D other){
		//Debug.Log (this.gameObject.name+" was triggered by "+ other.gameObject.name);
	}
}
