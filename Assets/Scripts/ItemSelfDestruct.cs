using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSelfDestruct : MonoBehaviour
{
    [SerializeField]
    private float delayTime;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, delayTime);
    }

}
