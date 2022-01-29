using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using System;

public class UniRxOperator : MonoBehaviour
{
    Subject<int> subject = null;
    IObservable<int> Observable { get { return subject; } }
    public int currentValue = -10;
    void Start()
    {
        subject = new Subject<int>();
        Observable.Where(v => v <= 10 && 1/v < 10)
                    .Select(x => x + 1)
                    .Subscribe(y => Debug.Log("filtering result " + y),
                    e => Debug.Log("error " + e));
    }

    void Update()
    {
        subject.OnNext(currentValue);
        currentValue++;
    }
}
