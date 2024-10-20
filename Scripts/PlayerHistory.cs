using NUnit.Framework;
using System;
using System.Collections.Generic;
using UnityEngine;


public class PlayerHistory : MonoBehaviour
{
    public static PlayerHistory Instance;
    [SerializeField] private Transform itemList;
    [SerializeField] private GameObject itemListObject;
    [SerializeField] private GameObject itemPrefab;

    void Awake()
    {
        Instance = this;
        gameObject.SetActive(false);
    }

    private void OnEnable()
    {
        ClearHistory();
        StartLoadHistory();
        //HistoryHandler.Instance.AddToListTest();
    }

    private void ClearHistory()
    {
        if (itemList.childCount > 0)
        {
            foreach (Transform child in itemListObject.transform)
            {
                Destroy(child.gameObject);
            }
        }
    }

    private void StartLoadHistory()
    {
        Debug.Log(HistoryHandler.Instance.histories.Count);
        foreach (var user in HistoryHandler.Instance.histories)
        {
            Instantiate(itemPrefab, new Vector3(0, 0, 0), itemPrefab.transform.rotation);
            GameObject childObject = Instantiate(itemPrefab, itemList);
            childObject.transform.localPosition = Vector3.zero;

            HistoryItem.Instance.ChangeObjectData(user.Destroyed, user.Received, user.Ratio, user.Date, user.Time);
        }
    }
}
