using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UniRx;
public class UniRxButtonObservable : MonoBehaviour
{
    [SerializeField] Button button;

    void Start()
    {
        button.OnClickAsObservable().Buffer(2).Subscribe(msg => Debug.Log("hited "));
    }
}
