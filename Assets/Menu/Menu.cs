using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu : MonoBehaviour
{

    public GameObject main;
    public GameObject levels;
    // Start is called before the first frame update
    void Start()
    {
        main.SetActive(true);
        levels.SetActive(false);

    }

    public void OpenMain()
    {
        main.SetActive(true);
        levels.SetActive(false);
    }

    public void ResetSave()
    {
        GameManager.GetInstance().ResetSave();
    }

    public void OpenLevels()
    {
        main.SetActive(false);
        levels.SetActive(true);
    }


    public void Exit()
    {
        
        Application.Quit();
    }
}

