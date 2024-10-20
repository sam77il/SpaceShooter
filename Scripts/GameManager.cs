using System.Collections.Generic;
using UnityEngine;
using static PlayerHistory;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public bool gameStarted = false;
    public int score;
    public bool gameOver = false;
    public int wentThroughAsteroids;
    public AudioSource explosionAudio;

    void Awake()
    {
        Instance = this;
        Cursor.visible = false;
    }
}
