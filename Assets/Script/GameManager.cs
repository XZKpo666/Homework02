using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public int score;
    public float time;
    public int endScore;

    private void Update()
    {
        IncreaseScore();
    }
    public void IncreaseScore()
    {
        time += 10f * Time.deltaTime;
        score = (int)(time);       
    }

    public void GameOver()
    {
        LordEndScene();
    }

    void LordEndScene()
    {
        endScore = score;
        PlayerPrefs.SetInt("EndScore", endScore);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
