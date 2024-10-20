using System;
using System.Data;
using UnityEngine;

public class Spaceship : MonoBehaviour
{
    [SerializeField] private float moveSpeed;
    [SerializeField] private GameObject laserObject;
    [SerializeField] private GameObject cannonLeft;
    [SerializeField] private GameObject cannonRight;
    private HistoryHandler historyHandler;

    void Update()
    {
        Movement();
        Shooting();

        if (GameManager.Instance.wentThroughAsteroids == 3)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            Destroy(gameObject);
        }
    }

    private void OnDestroy()
    {
        HistoryHandler.Instance.AddToList();
        GameManager.Instance.gameOver = true;
    }

    void Movement()
    {
        Vector3 planeMovement = new Vector3(0, 0, 0);

        if (!GameManager.Instance.gameOver)
        {
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                planeMovement.x -= 1;
            }
            if (Input.GetKey(KeyCode.RightArrow))
            {
                planeMovement.x += 1;
            }
        }

        transform.Translate(planeMovement * moveSpeed * Time.deltaTime);

        Vector3 planePosition = transform.position;
        planePosition.x = Mathf.Clamp(planePosition.x, -28, 28);

        transform.position = planePosition;
    }

    void Shooting()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(laserObject, cannonRight.transform.position, laserObject.transform.rotation);
            Instantiate(laserObject, cannonLeft.transform.position, laserObject.transform.rotation);
        }
    }
}
