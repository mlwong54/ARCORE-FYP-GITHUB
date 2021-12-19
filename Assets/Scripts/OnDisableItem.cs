using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnDisableItem : MonoBehaviour
{
    [SerializeField] private GameObject[] itemsToDisable;
    [SerializeField] private GameObject[] imageToDisable;
    private bool onOff;

    public void DisableItem(int value)
    {
        itemsToDisable[value].SetActive(false);
    }

    public void EnableItem(int value)
    {
        itemsToDisable[value].SetActive(true);
    }

    public void setOnOffImage()
    {
        onOff = !onOff;
    }

    public void OnOffImage()
    {
        if(onOff ==true)
        {
            imageToDisable[0].SetActive(true);
            imageToDisable[1].SetActive(false);
        }
        else
        {
            imageToDisable[0].SetActive(false);
            imageToDisable[1].SetActive(true);
        }
    }
}
