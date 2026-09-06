using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public int score = 0;
    public int targetScore = 20;
    public int lives = 3;

    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI livesText;
    public TextMeshProUGUI gameOverText;
    public TextMeshProUGUI winText;

    public GameObject restartButton;

    void Start()
    {
        UpdateScoreUI();
        UpdateLivesUI();

        gameOverText.gameObject.SetActive(false);
        restartButton.gameObject.SetActive(false);
        winText.gameObject.SetActive(false);
    }

    public void AddScore(int amount)
    {
        score += amount;
        UpdateScoreUI();

        Debug.Log("Score: " + score);

        if (score >= targetScore)
        {
            WinGame();
        }
    }

    public void LoseLife()
    {
        lives--;

        UpdateLivesUI();

        Debug.Log("Lives: " + lives);

        if (lives <= 0)
        {
            GameOver();
        }
    }

    void GameOver()
    {
        Debug.Log("GAME OVER!");

        gameOverText.gameObject.SetActive(true);
        restartButton.gameObject.SetActive(true);

        Time.timeScale = 0f;
    }
    void WinGame()
    {
        Debug.Log("YOU WIN!");

        winText.gameObject.SetActive(true);
        restartButton.gameObject.SetActive(true);

        Time.timeScale = 0f;
    }

    void UpdateScoreUI()
    {
        scoreText.text = "SCORE: " + score;
    }

    void UpdateLivesUI()
    {
        livesText.text = "LIVES: " + lives;
    }

    public void RestartGame()
    {
        Time.timeScale = 1f;

        SceneManager.LoadScene(
            SceneManager.GetActiveScene().buildIndex
        );
    }
}