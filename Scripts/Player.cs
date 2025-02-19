using UnityEngine;

using UnityEngine.SceneManagement;

public class TopDownPlayer : MonoBehaviour
{
    public float moveSpeed = 5f;

    private Rigidbody2D rb;
    private Vector2 moveInput;
    private bool canTeleport = false; // ��Ż ���� �ִ��� ����

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        moveInput.x = Input.GetAxisRaw("Horizontal");
        moveInput.y = Input.GetAxisRaw("Vertical");
        moveInput.Normalize();

        if (moveInput != Vector2.zero)
        {
            float angle = Mathf.Atan2(moveInput.y, moveInput.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0, 0, angle - 90);
        }

        // ��Ż ������ Space Ű�� ������ �� �̵�
        if (canTeleport && Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("��Ż");
            SceneManager.LoadScene("minigame"); 
        }
    }

    void FixedUpdate()
    {
        rb.velocity = moveInput * moveSpeed;
    }

    // ��Ż ���� �ִ��� ����
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Portal"))
        {
            canTeleport = true;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Portal"))
        {
            canTeleport = false;
        }
    }
}
