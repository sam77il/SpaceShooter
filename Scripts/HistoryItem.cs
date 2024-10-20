using UnityEngine;
using TMPro;

public class HistoryItem : MonoBehaviour
{
    public static HistoryItem Instance;
    [SerializeField] TextMeshProUGUI Destroyed;
    [SerializeField] TextMeshProUGUI Received;
    [SerializeField] TextMeshProUGUI Ratio;
    [SerializeField] TextMeshProUGUI Date;
    [SerializeField] TextMeshProUGUI Time;

    void Awake()
    {
        Instance = this;
    }

    public void ChangeObjectData(int destroyed, int received, float ratio, string date, string time)
    {
        Destroyed.text = System.Convert.ToString(destroyed);
        Received.text = System.Convert.ToString(received);
        Ratio.text = System.Convert.ToString(ratio);
        Date.text = System.Convert.ToString(date);
        Time.text = System.Convert.ToString(time);
    }
}
