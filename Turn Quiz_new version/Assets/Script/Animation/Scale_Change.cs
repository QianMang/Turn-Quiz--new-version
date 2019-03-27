using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scale_Change : MonoBehaviour {
    public float changeSpeed;
    public float maxScale;
    public float minScale;
    float curScale;
    bool animationFlag = true;
	// Use this for initialization
	void Start () {
	    
	}
	
	// Update is called once per frame
	void Update () {
       
        curScale = this.transform.localScale.x;
        if(animationFlag==true){
           // Debug.Log("123");
            if (curScale <= minScale) animationFlag = false;
            this.transform.localScale-=new Vector3( changeSpeed,  changeSpeed, 0);
            
        }else{
            if (curScale >= maxScale) animationFlag = true;
            this.transform.localScale+=new Vector3( changeSpeed,  changeSpeed, 0);
        }
	}
}
