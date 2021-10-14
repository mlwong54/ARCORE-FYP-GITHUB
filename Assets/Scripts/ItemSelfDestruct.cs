using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSelfDestruct : MonoBehaviour
{
    [SerializeField]
    private float delayTime;
    // Start is called before the first frame update
    void OnEnable()
    {
        Invoke("DestroySelf", delayTime);
        //StartCoroutine(WaitUntilDestroy(3));
    }

    void DestroySelf()
    {
        TimerScoreControl.Instance.ReturnToPool(gameObject);
    }

}
