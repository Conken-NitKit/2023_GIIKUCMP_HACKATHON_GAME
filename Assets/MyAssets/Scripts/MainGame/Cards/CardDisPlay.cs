using System;
using UniRx;
using UnityEngine;
using TMPro;

namespace Assets.MyAssets.Scripts.MainGame.Cards
{
    public class CardDisPlay : MonoBehaviour
    {
        private const int DEFULT_CARD_NUM = 10;
        private TextMeshPro[] _cardTMPs = new TextMeshPro[DEFULT_CARD_NUM];
        
        [SerializeField]
        private CardDB _cardDb;
        [SerializeField]
        private GameObject _cardObject;

        public void DrawFirst()
        {
            var _drawCards = _cardDb.DrawCards(DEFULT_CARD_NUM);
            for (int i = 0; i < DEFULT_CARD_NUM; i++)
            {
                _cardTMPs[i] = Instantiate(_cardObject, new Vector2(-6.75f + i * 1.5f,-4f), Quaternion.identity)
                    .GetComponentInChildren<TextMeshPro>();
                _cardTMPs[i].text = _drawCards[i];
            }
        }
    }
}

