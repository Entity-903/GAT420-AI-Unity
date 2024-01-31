using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EventListenerBase<T> : MonoBehaviour
{
    [SerializeField]
    private EventBase<T> _event = default;

    public UnityEvent<T> listener;

    private void OnEnable()
    {
        _event?.Subscribe(Respond);
    }

    private void OnDisable()
    {
        _event?.Unsubscribe(Respond);
    }

    private void Respond(T value)
    {
        listener?.Invoke(value);
    }
}
