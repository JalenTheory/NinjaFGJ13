using UnityEngine;
using System.Collections;  
using AssemblyCSharp;
	
	 
public class Blobb : MonoBehaviour, IDamageable  {
	
	public int health; 
	public bool left;
	public int time;
	public float speed;
	private float curTime;
	private bool ground;
	private CollisionChecker[] collisionCheckers;
	
	// Use this for initialization
	void Start () {
		curTime = time;
		collisionCheckers = this.GetComponentsInChildren<CollisionChecker>();
	}
	
	// Update is called once per frame
	void Update () {

	}
	
	void FixedUpdate(){
		if(!ground)
			return;
		
		foreach(CollisionChecker colChecker in collisionCheckers){
			if(!colChecker.collide){
				if(colChecker.name == "leftDown"  && left){
					curTime = time;
					left = false;
				}else if(colChecker.name == "rightDown"  && !left){
					curTime = time;
					left = true;
				}
			}else{
				if(colChecker.name == "left" && !left){
					curTime = time;
					left = false;
				}else if(colChecker.name == "right" && !left){
					curTime = time;
					left = true;
				}	
			}
		}
		if(time != 0){
			curTime -= Time.deltaTime;
			if(curTime <= 0){
				curTime = time;
				left = !left;
			}
		}
		if(left){
			rigidbody.velocity = new Vector3(-speed, 0, 0);
		}else{
			rigidbody.velocity = new Vector3(speed, 0, 0);
		}
		
	}
	
	void OnCollisionEnter(Collision collision) {
		print ("asdad");
	    IDamageable[] cs = collision.gameObject.GetComponents(System.Type.GetType("AssemblyCSharp.IDamageable")) as IDamageable[];
		if(cs == null)
			return;
		foreach(IDamageable c in cs){
			c.Damage(1);
		}
		
		ground = true;
		rigidbody.drag = 10;
	}
	
	void OnCollisionExit(Collision collision) {
		ground = false;
		rigidbody.drag = 0;
	}
	
	public bool Damage(int damage){
		rigidbody.velocity = Vector3.zero;
		health -= damage;
		if(health <= 0){
			Destroy(this.gameObject);
		}
		return true;
	}
}
