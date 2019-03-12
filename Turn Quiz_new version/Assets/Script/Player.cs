using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    GameObject MainCamera;
    Vector2 moveDirection = Vector2.zero;

	// Use this for initialization
	void Start () {
        MainCamera = GameObject.FindWithTag("MainCamera");
	}
	
	// Update is called once per frame
	void Update () {
        if(Input.anyKeyDown)
            MovePlayer();
	}

    void MovePlayer()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow)){
            moveDirection = Vector2.up;
           
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow)){
            moveDirection = Vector2.down;
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow)){
            moveDirection = Vector2.left;
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow)){
            moveDirection = Vector2.right;
            
        }
        if (MainCamera.GetComponent<LevelManager>().CheckMove(moveDirection))
        {
            this.transform.Translate(moveDirection);
            //change map
        }
    }



 

}
