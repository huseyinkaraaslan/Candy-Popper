using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public Text scoreText, endScreenScoreText, firstScoreText, secondScoreText, thirdScoreText;
    private int scoreValue, firstScore, secondScore, thirdScore;

    void Start()
    {
        firstScore = PlayerPrefs.GetInt(nameof(firstScore), firstScore);
        secondScore = PlayerPrefs.GetInt(nameof(secondScore), secondScore);
        thirdScore = PlayerPrefs.GetInt(nameof(thirdScore), thirdScore);

        firstScoreText.text = firstScore.ToString();
        secondScoreText.text = secondScore.ToString();
        thirdScoreText.text = thirdScore.ToString();
    }

    void Update()
    {
        scoreValue = gameObject.GetComponent<BlowUpCandy>().score;
        scoreText.text = scoreValue.ToString();

        if (gameObject.GetComponent<Timer>().time <= 0)
        {
            endScreenScoreText.text = scoreValue.ToString();
            if (scoreValue > firstScore)
            {
                thirdScore = secondScore;
                secondScore = firstScore;
                firstScore = scoreValue;
                PlayerPrefs.SetInt(nameof(thirdScore), thirdScore);
                PlayerPrefs.SetInt(nameof(secondScore), secondScore);
                PlayerPrefs.SetInt(nameof(firstScore), firstScore);
            }
            else if (scoreValue > secondScore && scoreValue < firstScore)
            {
                thirdScore = secondScore;
                secondScore = scoreValue;
                PlayerPrefs.SetInt(nameof(thirdScore), thirdScore);
                PlayerPrefs.SetInt(nameof(secondScore), secondScore);
            }
            else if (scoreValue > thirdScore && scoreValue < secondScore)
            {
                thirdScore = scoreValue;
                PlayerPrefs.SetInt(nameof(thirdScore), thirdScore);
            }
        }
    }
}