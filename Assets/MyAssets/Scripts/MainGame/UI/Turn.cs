using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Assets.MyAssets.Scripts.MainGame.GameManagers;
using UniRx;

namespace Assets.MyAssets.Scripts.MainGame.UI
{
    public class Turn : MonoBehaviour
    {
        [SerializeField] 
        private MainGameManager _mainGameManager;
        [SerializeField] 
        private TextMeshPro _textMesh;
        
        void Start()
        {
            _mainGameManager.CurrentTurnNum.Subscribe(x =>
            {
                _textMesh.text = $"残り{x}";
            });
        }
    }
}

