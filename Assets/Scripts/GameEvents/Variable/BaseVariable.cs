using UnityEngine;
using System;

public abstract class BaseVariable<T> : ScriptableObject, ISerializationCallbackReceiver
{
    public T InitialValue;

    [NonSerialized]
    public T RuntimeValue;

    public void OnAfterDeserialize()
    {
        RuntimeValue = InitialValue;
    }

    public void OnBeforeSerialize() { }
}
