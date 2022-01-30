using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using System;

public class UniRxIObservable : MonoBehaviour
{
    Subject<string> subject = null;
    IObservable<string> Observable { get { return subject; } }
    void Start()
    {
        subject = new Subject<string>();
        Observable.Subscribe(t => Debug.Log(t));
    }

    void Update()
    {
        subject.OnNext("hoge hoge");
    }
}
