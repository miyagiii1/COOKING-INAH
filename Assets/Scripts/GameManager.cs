using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public int score = 0;
    public int targetScore = 20;
    public int lives = 3;

    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI livesText; // now just static "LIVES:" label
    public TextMeshProUGUI gameOverText;
    public TextMeshProUGUI winText;
    public GameObject restartButton;

    public Image[] hearts;       // assign Heart1, Heart2, Heart3 in Inspector
    public Sprite fullHeart;     // assign HEART sprite
    public Sprite brokenHeart;   // assign LOSE sprite

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
        // Update heart icons instead of a number
        for (int i = 0; i < hearts.Length; i++)
        {
            if (i < lives)
            {
                hearts[i].sprite = fullHeart;
            }
            else
            {
                hearts[i].sprite = brokenHeart;
            }
        }
    }

    public void RestartGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(
            SceneManager.GetActiveScene().buildIndex
        );
    }
}