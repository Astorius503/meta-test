using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pipe : MonoBehaviour
{
    public float speed = 2f;

    void Update()
    {
        transform.position += Vector3.left * speed * Time.deltaTime;

        // 화면 왼쪽 끝에서 제거
        if (transform.position.x < -4f)
        {
            Destroy(gameObject);
        }
    }
}


