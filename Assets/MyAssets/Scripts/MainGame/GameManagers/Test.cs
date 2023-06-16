using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using TMPro;
using Assets.MyAssets.Scripts.MainGame.GameManagers;

public class Test : MonoBehaviour
{
    [SerializeField]
    private TimeManager _timeManager;

    [SerializeField] private TextMeshPro hoge;
    
    void Start()
    {
        _timeManager.TurnSecond.Subscribe(_ =>
        {
            hoge.text = $"{(int)_timeManager.TurnSecond.Value}";
        });
    }
}
