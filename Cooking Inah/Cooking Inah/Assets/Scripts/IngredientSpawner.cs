using UnityEngine;

public class IngredientSpawner : MonoBehaviour
{
    public GameObject ingredientPrefab;

    public float spawnInterval = 1.5f;

    public float leftLimit = -7f;
    public float rightLimit = 7f;

    void Start()
    {
        InvokeRepeating("SpawnIngredient", 1f, spawnInterval);
    }

    void SpawnIngredient()
    {
        float randomX = Random.Range(leftLimit, rightLimit);

        Vector3 spawnPosition = new Vector3(
            randomX,
            transform.position.y,
            0f
        );

        Instantiate(
            ingredientPrefab,
            spawnPosition,
            Quaternion.identity
        );
    }
}