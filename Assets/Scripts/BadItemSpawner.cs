using UnityEngine;

public class BadItemSpawner : MonoBehaviour
{
    public GameObject badItemPrefab;

    public float spawnInterval = 3f;

    public float leftLimit = -7f;
    public float rightLimit = 7f;

    void Start()
    {
        InvokeRepeating("SpawnBadItem", 2f, spawnInterval);
    }

    void SpawnBadItem()
    {
        float randomX = Random.Range(leftLimit, rightLimit);

        Vector3 spawnPosition = new Vector3(
            randomX,
            transform.position.y,
            0f
        );

        Instantiate(
            badItemPrefab,
            spawnPosition,
            Quaternion.identity
        );
    }
}