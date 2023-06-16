using System;
using UniRx;

namespace Assets.MyAssets.Scripts.MainGame.GameManagers
{
    public enum GameState
    {
        Init,
        HappyTurn,
        BadTurn,
        BeforeResult,
    }
    
    [Serializable]
    public class GameStateReactiveProperty : ReactiveProperty<GameState>
    {
        public GameStateReactiveProperty()
        {
        }

        public GameStateReactiveProperty(GameState initialValue)
            : base(initialValue)
        {
        }
    }
}
