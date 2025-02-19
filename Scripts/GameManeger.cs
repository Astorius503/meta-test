using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject gameOverUI;
    public Text scoreText;

    private float score = 0f;
    private bool isGameOver = false;

    void Start()
    {
        gameOverUI.SetActive(false); // ���� ���� �� GameOver UI ����
    }

    void Update()
    {
        if (!isGameOver)
        {
            score += Time.deltaTime; // ���� �ð� ����
            scoreText.text = "Score: " + Mathf.FloorToInt(score).ToString();
        }
    }

    public void GameOver()
    {
        isGameOver = true;
        gameOverUI.SetActive(true); // ���� ���� �� UI ǥ��
        Time.timeScale = 0; // ���� ����
    }

    public void RestartGame()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}



