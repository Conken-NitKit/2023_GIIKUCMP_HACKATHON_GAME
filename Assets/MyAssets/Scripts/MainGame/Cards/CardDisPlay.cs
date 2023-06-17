using System;
using UniRx;
using UnityEngine;
using TMPro;

namespace Assets.MyAssets.Scripts.MainGame.Cards
{
    public class CardDisPlay : MonoBehaviour
    {
        private const int DEFULT_CARD_NUM = 10;
        private ReactiveCollection<string> _cardTexts = new ReactiveCollection<string>();
        private TextMeshPro[] _cards = new TextMeshPro[DEFULT_CARD_NUM];
        
        private Vector2[] _cardPositions = new Vector2[10];
        
        [SerializeField]
        private CardDB _cardDb;
        [SerializeField]
        private GameObject _cardObject;

        public void DrawFirst()
        {
            _cardTexts.ObserveReplace().Subscribe(replaceEvent =>
             {
                 _cards[replaceEvent.Index].text = _cardTexts[replaceEvent.Index];
             });
            
            var drawCards = _cardDb.DrawCards(DEFULT_CARD_NUM);
            for (int i = 0; i < DEFULT_CARD_NUM; i++)
            {
                _cardPositions[i] = new Vector2(-6.75f + i * 1.5f, -4f);
                var cards = Instantiate(_cardObject, _cardPositions[i], Quaternion.identity);
                _cards[i] = cards.GetComponentInChildren<TextMeshPro>();
                cards.GetComponent<CardInfo>().CardNum = i;
                _cardTexts.Add(_cards[i].text);
                _cardTexts[i] = drawCards[i];
            }
        }
        
        public void ReDrawAllCard()
        {
            var drawCards = _cardDb.DrawCards(DEFULT_CARD_NUM);
            for (int i = 0; i < DEFULT_CARD_NUM; i++)
            {
                _cardTexts[i] = drawCards[i];
            }
        }

        public void ReDrawCard(int cardIndex)
        {
            var drawCards = _cardDb.DrawCards(1);
            _cardTexts[cardIndex] = drawCards[0];
        }
    }
}

