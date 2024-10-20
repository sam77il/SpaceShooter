using System;
using System.Collections.Generic;
using UnityEngine;

public class HistoryHandler : MonoBehaviour
{
    public static HistoryHandler Instance;

    public List<History> histories = new List<History>{};

    public class History
    {
        public int Destroyed { get; set; }
        public int Received { get; set; }
        public float Ratio { get; set; }
        public string Date { get; set; }
        public string Time { get; set; }

    }

    public void AddToList()
    {
        float finalRatio = 0;

        if (GameManager.Instance.wentThroughAsteroids == 0)
        {
            finalRatio = GameManager.Instance.score / 1;
        } else
        {
            finalRatio = GameManager.Instance.score / GameManager.Instance.wentThroughAsteroids;
        }

        DateTime currentDate = DateTime.Now;
        TimeSpan currentTime = currentDate.TimeOfDay;
        histories.Add(new History { Destroyed = GameManager.Instance.score, Received = GameManager.Instance.wentThroughAsteroids, Ratio = finalRatio, Date = currentDate.ToString("MM/dd/yyyy"), Time = currentDate.ToString("HH:mm") });
    }

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
