using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    public float Speed =20f;
    private float Behind =31f;
    public bool is30 = false;
    public float dis;
    private int collisionCount = 0;

    private void Update()
    {
        dis = transform.position.magnitude;
        transform.position += new Vector3(0, 1, -1) * Speed * Time.deltaTime;
        IsBehind();
        if (is30 == true)
        {
            if (transform.position.magnitude > Behind)
            {
                Destroy(gameObject);
            }
        }
    }

    void IsBehind()
    {
        if (transform.position.magnitude < 30f)
        {
            is30 = true;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == ("ProtectingMask"))
        {
            if (collisionCount == 0)
            {
                collisionCount++;
                Destroy(gameObject);
            }
        }
    }
}
