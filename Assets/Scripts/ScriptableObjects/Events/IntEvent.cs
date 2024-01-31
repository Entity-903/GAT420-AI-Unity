using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Events/Int Event")]
public class IntEvent : EventBase<int>
{
    //public UnityAction<int> onEventRaised;

    //public void RaiseEvent(int value)
    //{
    //    onEventRaised?.Invoke(value);
    //}

    //public void Subscribe(UnityAction<int> function)
    //{
    //    onEventRaised += function;
    //}

    //public void Unsubscribe(UnityAction<int> function)
    //{
    //    onEventRaised -= function;
    //}
}
