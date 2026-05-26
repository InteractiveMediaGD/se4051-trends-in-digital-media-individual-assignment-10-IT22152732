//using UnityEngine;
//using TMPro;

//public class GameManager : MonoBehaviour
//{
//    public static GameManager instance;

//    public TMP_Text scoreText;
//    private int score = 0;

//    void Awake()
//    {
//        instance = this;
//    }

//    public void AddScore()
//    {
//        score++;
//        scoreText.text = "Score: " + score;
//    }
//}

using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public TMP_Text scoreText;
    public int totalCrystals = 3;

    private int score = 0;

    void Awake()
    {
        instance = this;
    }

    void Start()
    {
        score = 0;

        if (scoreText != null)
        {
            scoreText.text = "Score: 0";
        }
    }

    public void AddScore()
    {
        score++;

        if (scoreText != null)
        {
            scoreText.text = "Score: " + score;
        }

        UnityEngine.Debug.Log("Crystal collected. Score = " + score + " / " + totalCrystals);
    }

    public int GetScore()
    {
        return score;
    }

    public bool HasCollectedAllCrystals()
    {
        return score >= totalCrystals;
    }
}