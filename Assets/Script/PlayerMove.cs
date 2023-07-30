using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerMove : MonoBehaviour
{
    public GameObject Parent;
    public GameObject ProtectingMask;
    public float sensitivity = 3f;
    private Vector2 turn;

    public bool isSpeedUp = false;
    private int collisionCount = 0;

    void Update()
    {
        if (Time.timeScale > 0)
        {
            PlayerMovment();
        }
    }

    public void PlayerMovment()
    {               
        if (Input.GetKey(KeyCode.Space))
        {
            PlayerSpeedUp();
        }
        else
        {
            Time.timeScale = 1f;
            isSpeedUp = false;
        }        
    }

    void PlayerSpeedUp()
    {
        if (isSpeedUp == false)
        {
            Time.timeScale = 2f;
            isSpeedUp = true;
        }
    }

    private void OnMouseDrag()
    {
        turn.x += Input.GetAxis("Mouse X") * sensitivity;
        Parent.transform.localRotation = Quaternion.Euler(0, -turn.x, 0);
    }

    private void OnCollisionEnter(Collision collision)
    {      
        if (collision.gameObject.tag == ("Obstacle"))
        {            
            if (collisionCount == 1)
            {
                FindObjectOfType<GameManager>().GameOver();
            }
            else if (collisionCount == 0)
            {
                collisionCount++;
                Destroy(ProtectingMask);
            }
        }
    }
}
