using UnityEngine;

using UnityEngine.SceneManagement;

public class TopDownPlayer : MonoBehaviour
{
    public float moveSpeed = 5f;

    private Rigidbody2D rb;
    private Vector2 moveInput;
    private bool canTeleport = false; // 포탈 위에 있는지 여부

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

        // 포탈 위에서 Space 키를 누르면 씬 이동
        if (canTeleport && Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("포탈");
            SceneManager.LoadScene("minigame"); 
        }
    }

    void FixedUpdate()
    {
        rb.velocity = moveInput * moveSpeed;
    }

    // 포탈 위에 있는지 감지
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
