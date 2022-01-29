using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using System;
public class UniRxIObsever : MonoBehaviour
{
    Subject<string> subject = null;
    IObservable<string> Observable { get { return subject; } }

    public enum RunCase
    {
        RunCompelet,
    }
    public RunCase runCase;
    void Start()
    {
        subject = new Subject<string>();
        Observable.Subscribe(t => Debug.Log("next" + t), 
                        e => Debug.Log("error " + e),
                        () => Debug.Log("compeleted"));

        // or
        // subject.Subscribe(t => Debug.Log("next" + t), 
        //                 e => Debug.Log("error " + e),
        //                 () => Debug.Log("compelet "));
    }
    void Update()
    {
        switch(runCase)
        {
            case RunCase.RunCompelet:
                OnUpdateComplete();
                break;
        }
    }
    void OnUpdateComplete()
    {
        subject.OnNext(" hoge hoge ");
        subject.OnCompleted();
        subject.OnNext("won't excute");
    }

}
