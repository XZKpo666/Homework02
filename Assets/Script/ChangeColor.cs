using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ChangeColor : MonoBehaviour
{
    public GameManager gameManager;  
    public new Light light;
    public int lightChange;
    public float duration = 2.0f;
    public float[] currentTime;

    private void Start()
    {
        light = GetComponent<Light>();
        currentTime = new float[10];
        for(int i = 0; i < currentTime.Length; i++)
        {
            currentTime[i] = 0;
        }
    }

    void Update()
    {
        ChangeLightColor();
    }

    void ChangeLightColor()
    {       
        lightChange = (gameManager.score / 100);
        if (lightChange % 7 == 0)
        {
            for (int i = 0; i < currentTime.Length; i++)
            {
                currentTime[i] = 0;
            }
            light.color = Color.white;
        }
        else if (lightChange % 7 == 1)
        {
            light.color = Color.Lerp(Color.white, Color.red, ChangeTime(lightChange % 10));
        }
        else if (lightChange % 7 == 2)
        {
            light.color = Color.Lerp(Color.red, Color.blue, ChangeTime(lightChange % 10));
        }
        else if (lightChange % 7 == 3)
        {
            light.color = Color.Lerp(Color.blue, Color.green, ChangeTime(lightChange % 10));
        }
        else if (lightChange % 7 == 4)
        {
            light.color = Color.Lerp(Color.green, Color.yellow, ChangeTime(lightChange % 10));
        }
        else if (lightChange % 7 == 5)
        {
            light.color = Color.Lerp(Color.yellow, new Color(1,0,1), ChangeTime(lightChange % 10));
        }
        else if (lightChange % 7 == 6)
        {
            light.color = Color.Lerp(new Color(1, 0, 1), new Color(0, 1, 1), ChangeTime(lightChange % 10));
        }
    }

    float  ChangeTime(int i)
    {
        currentTime[i-1] += Time.deltaTime;
        float t = Mathf.Clamp01(currentTime[i-1] / duration);
        return t;
    }

}
