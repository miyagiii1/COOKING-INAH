using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public int score = 0;
    public int targetScore = 20;
    public int lives = 3;

    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI livesText;
    public TextMeshProUGUI gameOverText;
    public TextMeshProUGUI winText;
    public UnityEngine.UI.Image heart1;
    public UnityEngine.UI.Image heart2;
    public UnityEngine.UI.Image heart3;

    public Sprite brokenHeartSprite;

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

        if (lives == 2)
        {
            StartCoroutine(BreakHeart(heart3));
        }
        else if (lives == 1)
        {
            StartCoroutine(BreakHeart(heart2));
        }
        else if (lives <= 0)
        {
            StartCoroutine(BreakHeart(heart1));
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
    System.Collections.IEnumerator BreakHeart(UnityEngine.UI.Image heart)
    {
        heart.sprite = brokenHeartSprite;

        yield return new WaitForSecondsRealtime(0.3f);

        heart.gameObject.SetActive(false);
    }
}