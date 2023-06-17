using Assets.MyAssets.Scripts.MainGame.GameManagers;
using UnityEngine;
using TMPro;

namespace Assets.MyAssets.Scripts.MainGame.Cards
{
    public class CardInfo : MonoBehaviour , ISendable
    {
        [SerializeField]
        private TextMeshPro _cardText;

        private MainGameManager _mainGameManager;
        
        private CardDisPlay _cardDisPlay;

        public int CardNum;

        public string ReceiveText()
        {
            var text = _cardText.text;
            Debug.Log(text);
            _cardDisPlay.ReDrawCard(CardNum);
            return text;
            if (!_mainGameManager.ChooseCardText.Value)
            {
                _mainGameManager.ChooseCardText.Value = true;
            }

            return default;
        }

        void Start()
        {
            var gameManager = GameObject.FindWithTag("GameManager");
            _mainGameManager = gameManager.GetComponent<MainGameManager>();
            _cardDisPlay = gameManager.GetComponent<CardDisPlay>();
        }
    }
}
