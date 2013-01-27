using UnityEngine;
using System.Collections;

public class MC : MonoBehaviour {
	
	
	// Use this for initialization
	void Start () {
		
	}
	
	void OnControllerHit(ControllerColliderHit c){
		print (c.gameObject.name);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	 void FixedUpdate(){
		//transform.position.Set(transform.position.x, transform.position.y, 0);
	}
	
	
}
