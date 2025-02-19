using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
using UnityEditor.Experimental.RestService;
using UnityEditor.Timeline;
using UnityEngine;
using UnityEngine.Animations;

using UnityEngine;

public class TopDownPlayer : MonoBehaviour
{
    public float moveSpeed = 5f; // 이동 속도

    private Rigidbody2D rb;
    private Vector2 moveInput;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // 입력 받기 (WASD 또는 방향키)
        moveInput.x = Input.GetAxisRaw("Horizontal"); // A(-1) / D(1)
        moveInput.y = Input.GetAxisRaw("Vertical");   // W(1) / S(-1)
        moveInput.Normalize(); // 대각선 이동 속도 조정

        // 이동 방향을 바라보도록 회전
        if (moveInput != Vector2.zero)
        {
            float angle = Mathf.Atan2(moveInput.y, moveInput.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0, 0, angle - 90);
        }
    }

    void FixedUpdate()
    {
        // 물리 기반 이동 적용
        rb.velocity = moveInput * moveSpeed;
    }
}