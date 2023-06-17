using System.Collections;
using System.Collections.Generic;
using Assets.MyAssets.Scripts.MainGame.Cards;
using Assets.MyAssets.Scripts.MainGame.Players;
using Photon.Pun;
using UniRx;
using UnityEngine;

namespace Assets.MyAssets.Scripts.MainGame.GameManagers
{
    public class MainGameManager : MonoBehaviourPunCallbacks
    {
        private ReactiveProperty<bool> _isHappyTurn = new ReactiveProperty<bool>();
        public IReadOnlyReactiveProperty<bool> IsHappyTurn { get { return _isHappyTurn; } }

        private IntReactiveProperty _currentTurnNum = new IntReactiveProperty();
        public IReadOnlyReactiveProperty<int> CurrentTurnNum { get { return _currentTurnNum; } }

        private const int DefaultTurnNum = 30;
                
        [SerializeField]
        private TimeManager _timeManager;
        [SerializeField]
        private TextManager _textManager;

        [SerializeField]
        private CardDB _cardDb;

        [SerializeField] 
        private CardDisPlay _cardDisPlay;

        public string playerName;

        public ReactiveProperty<bool> ChooseCardText = new ReactiveProperty<bool>(false);

        [SerializeField] private PlayerCore _playerCore;
        
        private GameStateReactiveProperty _currentState
            = new GameStateReactiveProperty(GameState.Init);
        
        public IReadOnlyReactiveProperty<GameState> CurrentGameState
        {
            get { return _currentState; }
        }
        
        [SerializeField]
        string _sheetName;

        private bool _isMasterClient;

        public void StartManager()
        {
            _isMasterClient = PhotonNetwork.IsMasterClient;
            _currentState.Subscribe(state =>
            {
                OnStateChanged(state);
                Debug.Log($"nextstate{state}");
            });
        }
        
        void OnStateChanged(GameState nextState)
        {
            switch (nextState)
            {
                case GameState.Init:
                    StartCoroutine(InitCoroutine());
                    break;
                case GameState.HappyTurn:
                    HappyTurn();
                    break;
                case GameState.BadTurn:
                    BadTurn();
                    break;
                case GameState.BeforeResult:
                    BeforeResult();
                    break;
                default:
                    break;
            }
        }

        IEnumerator InitCoroutine()
        {
            _currentTurnNum.Value = 0;
            
            if (_isMasterClient)
            {
                Debug.Log(PhotonNetwork.InstantiateRoomObject("TextBoard", new Vector3(0f, 1f, 0f), Quaternion.identity));
            }

            _cardDisPlay.DrawFirst();
            _textManager.InitTextBoard();
            _playerCore.CreatePlayer(_isMasterClient, playerName);
            Debug.Log("どうも");


            _currentState.Value = GameState.HappyTurn;
            
            Debug.Log(_currentState.Value);
            yield break;
        }

        void HappyTurn()
        {
            Debug.Log(GameState.HappyTurn);
            _isHappyTurn.Value = true;
            _timeManager.RestartTimer();
            

            ChooseCardText.Subscribe(_ =>
            {
                if (!ChooseCardText.Value)
                {
                    _timeManager.StopTimer();
                    if (CurrentTurnNum.Value < DefaultTurnNum)
                    {
                        _currentState.Value = GameState.BadTurn;
                        _currentState.Value++;
                    }
                }
            });
            
            _timeManager.TurnSecond.Subscribe(_ =>
            {
                if (_timeManager.TurnSecond.Value <= 0 && _playerCore.Parameter.IsHappyTeam)
                {
                    _currentState.Value = GameState.BadTurn;
                }
            });

            _currentTurnNum.Value++;
        }

        void BadTurn()
        {
            _isHappyTurn.Value = false;
            _timeManager.RestartTimer();

            ChooseCardText.Subscribe(_ =>
            {
                if (!ChooseCardText.Value)
                {
                    _timeManager.StopTimer();
                    
                }

                if (CurrentTurnNum.Value < DefaultTurnNum)
                {
                    _currentState.Value = GameState.HappyTurn;
                    _currentState.Value++;
                }
                else
                {
                    _currentState.Value = GameState.BeforeResult;
                }
            });
            
            _timeManager.TurnSecond.Subscribe(_ =>
            {
                if (_timeManager.TurnSecond.Value <= 0 && _playerCore.Parameter.IsHappyTeam)
                {
                    _currentState.Value = GameState.BadTurn;
                }
            });

            _currentTurnNum.Value++;
        }

        void BeforeResult()
        {
            
        }

    }
}

