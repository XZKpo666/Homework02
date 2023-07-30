using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AnimatedScreenTexture : MonoBehaviour
{
    public float speedY = 1f;
    private float curY;

    private void Start()
    {
        curY = GetComponent<Renderer>().material.mainTextureOffset.y;
    }

    private void FixedUpdate()
    {
        curY += Time.deltaTime * speedY;               
        GetComponent<Renderer>().material.SetTextureOffset("_MainTex" , new Vector2(0f, curY));
    }
}
