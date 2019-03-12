using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class UIManager : MonoBehaviour {

   GameObject LevelControl;
    public Text ClearText;
    // Use this for initialization
    void Start () {
        LevelControl = GameObject.FindWithTag("levelControl");
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void ChooseLevel(int levelNo)
    {
        LevelControl.GetComponent<levelControl>().SetLevelNo(levelNo);
        SceneManager.LoadScene("GameScene");
    }

    public void Retry()
    {
        SceneManager.LoadScene("GameScene");
    }

    public void Menu()
    {
        SceneManager.LoadScene("Menu");
    }

    public void ClearTextSetActive()
    {
        ClearText.gameObject.SetActive(true);
    }

}
