using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EventBase<T> : ScriptableObjectBase
{
	public UnityAction<T> onEventRaised;

	public void RaiseEvent(T value)
	{
		onEventRaised?.Invoke(value);
	}

	public void Subscribe(UnityAction<T> function)
	{
		onEventRaised += function;
	}

	public void Unsubscribe(UnityAction<T> function)
	{
		onEventRaised -= function;
	}
}
