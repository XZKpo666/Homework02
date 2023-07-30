using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameManager gameManager;
    public GameObject prefab;
    public float spawnRate = 1f;
    private int spawnCount;
    private float radius = 6f;

    private void Spawn()
    {
        Vector3 center = this.transform.position;
        float i = Random.Range(0f, 360f);
        float rad = i * Mathf.PI / 180;
        float x = center.x + radius * Mathf.Cos(rad);
        float y = center.y + radius * Mathf.Sin(rad);
        prefab.transform.position = new Vector3(x, y, center.z);
        Instantiate(prefab);
    }

    private void MultipleClone()
    {
        spawnCount = (gameManager.score / 100) + 1;
        for (int i = 0; i < spawnCount; i++)
            Spawn();       
    }

    private void OnEnable()
    {
        InvokeRepeating(nameof(MultipleClone), spawnRate, spawnRate);
    }

    private void OnDisable()
    {
        CancelInvoke(nameof(MultipleClone));
    }
}
