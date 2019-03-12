using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour {

    

    public GameObject Wall;
    public GameObject Wall_0;
    public GameObject Wall_1;
    public GameObject Player;
    public GameObject Destination;
    LevelInfo curLevel;
    Level level;
    //use in CreateLevelScene()
    Vector3 ScenePosition;
    GameObject newObject;

    //use in CheckMove()
    private int curX;  //player_x
    private int curY;

    //use in TurnScene()
    public Sprite Wall_0_sprite;
    public Sprite Wall_1_sprite;

	// Use this for initialization
	void Start () {
        
        GetCurLevel(2);
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
        }
       
        curLevel.Wall_01_index_list = new List<Vector2>();
        curLevel.Wall_01_list = new List<GameObject>();
        
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
                    case -2: newObject = Instantiate(Destination, ScenePosition, Quaternion.identity) as GameObject; break;
                    case -1: newObject= Instantiate(Player, ScenePosition, Quaternion.identity) as GameObject; curX = i; curY = j;  break;
                    case 1: newObject = Instantiate(Wall, ScenePosition, Quaternion.identity) as GameObject; break;
                    case 2: newObject = Instantiate(Wall_0, ScenePosition, Quaternion.identity) as GameObject;
                                curLevel.Wall_01_index_list.Add(new Vector2(i, j));curLevel.Wall_01_list.Add(newObject); break;
                    case 3: newObject = Instantiate(Wall_1, ScenePosition, Quaternion.identity) as GameObject;
                                curLevel.Wall_01_index_list.Add(new Vector2(i, j)); curLevel.Wall_01_list.Add(newObject); break;
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
        else
        {
            
            curX = nextX;
            curY = nextY;
            TurnScene();
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
                print("2");
                curLevel.levelScene[wall_i, wall_j] = 2;
                curLevel.Wall_01_list[i].GetComponent<SpriteRenderer>().sprite = Wall_0_sprite;
            }
        }
    }
   
}
