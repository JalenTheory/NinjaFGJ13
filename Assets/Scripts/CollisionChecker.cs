using UnityEngine;
using System.Collections;

public class CollisionChecker : MonoBehaviour {
	public bool collide;
	
	void OnTriggerEnter(Collider c){
		collide = true;
	}
	
	void OnTriggerExit(Collider c){
		collide = false;
	}
}
