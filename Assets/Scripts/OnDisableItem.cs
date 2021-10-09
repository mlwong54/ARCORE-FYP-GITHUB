using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnDisableItem : MonoBehaviour
{
    [SerializeField] private GameObject itemtoDisable;

    public void DisableItem()
    {
        itemtoDisable.SetActive(false);
    }

    public void EnableItem()
    {
        itemtoDisable.SetActive(true);
    }
}
