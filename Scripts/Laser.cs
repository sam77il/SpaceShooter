using UnityEngine;

public class Laser : MonoBehaviour
{
    public float speed;

    void Update()
    {
        transform.Translate(Vector3.up * speed * Time.deltaTime);

        if (transform.position.y >= 20)
        {
            Destroy(gameObject);
        }
    }
}
