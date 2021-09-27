using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSelfRotate : MonoBehaviour
{
    [SerializeField]
    private float speed;
    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.down * speed * Time.deltaTime);
    }
}
