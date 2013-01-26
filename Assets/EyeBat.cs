using UnityEngine;
using System.Collections;
using AssemblyCSharp;

public class EyeBat : MonoBehaviour, IDamageable {
	public int health; 
	public float speed;
	public float radius;
	//private float TAU = Mathf.PI * 2;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	}
	
	public bool Damage(int damage){
		health -= damage;
		if(health < 0){
			Destroy(this.gameObject);
		}
		return true;
	}
}
