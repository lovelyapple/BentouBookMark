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
        RunError,
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
            case RunCase.RunError:
                OnUpdateError();
                break;
        }
    }
    void OnUpdateComplete()
    {
        subject.OnNext(" hoge hoge ");
        subject.OnCompleted();
        subject.OnNext("won't excute");
    }
    void OnUpdateError()
    {
        subject.OnNext(" hoge hoge");
        subject.OnError(new Exception(" hoge error"));
        subject.OnNext("won't excute");
    }
}
