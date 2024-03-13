using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    [SerializeField]
    public int crystals;
    [SerializeField]
    public bool[] buyedBalls;
    [SerializeField]
    public bool[] buyedBacks;
    public bool learnCompleted;
    [SerializeField]
    public List<int> stars = new List<int>();
    public int UnlockedLevels;
    public List<Sprite> BallSprites = new List<Sprite>();
    public List<Sprite> BackSprites = new List<Sprite>();

    public int ChoosedBall;
    public int ChoosedBack;

    private void Awake()
    {
        if (instance != null)
            Destroy(this);
        instance = this;
#if UNITY_EDITOR
        PlayerPrefs.DeleteAll();
        crystals = 10000;
#endif
        LoadAllData();
    }
    [SerializeField]
    private Image background;
    [SerializeField]
    private Sprite[] backgroundSprites;
    public void ChangeBackground(int i)
    {
        background.sprite = backgroundSprites[i];
        ChoosedBack = i;
        SaveAllData();
    }
    public void ChangeBall(int i)
    {
        ChoosedBall = i;
        SaveAllData();
    }
    public bool CheckBuyedBallsArr(int i)
    {
        return buyedBalls[i];
    }
    public bool CheckBuyedBacksArr(int i)
    {
        return buyedBacks[i];
    }
    public void ChangeBuyedBallsArr(int i)
    {
        buyedBalls[i] = true;
        SaveAllData();
        UpdateCrystalsText();
    }
    public void ChangeBuyedBacksArr(int i)
    {
        buyedBacks[i] = true;
        SaveAllData();
        UpdateCrystalsText();
    }
    public bool CheckCanBuy(int cost)
    {
        if (crystals >= cost)
        {
            crystals -= cost;
            return true;
        }
        else return false;
    }
    public void LoadAllData()
    {
        if (PlayerPrefs.HasKey("crystals"))
            crystals = PlayerPrefs.GetInt("crystals");
        UpdateCrystalsText();

        if (PlayerPrefs.HasKey("learnCompleted"))
            learnCompleted = Convert.ToBoolean(PlayerPrefs.GetInt("learnCompleted"));

        if (PlayerPrefs.HasKey("ChoosedBall"))
            ChoosedBall = PlayerPrefs.GetInt("ChoosedBall");
        if (PlayerPrefs.HasKey("ChoosedBack"))
            ChoosedBack = PlayerPrefs.GetInt("ChoosedBack");
        if (PlayerPrefs.HasKey("UnlockedLevels"))
            UnlockedLevels = PlayerPrefs.GetInt("UnlockedLevels");
        for (int i = 0; i < buyedBalls.Length; i++)
        {
            if (PlayerPrefs.HasKey("Ball" + i.ToString()))
                buyedBalls[i] = Convert.ToBoolean(PlayerPrefs.GetInt("Ball" + i.ToString()));
        }

        for (int i = 0; i < buyedBacks.Length; i++)
        {
            if (PlayerPrefs.HasKey("Back" + i.ToString()))
                buyedBacks[i] = Convert.ToBoolean(PlayerPrefs.GetInt("Back" + i.ToString()));
        }

        for(int i = 0; i < stars.Count; i++)
        {
            if (PlayerPrefs.HasKey("stars" + i.ToString()))
                stars[i] = PlayerPrefs.GetInt("stars" + i.ToString());
        }
        ChangeBackground(ChoosedBack);
        ChangeBall(ChoosedBall);
    }

    public void SaveAllData()
    {
        PlayerPrefs.SetInt("crystals", crystals);
        PlayerPrefs.SetInt("learnCompleted", Convert.ToInt32(learnCompleted));

        for (int i = 0; i < buyedBalls.Length; i++) 
        {
            PlayerPrefs.SetInt("Ball" + i.ToString(), Convert.ToInt32(buyedBalls[i]));
        }

        for (int i = 0; i < buyedBacks.Length; i++)
        {
            PlayerPrefs.SetInt("Back" + i.ToString(), Convert.ToInt32(buyedBacks[i]));
        }
        
        PlayerPrefs.SetInt("ChoosedBall", ChoosedBall);
        PlayerPrefs.SetInt("ChoosedBack", ChoosedBack);
    }
    public void SaveCompletedlevel(int getedStars,int completedLevel)
    {
        PlayerPrefs.SetInt("stars" + completedLevel.ToString(), getedStars);
        PlayerPrefs.SetInt("UnlockedLevels", UnlockedLevels);

    }
    public void AddToCrystals(int plus)
    {
        crystals += plus;
        SaveAllData();
        UpdateCrystalsText();
    }

    [SerializeField]
    private TextMeshProUGUI[] crystalsText;

    public void UpdateCrystalsText()
    {
        float f = 0;
        string str = crystals.ToString();
        if (crystals >= 1000000)
        {
            f = (crystals / 1000000);
            Math.Round(f, 1);
            str = f.ToString() + "M";
        }
        else if (crystals > 1000)
        {
            f = crystals / 1000;
            Math.Round(f, 1);
            str = f.ToString() + "K";
        }
        foreach (var text in crystalsText) 
        {
            text.text = str;
        }
    }
}
