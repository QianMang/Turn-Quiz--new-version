using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class levelControl : MonoBehaviour {
    private int chooseLevelNo;
	// Use this for initialization
	void Start () {
        DontDestroyOnLoad(this.gameObject);
        SceneManager.LoadScene("Menu");
    }
	
	public void SetLevelNo(int no)
    {
        chooseLevelNo = no;
    }
    public int GetLevelNo()
    {
        return chooseLevelNo;
    }
}
