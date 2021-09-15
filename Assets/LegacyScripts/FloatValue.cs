using UnityEngine;
using System;

[CreateAssetMenu(fileName = "FloatValue", menuName = "Legacy Scriptable Objects/FloatValue", order = 1)]
public class FloatValue : ScriptableObject, ISerializationCallbackReceiver
{
    public float value;

    [NonSerialized]
    public float runtimeValue;

    public void OnAfterDeserialize()
    {
        runtimeValue = value;
    }

    public void OnBeforeSerialize()
    {
    }
}