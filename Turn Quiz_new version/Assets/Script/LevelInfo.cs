using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelInfo{
   
    public  int levelNo;
    public int[,] levelScene;
    public int index_i;
    public int index_j;
    public  List<Vector2> Wall_01_index_list;
    public List<GameObject> Wall_01_list;
   

}

public class Level
{
    public int level_1_i=8;
    public int level_1_j = 3;
    // -2 destination, -1 start point, 0.empty,1. wall ; 2. wall_0 ;  3. wall_1 ; 4. lock_door ; 5. key  ; 6. turn_item
    public int[,] level_1 = new int[8, 3]
    {
        {1,1,1 },
        {1,-2,1 },
        {1,0,1 },
        {1,2,1 },
        {1,0,1 },
        {1,0,1 },
        {1,-1,1},
        {1,1,1 },
    };

    public int level_2_i = 11;
    public int level_2_j = 7;
    public int[,] level_2 = new int[11, 7]
    {
        {1,1,1,1,1,1,1 },
        {1,1,1,-2,1,1,1 },
        {1,1,1,4,1,1,1 },
        {1,5,0,0,0,0,1 },
        {1,0,0,0,0,0,1 },
        {1,2,1,1,1,3,1 },
        {1,0,0,0,0,0,1 },
        {1,1,2,2,2,1,1 },
        {1,0,0,0,0,0,1},
        {1,0,0,-1,0,0,1 },
        {1,1,1,1,1,1,1 }
    };
    public int level_3_i=9;
    public int level_3_j=9;
    public int[,] level_3 = new int[9, 9]
    {
        {0,0,0,1,1,1,0,0,0 },
        { 0,0,0,1,-2,1,0,0,0 },
        { 0,0,0,1,0,1,0,0,0 },
        {1,1,1,1,2,1,0,0,0 },
        {1,6,0,3,0,1,0,0,0 },
        {1,1,1,1,0,1,0,0,0 },
        {0,0,0,1,0,1,0,0,0 },
        {0,0,0,1,-1,1,0,0,0 },
         {0,0,0,1,1,1,0,0,0 },
    };
    public int level_4_i = 9;
    public int level_4_j = 9;
    public int[,] level_4 = new int[9, 9]
    {
        {0,0,0,1,1,1,0,0,0 },
        { 0,0,0,1,-2,1,0,0,0 },
        { 0,0,0,1,4,1,0,0,0 },
        {1,1,1,1,3,1,0,0,0 },
        {1,6,5,3,0,1,0,0,0 },
        {1,1,1,1,0,1,0,0,0 },
        {0,0,0,1,0,1,0,0,0 },
        {0,0,0,1,-1,1,0,0,0 },
         {0,0,0,1,1,1,0,0,0 },
    };
    public int level_5_i = 9;
    public int level_5_j = 9;
    public int[,] level_5 = new int[9, 9]
    {
        {0,1,1,1,1,1,1,1,0 },
        { 0,1,0,3,5,2,0,1,0 },
        { 0,1,0,1,1,1,0,1,0 },
        {0,1,0,0,-1,0,0,1,0 },
        {0,1,6,0,0,0,0,1,0 },
        {0,1,2,3,2,3,2,1,0 },
        {0,1,1,1,4,1,1,1,0 },
        {0,0,0,1,-2,1,0,0,0 },
         {0,0,0,1,1,1,0,0,0 },
    };
}

