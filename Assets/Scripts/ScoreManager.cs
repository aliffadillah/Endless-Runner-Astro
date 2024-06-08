using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public Text scoreText;
    public Text highScoreText; // Tambahkan Text untuk menampilkan high score
    private float score;
    private int highScore;

    void Start()
    {
        // Memuat high score dari PlayerPrefs
        highScore = PlayerPrefs.GetInt("HighScore", 0);
        highScoreText.text = "High Score: " + highScore.ToString();
    }

    void Update()
    {
        if (GameObject.FindGameObjectWithTag("Player") != null)
        {
            score += 1 * Time.deltaTime;
            scoreText.text = "Score: " + ((int)score).ToString();

            // Memeriksa apakah skor saat ini melebihi high score
            if ((int)score > highScore)
            {
                highScore = (int)score;
                highScoreText.text = "High Score: " + highScore.ToString();
                // Menyimpan high score yang baru
                PlayerPrefs.SetInt("HighScore", highScore);
            }
        }
    }

    public void IncreaseScore(int amount)
    {
        score += amount;
    }

    public float GetScore()
    {
        return score;
    }
}