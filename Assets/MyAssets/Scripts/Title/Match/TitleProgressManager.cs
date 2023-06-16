using System;
using System.Collections;
using System.Collections.Generic;
using MyAssets.Scripts.Title;
using TMPro;
using UniRx;
using UnityEngine;
using Zenject;

public class TitleProgressManager : MonoBehaviour
{
    [SerializeField] private SceneLoader _sceneLoader;
    private IMatchData _matchData;
    [Inject]
    public void Construct(IMatchData matchData)
    {
        _matchData = matchData;
    }

    public void LoadMatchScene(string name)
    {
        _matchData.PlayerName = new ReactiveProperty<string>(name);
    }

    public void LoadMatchScene(string name,int roomNum)
    {
        _matchData.PlayerName = new ReactiveProperty<string>(name);
        _matchData.RoomNum = new ReactiveProperty<int>(roomNum);
        
        _sceneLoader.LoadScene("Matching");
    }
    public void LoadLibScene()
    {
        _sceneLoader.LoadScene("Library");
    }
}
