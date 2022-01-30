using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using System;
public class UniRxReactiveProperties : MonoBehaviour
{
    ReactiveProperty<uint> valueReactiveProperty = new ReactiveProperty<uint>(0);
    IObservable<uint> valueObservable { get { return valueReactiveProperty; } }
    void Start()
    {
        valueObservable.Subscribe(v => Debug.Log("value " + v), e => Debug.Log("error " + e));

        for (uint i = 0; i < 10; i++)
            valueReactiveProperty.Value = i;

        valueReactiveProperty.Value = 10;// wont active
    }
}
