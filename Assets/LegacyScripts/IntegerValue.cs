using UnityEngine;
using System;

[CreateAssetMenu(fileName = "IntegerValue", menuName = "Legacy Scriptable Objects/IntegerValue", order = 1)]
public class IntegerValue : ScriptableObject, ISerializationCallbackReceiver
{
    public int value;

    [NonSerialized]
    public int runtimeValue;

    public void OnAfterDeserialize()
    {
        runtimeValue = value;
    }

    public void OnBeforeSerialize()
    {
    }
}