using UnityEngine;

public class Ingredient : MonoBehaviour
{
    public Sprite[] ingredientSprites;

    private void Start()
    {
        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();

        int randomIndex = Random.Range(0, ingredientSprites.Length);

        spriteRenderer.sprite = ingredientSprites[randomIndex];
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            GameManager gameManager = FindFirstObjectByType<GameManager>();

            if (gameManager != null)
            {
                gameManager.AddScore(1);
            }

            Destroy(gameObject);
        }
    }
}