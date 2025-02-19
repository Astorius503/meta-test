using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject gameOverUI; // ���� ���� UI
    public string mainSceneName = "Main"; // ���ư� �� �̸�
    public Text scoreText; // ���� ǥ�� UI
    private bool isGameOver = false;
    private float score = 0f; // ���� �ð� (����)

    void Start()
    {
        gameOverUI.SetActive(false); // ���� ���� �� Game Over UI ����
    }

    void Update()
    {
        if (!isGameOver)
        {
            score += Time.deltaTime; // ���� �ð� ����
            scoreText.text = "Score: " + Mathf.FloorToInt(score).ToString(); // UI ������Ʈ
        }

        if (isGameOver && Input.GetKeyDown(KeyCode.Space)) // ���� ���� ���¿��� �����̽��� �Է� ����
        {
            LoadMainScene();
        }
    }

    public void GameOver()
    {
        isGameOver = true;
        gameOverUI.SetActive(true); // ���� ���� UI ǥ��
        Time.timeScale = 0; // ���� ����
    }

    void LoadMainScene()
    {
        Time.timeScale = 1; // �ð� ���� ����
        SceneManager.LoadScene(mainSceneName); // Main ������ �̵�
    }
}





