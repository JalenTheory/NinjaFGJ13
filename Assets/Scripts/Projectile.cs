using UnityEngine;
using System.Collections;
using AssemblyCSharp;

public class Projectile : MonoBehaviour {
	public int Damage;
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
	
	void FixedUpdate () {
		
	}
	
	void OnCollisionEnter(Collision collision) {
		IDamageable[] cs = collision.gameObject.GetComponents(System.Type.GetType("AssemblyCSharp.IDamageable")) as IDamageable[];
		if(cs == null)
			return;
		foreach(IDamageable c in cs){
			c.Damage(Damage);
		}
		Destroy(this.gameObject);
	}

}
