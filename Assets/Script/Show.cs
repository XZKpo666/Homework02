using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Show : MonoBehaviour
{
    public Text showScore;
    public GameManager gameManager;

    void Update()
    {
        showScore.text = "Depth:" + gameManager.score.ToString();
    }
}
