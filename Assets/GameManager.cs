using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    private static GameManager instance;

    [SerializeField]
    private int[] levels = new int [3];

    [SerializeField]
    private LevelInfo CurrentLevel;


    private void Awake()
    {
        if(instance != null)
        {
            Destroy(gameObject);
            return;
        }
        instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public static GameManager GetInstance()
    {
        return instance;
    }

    private void Start()
    {
        Save_System.Load();
    }

    public void LoadLevel()
    {
        SceneManager.LoadScene("Level " + CurrentLevel.LevelID);
    }

    public void LoadMenu()
    {
        Save_System.Save();
        SceneManager.LoadScene("Menu");
    }

    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public int getLevelState(int id)
    {
        return instance.levels[id-1];
    }

    public void SetCurrentLevel(LevelInfo info)
    {
        CurrentLevel = info;
    }

    public LevelInfo GetLevelInfo()
    {
        return CurrentLevel;
    }

    public void SetLevelState(int s,int id)
    {
        levels[id-1] = s;
    }

    public int[] SaveLevels()
    {
        return levels;
    }

    public void LoadLevels(int[] l)
    {
        levels = l;
    }
    public void ResetSave()
    {
        levels = new int[3];
        Save_System.ResetSave();
        SceneManager.LoadScene("Menu");
    }
}
