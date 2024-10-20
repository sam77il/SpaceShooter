using UnityEngine;

public class Asteroid : MonoBehaviour
{
    public Spaceship spaceshipp;
    [SerializeField] private float speed;
    [SerializeField] GameObject spaceship;

    void Update()
    {
        transform.Rotate(new Vector3(180, 180, 0) * Time.deltaTime);
        transform.Translate(Vector3.down * speed * Time.deltaTime, Space.World);

        if (transform.position.y <= -20)
        {
            if (!GameManager.Instance.gameOver)
            {
                GameManager.Instance.wentThroughAsteroids += 1;
            }
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Laser")
        {
            Destroy(gameObject);
            Destroy(other.gameObject);

            GameManager.Instance.explosionAudio.Play();

            if (!GameManager.Instance.gameOver)
            {
                GameManager.Instance.score += 1;
            }
        }
    }
}
