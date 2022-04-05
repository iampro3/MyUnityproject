using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Scoremanager : MonoBehaviour
{
    public Text CurrentScoreUI;
    public Text bestScoreUI;
    private int CurrentScore;
    private int bestScore;

    public static Scoremanager Instance = null;

    public int Score
    {
        get
        {
            return CurrentScore;
        }
        set
        {
            CurrentScore = value;
            CurrentScoreUI.text = "현재점수 : " + CurrentScore;

            if (CurrentScore > bestScore)
            {
                bestScore = CurrentScore;
                bestScoreUI.text = "최고 점수 :" + bestScore;
                PlayerPrefs.SetInt("Best Score", bestScore);
            }
        }
    }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }

    }

    // Start is called before the first frame update
    void Start()
    {
        bestScore = PlayerPrefs.GetInt("Best Score", 0);
        bestScoreUI.text = "최고 점수 :" + bestScore;
    }


    // Update is called once per frame
    void Update()
    {

    }
}
