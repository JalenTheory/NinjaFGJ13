using UnityEngine;
using System.Collections;
using AssemblyCSharp;

namespace AssemblyCSharp
{
public class Sword : MonoBehaviour
{
public bool isActive;
public int Damage;
public float dir;
public float range;
public float timeActive;
private float counter;

//when the user clicks, isactive is true and we should check how long it has been active for
//

// Use this for initialization
void Start () {

}

// Update is called once per frame
void Update () {
if(isActive ==true )
{
counter += Time.deltaTime;	
if(counter>=timeActive)
{	
isActive=false;
counter=0;
}
}


}

void FixedUpdate () {

}


//if slash has occurred call this
void OnCollisionEnter(Collision collision) {
if(isActive ==true)
{	
IDamageable[] cs = collision.gameObject.GetComponents(System.Type.GetType("AssemblyCSharp.IDamageable")) as IDamageable[];
if(cs == null)
return;
foreach(IDamageable c in cs){
c.Damage(Damage);
}
Destroy(this.gameObject);
isActive = false;
}
}


}
}