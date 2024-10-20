using UnityEngine;
using TMPro;
using System;
using UnityEngine.SceneManagement;

public class HUDCanvasManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private TextMeshProUGUI wentThroughText;
    [SerializeField] private GameObject gameoverText;
    [SerializeField] private GameObject restartButton;
    [SerializeField] private GameObject backToStartButton;
    [SerializeField] private GameObject spaceshipPrefab;

    void Start()
    {
        gameoverText.SetActive(false);
        restartButton.SetActive(false);
        backToStartButton.SetActive(false);
    }

    void Update()
    {
        scoreText.text = Convert.ToString(GameManager.Instance.score);
        wentThroughText.text = Convert.ToString(GameManager.Instance.wentThroughAsteroids);
        if (GameManager.Instance.gameOver && !gameoverText.activeSelf && !restartButton.activeSelf)
        {
            Cursor.visible = true;
            gameoverText.SetActive(true);
            restartButton.SetActive(true);
            backToStartButton.SetActive(true);
        }
    }

    public void RestartGame()
    {
        Cursor.visible = false;
        gameoverText.SetActive(false);
        restartButton.SetActive(false);
        backToStartButton.SetActive(false);
        Instantiate(spaceshipPrefab, new Vector3(0, -12.65f, 0), spaceshipPrefab.transform.rotation);
        GameManager.Instance.gameOver = false;
        GameManager.Instance.score = 0;
        GameManager.Instance.wentThroughAsteroids = 0;
    }

    public void BackToStartMenu()
    {
        SceneManager.LoadScene("StartMenu");
    }
}
