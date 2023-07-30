using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowEnd : MonoBehaviour
{
    public Text showScore;
    int score;

    private void Start()
    {
        score = PlayerPrefs.GetInt("EndScore");
    }

    private void Update()
    {
        showScore.text = "Depth:" + score.ToString();
    }
}
