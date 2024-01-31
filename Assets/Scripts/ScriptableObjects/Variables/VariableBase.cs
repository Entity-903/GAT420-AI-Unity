using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VariableBase<T> : ScriptableObject, ISerializationCallbackReceiver
{
    public T initialValue;

    [NonSerialized]
    public T value;

    public void OnAfterDeserialize()
    {
        value = initialValue;
    }

    public void OnBeforeSerialize()
    {
        //
    }
}
