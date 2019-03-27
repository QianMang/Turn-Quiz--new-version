using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour {

    

    public GameObject Wall;
    public GameObject Wall_0;
    public GameObject Wall_1;
    public GameObject Player;
    public GameObject Destination;
    public GameObject LockDoor;
    public GameObject Key;
    public GameObject Turn_item;
    //audio
    public GameObject Sound_door;
    public GameObject Sound_get;
    public GameObject Sound_win;
    public GameObject Sound_btn;

    LevelInfo curLevel;
    Level level;
    GameObject LevelControl;
    //use in CreateLevelScene()
    Vector3 ScenePosition;
    GameObject newObject;

    //use in CheckMove()
    private int curX;  //player_x
    private int curY;
    private int keyNum = 0;
    GameObject mainCamera;
    //use in TurnScene()
    public Sprite Wall_0_sprite;
    public Sprite Wall_1_sprite;
    //use in animation
    Vector3 changeScale = new Vector3(0.008f, 0.008f, 0);

	// Use this for initialization
	void Start () {
        LevelControl = GameObject.FindWithTag("levelControl");
        mainCamera = GameObject.FindWithTag("MainCamera");
        GetCurLevel(LevelControl.GetComponent<levelControl>().GetLevelNo());
        CreateLevelScene();
        AdjustCamera();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void GetCurLevel(int thisLevel)
    {
       
        curLevel = new LevelInfo();
        level = new Level();
        
        curLevel.levelNo = thisLevel;
        switch (thisLevel)
        {
            case 1:
                curLevel.levelScene = level.level_1;
                curLevel.index_i = level.level_1_i;
                curLevel.index_j = level.level_1_j;
                break;
            case 2:
                curLevel.levelScene = level.level_2;
                curLevel.index_i = level.level_2_i;
                curLevel.index_j = level.level_2_j;
                break;
            case 3:
                curLevel.levelScene = level.level_3;
                curLevel.index_i = level.level_3_i;
                curLevel.index_j = level.level_3_j;
                break;
            case 4:
                curLevel.levelScene = level.level_4;
                curLevel.index_i = level.level_4_i;
                curLevel.index_j = level.level_4_j;
                break;
            case 5:
                curLevel.levelScene = level.level_5;
                curLevel.index_i = level.level_5_i;
                curLevel.index_j = level.level_5_j;
                break;
        }
       
        curLevel.Wall_01_index_list = new List<Vector2>();
        curLevel.Wall_01_list = new List<GameObject>();
        curLevel.AllGameObjects_list = new List<GameObject>();
        
    }

    void CreateLevelScene()
    {
        for (int i = 0; i <curLevel.index_i; i++)
        {
            for (int j = 0; j < curLevel.index_j; j++)
            {
                ScenePosition = new Vector3(j ,-i, 1);
                switch (curLevel.levelScene[i,j])
                {
                    case 0:break;
                    case -2: newObject = Instantiate(Destination, ScenePosition, Quaternion.identity) as GameObject;
                        //curLevel.AllGameObjects_list.Add(newObject);
                        break;
                    case -1: newObject= Instantiate(Player, ScenePosition, Quaternion.identity) as GameObject; curX = i; curY = j;
                        curLevel.AllGameObjects_list.Add(newObject);
                        break;
                    case 1: newObject = Instantiate(Wall, ScenePosition, Quaternion.identity) as GameObject;//Debug.Log(newObject);
                        curLevel.AllGameObjects_list.Add(newObject);
                        break;
                    case 2: newObject = Instantiate(Wall_0, ScenePosition, Quaternion.identity) as GameObject;
                                curLevel.Wall_01_index_list.Add(new Vector2(i, j));curLevel.Wall_01_list.Add(newObject);
                        curLevel.AllGameObjects_list.Add(newObject);
                        break;
                    case 3: newObject = Instantiate(Wall_1, ScenePosition, Quaternion.identity) as GameObject;
                                curLevel.Wall_01_index_list.Add(new Vector2(i, j)); curLevel.Wall_01_list.Add(newObject);
                        curLevel.AllGameObjects_list.Add(newObject);
                        break;
                    case 4: newObject = Instantiate(LockDoor, ScenePosition, Quaternion.identity) as GameObject;
                        curLevel.AllGameObjects_list.Add(newObject);
                        break;
                    case 5: newObject = Instantiate(Key, ScenePosition, Quaternion.identity) as GameObject;
                        curLevel.AllGameObjects_list.Add(newObject);
                        break;
                    case 6: newObject = Instantiate(Turn_item, ScenePosition, Quaternion.identity) as GameObject;
                        curLevel.AllGameObjects_list.Add(newObject);
                        break;
                    default:break;
                }
                
            }
        }
    }

    void AdjustCamera()
    {
        this.transform.position = new Vector3(curLevel.index_j / 2, -curLevel.index_i / 2, -10);
    }

    public bool CheckMove(Vector2 direction)  //check and turn
    {
        int nextX = curX - (int)direction.y;
        int nextY = curY + (int)direction.x;
        if (curLevel.levelScene[nextX, nextY] == 1 || curLevel.levelScene[nextX, nextY] == 3)
        {
            return false;
        }
        else if(curLevel.levelScene[nextX,nextY]==4 && keyNum == 0)
        {
            
            return false;
        }
        
        else
        {
            if (curLevel.levelScene[nextX, nextY] == 5)   //key
            {
                Sound_get.GetComponent<AudioSource>().Play();
                curLevel.levelScene[nextX, nextY] = 0;
                keyNum++;
            }
            else if(curLevel.levelScene[nextX, nextY] == 4)   //door
            {
                Sound_door.GetComponent<AudioSource>().Play();
                curLevel.levelScene[nextX, nextY] = 0;
                keyNum--;

            }
            else if (curLevel.levelScene[nextX, nextY] == 6)
            {
                Sound_get.GetComponent<AudioSource>().Play();
                TurnScene();
                curLevel.levelScene[nextX, nextY] = 0;
            }
            else if(curLevel.levelScene[nextX, nextY] == -2)      // level clear
            {
                Sound_win.GetComponent<AudioSource>().Play();
                mainCamera.GetComponent<UIManager>().ClearTextSetActive();
                ClearScene();
            }
            
            curX = nextX;
            curY = nextY;
            
            TurnScene();            /////
            return true;
        }
    }

    void TurnScene()
    {
        int wall_i;
        int wall_j;
        for(int i = 0; i < curLevel.Wall_01_list.Count; i++)   //  Turn 01_wall
        {
            
            wall_i = (int)(curLevel.Wall_01_index_list[i].x);
            wall_j = (int)(curLevel.Wall_01_index_list[i].y);
            if (curLevel.levelScene[wall_i,wall_j ] == 2 &&( wall_i != curX || wall_j!=curY))
            {
               
                curLevel.levelScene[wall_i, wall_j] = 3;
                curLevel.Wall_01_list[i].GetComponent<SpriteRenderer>().sprite = Wall_1_sprite;
            }else if(curLevel.levelScene[wall_i, wall_j] == 3 &&( wall_i != curX || wall_j != curY))
            {
                
                curLevel.levelScene[wall_i, wall_j] = 2;
                curLevel.Wall_01_list[i].GetComponent<SpriteRenderer>().sprite = Wall_0_sprite;
            }
        }
    }
   
    void ClearScene(){
        for(int i=0;i<curLevel.AllGameObjects_list.Count;i++){
            if(curLevel.AllGameObjects_list[i]!=null)
                StartCoroutine(Animation_rotate_scale(curLevel.AllGameObjects_list[i]));
        }
        StartCoroutine(NextLevel());
    }

    IEnumerator Animation_rotate_scale(GameObject obj){
        for (; obj.transform.localScale.x>0;)
        {
            obj.transform.localScale -= changeScale;
            obj.transform.Rotate(0, 0, 2);
            yield return null;
        }
        obj.SetActive(false);
    }
    IEnumerator NextLevel(){
        yield return new WaitForSeconds(1.0f);
        if (LevelControl.GetComponent<levelControl>().GetLevelNo() + 1 == 6)
            mainCamera.GetComponent<UIManager>().ChooseLevel(LevelControl.GetComponent<levelControl>().GetLevelNo());
        else
            mainCamera.GetComponent<UIManager>().ChooseLevel(LevelControl.GetComponent<levelControl>().GetLevelNo()+1);
    }
}
