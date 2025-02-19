using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject gameOverUI; // 게임 오버 UI
    public string mainSceneName = "Main"; // 돌아갈 씬 이름
    private bool isGameOver = false;

    void Start()
    {
        gameOverUI.SetActive(false); // 게임 시작 시 Game Over UI 숨김
    }

    void Update()
    {
        if (isGameOver && Input.GetKeyDown(KeyCode.Space)) // 게임 오버 상태에서 스페이스바 입력 감지
        {
            LoadMainScene();
        }
    }

    public void GameOver()
    {
        isGameOver = true;
        gameOverUI.SetActive(true); // 게임 오버 UI 표시
        Time.timeScale = 0; // 게임 정지
    }

    void LoadMainScene()
    {
        Time.timeScale = 1; // 시간 정지 해제
        SceneManager.LoadScene(mainSceneName); // Main 씬으로 이동
    }
}





