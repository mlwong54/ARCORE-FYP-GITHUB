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
        StartCoroutine(WaitUntilDestroy(3));
    }

    private void OnDisable()
    {
        StopAllCoroutines();
    }

    IEnumerator WaitUntilDestroy(int interval)
    {
        yield return new WaitForSeconds(interval);
        TimerScoreControl.Instance.ReturnToPool(gameObject);
    }
}
