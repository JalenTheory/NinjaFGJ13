using UnityEngine;
using System.Collections;

public class Projectile : MonoBehaviour {
	public float dir;
	public float velocity;

	// Use this for initialization
	void Start () {
		transform.Rotate(new Vector3(0, dir, 0));
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate(new Vector3(velocity, 0, 0) * Time.deltaTime);
	}
}
