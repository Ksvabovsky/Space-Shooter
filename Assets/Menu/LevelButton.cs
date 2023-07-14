using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LevelButton : MonoBehaviour
{

    [SerializeField]
    private LevelInfo info;

    public Image starOne;
    public Image starTwo;
    public Image starThree;

    public Sprite starEarned;
    
    [SerializeField]
    private GameManager gameManager;
    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameManager.GetInstance();
        info.levelState = gameManager.getLevelState(info.LevelID);
        SetStars(info.levelState);

    }

    void SetStars(int s)
    {
        switch (s)
        {
            case 1:
                starOne.sprite = starEarned;
                break;
            case 2:
                starOne.sprite = starEarned;
                starTwo.sprite = starEarned;
                break;
            case 3:
                starOne.sprite = starEarned;
                starTwo.sprite = starEarned;
                starThree.sprite = starEarned;
                break;
        }
    }

    private void OnMouseOver()
    {
        gameManager.SetCurrentLevel(info);
    }

    public void StartLevel()
    {
        gameManager.SetCurrentLevel(info);
        gameManager.LoadLevel();
    }


}
