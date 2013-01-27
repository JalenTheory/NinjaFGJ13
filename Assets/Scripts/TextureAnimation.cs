using UnityEngine;
using System.Collections;
 
class TextureAnimation : MonoBehaviour
{
    public int columns = 2;
    public int rows = 1;
    public float framesPerSecond = 10f;
 
 public string action = "run";
    //the current frame to display
    private int index = 0;
 
    void Start()
    {
        StartCoroutine(updateTiling());
 
        //set the tile size of the texture (in UV units), based on the rows and columns
        Vector2 size = new Vector2(1f / columns, 1f / rows);
        renderer.sharedMaterial.SetTextureScale("_MainTex", size);
    }
	
	
 
	
	
    private IEnumerator updateTiling( )
    {
		  
		  
		
		
        while (true)
        {
			 
			if(Input.GetButton ("Fire1") ){
				 
				columns=3;  
				Texture2D myGUITexture = (Texture2D)Resources.Load("ninja-slash");
			renderer.material.SetTexture("_MainTex",myGUITexture);	}
			
							
			if(Input.GetButton ("Fire2") ){columns=4; Texture2D myGUITexture = (Texture2D)Resources.Load("ninja-throw");
			renderer.material.SetTexture("_MainTex",myGUITexture);
				}
			
			if(Input.GetButton ("Jump") ){
				columns=4;Texture2D myGUITexture = (Texture2D)Resources.Load("ninja-jump");
			renderer.material.SetTexture("_MainTex",myGUITexture);
				
			if(Input.GetButton ("Fire1") ){
					columns=3;  myGUITexture = (Texture2D)Resources.Load("ninja-jumpslash");
			renderer.material.SetTexture("_MainTex",myGUITexture);	}
					
			else if(Input.GetButton ("Fire2") ){columns=4; myGUITexture = (Texture2D)Resources.Load("ninja-jumpthrow");
			renderer.material.SetTexture("_MainTex",myGUITexture);}
					
					else {
				columns=4;
					myGUITexture = (Texture2D)Resources.Load("ninja-jump");
			renderer.material.SetTexture("_MainTex",myGUITexture);
				}}
//				
			if(Input.GetButton ("Horizontal") ){
				
				columns=4; 
				Texture2D myGUITexture = (Texture2D)Resources.Load("ninja-run");
				renderer.material.SetTexture("_MainTex",myGUITexture);
				
				}
//			
//			
//			else{columns=1; 
//				Texture2D myGUITexture = (Texture2D)Resources.Load("ninja-stand");
//			renderer.material.SetTexture("_MainTex",myGUITexture);
//			 
//			}
//			 
//			 
			//death
			 
			
			  	 
	            //move to the next index
            index++;
            if (index >= rows * columns)
                index = 0;
 
            //split into x and y indexes
            Vector2 offset = new Vector2((float)index / columns - (index / columns), //x index
                                          (index / columns) / (float)rows);          //y index
 
            renderer.sharedMaterial.SetTextureOffset("_MainTex", offset);
 
            yield return new WaitForSeconds(1f / framesPerSecond);
        }
 
    }
}

