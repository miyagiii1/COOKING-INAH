using UnityEngine;

public class BadItem : MonoBehaviour
{
    public Sprite[] badItemSprites;

    private void Start()
    {
        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();

        int randomIndex = Random.Range(0, badItemSprites.Length);

        spriteRenderer.sprite = badItemSprites[randomIndex];
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            GameManager gameManager = FindFirstObjectByType<GameManager>();

            if (gameManager != null)
            {
                gameManager.LoseLife();
            }

            Destroy(gameObject);
        }
    }
}