using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
public class UniRxTest : MonoBehaviour
{
    Subject<string> sub = null;
    void Start()
    {
        sub = new Subject<string>();
        sub.Subscribe(t => Debug.Log(t));
    }
    void Update()
    {
        sub.OnNext("hoge hoge ");
    }
}
