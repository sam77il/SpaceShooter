using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject asteroidPrefab;
    private float timer = 2;

    bool TimerFinished()
    {
        timer -= Time.deltaTime;

        if (timer <= 0 )
        {
            timer = 2;
            return true;
        } else
        {
            return false;
        }
    }
    void Update()
    {
        if (TimerFinished() && !GameManager.Instance.gameOver)
        {
            Vector3 spawnPosition = new Vector3(Random.Range(-27, 27), 18, 0);
            Instantiate(asteroidPrefab, spawnPosition, asteroidPrefab.transform.rotation);
        }
    }
}
