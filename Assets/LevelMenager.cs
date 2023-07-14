using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.SceneManagement;
using TMPro;

public class LevelMenager : MonoBehaviour
{

    [SerializeField]
    private float GameTime;

    [SerializeField]
    private float Delay = 0.5f;

    [SerializeField]
    private bool playing;

    public TMP_Text timeTExt;
    public TMP_Text WinTimeText;
    public TMP_Text goText;

    public GameObject WinScreen;
    public GameObject LostScreen;

    [Header("Auto Find in Scene")]

    [SerializeField]
    private List<Alien> Aliens;

    [SerializeField]
    private Player_Script Player;

    [SerializeField]
    private GameManager gameManager;

    private static LevelMenager instance;

    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }
        instance = this;
    }

    public static LevelMenager GetInstance()
    {
        return instance;
    }

    
    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameManager.GetInstance();
        Player = Player_Script.getInstance();
        GameTime = 0f;
        WinScreen.SetActive(false);
        LostScreen.SetActive(false);
        goText.gameObject.SetActive(false);
        playing = false;
        StartCoroutine(StartDelay());
    }

    // Update is called once per frame
    void Update()
    {
        
        if (playing)
        {
            GameTime = GameTime + Time.deltaTime;
            UpdateTimeText( timeTExt);
        }

        if(Player == null)
        {
            playing = false;
            LostScreen.SetActive(true);
            //Time.timeScale = 0f;
        }


        if(Aliens.Count <= 0 && playing)
        {
            playing = false;
            UpdateTimeText(WinTimeText);
            WinScreen.SetActive(true);
            //Time.timeScale = 0f;
        }
        
    }

    public void SignAlien(Alien a)
    {
        Aliens.Add(a);
    }

    public void UnsignAlien(Alien a)
    {
        Aliens.Remove(a);
    }

    void UpdateTimeText(TMP_Text text)
    {
        float minutes = Mathf.FloorToInt(GameTime / 60);
        float seconds = Mathf.FloorToInt(GameTime % 60);
        float mili = GameTime % 1f % 0.01f;

        string timeString = string.Format("{00:00}:{1:00}", minutes, seconds);

        text.text = timeString;

    }
    public void Win()
    {
        LevelInfo info = gameManager.GetLevelInfo();
        int state = gameManager.getLevelState(info.LevelID);
        if(GameTime<info.time1 && state < 1)
        {
            gameManager.SetLevelState(1, info.LevelID);
        }
        if (GameTime < info.time2 && state < 2)
        {
            gameManager.SetLevelState(2, info.LevelID);
        }
        if (GameTime < info.time3 && state < 3)
        {
            gameManager.SetLevelState(3, info.LevelID);
        }


            GoMenu();
    }
    public void GoMenu()
    {
        //Time.timeScale = 1f;
        gameManager.LoadMenu();
        
    }

    public void Restart()
    {
        //Time.timeScale = 1f;
        gameManager.RestartLevel();
        
    }

    private IEnumerator StartDelay()
    {
        yield return new WaitForSeconds(0.1f);
        //Time.timeScale = 0f;
        yield return new WaitForSeconds(Delay);
        //Time.timeScale = 1f;
        goText.gameObject.SetActive(true);
        playing = true;
        Player.StartPlaying();
        foreach(Alien alien in Aliens)
        {
            alien.StartPlaying();
        }
        yield return new WaitForSeconds(0.3f);
        goText.gameObject.SetActive(false);
    }
}
