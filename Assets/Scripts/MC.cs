using UnityEngine;
using System.Collections;
using AssemblyCSharp;
public class MC : MonoBehaviour, IDamageable{
	public bool gotDamaged;
	public int health;
	public Sword weapon;
	public Vector3 checkpoint;
	// Use this for initialization
	void Start () {
	
	}
	
	void Die(){
		Destroy(this.gameObject);
	}
	
	void OnControllerHit(ControllerColliderHit c){
		print (c.gameObject.name);
	}
	
	// Update is called once per frame
	void Update () {
		if(transform.position.y < -0.6f)
			Die();
	
		if(Input.GetMouseButtonUp(0))
		{
			Debug.Log("Pressed left click.");	
			weapon.isActive = true;
			/*sword has to be visible here*/
		}
	}
	
	public bool Damage(int damage){
		health -= damage;
		if(health <= 0)
			Die ();
		return true;
	}

}