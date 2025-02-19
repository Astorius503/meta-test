using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeSpawn : MonoBehaviour
{
    public GameObject pipePrefab;
    public float spawnRate = 2f;
    public float minY = -2f;
    public float maxY = 2f;
    public float minScale = 0.1f;
    public float maxScale = 0.2f;

    void Start()
    {
        InvokeRepeating("SpawnPipe", 1f, spawnRate);
    }

    void SpawnPipe()
    {
        float randomY = Random.Range(minY, maxY);
        float randomScale = Random.Range(minScale, maxScale);

        // 아래쪽 파이프 생성
        GameObject bottomPipe = Instantiate(pipePrefab, new Vector3(5f, randomY, 0f), Quaternion.identity);
        bottomPipe.transform.localScale = new Vector3(0.1f, randomScale, 0.1f);

        // 위쪽 파이프 생성 (반전)
        GameObject topPipe = Instantiate(pipePrefab, new Vector3(5f, randomY + 4f, 0f), Quaternion.Euler(0, 0, 180));
        topPipe.transform.localScale = new Vector3(0.1f, randomScale, 0.1f);
    }
}

