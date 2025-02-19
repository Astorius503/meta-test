using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject gameOverUI;
    public Text scoreText;
    public string nextSceneName = "Main";
    private float score = 0f;
    private bool isGameOver = false;

    void Start()
    {
        gameOverUI.SetActive(false); // 게임 시작 시 GameOver UI 숨김
    }

    void Update()
    {
        if (!isGameOver)
        {
            score += Time.deltaTime; // 생존 시간 증가
            scoreText.text = "Score: " + Mathf.FloorToInt(score).ToString();
        }
    }

    public void GameOver()
    {
        isGameOver = true;
        gameOverUI.SetActive(true); // 게임 오버 시 UI 표시
        Time.timeScale = 0; // 게임 정지

        Invoke("LoadNextScene", 5f);
    }

    public void LoadNextScene()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(nextSceneName);
    }
}



