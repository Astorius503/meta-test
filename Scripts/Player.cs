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
    public float moveSpeed = 5f; // �̵� �ӵ�

    private Rigidbody2D rb;
    private Vector2 moveInput;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // �Է� �ޱ� (WASD �Ǵ� ����Ű)
        moveInput.x = Input.GetAxisRaw("Horizontal"); // A(-1) / D(1)
        moveInput.y = Input.GetAxisRaw("Vertical");   // W(1) / S(-1)
        moveInput.Normalize(); // �밢�� �̵� �ӵ� ����

        // �̵� ������ �ٶ󺸵��� ȸ��
        if (moveInput != Vector2.zero)
        {
            float angle = Mathf.Atan2(moveInput.y, moveInput.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0, 0, angle - 90);
        }
    }

    void FixedUpdate()
    {
        // ���� ��� �̵� ����
        rb.velocity = moveInput * moveSpeed;
    }
}