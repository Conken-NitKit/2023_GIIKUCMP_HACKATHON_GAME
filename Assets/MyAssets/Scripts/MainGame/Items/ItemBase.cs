using Assets.MyAssets.Scripts.MainGame.Cards;
using Assets.MyAssets.Scripts.MainGame.GameManagers;
using UnityEngine;

namespace Assets.MyAssets.Scripts.MainGame.Items
{
    public abstract class ItemBase : MonoBehaviour
    {
        [SerializeField]
        public ItemType ItemType { get; }

        protected MainGameManager _mainGameManager;
        protected TextManager _textManager;
        protected CardDisPlay _cardDisPlay;

        void Start()
        {
            var gameManager = GameObject.FindWithTag("GameManager");
            _mainGameManager = gameManager.GetComponent<MainGameManager>();
            _textManager = gameManager.GetComponent<TextManager>();
            _cardDisPlay = gameManager.GetComponent<CardDisPlay>();
        }

        public abstract void ActivateEffect();
    }
}
