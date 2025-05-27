using UnityEngine;

public class Target : MonoBehaviour
{
    public GameObject targetPrefab;
    public ScoreManager scoreManager;

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Bird"))
        {
            scoreManager.AddScore(1);
            SpawnNewTarget(collision.relativeVelocity.normalized);
            Destroy(gameObject);
        }
    }

    void SpawnNewTarget(Vector2 direction)
    {

        Vector2 newPos = (Vector2)transform.position + direction * UnityEngine.Random.Range(2f, 5f);
        Instantiate(targetPrefab, newPos, Quaternion.identity);
    }
}
