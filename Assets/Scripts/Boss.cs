using UnityEngine;
using System.Collections;
using AssemblyCSharp;

public class Boss : MonoBehaviour, IDamageable {
	public int health;
	public float bob;
	public float horizontal;
	public float speed;
	public float attackRise;
	public float attackCoolDown;
	public int attackChangeUpperRange;
	public float attackSpeed;
	private float coolDownTimer;
	private float timer;
	private bool rising;
	private bool moving;
	private float savedCap;
	private bool once;
	private float time;
	// Use this for initialization
	void Start () {
		once = true;
		rising = true;
		moving = true;
		coolDownTimer = attackCoolDown;
		timer = 1;
		time = Time.timeSinceLevelLoad;
	}
	
	// Update is called once per frame
	void Update () {
		if(moving){
			if(coolDownTimer <= 0){
				if(Random.Range(0, attackChangeUpperRange) == 0){
					moving = false;
					coolDownTimer = attackCoolDown;
				}
			}else{
				coolDownTimer -= Time.deltaTime;
			}
		}else{
			if(rising){
				timer += Time.deltaTime;
				if(timer >= attackRise){
					rising = false;
				}
			}else{
				timer -= Time.deltaTime;
				if(timer <= 1){
					rising = true;
					moving = true;
				}
			}
		}
	}
	
	void FixedUpdate(){
		if(moving){
			if(!once){
				time = savedCap;
				once = true;
			}
			rigidbody.transform.Translate(new Vector3(Mathf.Cos(time * speed) * horizontal, 0, Mathf.Sin(time) * bob));
		}else{
			if(once){
				savedCap = time;
				once = false;
			}
			rigidbody.transform.Translate(new Vector3(0, 0, (rising?-1:1) * timer * attackSpeed));
		}
		time += Time.deltaTime;
	}
		
	public bool Damage(int damage){
		health -= damage;
		if(health <= 0)
			Destroy (gameObject);
		return true;
	}
}
